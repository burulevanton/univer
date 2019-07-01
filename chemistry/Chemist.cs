using System;
using System.Collections.Generic;
using System.Linq;
using Chemistry.Interfaces;
using Chemistry.Log;

namespace Chemistry
{
    public class Chemist
    {
        public Chemist(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
        
        private Knowledge Knowledge { get; } = new Knowledge();

        public void DoExperiment(IExperiment experiment)
        {
            experiment.AtomicCollection.Sort(AtomicComparators.GetTypeDescendingComparer());
            experiment.Chemist = this;
            switch (experiment.Type)
            {
                case ExperimentType.Compound:
                    LogEvents.ExperimentStarted(experiment);
                    var atomicCollectionSize = experiment.AtomicCollection.Count;
                    var result = CheckCompounds(experiment.AtomicCollection);
                    if (atomicCollectionSize == experiment.AtomicCollection.Count)
                    {
                        LogEvents.ExperimentFailed(experiment);
                    }
                    else
                    {
                        LogEvents.ExperimentEnded(experiment);
                    }
                    break;
                case ExperimentType.Ion:
                    LogEvents.ExperimentStarted(experiment);
                    var ions = CheckIonCompounds(experiment.AtomicCollection);
                    if (ions != null)
                    {
                        LogEvents.IonsGot(ions);
                        LogEvents.ExperimentEnded(experiment);   
                    }
                    else
                    {
                        LogEvents.ExperimentFailed(experiment);
                    }
                    break;
                case ExperimentType.Isotope:
                    LogEvents.ExperimentStarted(experiment);
                    var isotopes = GetIsotopes(experiment.AtomicCollection);
                    if (isotopes != null)
                    {
                        LogEvents.IsotopeGot(isotopes);
                        LogEvents.ExperimentEnded(experiment);
                    }
                    else
                    {
                        LogEvents.ExperimentFailed(experiment);
                    }
                    break;
            }
        }

        private AtomicCollection<IAtomic> CheckCompounds(AtomicCollection<IAtomic> experimentCollection)
        {
            foreach (var compound in Knowledge.KnownCompounds)
            {
                var result = CanChemistDoCompound(compound, experimentCollection);
                if (result != null)
                {
                    var atomStack = new List<AtomStack>();
                    foreach (var iatomic in result)
                    {
                        atomStack.Add(new AtomStack(iatomic));
                        experimentCollection.Remove(iatomic);
                    }
                    Compound newCompound = new Compound(atomStack);
                    LogEvents.CompoundGot(compound);
                    CheckCompounds(experimentCollection);
                }
            }
            return experimentCollection;
        }

        private AtomicCollection<IAtomic> CanChemistDoCompound(Compound compound, AtomicCollection<IAtomic> experimentCollection)
        {
            var compoundAtoms = compound.GetAtoms();
            var neededIatomicCollection = new AtomicCollection<IAtomic>();
            foreach (var iatomic in experimentCollection)
            {
                if (compound.Count == 0) return neededIatomicCollection.Count == 0 ? null : neededIatomicCollection;
                if (iatomic is Isotope)
                    return null;
                if (iatomic is Compound)
                {
                    if (_fullCompoundNeeded(iatomic as Compound, compoundAtoms))
                    {
                        neededIatomicCollection.Add(iatomic);
                        foreach (var atom in (iatomic as Compound).GetAtoms())
                        {
                            compoundAtoms.Remove(atom);
                        }
                    }
                }
                if (iatomic is Atom && compoundAtoms.Contains(iatomic as Atom))
                {
                    compoundAtoms.Remove(iatomic as Atom);
                    neededIatomicCollection.Add(iatomic);
                }
            }
            return neededIatomicCollection.Count > 0 && compoundAtoms.Count==0 ? neededIatomicCollection : null;
        }

        private bool _fullCompoundNeeded(Compound compound, AtomicCollection<Atom> collection)
        {
            var compoundAtoms = compound.GetAtoms();
            var compoundAtomsLength = compoundAtoms.Count;
            var count = 0;
            foreach (var atom in collection)
            {
                if (!compoundAtoms.Contains(atom)) continue;
                count++;
                compoundAtoms.Remove(atom);
            }

            return count == compoundAtomsLength;
        }

        private List<Ion> CheckIonCompounds(AtomicCollection<IAtomic> experimentCollection)
        {
            foreach (var compound in Knowledge.KnownIonCompounds.Keys)
            {
                var result = CanChemistDoCompound(compound, experimentCollection);
                if (result != null)
                {
                    foreach (var atom in result)
                    {
                        experimentCollection.Remove(atom);
                    }
                    result.First().Electrons -= Knowledge.KnownIonCompounds[compound].Item1;
                    result.Last().Electrons += Knowledge.KnownIonCompounds[compound].Item2;
                    return new List<Ion>(new Ion[]
                    {
                        new Ion(result.First()),
                        new Ion(result.Last()) 
                    });
                    
                }
            }
            return null;
        }

        private List<Isotope> GetIsotopes(AtomicCollection<IAtomic> experimentCollection)
        {
            List<Isotope> isotopes = new List<Isotope>();
            foreach (var iAtomic in experimentCollection)
            {
                if (iAtomic is Isotope)
                {
                    continue;
                }

                if (iAtomic is Compound)
                {
                    Random random = new Random();
                    var atoms = (iAtomic as Compound).GetAtoms();
                    var atom = atoms[random.Next(atoms.Count)];
                    if (random.Next(101) > 50)
                    {
                        if(atom.GetElements().ToArray()[0].PrincipalIsotope != null)
                            isotopes.Add(atom.GetElements().ToArray()[0].PrincipalIsotope);
                            //LogEvents.IsotopeGot(atom.GetElements().ToArray()[0].PrincipalIsotope);
                    }
                }

                if (iAtomic is Atom)
                {
                    var isotope = iAtomic.GetElements().ToArray()[0].PrincipalIsotope;
                    if (isotope!=null)
                        isotopes.Add(isotope);
                        //LogEvents.IsotopeGot(isotope);
                }
            }
            return isotopes.Count > 0 ? isotopes : null;
        }       
    }
}