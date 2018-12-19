using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using Chemistry.Config;
using Chemistry.Interfaces;
using Chemistry.Log;

namespace Chemistry
{
    class Program
    {
        static void Main(string[] args)
        {
             Configuration.Load();

        
//           Element C = new Element("C",6, 12.0106, 14, 2);
//           Element O = new Element("O", 8, 15.99903, 16, 2);
//            PeriodicTable.Add(C);
//            
//            
//            C.AddIsotope(12, 12, 0.9893);
//            C.AddIsotope(13, 13.00335, 0.0107);
//            
//            List<AtomStack> list = new List<AtomStack>();
//            AtomStack c_atom_isotope = new AtomStack(C.PrincipalIsotope,1);
//            AtomStack c_atom = new AtomStack(C);
//            AtomStack o_atom = new AtomStack(O, 2);
//            list.Add(c_atom);
//            list.Add(o_atom);
//            Compound co2 = new Compound(list);
//            co2.Electrons -= 1;
//            Ion test_ion = (Ion) co2;
//            Console.WriteLine(test_ion);
//            
//            
//            test_ion = co2.ToIon();
//            Console.WriteLine(test_ion);

            
            Chemist chemist = new Chemist("anton");
            CompoundExperiment compoundExperiment = new CompoundExperiment(1);
            Compound ho = new Compound(new AtomStack[]
            {
                PeriodicTable.GetElement("H"),
                PeriodicTable.GetElement("O")
            });
//            AtomicCollection<IAtomic> collection = new AtomicCollection<IAtomic>(){ho};
//            Console.WriteLine(collection.Contains(new Atom(PeriodicTable.GetElement("H"))));
            compoundExperiment.AtomicCollection.Add(ho);
            compoundExperiment.AtomicCollection.Add(new Atom(PeriodicTable.GetElement("C")));
            compoundExperiment.AtomicCollection.Add(new Atom(PeriodicTable.GetElement("H")));
            compoundExperiment.AtomicCollection.Add(new Atom(PeriodicTable.GetElement("O")));
            compoundExperiment.AtomicCollection.Add(new Atom(PeriodicTable.GetElement("O")));
            IonExperiment ionExperiment = new IonExperiment(1);
            //ionExperiment.AtomicCollection.Add(new Atom(PeriodicTable.GetElement("Na")));
            //ionExperiment.AtomicCollection.Add(new Atom(PeriodicTable.GetElement("O")));
            //ionExperiment.AtomicCollection.Add(new Atom(PeriodicTable.GetElement("H")));
            ionExperiment.AtomicCollection.Add(new Atom(PeriodicTable.GetElement("Ca")));
            ionExperiment.AtomicCollection.Add(new Atom(PeriodicTable.GetElement("F")));
            ionExperiment.AtomicCollection.Add(new Atom(PeriodicTable.GetElement("F")));
            IsotopeExperiment isotopeExperiment = new IsotopeExperiment(1);
            isotopeExperiment.AtomicCollection.Add(new Atom(PeriodicTable.GetElement("Na")));
            chemist.DoExperiment(compoundExperiment);
            chemist.DoExperiment(ionExperiment);
            chemist.DoExperiment(isotopeExperiment);
            
        }
    }
}
