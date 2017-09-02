using System;
using ProjectEulerLibrary;
using System.Collections.Generic;

namespace ProjectEuler.Problems
{
	class Problem87 : Problem
	{
		public override void Run()
		{
            int[] primes = PrimeHelper.ArrayOfPrimeNumbersToMax(7069 + 1);

            List<int> secondPoweredPrimes = new List<int>();
            List<int> thirdPoweredPrimes = new List<int>();
            List<int> fourthPoweredPrimes = new List<int>();

            for(int i = 0; i < primes.Length; i++)
            {
                int currentPrime = primes[i];
                if (currentPrime <= 7069)
                {
                    secondPoweredPrimes.Add(currentPrime * currentPrime);
                }
                if (currentPrime <= 367)
                {
                    thirdPoweredPrimes.Add(currentPrime * currentPrime * currentPrime);
                }
                if (currentPrime <= 83)
                {
                    fourthPoweredPrimes.Add(currentPrime * currentPrime * currentPrime * currentPrime);
                }
            }

            HashSet<int> numbers = new HashSet<int>();

            int max = 50000000;
            for (int i = 0; i < fourthPoweredPrimes.Count; i++)
            {
                for (int j = 0; j < thirdPoweredPrimes.Count; j++)
                {
                    for (int k = 0; k < secondPoweredPrimes.Count; k++)
                    {
                        int num = fourthPoweredPrimes[i] + thirdPoweredPrimes[j] + secondPoweredPrimes[k];
                        if (num < max && !numbers.Contains(num))
                        {
                            numbers.Add(num);                            
                        }
                    }
                }
            }

            Console.WriteLine("Result is: {0}", numbers.Count);
        }
	}
}
