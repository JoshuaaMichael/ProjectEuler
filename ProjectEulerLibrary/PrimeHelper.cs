using System;
using System.Collections.Generic;

namespace ProjectEulerLibrary
{
    public static class PrimeHelper
    {
        public static int[] ArrayOfPrimeNumbersToMax(int maxNumber)
        {
            //Sieve of Eratosthenes
            if(maxNumber < 2)
            {
                return new int[] { };
            }
            bool[] isPrime = new bool[maxNumber];
            int sqrtMaxNumber = (int)Math.Sqrt(maxNumber);
            int countNotPrime = 2; //0,1

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

            int[] primes = ConvertToPrimes(isPrime, countNotPrime, 0);

            return primes;
        }

        private static int[] ConvertToPrimes(bool[] isPrime, int countNotPrime, int offset)
        {
            int[] primes = new int[isPrime.Length - countNotPrime]; //Length of count of primes
            int j = 0;

            for (int i = 0; i < isPrime.Length; i++)
            {
                if (isPrime[i])
                {
                    primes[j++] = i + offset;
                }
            }

            return primes;
        }

        //The new idea
        public static int[] ArrayOfPrimeNumbersToMax_dev(int maxNumber)
        {
            //Based on Sieve of Eratosthenes
            if (maxNumber < 2)
            {
                return new int[] { };
            }
            int sqrtMaxNumber = (int)Math.Sqrt(maxNumber);
            bool[] isPrime = new bool[sqrtMaxNumber];
            int countNotPrime = 2; //0,1
            for (int i = 2; i < isPrime.Length; i++) isPrime[i] = true;



            for (int i = 2; i < isPrime.Length; i++)
            {
                if (isPrime[i])
                {
                    for (int j = i * 2; j < isPrime.Length; j += i)
                    {
                        if (isPrime[j] == true)
                        {
                            isPrime[j] = false;
                            countNotPrime += 1;
                        }
                    }
                }
            }

            int[] primes = ConvertToPrimes(isPrime, countNotPrime, 0);
            List<int> primesResult = new List<int>(primes);

            int oddFirstNumber = (primes[primes.Length - 1] % 2 == 0) ? primes[primes.Length - 1] + 1 : primes[primes.Length - 1];
            int oddLastNumber = (maxNumber % 2 == 0) ? maxNumber + 1 : maxNumber;

            for(int i = oddFirstNumber; i <= oddLastNumber; i+=2)
            {
                if(i % 9999 == 0)
                {
                    Console.WriteLine("Up to: {0}/{1}, {2:N2}% - {3} primes so far", i, int.MaxValue, ((double)i/(double)int.MaxValue)*100.0, primesResult.Count);
                }

                bool foundDivisor = false;
                for(int j = 0; j < primes.Length; j++)
                {
                    if (i % primes[j] == 0)
                    {
                        foundDivisor = true;
                        break;
                    }
                }
                if(!foundDivisor)
                {
                    primesResult.Add(i);
                }
            }
            
            //This is good for RAM usage, however it's less efficeint in terms of processing
            //Going to need to do a bool array of some size, and process it in chunks, removing the multiples of the primes
            //It will be more memory heavy, however it will be far better processing
            //Due to the pieces it tests with next, sets of pieces could be

            return primesResult.ToArray();
        }

        //The new idea
        public static int[] ArrayOfPrimeNumbersToMax_dev2(int maxNumber)
        {
            //Based on Sieve of Eratosthenes
            if (maxNumber < 2)
            {
                return new int[] { };
            }
            int sqrtMaxNumber = (int)Math.Sqrt(maxNumber);
            bool[] isPrime = new bool[sqrtMaxNumber];
            int countNotPrime = 2; //0,1
            for (int i = 2; i < isPrime.Length; i++) isPrime[i] = true;

            for (int i = 2; i < isPrime.Length; i++)
            {
                if (isPrime[i])
                {
                    for (int j = i * 2; j < isPrime.Length; j += i)
                    {
                        if (isPrime[j] == true)
                        {
                            isPrime[j] = false;
                            countNotPrime += 1;
                        }
                    }
                }
            }

            int[] primes = ConvertToPrimes(isPrime, countNotPrime, 0);
            int oddFirstNumber = (primes[primes.Length - 1] % 2 == 0) ? primes[primes.Length - 1] + 1 : primes[primes.Length - 1];
            int oddLastNumber = (maxNumber % 2 == 0) ? maxNumber + 1 : maxNumber;

            List<int> primesResult = CheckForPrimes(oddFirstNumber, oddLastNumber, primes);

            //This is good for RAM usage, however it's less efficeint in terms of processing
            //Going to need to do a bool array of some size, and process it in chunks, removing the multiples of the primes
            //It will be more memory heavy, however it will be far better processing
            //Due to the pieces it tests with next, sets of pieces could be

            return primesResult.ToArray();
        }

        private static List<int> CheckForPrimes(int min, int max, int[] knownPrimes)
        {
            bool[] isPrime = new bool[(max - min) + 1]; //(100 - 50) + 1, 51 options, inclusive

            for (int i = 0; i < isPrime.Length; i++) isPrime[i] = true;

            List<int> primes = new List<int>();
            int countNotPrime = 0; //Need to check for the cases where min = 0

            for (int i = min; i < max; i++)
            {
                if (isPrime[i - min])
                {
                    for (int j = i * 2; j < isPrime.Length; j += i)
                    {
                        if (isPrime[j] == true)
                        {
                            isPrime[j] = false;
                            countNotPrime += 1;
                        }
                    }
                }
            }

            return new List<int>(ConvertToPrimes(isPrime, countNotPrime, min));







            for (int i = min; i <= max; i += 2)
            {
                bool foundDivisor = false;
                for (int j = 0; j < knownPrimes.Length; j++)
                {
                    if (i % knownPrimes[j] == 0)
                    {
                        foundDivisor = true;
                        break;
                    }
                }
                if (!foundDivisor)
                {
                    primes.Add(i);
                }
            }
            return primes;
        }
    }
}
