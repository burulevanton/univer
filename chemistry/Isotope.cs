using System;
using System.Collections.Generic;
using System.Globalization;
using Chemistry.Interfaces;

namespace Chemistry
{
    /// <summary>
    /// Реализация класса Изотоп
    /// </summary>
    public class Isotope : IAtomic
    {
        /// <summary>
        /// Инициализация экземпляра класса <see cref="Isotope"/>
        /// </summary>
        /// <param name="parentElement">Элемент</param>
        /// <param name="massNumber">Массовое число</param>
        /// <param name="atomicWeight">Атомная масло</param>
        /// <param name="abundance">Встречаемость</param>
        public Isotope(Element parentElement, int massNumber, double atomicWeight, double abundance)
        {
            Element = parentElement;
            MassNumber = massNumber;
            AtomicWeight = atomicWeight;
            RelativeAbundance = abundance;
            Electrons = parentElement.Electrons;
            Protons = parentElement.Protons;
        }

        /// <summary>
        /// Элемент
        /// </summary>
        public Element Element { get; private set; }
        
        /// <summary>
        /// Массовое число
        /// </summary>
        public int MassNumber { get; private set; }
        
        /// <summary>
        /// Встречаемость
        /// </summary>
        public double RelativeAbundance { get; private set; }
        
        /// <summary>
        /// Атомное число
        /// </summary>
        public int AtomicNumber => Element.AtomicNumber;

        /// <summary>
        /// Атомная масса
        /// </summary>
        public double? AtomicWeight { get; }
        
        /// <summary>
        /// Электроны
        /// </summary>
        public int Electrons { get; set;  }
        
        /// <summary>
        /// Протоны
        /// </summary>
        public int Protons { get;}

        /// <summary>
        /// Нейтроны
        /// </summary>
        public int Neutrons => MassNumber - Element.AtomicNumber;

        /// <summary>
        /// Конвертация <see cref="Isotope"/> в <see cref="Ion"/>
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public Ion ToIon()
        {
            if(!IsIon())
                throw new Exception("Невозможно преобразовать незаряженный изотоп в ион");
            return new Ion(this);
        }
        
        /// <summary>
        /// Является ли <see cref="Isotope"/> ионом
        /// </summary>
        /// <returns></returns>
        public bool IsIon() => Electrons != Protons;

        /// <summary>
        /// Является ли <see cref="Isotope"/> химическим соединением
        /// </summary>
        /// <returns></returns>
        public bool IsCompound() => false;

        /// <summary>
        /// Получение элементов изотопа
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Element> GetElements() => new[] {Element};
        
        /// <summary>
        /// Текстовое представление <see cref="Isotope"/>
        /// </summary>
        /// <returns></returns>
        public override string ToString() => string.Format("{0}{{{1}}}", Element.Symbol, MassNumber);
    }
}