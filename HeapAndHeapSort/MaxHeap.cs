using System;
using System.Collections.Generic;

namespace HeapAndHeapSort
{
    public class MaxHeap<T> where T : IComparable<T>
    {
        private const int DefaultCapcity = 4;
        private T[] _heap;
        private int defaultCapcity;

        public int Count { get; private set; }

        public bool IsFull => Count == _heap.Length;
        public bool IsEmpty => Count == 0;

        public MaxHeap() : this(DefaultCapcity)
        {

        }

        public MaxHeap(int capacity)
        {
            _heap = new T[capacity];
        }

        public void Insert(T value)
        {
            if (IsFull)
            {
                var newHeapWithLargerSize = new T[_heap.Length * 2];
                Array.Copy(_heap, 0, newHeapWithLargerSize, 0, _heap.Length);
                _heap = newHeapWithLargerSize;

            }

            _heap[Count] = value;

            MoveUpNewItem(Count);
            Count++;
        }

        public void MoveUpNewItem(int indexOfNewItem)
        {
            T newValue = _heap[indexOfNewItem];

            while (indexOfNewItem > 0 && IsParentless(newValue, indexOfNewItem))
            {
                _heap[indexOfNewItem] = GetParent(indexOfNewItem);
                indexOfNewItem = ParentIndex(indexOfNewItem);
            }

            _heap[indexOfNewItem] = newValue;

        }

        public IEnumerable<T> GetAllValues()
        {

            for (int i = 0; i < Count; i++)
            {
                var item = _heap[i];
                yield return item;

            }
        }

        private bool IsParentless(T newValue, int index)
        {
            return newValue.CompareTo(GetParent(index)) > 0;
        }

        private T GetParent(int index)
        {
            return _heap[ParentIndex(index)];
        }

        private int ParentIndex(int index)
        {
            return (index - 1) / 2;
        }
    }
}
