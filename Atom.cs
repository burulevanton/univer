using System;
using Chemistry.Interfaces;

namespace Chemistry
{
    public class Atom : IAtomic
    {
        public float? AtomicWeight { get; }
        public int Electrons { get; set; }
        public int Protons { get; set; }
        public int Neutrons { get; set; }
        public Ion ToIon()
        {
            if(!IsIon())
                throw new Exception("Невозможно преобразовать незаряженный атом в ион");
            return new Ion(this);
        }

        public bool IsIon()
        {
            return Electrons != Protons;
        }
    }
}