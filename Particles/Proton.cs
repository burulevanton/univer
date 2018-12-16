using Chemistry.Interfaces;

namespace Chemistry.Particles
{
    public class Proton : ICharged
    {
        public int GetCharge() => 1;
    }
}