using Chemistry.Interfaces;

namespace Chemistry.Particles
{
    public class Neutron : ICharged
    {
        public int GetCharge() => 0;

        public override string ToString()
        {
            return "n";
        }
    }
}