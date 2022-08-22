using System;

namespace HeapAndHeapSort
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var heapTest = new Heap<int>();
            heapTest.Insert(24);
            heapTest.Insert(37);
            heapTest.Insert(17);
            heapTest.Insert(28);
            heapTest.Insert(31);
            heapTest.Insert(29);
            heapTest.Insert(15);
            heapTest.Insert(12);
            heapTest.Insert(20);

            Console.WriteLine(heapTest.Peek());
            Console.WriteLine(heapTest.Remove());
            Console.WriteLine(heapTest.Peek());
            heapTest.Insert(40);
            Console.WriteLine(heapTest.Peek());


            foreach (var item in heapTest.GetAllValues())
            {
                Console.WriteLine($"Heap item: {item}");

            }

            Console.Read();

        }
    }
}
