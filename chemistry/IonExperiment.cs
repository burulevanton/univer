using Chemistry.Interfaces;

namespace Chemistry
{
    public class IonExperiment:IExperiment
    {
        public IonExperiment(int number)
        {
            this.Number = number;
        }

        public AtomicCollection<IAtomic> AtomicCollection { get; } = new AtomicCollection<IAtomic>();
        public ExperimentType Type { get; } = ExperimentType.Ion;
        public string Name { get; } = "Эксперимент по получению ионов";
        public int Number { get; }
        public Chemist Chemist { get; set; }
    }
}