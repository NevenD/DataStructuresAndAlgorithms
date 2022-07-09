using Lists;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Stacks
{
    public class LinkedStack<T> : IEnumerable<T>
    {

        private readonly SingleLinkedList<T> _list = new SingleLinkedList<T>();
        public void Push(T item)
        {
            _list.AddFirstElement(item);
        }

        public T Peek()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException();
            }

            return _list.Head.Value;
        }

        public void Pop()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException();
            }
            _list.RemoveFirstElement();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool IsEmpty => Count == 0;
        public int Count => _list.Count;
    }
}
