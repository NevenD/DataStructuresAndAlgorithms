using DataStructureLibrary;
using System;
using System.Diagnostics;
using System.Linq;

namespace DataStructuresAndAlgorithms
{
    internal partial class Program
    {
        private static void Main(string[] args)
        {
            var integerList = DataIn.ReadTestIntegers("TestData\\1Kints.txt").ToArray();

            var watch = new Stopwatch();
            watch.Start();

            var triplets = ThreeSum.CountIntegers(integerList);

            watch.Stop();

            Console.WriteLine($"Number of zero-sum: {triplets}");
            Console.WriteLine($"Time taken: {watch.Elapsed:g}");

        }
    }
}
