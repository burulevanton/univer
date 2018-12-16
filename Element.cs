using System;
using System.Collections.Generic;

namespace Chemistry
{
    public class Element
    {

        public Element(string symbol, int atomicNumber, int massNumber, int group, int period)
        {
            Symbol = symbol;
            AtomicNumber = atomicNumber;
            Group = group;
            Period = period;
            MassNumber = massNumber;
            CurrentNumOfIzotopes = 0;
        }
        
        public string Symbol { get; private set; }
        
        public int AtomicNumber { get; private set; }
        
        public int MassNumber { get; private set; }
        
        public int Group { get; private set; }
        
        public int Period { get; private set; }

        public int Protons => AtomicNumber;

        public int Electrons => AtomicNumber;

        public int Neutrons => MassNumber - AtomicNumber;
        
        private Dictionary<int, Isotope> _isotopesByMassNumber = new Dictionary<int, Isotope>();
        
        private List<Isotope> _isotopesInOrderTheyAdded = new List<Isotope>();
        
        public int CurrentNumOfIzotopes { get; private set; }

        public Isotope this[int massNumber] => _isotopesByMassNumber[massNumber];
        
        public Isotope PrincipalIsotope { get; private set; }

        public void AddIsotope(int massNumber, double atomicMass, double abundance)
        {
            if (_isotopesByMassNumber[massNumber] != null)
            {
                throw new ArgumentException("Изотоп с таким массовым числом уже существует");
            }
            var isotope = new Isotope(this, massNumber, atomicMass, abundance);
            _isotopesByMassNumber.Add(massNumber, isotope);
            _isotopesInOrderTheyAdded.Add(isotope);
            if (PrincipalIsotope == null || abundance > PrincipalIsotope.RelativeAbundance)
                PrincipalIsotope = isotope;
        }
    }
}