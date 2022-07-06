using System;

namespace Lists
{
    public static class ListsInitialHelpers
    {

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
    }
}