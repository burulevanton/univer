using Chemistry.Interfaces;

namespace Chemistry
{
    public class CompoundExperiment:IExperiment
    {
        public CompoundExperiment(int number)
        {
            this.Number = number;
        }

        public AtomicCollection<IAtomic> AtomicCollection { get; } = new AtomicCollection<IAtomic>();

        public ExperimentType Type { get; } = ExperimentType.Compound;
        
        public string Name { get; } = "Эксперимент по созданию химических соединений";
        
        public int Number { get; }
        public Chemist Chemist { get; set; }
    }
}