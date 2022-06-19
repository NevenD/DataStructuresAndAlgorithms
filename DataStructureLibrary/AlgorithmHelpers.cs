namespace DataStructureLibrary
{
    public static class AlgorithmHelpers
    {


        public static void SwapElements(int[] array, int firstElement, int secondElement)
        {
            if (firstElement == secondElement)
            {
                return;
            }

            // temporary value for first value
            int tempFirstValue = array[firstElement];
            array[firstElement] = array[secondElement];
            array[secondElement] = tempFirstValue;
        }
    }
}