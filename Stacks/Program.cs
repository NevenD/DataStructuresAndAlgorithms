using System;

namespace Stacks
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var stacks = new ArrayStack<int>();
            stacks.Push(1);
            stacks.Push(2);
            stacks.Push(3);
            stacks.Push(4);


            Console.WriteLine($"Should write out 4: {stacks.Peek()}");

            stacks.Pop();

            Console.WriteLine($"Should write out 3: {stacks.Peek()}");

            Console.WriteLine("Iterate over the stack");

            foreach (var stack in stacks)
            {
                Console.WriteLine(stack);
            }


        }
    }
}
