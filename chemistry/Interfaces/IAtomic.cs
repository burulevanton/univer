using System.Collections;
using System.Collections.Generic;

namespace Chemistry.Interfaces
{

    /// <summary>
    /// Реализация атомарного строения
    /// </summary>
    public interface IAtomic
    {
        /// <summary>
        /// Атомная масса
        /// </summary>
        double? AtomicWeight { get; }
        
        /// <summary>
        /// Количество электронов
        /// </summary>
        int Electrons { get; set; }

        /// <summary>
        /// Количество протонов
        /// </summary>
        int Protons { get; }
        
        /// <summary>
        /// Количество нейтронов
        /// </summary>
        int Neutrons { get; }
        
        /// <summary>
        /// Конвертирует текущее состояние <see cref="IAtomic"/> в <see cref="Ion"/>
        /// </summary>
        /// <returns></returns>
        Chemistry.Ion ToIon();
        
        /// <summary>
        /// Проверяет является ли <see cref="IAtomic"/> ионом
        /// </summary>
        /// <returns></returns>
        bool IsIon();
        
        /// <summary>
        /// Проверяет является ли <see cref="IAtomic"/> соединением
        /// </summary>
        /// <returns></returns>
        bool IsCompound();
        
        /// <summary>
        /// Возвращает все используемые химические элементы
        /// </summary>
        /// <returns></returns>
        IEnumerable<Chemistry.Element> GetElements();

        /// <summary>
        /// Текстовое представление интерфейса <see cref="IAtomic"/>
        /// </summary>
        /// <returns></returns>
        string ToString();

    }
}