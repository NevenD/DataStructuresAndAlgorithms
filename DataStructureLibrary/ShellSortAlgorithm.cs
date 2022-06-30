namespace DataStructureLibrary
{
    public class ShellSortAlgorithm
    {
        public static void ShellSort(int[] array)
        {
            int gap = 1;
            int maxGapValue = array.Length / 3;
            while (gap < maxGapValue)
            {
                gap = 3 * gap + 1;
            }

            while (gap >= 1)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = i; j >= gap && array[j] < array[j - gap]; j -= gap)
                    {
                        AlgorithmHelpers.SwapElements(array, j, j - gap);
                    }
                }
                gap /= 3;
            }
        }
    }
}
