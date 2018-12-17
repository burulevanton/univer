using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Chemistry.Interfaces;

namespace Chemistry
{
    /// <summary>
    /// Реализация класса Ион
    /// </summary>
    public class Ion : ICharged
    {
        /// <summary>
        /// Инициализация экземляра класса <see cref="Ion"/>
        /// </summary>
        /// <param name="content">Атомарное состояние иона</param>
        /// <exception cref="ArgumentException"></exception>
        public Ion(IAtomic content)
        {
            if(!content.IsIon())
                throw new ArgumentException("Не является ионом");
            Content = content;
        }
        
        /// <summary>
        /// Инициализация экземляра класса <see cref="Ion"/>
        /// </summary>
        /// <param name="element">Элемент</param>
        /// <param name="charge">Заряд</param>
        public Ion(Element element, int charge = 0) : this(new Atom(element, charge)){}
        
        /// <summary>
        /// Инициализация экземпляра класса <see cref="Ion"/>
        /// </summary>
        /// <param name="atoms">Колекция атомов</param>
        public Ion(IEnumerable<Atom> atoms) : this(new Compound(atoms.Select(x => new AtomStack(x)))) {}

        /// <summary>
        /// Является ли ион полиатомным
        /// </summary>
        public bool IsPolyatomic => Content.IsCompound() && ((Compound) Content).Sum(x => x.Size) > 1;

        /// <summary>
        /// Является ли ион катионом
        /// </summary>
        public bool IsCation => GetCharge() > 0;

        /// <summary>
        /// Является ли ион анионом
        /// </summary>
        public bool IsAnion => GetCharge() < 0;

        /// <summary>
        /// Является ли ион моноатомным
        /// </summary>
        public bool IsMonatomic => !Content.IsCompound();
        
        /// <summary>
        /// Атомное состояние иона
        /// </summary>
        public IAtomic Content { get; }
        
        /// <summary>
        /// Заряд иона
        /// </summary>
        /// <returns></returns>
        public int GetCharge() => -(Content.Electrons - Content.Protons);

        /// <summary>
        /// Конвертация <see cref="Compound"/> в <see cref="Ion"/>
        /// </summary>
        /// <param name="compound">Соединение</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static implicit operator Ion(Compound compound)
        {
            if (!compound.IsIon())
            {
                throw new ArgumentException(string.Format("Cоединение {} не является ионом", compound));
            }
            return new Ion(compound);
        }

        /// <summary>
        /// Конвертация <see cref="Atom"/> в <see cref="Ion"/>
        /// </summary>
        /// <param name="atom">Атом</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static implicit operator Ion(Atom atom)
        {
            if(!atom.IsIon())
                throw new ArgumentException(string.Format("Атом {} не является ионом", atom));
            return new Ion(atom);
        }

        /// <summary>
        /// Конвертация <see cref="Ion"/> в <see cref="Compound"/>
        /// </summary>
        /// <returns></returns>
        public Compound ToCompound() => Content.IsCompound() ? (Compound) Content : null;

        /// <summary>
        /// Конвертация <see cref="Ion"/> в <see cref="Atom"/>
        /// </summary>
        /// <returns></returns>
        public Atom ToAtom() => !Content.IsCompound() ? (Atom) Content : null;

        /// <summary>
        /// Текстовое представление <see cref="Ion"/>
        /// </summary>
        /// <returns></returns>
        public override string ToString() => string.Format("{0}{1}", Content, IsAnion ? "-" : "+");
    }
}