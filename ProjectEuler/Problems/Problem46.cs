using System;
using ProjectEulerLibrary;
using System.Collections.Generic;

namespace ProjectEuler.Problems
{
	class Problem46 : Problem
	{
        public override void Run()
        {
            int max = 1000000;
            int[] primes = PrimeHelper.ArrayOfPrimeNumbersToMax(max);
            HashSet<int> primesHashset = new HashSet<int>(primes); //!.contains = composite
            HashSet<int> squareHashset = GenerateHashSetOfSquareNumbers(1, 10000);

            for(int i = 9; i < max; i+=2) //Only odd numbers
            {
                if (!primesHashset.Contains(i)) //Is composite
                {
                    bool found = false;
                    for (int j = 0; j < primes.Length && primes[j] < i; j++)
                    {
                        int temp = (i - primes[j]) / 2;

                        if (squareHashset.Contains(temp))
                        {
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    { 
                        Console.WriteLine("Result is {0}", i);
                        return;
                    }
                }

            }
        }

        private HashSet<int> GenerateHashSetOfSquareNumbers(int minBase, int maxBase)
        {
            HashSet<int> result = new HashSet<int>();
            for (int i = minBase; i <= maxBase; i++)
            {
                result.Add(i * i);
            }

            return result;
        }
    }
}
