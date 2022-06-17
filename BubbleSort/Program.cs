using System;

namespace BubbleSort
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static void BubbleSort(int[] array)
        {
            // starts from the last element and goes backwards
            for (int partIndex = array.Length - 1; partIndex > 0; partIndex--)
            {
                // partition index is a wall
                // second element is firstElement + 1
                // inner loop will get shorter and shorter with progress of algorithm
                for (int firstElement = 0; firstElement < partIndex; firstElement++)
                {
                    if (CheckIfFirstElementIsGreaterThanSecondElement(array[firstElement], array[firstElement + 1]))
                    {
                        SwapElements(array, firstElement, firstElement + 1);
                    }
                }
            }

        }

        private static bool CheckIfFirstElementIsGreaterThanSecondElement(int firstElement, int secondElement)
        {
            return firstElement > secondElement;
        }


        private static void SwapElements(int[] array, int firstElement, int secondElement)
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
