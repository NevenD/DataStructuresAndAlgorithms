using System;

namespace Trees
{
    public class Program
    {

        private static void Main(string[] args)
        {

            var binarySearchTreeTest = new BinarySearchTree<int>();
            binarySearchTreeTest.Insert(37);
            binarySearchTreeTest.Insert(24);
            binarySearchTreeTest.Insert(17);
            binarySearchTreeTest.Insert(28);
            binarySearchTreeTest.Insert(31);
            binarySearchTreeTest.Insert(29);
            binarySearchTreeTest.Insert(15);
            binarySearchTreeTest.Insert(12);
            binarySearchTreeTest.Insert(20);


            foreach (var item in binarySearchTreeTest.TraverseInOrder())
            {
                Console.WriteLine($"{item}");

            }
            Console.WriteLine($"MIN: {binarySearchTreeTest.MinimumValue()}");
            Console.WriteLine($"MAX: {binarySearchTreeTest.MaximumValue()}");
            Console.WriteLine($"GET: {binarySearchTreeTest.Get(37).Value}");

            Console.Read();

        }
    }
}
