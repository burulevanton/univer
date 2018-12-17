using System.Collections;
using System.Collections.Generic;

namespace Chemistry.Interfaces
{

    public interface IAtomic
    {
        double? AtomicWeight { get; }
        
        int Electrons { get; }

        int Protons { get; }
        
        int Neutrons { get; }

        Chemistry.Ion ToIon();

        bool IsIon();

        bool IsCompound();
        

        IEnumerable<Chemistry.Element> GetElements();

        string ToString();

    }
}