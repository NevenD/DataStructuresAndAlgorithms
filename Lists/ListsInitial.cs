using System;
using System.Collections.Generic;

namespace Lists
{
    public class ListsInitial
    {
        private static void Main(string[] args)
        {
            //RunList();
            ChainedNodes();
            Console.Read();
        }

        public static void ChainedNodes()
        {
            Node firstNode = new Node() { Value = 5 };
            Node secondNode = new Node() { Value = 1 };

            firstNode.Next = secondNode;

            Node thirdNode = new Node() { Value = 3 };
            secondNode.Next = thirdNode;



            while (firstNode != null)
            {
                Console.WriteLine(firstNode.Value);
                firstNode = firstNode.Next;
            }
        }

        // Resizing is an expensive operation
        // Capacity is unchanged
        public static void RunList()
        {
            var list = new List<int>();
            // capacity is doubled
            // with first adding element it's added to 4
            // when reaches 4, the capacity doubles, etc.
            for (int i = 0; i < 16; i++)
            {
                list.Add(i);
                LogCountAndCapacity(list);
            }

            for (int i = 10; i > 0; i--)
            {
                list.RemoveAt(i - 1);
                LogCountAndCapacity(list);
            }

            // to preserve some memory we can TrimExcess to remove extra capacity
            // capacity is not automatically resized
            // will have effect if only is used less then 90% capacity
            list.TrimExcess();
        }

        public static void ApiMembers()
        {
            var list = new List<int>() { 1, 0, 5, 3, 4 };

            //list provides the sort method
            // primitive values will be sorted by ascending order by order
            // we don't need any arguments
            list.Sort();


            int indexBinarySearch = list.BinarySearch(3);

            list.Reverse();


            //  unable to change elements add or remove
            IReadOnlyCollection<int> readonlyList = list.AsReadOnly();

            // reference types
            var listOfCustomers = new List<MockCustomer>()
            {
                new MockCustomer() {BirthDate = new DateTime(1988,09,12), Name="Elias"},
                new MockCustomer() {BirthDate = new DateTime(1990,06,09), Name="Marina"},
                new MockCustomer() {BirthDate = new DateTime(2015,06,09), Name="Ann"},
            };


            // this will sort customers in ascending order by BirthDate
            // if primitive methods then it will use quick sort algorithm

            // dependes on the platform if .NET Core then it will use IntroSort, Heap Sort, or Qsort
            // this sorting is Unstable
            // Linearithmic growth
            listOfCustomers.Sort((left, right) =>
            {
                if (left.BirthDate > right.BirthDate)
                {
                    return 1;
                }

                if (right.BirthDate > left.BirthDate)
                {
                    return -1;
                }

                // if values are equal returns 0
                return 0;
            });
        }

        private static void LogCountAndCapacity(List<int> list)
        {
            Console.WriteLine($"Count={list.Count}. Capacity={list.Capacity}");
        }

    }


    public class MockCustomer
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
