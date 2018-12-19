
using System;
using System.Linq;
using System.Text;
using Chemistry.Interfaces;

namespace Chemistry
{
    /// <summary>
    /// Реализация класса Стэк Атомов
    /// </summary>
    public class AtomStack
    {
        
        /// <summary>
        /// Инициализация экземляра класса <see cref="AtomStack"/>
        /// </summary>
        /// <param name="element">Химический элемент</param>
        /// <param name="size">Количество атомов элемента</param>
        public AtomStack(Element element, int size = 1) : this(new Atom(element), size)
        {
        }
        
        /// <summary>
        /// Инициализицая экземпляра класса <see cref="AtomStack"/>
        /// </summary>
        /// <param name="atom">Атом</param>
        /// <param name="size">Количество атомов</param>
        public AtomStack(IAtomic atom, int size = 1)
        {
            Atom = atom;
            Size = size;
        }
        
        /// <summary>
        /// Атом
        /// </summary>
        public IAtomic Atom { get; private set; }
        
        /// <summary>
        /// Количество атомов в стэке
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// Конвертирует <see cref="Element"/> в <see cref="AtomStack"/>
        /// </summary>
        /// <param name="element">Элемент</param>
        /// <returns></returns>
        public static implicit operator AtomStack(Element element) => new AtomStack(new Atom(element));

        /// <summary>
        /// Конвертация <see cref="Compound"/> в <see cref="AtomStack"/>
        /// </summary>
        /// <param name="compound">Химическое соединение</param>
        /// <returns></returns>
        public static implicit operator AtomStack(Compound compound) => new AtomStack(compound);

        /// <summary>
        /// Конвертация <see cref="Atom"/> в <see cref="AtomStack"/>
        /// </summary>
        /// <param name="atom"></param>
        /// <returns></returns>
        public static implicit operator AtomStack(Atom atom) => new AtomStack(atom);
        
        /// <summary>
        /// Текстовое представление класса <see cref="AtomStack"/>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var sb = new StringBuilder();

            IAtomic atomic = Atom as Compound;

            if (atomic != null)
            {
                if (Size == 1)
                {
                    sb.Append($"{atomic}");
                    return sb.ToString();
                }

                sb.Append($"{Size}({atomic})");
                return sb.ToString();
            }

            sb.Append($"{Atom}{(Size == 1 ? string.Empty : Size.ToString())}");
            return sb.ToString();
        }

        /// <summary>
        /// Атомная масса
        /// </summary>
        //todo
        public double? AtomicWeight => Atom.AtomicWeight * Size;

        public AtomicCollection<Atom> GetAtoms()
        {
            AtomicCollection<Atom> atomicCollection = new AtomicCollection<Atom>();
            Compound compound = Atom as Compound;
            if (compound != null)
            {
                atomicCollection.AddRange(compound.GetAtoms());
                return atomicCollection;
            }
            atomicCollection.Add(Atom as Atom);
            return atomicCollection;
        }
    }
}