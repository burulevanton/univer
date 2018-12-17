using Chemistry.Interfaces;

namespace Chemistry.Particles
{
    /// <summary>
    /// Реализация класса Протон
    /// </summary>
    public class Proton : ICharged
    {
        /// <summary>
        /// Возвращает заряд <see cref="Proton"/>
        /// </summary>
        /// <returns></returns>
        public int GetCharge() => 1;

        /// <summary>
        /// Текстовое представление <see cref="Proton"/>
        /// </summary>
        /// <returns></returns>
        public override string ToString() => "p+";
    }
}