using System;

namespace DataStructureLibrary
{
    /// <summary>
    /// Allocates much memory (amont depends of n)
    /// Stable sorting
    /// Running time is linearithmic O(nlog) time complexity
    /// </summary>
    public class MergeSortAlgorithm
    {
        public static void MergeSort(int[] array)
        {

            int[] aux = new int[array.Length];
            Sort(0, array.Length - 1);

            void Sort(int low, int high)
            {
                if (high <= low)
                {
                    return;
                }

                int mid = (high + low) / 2;

                Sort(low, mid);
                Sort(mid + 1, high);
                Merge(low, mid, high);
            }
            void Merge(int low, int mid, int high)
            {
                // if the last element of the last of the left side array
                // is less or equal, the first element, the first element of the right
                // side array it means that they are already sorted
                if (array[mid] <= array[mid] + 1)
                {
                    return;
                }

                int i = low;
                int j = mid + 1;

                Array.Copy(array, low, aux, low, high - low + 1);

                for (int k = low; k <= high; k++)
                {
                    // if left part is empty then we should take elements from 
                    // right side
                    if (i > mid)
                    {
                        array[k] = aux[j++];
                    }
                    // if right part is empty then we should take elementrs from left side
                    else if (j > high)
                    {
                        array[k] = aux[i++];
                    }
                    // current key on the right is less then current key on the left
                    // then take from the right side
                    else if (aux[j] < aux[i])
                    {
                        array[k] = aux[j++];
                    }
                    else
                    {
                        array[k] = aux[i++];
                    }

                }
            }
        }
    }
}
