using System;
using System.Collections.Generic;
using Chemistry.Interfaces;

namespace Chemistry
{
    public class Atom : IAtomic
    {
        public Atom(Element element)
        {
            Element = element;
            Electrons = element.Electrons;
            Neutrons = element.Neutrons;
            Protons = element.Protons;
        }

        public Atom(Element element, int charge = 0) : this(element)
        {
            if (Electrons - charge < 0)
                throw new ArgumentOutOfRangeException("Количество электронов в ионе не может быть меньше 0");
            Electrons -= charge;
        }
        
        public Element Element { get; }
        public double? AtomicWeight => Element.AtomicWeight;
        public int Electrons { get; set; }
        public int Protons { get; }
        public int Neutrons { get;}
        
        public Ion ToIon()
        {
            if(!IsIon())
                throw new Exception("Невозможно преобразовать незаряженный атом в ион");
            return new Ion(this);
        }

        public bool IsIon() => Electrons != Protons;

        public bool IsCompound() => false;

        public IEnumerable<Element> GetElements() => new[] {Element};

        public override string ToString() => Element.Symbol;
    }
}