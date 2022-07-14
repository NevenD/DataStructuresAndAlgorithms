using Lists;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Queues
{
    public class QueueLinkedList<T> : IEnumerable<T>
    {

        private readonly SingleLinkedList<T> _list = new SingleLinkedList<T>();

        public void Enqueue(T item)
        {
            _list.AddFirstElement(item);
        }

        public void Dequeue()
        {
            _list.RemoveFirstElement();
        }

        public T Peek()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException();
            }
            return _list.Head.Value;
        }

        public int Count => _list.Count;

        public bool IsEmpty => Count == 0;

        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
