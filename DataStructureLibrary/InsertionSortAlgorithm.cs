namespace DataStructureLibrary
{
    /// <summary>
    /// Uses a small amount of extra memory (doesn't depend on n)
    /// Stable
    /// O(n2) time complexity (quadratic)
    /// Problem is that there are lot of sfiting elements
    /// </summary>
    public static class InsertionSortAlgorithm
    {
        public static void InsertionSort(int[] array)
        {
            // "wall" is now at the beginning of the array, at index 1
            for (int partIndex = 1; partIndex < array.Length; partIndex++)
            {
                // save currently unsorted element
                int currentUnsorted = array[partIndex];
                int element = 0;
                // if element is greater than zero and element is greater than currentUnsorted 
                for (element = partIndex; element > 0 && array[element - 1] > currentUnsorted; element--)
                {
                    // shift the elements
                    array[element] = array[element - 1];
                }
                array[element] = currentUnsorted;
            }
        }
    }
}
