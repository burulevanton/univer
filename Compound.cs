using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chemistry.Interfaces;

namespace Chemistry
{
    /// <summary>
    /// Представляет класс Химическое соединение
    /// </summary>
    public class Compound : List<AtomStack>, IAtomic
    {
        /// <summary>
        /// Инициализация экземляра класса <see cref="Compound"/>
        /// </summary>
        /// <param name="enumerable">Коллекция стэка атомов</param>
        /// <param name="charge">Заряд</param>
        public Compound(IEnumerable<AtomStack> enumerable, int charge = 0) : base(enumerable)
        {
            Electrons = this.Sum(x => x.Size * x.Atom.Electrons) - charge;
            Neutrons = this.Sum(x => x.Size * x.Atom.Neutrons);
            Protons = this.Sum(x => x.Size * x.Atom.Protons);

            Organize();
        }

        /// <summary>
        /// Атомная масса
        /// </summary>
        public double? AtomicWeight => this.Sum(x => x.AtomicWeight);
        
        /// <summary>
        /// Количество электронов
        /// </summary>
        public int Electrons { get; set; }
        
        /// <summary>
        /// Количество протонов
        /// </summary>
        public int Protons { get; }
        
        /// <summary>
        /// Количество нейтронов
        /// </summary>
        public int Neutrons { get; }
        
        /// <summary>
        /// Конвертация <see cref="Compound"/> в <see cref="Ion"/>
        /// </summary>
        /// <returns></returns>
        public Ion ToIon()
        {
            if(!IsIon())
                throw new Exception("Невозможно преобразовать незаряженное соединение в ион");
            return new Ion(this);
        }

        /// <summary>
        /// Проверка, является ли <see cref="Compound"/> ионом
        /// </summary>
        /// <returns></returns>
        public bool IsIon() => Electrons != Protons;
        
        /// <summary>
        /// Проверка, является ли <see cref="Compound"/> химическим соединением
        /// </summary>
        /// <returns></returns>
        public bool IsCompound() => true;

        /// <summary>
        /// Коллекция элементов, которые присутствуют в химическом соединении
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Element> GetElements() => this.SelectMany(x => x.Atom.GetElements().Distinct());

        /// <summary>
        /// Организация химическое соединения
        /// </summary>
        private void Organize()
        {
            foreach (var element in GetElements().ToArray())
            {
                int count = this.Count(x => Equals(x.Atom.GetElements().ToArray()[0], element) && x.Atom.GetType() != typeof(Isotope));

                if (count <= 1) continue;

                int size = this.Where(x => Equals(x.Atom.GetElements().ToArray()[0], element)).Sum(x => x.Size);
                var stack = new AtomStack(element, size);

                int index = FindIndex(x => x.Atom.GetElements().ToArray()[0].Equals(element));

                RemoveAll(x => x.Atom.GetElements().ToArray()[0].Equals(element));
                Insert(index, stack);
            }
        }

        /// <summary>
        /// Соединение <see cref="Compound"/> с <see cref="Element"/>
        /// </summary>
        /// <param name="element">"Элемент</param>
        /// <param name="size">Количество</param>
        /// <returns></returns>
        public Compound With(Element element, int size = 1)
        {
            Add(new AtomStack(element, size));
            return this;
        }

        /// <summary>
        /// Соединение <see cref="Compound"/> c некоторым количеством <see cref="IAtomic"/>
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public Compound With(params IAtomic[] items)
        {
            AddRange(items.Select(x => new AtomStack(x)));
            return this;
        }

        /// <summary>
        /// Соединение <see cref="Compound"/> c некоторым количество <see cref="Element"/>
        /// </summary>
        /// <param name="elements"></param>
        /// <returns></returns>
        public Compound With(params Element[] elements)
        {
            AddRange(elements.Select(x => new AtomStack(x)));
            return this;
        }

        /// <summary>
        /// Соединение <see cref="Compound"/> c некотрым количеством <see cref="AtomStack"/>
        /// </summary>
        /// <param name="stacks"></param>
        /// <returns></returns>
        public Compound With(params AtomStack[] stacks)
        {
            AddRange(stacks);
            return this;
        }

        /// <summary>
        /// Проверка, содержит ли <see cref="Compound"/> <see cref="Element"/>
        /// </summary>
        /// <param name="element">Элемент</param>
        /// <returns></returns>
        public bool Contains(Element element) => GetElements().Any(x => x.Equals(element));

        /// <summary>
        /// Конвертация списка <see cref="Element"/> в <see cref="Compound"/>
        /// </summary>
        /// <param name="elements">Элементы</param>
        /// <returns></returns>
        public static implicit operator Compound(Element[] elements) => new Compound(elements.Select(x => new AtomStack(x)));
        
        /// <summary>
        /// Конвертация списка <see cref="Atom"/> в <see cref="Compound"/>
        /// </summary>
        /// <param name="atoms"></param>
        /// <returns></returns>
        public static implicit operator Compound(Atom[] atoms) => new Compound(atoms.Select(x => new AtomStack(x)));
        
        /// <summary>
        /// Конвертация списка <see cref="AtomStack"/> в <see cref="Compound"/>
        /// </summary>
        /// <param name="stacks"></param>
        /// <returns></returns>
        public static implicit operator Compound(AtomStack[] stacks) => new Compound(stacks);
        
        /// <summary>
        /// Текстовое представление <see cref="Compound"/>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var stack in this)
                sb.Append(stack);

            return sb.ToString();
        }
    }
}