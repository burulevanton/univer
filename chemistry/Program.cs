using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using System.Linq;
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
            Chemist chemist = new Chemist("Антон");
            var h = new Atom(PeriodicTable.GetElement("H"));
            var o = new Atom(PeriodicTable.GetElement("O"));
            var c = new Atom(PeriodicTable.GetElement("C"));
            //Позволяет использовать тип с большей глубиной наследования, чем задано изначально.
            //Экземпляр IEnumerable<Derived> (IEnumerable(Of Derived) в Visual Basic) можно присвоить переменной типа IEnumerable<Base>
            AtomicCollection<IAtomic> iAtomics = new AtomicCollection<IAtomic>() {h, o, c};
            AtomicCollection<Atom> atoms = new AtomicCollection<Atom>() {h, o, c};

            void DoSomething(IEnumerable<IAtomic> ienumerable)
            {
                foreach (var element in ienumerable)
                {
                    Console.WriteLine(element);
                }
            }

            DoSomething(iAtomics.Concat(atoms));
            
            //Позволяет использовать более универсальный тип (с меньшей глубиной наследования), чем заданный изначально.
            //Экземпляр Action<Base> (Action(Of Base) в Visual Basic) можно присвоить переменной типа Action<Derived>.
            Action<IAtomic> action = Console.WriteLine;
            Action<Atom> atom_action = action;
            action(h);
            atom_action(h);
            
            
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
            var compoundExperiment2 = new CompoundExperiment(2);
            Compound h3 = new Compound(new AtomStack[]
            {
                new AtomStack(PeriodicTable.GetElement("H"),3), 
            });
            compoundExperiment2.AtomicCollection.Add(h3);
            compoundExperiment2.AtomicCollection.Add(new Atom(PeriodicTable.GetElement("N")));
            compoundExperiment2.AtomicCollection.Add(new Atom(PeriodicTable.GetElement("O")));
            compoundExperiment2.AtomicCollection.Add(new Atom(PeriodicTable.GetElement("Si")));
            chemist.DoExperiment(compoundExperiment2);
        }
    }
}
