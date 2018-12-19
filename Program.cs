using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using Chemistry.Interfaces;

namespace Chemistry
{
    class Program
    {
        static void Main(string[] args)
        {
           Element C = new Element("C",6, 12.0106, 14, 2);
           Element O = new Element("O", 8, 15.99903, 16, 2);
            PeriodicTable.Add(C);
            
            
            C.AddIsotope(12, 12, 0.9893);
            C.AddIsotope(13, 13.00335, 0.0107);
            
            List<AtomStack> list = new List<AtomStack>();
            AtomStack c_atom_isotope = new AtomStack(C.PrincipalIsotope,1);
            AtomStack c_atom = new AtomStack(C);
            AtomStack o_atom = new AtomStack(O, 2);
            list.Add(c_atom);
            list.Add(o_atom);
            Compound co2 = new Compound(list);
            co2.Electrons -= 1;
            Ion test_ion = (Ion) co2;
            Console.WriteLine(test_ion);
            
            
            test_ion = co2.ToIon();
            Console.WriteLine(test_ion);

            
            Chemist chemist = new Chemist();
            CompoundExperiment compoundExperiment = new CompoundExperiment();
            IonExperiment ionExperiment = new IonExperiment();
            IsotopeExperiment isotopeExperiment = new IsotopeExperiment();
            chemist.DoExperiment(compoundExperiment);
            chemist.DoExperiment(ionExperiment);
            chemist.DoExperiment(isotopeExperiment);
            
        }
    }
}
