namespace DataStructureLibrary
{
    public class SelectionSortAlgorithm
    {
        /// <summary>
        /// Swapping the smallest element with the first element of the array. 
        /// Search the entire array before we swap elements.
        /// </summary>
        /// <param name="array"></param>
        public static void SelectionSort(int[] array)
        {
            // loops are the hints for time complexity
            // two inner loops - algorithm for quadratic growth - Big O of  n^2
            for (int mainIndex = array.Length - 1; mainIndex > 0; mainIndex--)
            {
                int largestAt = 0;
                for (int i = 1; i <= mainIndex; i++)
                {

                    if (IsCurrentElementGreaterThanCurrentlyLargestElement(array[i], array[largestAt]))
                    {
                        largestAt = i;
                    }
                }

                AlgorithmHelpers.SwapElements(array, largestAt, mainIndex);
            }
        }

        private static bool IsCurrentElementGreaterThanCurrentlyLargestElement(int currentElement, int largestElement)
        {
            return currentElement > largestElement;
        }
    }
}
