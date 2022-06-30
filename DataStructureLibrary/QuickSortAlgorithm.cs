namespace DataStructureLibrary
{
    /// <summary>
    /// Recursive
    /// In place algorithm, small allocation of memory
    ///  (doesn't depend on n)
    ///  0(nlog) time complexity
    ///  Unstable
    /// </summary>
    public class QuickSortAlgorithm
    {

        public static void QuickSort(int[] array)
        {

            Sort(0, array.Length - 1);
            void Sort(int low, int high)
            {
                // sort is finishid if right is less
                // or equal the left boundary
                if (high <= low)
                {
                    return;
                }

                int j = Partition(low, high);
                Sort(low, j - 1);
                Sort(j + 1, high);

            }

            int Partition(int low, int high)
            {
                int i = low;
                int j = high + 1;

                // pivot element is the first in the partition
                int pivot = array[low];
                while (true)
                {
                    while (array[++i] < pivot)
                    {
                        if (i == high)
                        {
                            break;
                        }
                    }
                    while (pivot < array[--j])
                    {
                        if (j == low)
                        {
                            break;
                        }
                    }

                    if (i >= j)
                    {
                        break;
                    }

                    AlgorithmHelpers.SwapElements(array, i, j);
                }
                AlgorithmHelpers.SwapElements(array, low, j);

                return j;
            }
        }
    }
}
