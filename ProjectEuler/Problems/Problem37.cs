using System;
using ProjectEulerLibrary;
using System.Collections.Generic;

namespace ProjectEuler.Problems
{
	class Problem37 : Problem
	{
        public override void Run()
        {
            //int[] primes = ListOfPrimes(1000000).ToArray();
            int[] primes = PrimeHelper.ArrayOfPrimeNumbersToMax(1000000000);
            HashSet<int> primesHashset = new HashSet<int>(primes);
            primes = RemoveNumbersWithEvenDigits(primes);

            long total = 0;
            for(int i = 5; i < primes.Length; i++)
            {
                bool isTruncatable = IsTruncatable(primes[i], primesHashset);
                if(isTruncatable)
                {
                    total += primes[i];
                    Console.WriteLine("Found {0} is truncatable, sum now {1}", primes[i], total);
                }
            }

            Console.WriteLine("Result is: {0}", total);
        }

        private bool IsTruncatable(int prime, HashSet<int> primes)
        {
            int forwardPrime = prime;
            while(forwardPrime != 0)
            {
                forwardPrime /= 10;
                if (forwardPrime != 0 && !primes.Contains(forwardPrime))
                {
                    return false;
                }
            }

            string backwardPrimeStr = prime + "";
            int backwardPrime = prime;
            for(int i = backwardPrimeStr.Length; i > 0; i--)
            {
                backwardPrime %= (int)Math.Pow(10, i);
                if (backwardPrime != 0 && !primes.Contains(backwardPrime))
                {
                    return false;
                }
            }

            return true;
        }

        private int[] RemoveNumbersWithEvenDigits(int[] numbers)
        {
            List<int> numsWithoutEvenDigits = new List<int>();
            for(int i = 0; i < numbers.Length; i++)
            {
                string str = numbers[i] + "";
                bool foundEvenDigit = false;
                for (int j = 0; j < str.Length; j++)
                {                    
                    if (str[j] == '0' || str[j] == '2' || str[j] == '4' || str[j] == '6' || str[j] == '8')
                    {
                        foundEvenDigit = true;
                        break;
                    }
                }
                if(!foundEvenDigit)
                {
                    numsWithoutEvenDigits.Add(numbers[i]);
                }
            }
            return numsWithoutEvenDigits.ToArray();
        }

        public static List<int> ListOfPrimes(int count)
        {
            List<int> primes = new List<int>();

            if (count < 1)
            {
                throw new ArgumentException("Count too low");
            }
            primes.Add(2);
            for (int i = 3; primes.Count < count; i += 2)
            {
                if (MathHelper.IsPrime(i))
                {
                    primes.Add(i);
                }
            }
            return primes;
        }
    }
}
