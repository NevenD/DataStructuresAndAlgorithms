using System;
using System.Collections;
using System.Collections.Generic;

namespace Lists
{
    /// <summary>
    /// If we a value of 3 and we add 1 additionally. Then the value of 
    /// 3 will become tail, and value of 1 will be head
    /// </summary>
    public class SingleLinkedList<T> : IEnumerable<T>
    {
        public Node<T> Head { get; private set; }

        public Node<T> Tail { get; private set; }

        public int Count { get; private set; }

        public void AddFirstElement(T value)
        {
            AddFirst(new Node<T>(value));
        }

        private void AddFirst(Node<T> node)
        {
            // save off the current head
            Node<T> temporary = Head;
            Head = node;

            // shifting the former head
            Head.Next = temporary;

            Count++;

            if (Count == 1)
            {
                Tail = Head;
            }
        }

        public void AddLastElement(T value)
        {
            AddLast(new Node<T>(value));
        }

        private void AddLast(Node<T> node)
        {
            if (IsEmpty)
            {
                Head = node;
            }
            else
            {
                Tail.Next = node;
            }
            Tail = node;

            Count++;
        }


        public void RemoveFirstElement()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException();
            }
            // shift the head
            // make sure that nothing references former head
            // former head will be garbage collected
            Head = Head.Next;
            if (Count == 1)
            {
                Tail = null;
            }

            Count--;
        }


        public void RemoveLastElement()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException();
            }

            if (Count == 1)
            {
                Head = Tail = null;
            }
            else
            {
                // penultimate (pretposljedni)
                var current = Head;

                while (current.Next != Tail)
                {
                    current = current.Next;
                }

                current.Next = null;

                Tail = current;
            }
            Count--;
        }

        public bool IsEmpty => Count == 0;


        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
