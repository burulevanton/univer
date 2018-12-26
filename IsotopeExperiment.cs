using Chemistry.Interfaces;

namespace Chemistry
{
    public class IsotopeExperiment:IExperiment
    {
        public IsotopeExperiment(int number)
        {
            this.Number = number;
        }

        public AtomicCollection<IAtomic> AtomicCollection { get; } = new AtomicCollection<IAtomic>();
        public ExperimentType Type { get; } = ExperimentType.Isotope;
        public string Name { get; } = "Эксперимент по получению изотопа";
        public int Number { get; }
        public Chemist Chemist { get; set; }
    }
}