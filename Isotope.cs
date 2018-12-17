using System;
using System.Collections.Generic;
using System.Globalization;
using Chemistry.Interfaces;

namespace Chemistry
{
    public class Isotope : IAtomic
    {
        public Isotope(Element parentElement, int massNumber, double atomicWeight, double abundance)
        {
            Element = parentElement;
            MassNumber = massNumber;
            AtomicWeight = atomicWeight;
            RelativeAbundance = abundance;
            Electrons = parentElement.Electrons;
            Protons = parentElement.Protons;
        }

        public Element Element { get; private set; }
        
        public int MassNumber { get; private set; }
        
        public double RelativeAbundance { get; private set; }
        
        public int AtomicNumber => Element.AtomicNumber;


        public double? AtomicWeight { get; }
        public int Electrons { get; set;  }
        public int Protons { get;}

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

        public bool IsCompound() => false;

        public IEnumerable<Element> GetElements()
        {
            return new[] {Element};
        }
        
        public override string ToString()
        {
            return string.Format("{0}{{{1}}}", Element.Symbol, MassNumber);
        }
    }
}