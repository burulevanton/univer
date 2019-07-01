using System;
using System.Collections;
using System.Collections.Generic;
using Chemistry.Interfaces;

namespace Chemistry
{
    public static class AtomicComparators
    {
        public static AtomicCompare GetSymbolAscendingComparer() => new AtomicCompare((x,y) => string.CompareOrdinal(x.ToString(),y.ToString()));
        
        public static AtomicCompare GetSymbolDescendingComparer() => new AtomicCompare((x,y) => string.CompareOrdinal(y.ToString(), x.ToString()));

        private static int CompareTypes(IAtomic x, IAtomic y)
        {
            if (x.GetType() == y.GetType())
                return 0;
            if (x is Compound && (y is Atom || y is Isotope))
                return 1;
            if (x is Isotope)
            {
                if (y is Atom)
                    return 1;
                if (y is Compound)
                    return -1;
            }

            if (x is Atom && (y is Isotope || y is Compound))
                return -1;
            return 0;
        }
        
        public static AtomicCompare GetTypeAscendingComparer() => new AtomicCompare(CompareTypes);
        
        public static AtomicCompare GetTypeDescendingComparer() => new AtomicCompare((x,y) => CompareTypes(y,x));
     }
    
    public class AtomicCompare:IComparer<IAtomic>
    {
        private readonly Func<IAtomic, IAtomic, int> _compareMethod;

        public AtomicCompare(Func<IAtomic, IAtomic, int> compareMethod)
        {
            _compareMethod = compareMethod;
        }
        public int Compare(IAtomic x, IAtomic y) => _compareMethod(x, y);
    }
}