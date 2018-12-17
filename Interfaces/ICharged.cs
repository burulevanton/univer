namespace Chemistry.Interfaces
{
    /// <summary>
    /// Реализация заряженной частицы
    /// </summary>
    public interface ICharged
    {
        /// <summary>
        /// Возвращает заряд <see cref="ICharged"/>
        /// </summary>
        /// <returns></returns>
        int GetCharge();

        /// <summary>
        /// Текстовое представление интерфейса <see cref="ICharged"/>
        /// </summary>
        /// <returns></returns>
        string ToString();
    }
}