using System;
using System.Collections.Generic;

namespace Chemistry
{
    
    /// <summary>
    /// Статический класс представляющий абстракцию периодической таблицы
    /// </summary>
    public static class PeriodicTable
    {
        /// <summary>
        /// Словарь элементов по символу
        /// </summary>
        private static Dictionary<string, Element> _elements = new Dictionary<string, Element>();
        
        /// <summary>
        /// Массив элементов по массовому числу
        /// </summary>
        private static Element[] _elementsArray = new Element[128];

        /// <summary>
        /// Добавление элемента в <see cref="PeriodicTable"/>
        /// </summary>
        /// <param name="element">Элемент</param>
        /// <exception cref="ArgumentException"></exception>
        public static void Add(Element element)
        {
            if (_elements.ContainsKey(element.Symbol))
                throw new ArgumentException("Данный элемент уже существует");
            if (_elementsArray[element.AtomicNumber] != null)
                throw new ArgumentException("Данный элемент уже существует");
            _elements.Add(element.Symbol, element);
            _elementsArray[element.AtomicNumber] = element;
        }

        /// <summary>
        /// Получение элемента по символу
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        public static Element GetElement(string symbol) => _elements[symbol];

        /// <summary>
        /// Получение элемента по атомному числу
        /// </summary>
        /// <param name="atomicNumber"></param>
        /// <returns></returns>
        public static Element GetElement(int atomicNumber) => _elementsArray[atomicNumber];
    }
}