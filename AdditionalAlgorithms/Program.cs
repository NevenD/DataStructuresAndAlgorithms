using System;

namespace AdditionalAlgorithms
{
    public class Program
    {

        //additional algorithms repo
        //https://github.com/TheAlgorithms/C-Sharp/blob/2362b6f8bcedfc995da1b8397f4f92939597fb29/Algorithms/Graph/Dijkstra/DijkstraAlgorithm.cs#L118
        private static void Main(string[] args)
        {

            foreach (var prime in SieveOfEratosthenes.Sieve(30))
            {
                Console.WriteLine(prime);

            }

            Console.ReadLine();
        }
    }
}
