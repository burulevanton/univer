using System;
using Chemistry.Interfaces;

namespace Chemistry
{
    public class Chemist
    {
        public string Name { get; }

        public void DoExperiment(IExperiment experiment)
        {
            switch (experiment.Type)
            {
                case ExperimentType.Compound:
                    Console.WriteLine("Эксперимент с химическими соединениями");
                    break;
                case ExperimentType.Ion:
                    Console.WriteLine("Эксперимент с получением ионов");
                    break;
                case ExperimentType.Isotope:
                    Console.WriteLine("Эксперимент с получением изотопа");
                    break;
            }
        }
    }
}