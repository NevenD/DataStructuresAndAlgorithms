using System;
using System.Collections.Generic;

namespace SymbolTables
{
    /// <summary>
    /// It works for logarithmic time
    /// It works for 2N becuase for two arrays
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public class BinarySearch<TKey, TValue>
    {

        private TKey[] _keys;
        private TValue[] _values;

        public int CountNumberOfElements { get; private set; }

        private readonly IComparer<TKey> _comparer;

        public int ArrayCapacity => _keys.Length;

        private const int DefaultCapacity = 4;


        public BinarySearch(int capacity, IComparer<TKey> comparer)
        {
            _keys = new TKey[capacity];
            _values = new TValue[capacity];
            _comparer = comparer ?? throw new ArgumentNullException("Comparer cannot be null.");
        }

        public BinarySearch(int capacity) : this(capacity, Comparer<TKey>.Default) { }

        public BinarySearch() : this(DefaultCapacity) { }

        public int Rank(TKey key)
        {
            int low = 0;
            int high = CountNumberOfElements - 1;

            while (low <= high)
            {
                int mid = low + (high - low) / 2;

                int comparer = _comparer.Compare(key, _keys[mid]);

                // if the key we are searching for is lower
                if (comparer < 0)
                {
                    high = mid - 1;
                }
                else if (comparer > 0)
                {
                    // shifting searching field to the right side
                    low = mid + 1;
                }
                else
                {
                    return mid;
                }
            }

            // if we didn't found the key then we ll return low variable since it will be keys less then the keys 
            // that we have been searching for
            return low;
        }

        public TValue GetValueOrDefault(TKey key)
        {
            if (IsEmpty)
            {
                return default;
            }

            int rank = Rank(key);

            if (rank < CountNumberOfElements && _comparer.Compare(_keys[rank], key) == 0)
            {
                return _values[rank];

            }
            return default;
        }

        public void Add(TKey key, TValue value)
        {
            if (key == null)
            {
                throw new ArgumentNullException("Key can't be null");
            }

            int rank = Rank(key);

            // check if rank already exists
            if (rank < CountNumberOfElements && _comparer.Compare(_keys[rank], key) == 0)
            {
                _values[rank] = value;
                return;
            }

            if (CountNumberOfElements == ArrayCapacity)
            {
                Resize(ArrayCapacity * 2);
            }

            // if key doesn't exist, we need to insert it to proper place
            // shifting elements from the left to the right

            for (int j = ArrayCapacity; j > rank; j--)
            {
                _keys[j] = _keys[j - 1];
                _values[j] = _values[j - 1];
            }

            _keys[rank] = key;
            _values[rank] = value;

            CountNumberOfElements++;
        }

        public void Remove(TKey key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("Key can't be null");
            }

            if (IsEmpty)
            {
                return;
            }

            // to remove a key value pair, we need to find it

            int rank = Rank(key);
            // if they are not equal
            if (rank == CountNumberOfElements || _comparer.Compare(_keys[rank], key) != 0)
            {
                return;
            }

            // shift all the keys from the right to left starting from the rank
            for (int j = rank; j < CountNumberOfElements; j++)
            {
                _keys[j] = _keys[j + 1];
                _values[j] = _values[j + 1];
            }

            CountNumberOfElements--;

            _keys[CountNumberOfElements] = default(TKey);
            _values[CountNumberOfElements] = default(TValue);

            // resize if 1/4 is full
            // if there are to many adding/removing then performance will degrate because of the resizing
            if (CountNumberOfElements > 0 && CountNumberOfElements == _keys.Length / 4)
            {
                Resize(_keys.Length / 2);
            }
        }

        public bool Contains(TKey key)
        {
            int rank = Rank(key);
            if (rank < CountNumberOfElements && _comparer.Compare(_keys[rank], key) == 0)
            {
                return true;
            }

            return false;
        }

        public IEnumerable<TKey> Keys()
        {
            foreach (var key in _keys)
            {
                yield return key;
            }
        }

        private void Resize(int capacity)
        {
            TKey[] keysTemp = new TKey[capacity];
            TValue[] valueTemp = new TValue[capacity];

            for (int i = 0; i < CountNumberOfElements; i++)
            {
                keysTemp[i] = _keys[i];
                valueTemp[i] = _values[i];
            }

            _keys = keysTemp;
            _values = valueTemp;
        }

        public bool IsEmpty => CountNumberOfElements == 0;

    }
}
