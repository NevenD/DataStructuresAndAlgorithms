using System;

namespace HeapAndHeapSort
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var heapTest = new MaxHeap<int>();
            heapTest.Insert(24);
            heapTest.Insert(37);
            heapTest.Insert(17);
            heapTest.Insert(28);
            heapTest.Insert(31);

            foreach (var item in heapTest.GetAllValues())
            {
                Console.WriteLine($"Heap item: {item}");

            }

            Console.Read();

        }
    }
}
