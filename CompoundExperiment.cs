using Chemistry.Interfaces;

namespace Chemistry
{
    public class CompoundExperiment:IExperiment
    {
        public AtomicCollection<IAtomic> AtomicCollection { get; } = new AtomicCollection<IAtomic>();

        public ExperimentType Type { get; } = ExperimentType.Compound;
    }
}