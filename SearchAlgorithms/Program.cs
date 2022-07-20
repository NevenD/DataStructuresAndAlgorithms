using System;
using System.Collections.Generic;
using System.Linq;

namespace SearchAlgorithms
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var personList = new List<PersonMock>()
                {
                    new PersonMock() { Name = "Neven", Age = 36},
                    new PersonMock() { Name = "Neven1", Age = 37},
                    new PersonMock() { Name = "Neven2", Age = 38},
                    new PersonMock() { Name = "Neven3", Age = 39},
                    new PersonMock() { Name = "Neven4", Age = 40},
                    new PersonMock() { Name = "Neven5", Age = 41},
                };

            var intList = new List<int>() { 1, 2, 3, 4, 5, 12, 34, 9, 1 };


            bool contains = intList.Contains(3);
            bool containsObject = personList.Contains(new PersonMock() { Name = "Maja", Age = 41 }, new PersonMockComparer());

            bool exists = personList.Exists(person => person.Age == 36);

            int min = intList.Min();
            int max = intList.Max();

            int youngestPerson = personList.Min(person => person.Age);

            // Single, Any, All, TrueForAll, etc.
            // Represents linear search, they all work in linear time
            // Time complexity: O(n)

            Console.WriteLine("Hello World!");
        }

        private static bool Exists(int[] array, int number)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == number)
                {
                    return true;
                }
            }

            return false;
        }


        private static int IndexOf(int[] array, int number)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == number)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
