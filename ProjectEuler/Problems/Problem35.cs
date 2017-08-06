using System;
using ProjectEulerLibrary;
using System.Collections.Generic;

namespace ProjectEuler.Problems
{
	class Problem35 : Problem
	{
        public override void Run()
        {
            HashSet<long> primes = MathHelper.ListOfPrimeNumbers(1000000);

            int count = 0;
            foreach(long prime in primes)
            {
                List<string> rotations = MathHelper.ListAllRotations(prime.ToString());
                List<long> rotationsLong = new List<long>(rotations.Count);
                for(int j = 0; j < rotations.Count; j++)
                {
                    rotationsLong.Add(long.Parse(rotations[j]));
                }

                if(MathHelper.AreAllPrime(rotationsLong))
                {
                    Console.WriteLine("Found: {0}", prime);
                    count++;
                }                
            }

            Console.WriteLine("Result is: {0}", count);
        }
    }
}
