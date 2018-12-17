using System;
using System.Collections.Generic;
using Chemistry.Interfaces;

namespace Chemistry
{
    /// <summary>
    /// Реализация класса Атома <see cref="Element"/>
    /// </summary>
    public class Atom : IAtomic
    {
        /// <summary>
        /// Инициализация экземпляра класса <see cref="Atom"/>
        /// </summary>
        /// <param name="element">Химический элемент атома</param>
        public Atom(Element element)
        {
            Element = element;
            Electrons = element.Electrons;
            Neutrons = element.Neutrons;
            Protons = element.Protons;
        }

        /// <summary>
        /// Инициализация экземляра класса <see cref="Atom"/>
        /// </summary>
        /// <param name="element">Химический элемент</param>
        /// <param name="charge">Заряд атома</param>
        public Atom(Element element, int charge = 0) : this(element)
        {
            if (Electrons - charge < 0)
                throw new ArgumentOutOfRangeException("Количество электронов в ионе не может быть меньше 0");
            Electrons -= charge;
        }
        
        /// <summary>
        /// Химический элемент
        /// </summary>
        public Element Element { get; }
        
        /// <summary>
        /// Атомная масса
        /// </summary>
        public double? AtomicWeight => Element.AtomicWeight;
        
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
        public int Neutrons { get;}
        
        /// <summary>
        /// Конвертация атома в ион, если это возможно
        /// </summary>
        /// <returns><see cref="Ion"/></returns>
        public Ion ToIon()
        {
            //todo
            if(!IsIon())
                throw new Exception("Невозможно преобразовать незаряженный атом в ион");
            return new Ion(this);
        }

        /// <summary>
        /// Проверка, является ли атом ионом
        /// </summary>
        /// <returns></returns>
        public bool IsIon() => Electrons != Protons;

        /// <summary>
        /// Проверка, является ли атом химическим соединением
        /// </summary>
        /// <returns></returns>
        public bool IsCompound() => false;

        /// <summary>
        /// Получение списка элементов, содержащихся в атоме
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Element> GetElements() => new[] {Element};
        
        /// <summary>
        /// Текстовое представление класса <see cref="Atom"/> 
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Element.Symbol;
    }
}