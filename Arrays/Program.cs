using System;

namespace Arrays
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            TestOneBasedIndexArray();
        }

        private static void ArraysDemo()
        {
            int[] a1;
            a1 = new int[10];

            int[] a2 = new int[5];

            int[] a3 = new int[5] { 1, 3, -2, 5, 10 };

            int[] a4 = { 1, 2, 3, 4, 5 };


            for (int i = 0; i < a3.Length; i++)
            {
                Console.Write($"{a3[i]}");
            }

            Console.WriteLine();

            foreach (var el in a4)
            {
                Console.Write($"{el}");
            }

            Array myArray = new int[5];

            Array myArray2 = Array.CreateInstance(typeof(int), 5);
            myArray2.SetValue(1, 0);

            Console.WriteLine();
            Console.Read();
        }

        // we can set index at 1 instead of the zero as it it by default
        // it is not recommended
        // non zero based arrays are slower than zero based arrays
        private static void TestOneBasedIndexArray()
        {
            Array myArray = Array.CreateInstance(typeof(int), new int[] { 4 }, new[] { 1 });

            myArray.SetValue(2019, 1);
            myArray.SetValue(2020, 2);
            myArray.SetValue(2021, 3);
            myArray.SetValue(2022, 4);

            Console.WriteLine($"Starting index: {myArray.GetLowerBound(0)}"); // get the first index
            Console.WriteLine($"Starting index: {myArray.GetUpperBound(0)}"); // get the last index


            for (int i = myArray.GetLowerBound(0); i <= myArray.GetUpperBound(0); i++)
            {
                Console.WriteLine($"{myArray.GetValue(i)} at index {i}");
            }
            Console.Read();
        }

        private static void MultiDimensionalArrays()
        {
            int[,] array = new int[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } };
            int[,] array2 = { { 1, 2, 3 }, { 4, 5, 6 } };

            for (int i = 0; i < array2.GetLength(1); i++)
            {
                for (int j = 0; j < array2.GetLength(1); j++)
                {
                    Console.WriteLine($"{array2[i, j]}");
                }

                Console.WriteLine();
            }
        }

        private static void JaggedArrays()
        {
            int[][] jaggedArray = new int[4][];
            jaggedArray[0] = new int[1];
            jaggedArray[1] = new int[3];
            jaggedArray[2] = new int[2];
            jaggedArray[3] = new int[4];

            Console.WriteLine($"Enter the numbers for a jagged array");


            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    string st = Console.ReadLine();
                    jaggedArray[i][j] = int.Parse(st);
                }
            }
            Console.WriteLine("");
            Console.WriteLine("Printing the Elements");

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.Write(jaggedArray[i][j]);
                    Console.Write("\0");
                }

                Console.WriteLine("");

            }

        }
    }
}
