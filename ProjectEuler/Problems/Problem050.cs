using System;
using ProjectEulerLibrary;
using System.Collections.Generic;
using System.Diagnostics;

namespace ProjectEuler.Problems
{
    class Problem50 : Problem
    {
        public override void Run()
        {
            Stopwatch t = new Stopwatch();
            List<long> primes = MathHelper.ListOfPrimeNumbers(1000000);

            List<long> precomputedConsecutivePrimeSums = PrecomputeConsecutivePrimeSums(primes);

            long targetPrime = 0;
            int maxConsecutivePrimes = 0;
            int i = 0;
            foreach(long prime in primes)
            {
                i++;
                if(i % 1000 == 0)
                {
                    t.Stop();
                    Console.WriteLine("{0},{1} - took {2}", i, primes.Count, t.Elapsed);
                    t.Reset();
                    t.Start();
                }
                int temp = CountOfConsecutivePrimeSums(prime, precomputedConsecutivePrimeSums);
                if(temp > maxConsecutivePrimes)
                {
                    maxConsecutivePrimes = temp;
                    targetPrime = prime;
                }
            }

            Console.WriteLine("Result is: {0} with {1} terms", targetPrime, maxConsecutivePrimes);
        }

        private int CountOfConsecutivePrimeSums_old(long prime, List<long> precomputedPrimes)
        {
            int maxCountOfConsecutivePrimes = 0;

            for(int i = 0; i < precomputedPrimes.Count && precomputedPrimes[i] < prime; i++)
            {
                int count = 0;
                long sum = 0;
                for(int j = i; j < precomputedPrimes.Count && (precomputedPrimes[j] < prime); j++)
                {
                    sum += precomputedPrimes[j];
                    if(sum == prime)
                    {
                        count += 1;
                        if (count > maxCountOfConsecutivePrimes)
                        {
                            maxCountOfConsecutivePrimes = count;
                        }
                        break;
                    }
                    else if (sum < prime)
                    {
                        count += 1;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return maxCountOfConsecutivePrimes;
        }

        
        //Precompute the count set
        private List<long> PrecomputeConsecutivePrimeSums(List<long> precomputedPrimes)
        {
            List<long> precomputedConsecutivePrimeSums = new List<long>();
            precomputedConsecutivePrimeSums.Add(precomputedPrimes[0]);

            long sum = 0;
            for (int i = 0; i < precomputedPrimes.Count; i++)
            {
                sum += precomputedPrimes[i];
                precomputedConsecutivePrimeSums.Add(sum);
            }

            return precomputedConsecutivePrimeSums;
        }

        //New count consecutive prime function

        private int CountOfConsecutivePrimeSums(long prime, List<long> pcps)
        {
            int maxCountOfConsecutivePrimes = 0;

            //Go through each of the possible offset with [i]
            for (int i = 0; i < pcps.Count - 21 && pcps[i+1] - pcps[i] < prime; i++)
            {
                //Starting at the i offset of the pcps.count
                int count = 0;
                for (int j = i; j < pcps.Count; j++)
                {
                    if (pcps[j] - pcps[i] > prime)
                        break;
                    else if (pcps[j] - pcps[i] == prime)
                    {
                        //found!
                        count = j - i;
                        if (count > maxCountOfConsecutivePrimes)
                        {
                            maxCountOfConsecutivePrimes = count;
                        }
                    }
                }
            }
            return maxCountOfConsecutivePrimes;
        }
    }
}
