using System;
using System.Collections.Generic;
using JoshuaaM.PrimeSieve;

namespace ProjectEuler.Problems
{
	class Problem357 : Problem
	{
		public override void Run()
		{
            int[] primes = PrimeSieve.GeneratePrimesToMax(100000000, true); //n + 1 must be prime, subtract 1, test
            HashSet<int> primeHashset = new HashSet<int>(primes);
            long sum = 0;
            for (int i = 0; i < primes.Length; i++)
            {
                sum += IsSumOfFactorsPrime(primes[i] - 1, primeHashset) ? primes[i] - 1 : 0;
            }
            Console.WriteLine("Result is: {0}", sum);
		}

        private static bool IsSumOfFactorsPrime(int number, HashSet<int> primes)
        {
            int max = (int)Math.Sqrt(number);
            for (int factor = 2; factor <= max; factor++)
            {
                if (number % factor == 0)
                {
                    if(!primes.Contains(factor + number / factor))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
