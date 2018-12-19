using Chemistry.Interfaces;

namespace Chemistry
{
    public class IonExperiment:IExperiment
    {
        public AtomicCollection<IAtomic> AtomicCollection { get; } = new AtomicCollection<IAtomic>();
        public ExperimentType Type { get; } = ExperimentType.Ion;
    }
}