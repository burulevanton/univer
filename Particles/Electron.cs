using Chemistry.Interfaces;

namespace Chemistry.Particles
{

    public class Electron : ICharged
    {
        public int GetCharge() => -1;
    }
}