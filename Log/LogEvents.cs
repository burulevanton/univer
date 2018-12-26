using System;
using System.Collections.Generic;
using Chemistry.Interfaces;

namespace Chemistry.Log
{
    public static class LogEvents
    {
        public static event Action<IExperiment> OnExperimentStarted;
        public static event Action<IExperiment> OnExperimentEnded;
        public static event Action<IExperiment> OnExperimentFailed;
        public static event Action<Compound> OnCompoundGot;
        public static event Action<List<Ion>> OnIonsGot;
        public static event Action<List<Isotope>> OnIsotopeGot;

        public static void ExperimentStarted(IExperiment experiment)
        {
            OnExperimentStarted?.Invoke(experiment);
        }

        public static void ExperimentEnded(IExperiment experiment)
        {
            OnExperimentEnded?.Invoke(experiment);
        }

        public static void ExperimentFailed(IExperiment experiment)
        {
            OnExperimentFailed?.Invoke(experiment);
        }

        public static void CompoundGot(Compound compound)
        {
            OnCompoundGot?.Invoke(compound);
        }

        public static void IonsGot(List<Ion> ions)
        {
            OnIonsGot?.Invoke(ions);
        }

        public static void IsotopeGot(List<Isotope> isotopes)
        {
            OnIsotopeGot?.Invoke(isotopes);
        }
    }
}