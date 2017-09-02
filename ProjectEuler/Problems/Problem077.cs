using System;
using ProjectEulerLibrary;

namespace ProjectEuler.Problems
{
    class Problem77 : Problem
	{
        public override void Run()
        {
            int[] primes = PrimeHelper.ArrayOfPrimeNumbersToMax(5000);
            
            for (int i = 10; ; i++)
            {
                Console.Write("Current i - {0}, ", i);
                int countOfWays = 0;
                RecursiveSummationCounter(ref countOfWays, i, primes);
                Console.WriteLine("count of ways - {0}", countOfWays);
                if (countOfWays > 5000)
                {
                    Console.WriteLine("Result - {0}", i);
                    return;
                }
            }
        }

        private void RecursiveSummationCounter(ref int countOfWays, int remainder, int[] primes, int minimum = 0)
        {
            if (remainder == 0)
            {
                countOfWays++;
                return;
            }

            for (int i = minimum; primes[i] <= remainder; i++)
            {
                RecursiveSummationCounter(ref countOfWays, remainder - primes[i], primes, i);
            }
        }
    }
}
