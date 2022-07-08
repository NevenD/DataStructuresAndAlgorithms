using System;
using System.Collections;
using System.Collections.Generic;

namespace Stacks
{
    public class ArrayStack<T> : IEnumerable<T>
    {

        private T[] _items;

        public ArrayStack()
        {
            const int defaultCapacity = 4;
            _items = new T[defaultCapacity];
        }

        public ArrayStack(int capacity)
        {
            _items = new T[capacity];
        }


        public void Push(T item)
        {
            if (_items.Length == Count)
            {
                T[] doubleArray = new T[Count * 2];
                Array.Copy(_items, doubleArray, Count);

                _items = doubleArray;
            }
            _items[Count] = item;
            Count++;
        }

        public T Peek()
        {
            return _items[Count - 1];
        }

        public void Pop()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException();
            }

            Count--;
            _items[Count] = default(T);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                yield return _items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int Count { get; private set; }

        public bool IsEmpty => Count == 0;

    }
}
