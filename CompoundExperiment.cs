using Chemistry.Interfaces;

namespace Chemistry
{
    public class CompoundExperiment:IExperiment
    {
        public CompoundExperiment(int number)
        {
            this.number = number;
        }

        public AtomicCollection<IAtomic> AtomicCollection { get; } = new AtomicCollection<IAtomic>();

        public ExperimentType Type { get; } = ExperimentType.Compound;
        
        public string name { get; } = "Эксперимент по созданию химических соединений";
        
        public int number { get; }
    }
}