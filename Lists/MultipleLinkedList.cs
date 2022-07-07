using System;

namespace Lists
{

    // allocates twice memory then single
    // because of the double link
    public class MultipleLinkedList<T>
    {
        public MultipleNode<T> Head { get; private set; }
        public MultipleNode<T> Tail { get; private set; }

        public int Count { get; private set; }

        public void AddFirstElement(T value)
        {
            AddFirstElement(new MultipleNode<T>(value));
        }

        private void AddFirstElement(MultipleNode<T> node)
        {
            // save off the current head
            MultipleNode<T> temporary = Head;
            Head = node;

            // insert the rest of the list after the head
            Head.Next = temporary;

            if (IsEmpty)
            {
                Tail = Head;
            }
            else
            {
                // before: 1(head) --> 5 <--> 7 -->null
                // after: 3(head) --> 1 <--> 5 <--> 7 -->null 

                // update "previous" ref of the former head
                temporary.Previous = Head;
            }

            Count++;
        }


        public void AddLastElement(T value)
        {
            AddLastElement(new MultipleNode<T>(value));
        }

        private void AddLastElement(MultipleNode<T> node)
        {
            if (IsEmpty)
            {
                Head = node;
            }
            else
            {
                Tail.Next = node;
                node.Previous = Tail;
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
            Head = Head.Next;

            Count--;

            if (IsEmpty)
            {
                Tail = null;
            }
            else
            {
                Head.Previous = null;
            }
        }


        public void RemoveLastElement()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException();
            }

            if (Count == 1)
            {
                Head = null;
                Tail = null;
            }
            else
            {
                Tail.Previous.Next = null; // the last node
                Tail = Tail.Previous; // shift the Tail (now it is the former penultimate node)
            }
            Count--;
        }
        public bool IsEmpty => Count == 0;

    }
}
