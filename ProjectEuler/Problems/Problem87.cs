using System;
using ProjectEulerLibrary;
using System.Collections.Generic;

namespace ProjectEuler.Problems
{
	class Problem87 : Problem
	{
		public override void Run()
		{
            //The upper bound of the fourth power is primes that go to 83
            //The upper bound of the third power is primes that go to 367
            //The upper bound of the second power is primes that go to 7069
            //make 3 lists, one of each that go to that max
            //make 3 more lists, one for each second, third and fourth power
            //int total = 0;
            //for 4th power
            //for 3rd power (3rd power + 4th power < num)
            //for 2nd power (2nd power + 3rd power + 4th power < num)
            //if () total +=

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
