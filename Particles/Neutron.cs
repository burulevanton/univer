using Chemistry.Interfaces;

namespace Chemistry.Particles
{
    /// <summary>
    /// Реализация класса Нейтрон
    /// </summary>
    public class Neutron : ICharged
    {
        /// <summary>
        /// Возвращает заряд <see cref="Neutron"/>
        /// </summary>
        /// <returns></returns>
        public int GetCharge() => 0;

        /// <summary>
        /// Текстовое представление <see cref="Neutron"/>
        /// </summary>
        /// <returns></returns>
        public override string ToString() => "n";
    }
}