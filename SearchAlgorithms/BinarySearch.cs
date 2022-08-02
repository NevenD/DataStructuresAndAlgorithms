namespace SearchAlgorithms
{
    /// <summary>
    /// Idea is to divide each step on two parts to speed up the sorting process
    /// same for seaching. 
    /// Data must be sorted before searching. Binary search only works for sorted data.
    /// Algorithm takes element in the middle and compares against the search value.
    /// If equal then it's done.
    /// If element is greater than search value (element > value) then search the left half
    /// If element is smaller than search value (element < value) then search the right half
    /// log(n) steps
    /// </summary>
    public class BinarySearch
    {
        /// <summary>
        /// It's slower, we shouldn't use it.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int RecursiveBinarySearch(int[] array, int value)
        {
            return InternalRecursiveBinarySearch(0, array.Length);
            // local function
            int InternalRecursiveBinarySearch(int low, int high)
            {
                // break out of recursion
                if (low >= high)
                {
                    return -1;
                }

                int middleElement = (low + high) / 2;

                if (IsMiddleElementEqualToSearchValue(array[middleElement], value))
                {
                    return middleElement;
                }

                if (IsMiddleElementLowerThenSearchValue(array[middleElement], value))
                {
                    // passng the calls of the right side of the array
                    return InternalRecursiveBinarySearch(middleElement + 1, high);
                }

                return InternalRecursiveBinarySearch(low, middleElement);
            }
        }

        /// <summary>
        /// Iterative binary search approach, most common approach
        /// </summary>
        /// <param name="array"></param>
        /// <param name="value">Search value</param>
        /// <returns></returns>
        public static int IterativeSearch(int[] array, int value)
        {
            int lowBoundary = 0;
            int highBoundary = array.Length;

            while (lowBoundary < highBoundary)
            {
                int middleElement = (lowBoundary + highBoundary) / 2;

                if (IsMiddleElementEqualToSearchValue(array[middleElement], value))
                {
                    return middleElement;
                }

                if (IsMiddleElementLowerThenSearchValue(array[middleElement], value))
                {
                    // take the right half of splited array
                    lowBoundary = middleElement + 1;
                }
                else
                {
                    highBoundary = middleElement;
                }
            }
            return -1;
        }

        private static bool IsMiddleElementEqualToSearchValue(int middleElement, int searchValue)
        {
            return middleElement == searchValue;
        }

        private static bool IsMiddleElementLowerThenSearchValue(int middleElement, int searchValue)
        {
            return middleElement < searchValue;
        }
    }
}
