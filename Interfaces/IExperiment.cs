namespace Chemistry.Interfaces
{
    public interface IExperiment
    {
        AtomicCollection<IAtomic> AtomicCollection { get; }
        
        ExperimentType Type { get; }
        
        string Name { get; }
        
        int Number { get; }
        
        Chemist Chemist { get; set; }
    }
}