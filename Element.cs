using System;
using System.Collections.Generic;

namespace Chemistry
{
    public class Element
    {

        public Element(string symbol, int atomicNumber, double atomicWeight, int group, int period)
        {
            Symbol = symbol;
            AtomicNumber = atomicNumber;
            Group = group;
            Period = period;
            AtomicWeight = AtomicWeight;
        }
        
        public string Symbol { get; private set; }
        
        public int AtomicNumber { get; private set; }
        
        public double AtomicWeight { get; private set; }

        public int MassNumber => (int) Math.Round(AtomicWeight);
        
        public int Group { get; private set; }
        
        public int Period { get; private set; }

        public int Protons => AtomicNumber;

        public int Electrons => AtomicNumber;

        public int Neutrons => MassNumber - AtomicNumber;
        
        private Dictionary<int, Isotope> _isotopesByMassNumber = new Dictionary<int, Isotope>();

        public Isotope this[int massNumber] => _isotopesByMassNumber[massNumber];

        public List<Isotope> Isotopes { get; } = new List<Isotope>();

        public Isotope PrincipalIsotope { get; private set; }

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

        public override string ToString()
        {
            return Symbol;
        }
        
    }
}