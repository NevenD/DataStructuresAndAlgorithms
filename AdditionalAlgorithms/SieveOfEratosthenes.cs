using System.Collections.Generic;

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

    }
}
