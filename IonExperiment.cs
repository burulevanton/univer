using Chemistry.Interfaces;

namespace Chemistry
{
    public class IonExperiment:IExperiment
    {
        public IonExperiment(int number)
        {
            this.number = number;
        }

        public AtomicCollection<IAtomic> AtomicCollection { get; } = new AtomicCollection<IAtomic>();
        public ExperimentType Type { get; } = ExperimentType.Ion;
        public string name { get; } = "Эксперимент по получению ионов";
        public int number { get; }
    }
}