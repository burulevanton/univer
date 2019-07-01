using Chemistry.Interfaces;

namespace Chemistry.Particles
{

    /// <summary>
    /// Реализация класса Электрон
    /// </summary>
    public class Electron : ICharged
    {
        /// <summary>
        /// Возвращает заряд <see cref="Electron"/>
        /// </summary>
        /// <returns></returns>
        public int GetCharge() => -1;
        
        /// <summary>
        /// Текстовое представление <see cref="Electron"/>
        /// </summary>
        /// <returns></returns>
        public override string ToString() => "e-";
    }
}