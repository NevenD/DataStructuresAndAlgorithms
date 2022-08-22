using System;
using System.Collections.Generic;

namespace HeapAndHeapSort
{
    /// <summary>
    /// Heap Sort ins’t stable!!
    /// Max Heaps – Used when we want to get the Max in constant time
    /// Min Heaps – Used when we want to get the Min in constant time
    /// Heaps are implemented as arrays
    /// Heapifying the process of converting a binary tree into a heap
    /// Heap Sort is a sorting algorithm that makes use of the heap data structure. 
    /// 
    /// Each time the root element of the heap i.e. the largest element is removed and stored in an array. 
    /// It is replaced by the rightmost leaf element and then the heap is reestablished. 
    /// This is done until there are no more elements left in the heap and the array is sorted.
    /// </summary>
    /// 

    public class Heap<T> where T : IComparable<T>
    {
        private const int DefaultCapcity = 4;
        private T[] _heap;

        private int defaultCapcity;

        public int Count { get; private set; }

        public bool IsFull => Count == _heap.Length;
        public bool IsEmpty => Count == 0;

        public Heap() : this(DefaultCapcity)
        {

        }

        public Heap(int capacity)
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

        /// <summary>
        /// Performance - O(nlog(n))
        /// Q - sort is faster 5/10 times
        /// Use heap sort in life critical software
        /// </summary>
        public void Sort()
        {
            int lastHeapIndex = Count - 1;

            for (int i = 0; i < lastHeapIndex; i++)
            {
                Exchange(0, lastHeapIndex - i);
                MoveDownItem(0, lastHeapIndex - i - 1);
            }
        }


        public T Peek()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException();
            }

            return _heap[0];
        }


        public T Remove()
        {
            return RemoveItem(0);
        }

        private T RemoveItem(int index)
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException();
            }

            T removedValue = _heap[index];


            _heap[index] = _heap[Count - 1];
            if (index == 0 || _heap[index].CompareTo(GetParent(index)) < 0)
            {
                MoveDownItem(index, Count - 1);

            }
            else
            {
                MoveUpNewItem(index);
            }

            Count--;
            return removedValue;
        }

        private void MoveDownItem(int index, int lastHeapIndex)
        {

            while (index <= lastHeapIndex)
            {
                int leftChildIndex = LeftChildIndex(index);
                int rightChildIndex = RightChildIndex(index);

                if (leftChildIndex > lastHeapIndex)
                {
                    break;
                }

                int childIndexToSwap = GetChildIndexToSwap(leftChildIndex, rightChildIndex, lastHeapIndex);

                if (MoveDownItemIsLessThan(index, childIndexToSwap))
                {
                    Exchange(index, childIndexToSwap);

                }
                else
                {
                    break;
                }

                index = childIndexToSwap;

            }
        }

        private void Exchange(int leftIndex, int rightIndex)
        {
            T temporaryIndex = _heap[leftIndex];
            _heap[leftIndex] = _heap[rightIndex];
            _heap[rightIndex] = temporaryIndex;
        }

        private bool MoveDownItemIsLessThan(int index, int childIndexToSwap)
        {
            return _heap[index].CompareTo(_heap[childIndexToSwap]) < 0;
        }



        private int GetChildIndexToSwap(int leftChildIndex, int rightChildIndex, int lastHeapIndex)
        {
            int childToSwap;

            if (rightChildIndex > lastHeapIndex)
            {
                childToSwap = leftChildIndex;
            }
            else
            {
                int compareTo = _heap[leftChildIndex].CompareTo(_heap[rightChildIndex]);
                childToSwap = (compareTo > 0 ? leftChildIndex : rightChildIndex);
            }

            return childToSwap;
        }

        private int LeftChildIndex(int parentIndex)
        {
            return 2 * parentIndex + 1;
        }

        private int RightChildIndex(int parentIndex)
        {
            return 2 * parentIndex + 2;

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
