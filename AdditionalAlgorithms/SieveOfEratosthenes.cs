using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace AdditionalAlgorithms
{
    /// <summary>
    /// Generate sequence of prime numbers
    /// Prime number is only divisible by one and itself (2,3,5,7,11,13,17, etc)
    /// </summary>
    public static class SieveOfEratosthenes
    {

        public static IEnumerable<int> Sieve(int max)
        {
            bool[] isPrimeNumber = new bool[max + 1];
            byte minimumPrimeNumber = 2;

            for (int prime = minimumPrimeNumber; prime <= max; prime++)
            {

                if (isPrimeNumber[prime])
                {
                    continue;
                }

                yield return prime;

                for (int i = prime * prime; i <= max; i += prime)
                {
                    isPrimeNumber[i] = true;
                }

            }

        }

        public static List<BigInteger> GetPrimeNumbers(int count)
        {
            var output = new List<BigInteger>();
            byte minimumPrimeNumber = 2;

            for (BigInteger primeNumber = minimumPrimeNumber; output.Count < count; primeNumber++)
            {
                if (output.All(x => primeNumber % x != 0))
                {
                    output.Add(primeNumber);
                }
            }

            return output;
        }

    }
}
