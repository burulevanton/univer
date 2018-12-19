using Chemistry.Interfaces;

namespace Chemistry
{
    public class IsotopeExperiment:IExperiment
    {
        public IsotopeExperiment(int number)
        {
            this.number = number;
        }

        public AtomicCollection<IAtomic> AtomicCollection { get; } = new AtomicCollection<IAtomic>();
        public ExperimentType Type { get; } = ExperimentType.Isotope;
        public string name { get; } = "Эксперимент по получению изотопа";
        public int number { get; } 
    }
}