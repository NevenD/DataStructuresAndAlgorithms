using System;
using System.Collections.Generic;

namespace SymbolTables
{
    public class LinearSearch
    {
        // ST - Symbol table
        /// <summary>
        /// Searchin and Inserting Get and Add operation will take linear time O(N)
        /// </summary>
        /// <typeparam name="Tkey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        public class SequentialSearchST<Tkey, TValue>
        {
            private class Node
            {
                public Tkey Key { get; }
                public TValue Value { get; set; }

                public Node Next { get; set; }

                public Node(Tkey key, TValue value, Node next)
                {
                    Key = key;
                    Value = value;
                    Next = next;
                }
            }

            private Node _first;

            private readonly EqualityComparer<Tkey> _comparer;

            public int Count { get; private set; }

            public SequentialSearchST()
            {
                // default comparing comparing mechanism if the client doesn't want to specify the custom one
                // this comparerer will use default comparing mechanism (int, string, long, etc.)
                _comparer = EqualityComparer<Tkey>.Default;
            }

            public SequentialSearchST(EqualityComparer<Tkey> comparer)
            {
                _comparer = comparer ?? throw new ArgumentNullException();
            }

            public bool TryGet(Tkey key, out TValue outValue)
            {
                for (Node x = _first; x != null; x = x.Next)
                {
                    if (_comparer.Equals(x: key, y: x.Key))
                    {
                        outValue = x.Value;

                        return true;
                    }
                }

                outValue = default(TValue);
                return false;
            }

            public void Add(Tkey key, TValue value)
            {

                if (key == null)
                {
                    throw new ArgumentNullException("Key cannot be null.");
                }

                for (Node x = _first; x != null; x = x.Next)
                {
                    if (_comparer.Equals(x: key, y: x.Key))
                    {
                        x.Value = value;
                        return;
                    }
                }

                _first = new Node(key, value, _first);

                Count++;
            }

            public bool Contains(Tkey key)
            {
                for (Node x = _first; x != null; x = x.Next)
                {
                    if (_comparer.Equals(x: key, y: x.Key))
                    {
                        return true;
                    }
                }

                return false;
            }

            public bool Remove(Tkey key)
            {
                if (key == null)
                {
                    throw new ArgumentNullException("Key cannot be null.");
                }

                if (Count == 1 && _comparer.Equals(_first.Key, key))
                {
                    _first = null;
                    Count--;
                    return true;
                }

                Node prev = null;
                Node current = _first;

                while (current != null)
                {

                    if (_comparer.Equals(current.Key, key))
                    {
                        if (prev == null)
                        {
                            _first = current.Next;
                        }
                        else
                        {
                            prev.Next = current.Next;
                        }

                        Count--;

                        return true;
                    }

                    prev = current;
                    current = current.Next;
                }
                return false;

            }

            public IEnumerable<Tkey> Keys()
            {
                for (Node x = _first; x != null; x = x.Next)
                {
                    yield return x.Key;
                }
            }

        }
    }
}
