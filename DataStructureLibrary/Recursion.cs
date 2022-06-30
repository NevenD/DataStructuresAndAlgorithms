namespace DataStructureLibrary
{
    /// <summary>
    /// Recursion function is a function that calls itself
    /// </summary>
    public static class Recursion
    {
        public static int IterativeFactorial(int number)
        {
            if (number == 0)
            {
                return 1;
            }

            int factorial = 1;

            for (int i = 0; i <= number; i++)
            {
                factorial *= i;
            }

            return factorial;
        }

        /// <summary>
        /// Factorial examples
        /// 1! = 1 * 0! = 1;
        /// 2! = 2 * 1 = 2 * 1!
        /// 3! = 3 * 2 * 1 = 3 * 2!
        /// 4! = 4 * 3 * 2 * 1 = 4 * 3!;
        /// n! = n * (n-1)!
        /// 1 * RecursiveFactorial(1 - 1) = 1 ->
        /// 2 * RecursiveFactorial(2 - 1) = 2 * 1 // 1 because it was return from previous call
        /// 3 * RecursiveFactorial(3 - 2) = 3 * 2 // 2 because it was return from previous call
        /// It's more elegant but it's not free, it 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int RecursiveFactorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }

            return n * RecursiveFactorial(n - 1);
        }
    }
}
