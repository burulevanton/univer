using System;
using System.Collections;
using System.Collections.Generic;
using Chemistry.Interfaces;

namespace Chemistry
{
    public class AtomicCollection<T> : ICollection<T>, ICloneable where T : IAtomic
    {
        private readonly List<T> _collection;

        public AtomicCollection()
        {
            _collection = new List<T>();
        }

        public AtomicCollection(AtomicCollection<T> collection)
        {
            _collection = new List<T>(collection);
        }

        public int Count => _collection.Count;

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            _collection.Add(item);
        }

        public void AddRange(IEnumerable<T> items)
        {
            _collection.AddRange(items);
        }

        public void Clear()
        {
            _collection.Clear();
        }

        public bool Contains(T item) => _collection.Contains(item);

        public void CopyTo(T[] array, int arrayIndex)
        {
            _collection.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator() => _collection.GetEnumerator();

        public bool Remove(T item) => _collection.Remove(item);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public object Clone()
        {
            return new AtomicCollection<T>(this);
        }

        public void Sort(IComparer<T> comparer)
        {
            _collection.Sort(comparer);
        }

        public IAtomic this[int index] => _collection[index];
    }
}