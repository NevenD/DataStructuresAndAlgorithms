using NUnit.Framework;
using SearchAlgorithms;

namespace BinarySearchTests
{
    [TestFixture]
    public class BinarySearchTest
    {
        [Test]
        public void BinarySearch_SortedInput_ReturnsCorrectIndex()
        {
            int[] input = { 0, 3, 4, 7, 77, 88, 99, 123, 345 };
            Assert.AreEqual(2, BinarySearch.IterativeSearch(input, 4));
            Assert.AreEqual(3, BinarySearch.IterativeSearch(input, 7));
            Assert.AreEqual(4, BinarySearch.IterativeSearch(input, 77));
            Assert.AreEqual(5, BinarySearch.IterativeSearch(input, 88));

            Assert.AreEqual(2, BinarySearch.RecursiveBinarySearch(input, 4));
            Assert.AreEqual(3, BinarySearch.RecursiveBinarySearch(input, 7));
            Assert.AreEqual(4, BinarySearch.RecursiveBinarySearch(input, 77));
            Assert.AreEqual(5, BinarySearch.RecursiveBinarySearch(input, 88));
        }
    }
}