using System;
using System.Collections.Generic;

namespace Chemistry
{
    public static class PeriodicTable
    {
        private static Dictionary<string, Element> _elements = new Dictionary<string, Element>();
        
        private static Element[] _elementsArray = new Element[128];

        public static void Add(Element element)
        {
            if (_elements.ContainsKey(element.Symbol))
                throw new ArgumentException("Данный элемент уже существует");
            if (_elementsArray[element.AtomicNumber] != null)
                throw new ArgumentException("Данный элемент уже существует");
            _elements.Add(element.Symbol, element);
            _elementsArray[element.AtomicNumber] = element;
        }

        public static Element GetElement(string symbol) => _elements[symbol];

        public static Element GetElement(int atomicNumber) => _elementsArray[atomicNumber];
    }
}