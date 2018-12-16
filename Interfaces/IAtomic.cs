namespace Chemistry.Interfaces
{

    public interface IAtomic
    {
        float? AtomicWeight { get; }
        
        int Electrons { get; }

        int Protons { get; }
        
        int Neutrons { get; }

        Chemistry.Ion ToIon();

        bool IsIon();
    }
}