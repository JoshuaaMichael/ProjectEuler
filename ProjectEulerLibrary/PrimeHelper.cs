using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerLibrary
{
    public static class PrimeHelper
    {
        public static int[] ArrayOfPrimeNumbersToMax(int maxNumber)
        {
            //Sieve of Eratosthenes
            //Confirm maxNumber is positive
            bool[] isPrime = new bool[maxNumber];
            int sqrtMaxNumber = (int)Math.Sqrt(maxNumber);
            int countNotPrime = 2; //0,1

            //Will remove this
            for (int i = 2; i < isPrime.Length; i++) isPrime[i] = true;

            for (int i = 2; i <= sqrtMaxNumber; i++)
            {
                if (isPrime[i])
                {
                    for (int j = i * 2; j < isPrime.Length; j += i)
                    {
                        if(isPrime[j] == true)
                        {
                            isPrime[j] = false;
                            countNotPrime += 1;
                        }
                    }
                }
            }

            int[] primes = new int[isPrime.Length - countNotPrime]; //Length of count of primes
            int k = 0;

            for(int i = 0; i < isPrime.Length; i++)
            {
                if(isPrime[i])
                {
                    primes[k++] = i;
                }
            }

            return primes;
        }

        public static int[] ArrayOfPrimeNumbersToMax_flipped(int maxNumber)
        {
            //Sieve of Eratosthenes
            //Confirm maxNumber is positive
            bool[] isPrime = new bool[maxNumber];
            int sqrtMaxNumber = (int)Math.Sqrt(maxNumber);
            int countNotPrime = 2; //0,1
            isPrime[0] = true;
            isPrime[1] = true;

            //Will remove this
            //for (int i = 2; i < isPrime.Length; i++) isPrime[i] = true;

            for (int i = 2; i <= sqrtMaxNumber; i++)
            {
                if (!isPrime[i])
                {
                    for (int j = i * 2; j < isPrime.Length; j += i)
                    {
                        if (!isPrime[j])
                        {
                            isPrime[j] = true;
                            countNotPrime += 1;
                        }
                    }
                }
            }

            int[] primes = new int[isPrime.Length - countNotPrime]; //Length of count of primes
            int k = 0;

            for (int i = 0; i < isPrime.Length; i++)
            {
                if (!isPrime[i])
                {
                    primes[k++] = i;
                }
            }

            return primes;
        }

        public static long[] ArrayOfPrimeNumbers(int count)
        {
            return null;
        }
    }
}
