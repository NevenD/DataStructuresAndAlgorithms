using System;

namespace Lists
{
    public static class ListsInitialHelpers
    {

        public static void ChainedNodes()
        {
            var firstNode = new Node<int>(5);
            var secondNode = new Node<int>(1);

            firstNode.Next = secondNode;

            var thirdNode = new Node<int>(3);
            secondNode.Next = thirdNode;



            while (firstNode != null)
            {
                Console.WriteLine(firstNode.Value);
                firstNode = firstNode.Next;
            }
        }
    }
}