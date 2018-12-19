namespace Chemistry.Interfaces
{
    public interface IExperiment
    {
        AtomicCollection<IAtomic> AtomicCollection { get; }
        
        ExperimentType Type { get; }
        
        string name { get; }
        
        int number { get; }
    }
}