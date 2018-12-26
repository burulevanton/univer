using System.Collections.Generic;
using Chemistry.Interfaces;

namespace Chemistry.Log
{
    public abstract class Logger
    {
        protected Logger()
        {
            LogEvents.OnExperimentStarted += LogExperimentStarted;
            LogEvents.OnExperimentEnded += LogExperimentEnded;
            LogEvents.OnExperimentFailed += LogExperimentFailed;
            LogEvents.OnCompoundGot += LogCompoundGot;
            LogEvents.OnIonsGot += LogIonsGot;
            LogEvents.OnIsotopeGot += LogIsotopeGot;
        }

        public void LogExperimentStarted(IExperiment experiment)
        {
            Log($"Химик {experiment.Chemist.Name} начал {experiment.Name} №{experiment.Number} \n" +
                $"Используемые элементы: {string.Join(",",experiment.AtomicCollection)}");
        }

        public void LogExperimentEnded(IExperiment experiment)
        {
            Log($"Химик {experiment.Chemist.Name} закончил {experiment.Name} №{experiment.Number} \n" +
                $"Оставшиеся элементы: {string.Join(",", experiment.AtomicCollection)}");
        }

        public void LogExperimentFailed(IExperiment experiment)
        {
            Log($"Химик {experiment.Chemist.Name} провалил {experiment.Name} № {experiment.Number}");
        }

        public void LogCompoundGot(Compound compound)
        {
            Log($"Получено химическое соединение {compound}");
        }

        public void LogIonsGot(List<Ion> ions)
        {
            Log($"Получены ионы {string.Join(",", ions)}");
        }

        public void LogIsotopeGot(List<Isotope> isotopes)
        {
            Log($"Получены изотопы {string.Join(",", isotopes)}");
        }

        public abstract void Log(string content);
    }
}