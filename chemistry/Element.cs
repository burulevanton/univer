using System;
using System.Collections.Generic;

namespace Chemistry
{
    /// <summary>
    /// Реализация класса Элемент
    /// </summary>
    public class Element
    {

        /// <summary>
        /// Инициализация класса <see cref="Element"/>
        /// </summary>
        /// <param name="symbol">Символ элемента</param>
        /// <param name="atomicNumber">Атомный номер</param>
        /// <param name="atomicWeight">Атомная масса</param>
        /// <param name="group">Группа</param>
        /// <param name="period">Период</param>
        public Element(string symbol, int atomicNumber, double atomicWeight, int group, int period)
        {
            Symbol = symbol;
            AtomicNumber = atomicNumber;
            Group = group;
            Period = period;
            AtomicWeight = atomicWeight;
        }
        
        /// <summary>
        /// Символ
        /// </summary>
        public string Symbol { get; private set; }
        
        /// <summary>
        /// Атомный номер
        /// </summary>
        public int AtomicNumber { get; private set; }
        
        /// <summary>
        /// Атомная масса
        /// </summary>
        public double AtomicWeight { get; private set; }

        /// <summary>
        /// Массовое число
        /// </summary>
        public int MassNumber => (int) Math.Round(AtomicWeight);
        
        /// <summary>
        /// Группа
        /// </summary>
        public int Group { get; private set; }
        
        /// <summary>
        /// Период
        /// </summary>
        public int Period { get; private set; }

        /// <summary>
        /// Протоны
        /// </summary>
        public int Protons => AtomicNumber;

        /// <summary>
        /// Электроны
        /// </summary>
        public int Electrons => AtomicNumber;

        /// <summary>
        /// Нейтроны
        /// </summary>
        public int Neutrons => MassNumber - AtomicNumber;
        
        /// <summary>
        /// Словарь <see cref="Isotope"/> по массовому числу
        /// </summary>
        private Dictionary<int, Isotope> _isotopesByMassNumber = new Dictionary<int, Isotope>();

        /// <summary>
        /// Получение изотопа по массовому числу
        /// </summary>
        /// <param name="massNumber"></param>
        public Isotope this[int massNumber] => _isotopesByMassNumber[massNumber];

        /// <summary>
        /// Список <see cref="Isotope"/>
        /// </summary>
        public List<Isotope> Isotopes { get; } = new List<Isotope>();

        /// <summary>
        /// Главный изотоп(часто встречающийся)
        /// </summary>
        public Isotope PrincipalIsotope { get; private set; }

        /// <summary>
        /// Добавление <see cref="Isotope"/>
        /// </summary>
        /// <param name="massNumber">Массовое число</param>
        /// <param name="atomicWeight">Атомная масса</param>
        /// <param name="abundance">Частота обнаружения</param>
        /// <exception cref="ArgumentException"></exception>
        public void AddIsotope(int massNumber, double atomicWeight, double abundance)
        {
            if (_isotopesByMassNumber.ContainsKey(massNumber))
            {
                throw new ArgumentException("Изотоп с таким массовым числом уже существует");
            }
            var isotope = new Isotope(this, massNumber, atomicWeight, abundance);
            _isotopesByMassNumber.Add(massNumber, isotope);
            Isotopes.Add(isotope);
            if (PrincipalIsotope == null || abundance > PrincipalIsotope.RelativeAbundance)
                PrincipalIsotope = isotope;
        }

        /// <summary>
        /// Текстовое представление <see cref="Element"/>
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Symbol;

    }
}