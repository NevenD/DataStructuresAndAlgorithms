using System;
using System.Collections;
using System.Collections.Generic;

namespace Queues
{
    public class CircularQueue<T> : IEnumerable<T>
    {
        private T[] _queue;
        private int _head;
        private int _tail;

        public CircularQueue()
        {
            const int defaultValue = 4;
            _queue = new T[defaultValue];
        }

        public CircularQueue(int capacity)
        {
            _queue = new T[capacity];
        }

        public void Enqueue(T item)
        {
            // double the size of the array
            // only when the number of elements
            // is getting close to the lenght of the array
            if (Count == _queue.Length - 1)
            {
                int countPreviousResize = Count;
                T[] doubleArraySize = new T[2 * _queue.Length];

                Array.Copy(_queue, _head, doubleArraySize, 0, _queue.Length - _head);
                Array.Copy(_queue, 0, doubleArraySize, _queue.Length - _head, _tail);

                _queue = doubleArraySize;

                _head = 0;
                _tail = countPreviousResize;
            }
            _queue[_tail] = item;
            // if the queue is not wrapped
            // then increment tail
            if (_tail < _queue.Length - 1)
            {
                _tail++;
            }
            else
            {
                _tail = 0;
            }
        }

        public void Dequeue()
        {

            if (IsEmpty)
            {
                throw new InvalidOperationException();
            }

            _queue[_head++] = default(T);

            // if after removing element the queue is empty
            // set 0 to head and tail
            if (IsEmpty)
            {
                _head = _tail = 0;
            }
            else if (_head == _queue.Length)
            {
                _head = 0; // end of the array, we needto reset the head index
            }
        }

        public T Peek()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException();
            }
            return _queue[_head];
        }

        // calculates the number of elements
        // when the tail goes behind the head

        public int Count => _head <= _tail ? _tail - _head : _tail - _head + _queue.Length;
        public int Capacity => _queue.Length;

        public bool IsEmpty => Count == 0;
        public IEnumerator<T> GetEnumerator()
        {
            // queue is unrwraped
            if (_head <= _tail)
            {
                for (int i = _head; i < _tail; i++)
                {
                    yield return _queue[i];
                }
            }
            // queue is wraped
            else
            {
                for (int i = _head; i < _queue.Length; i++)
                {
                    yield return _queue[i];
                }

                // we have to run another loop
                // iterating from 0 to _tail because the queue is wrapped
                for (int i = 0; i < _tail; i++)
                {
                    yield return _queue[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}
