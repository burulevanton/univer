using System;
using Chemistry.Interfaces;

namespace Chemistry
{
    public class Isotope : IAtomic
    {
        public Isotope(Element parentElement, int massNumber, double atomicMass, double abundance)
        {
            Element = parentElement;
            MassNumber = massNumber;
            AtomicMass = atomicMass;
            RelativeAbundance = abundance;
            Electrons = parentElement.Electrons;
            Protons = parentElement.Protons;
        }

        public Element Element { get; private set; }
        
        public int MassNumber { get; private set; }
        
        public double AtomicMass { get; private set; }
        
        public double RelativeAbundance { get; private set; }
        
        public int AtomicNumber => Element.AtomicNumber;


        public float? AtomicWeight { get; }
        public int Electrons { get; set;  }
        public int Protons { get; set; }

        public int Neutrons => MassNumber - Element.AtomicNumber;

        public Ion ToIon()
        {
            if(!IsIon())
                throw new Exception("Невозможно преобразовать незаряженный изотоп в ион");
            return new Ion(this);
        }
        
        public bool IsIon()
        {
            return Electrons != Protons;
        }
        
        
    }
}