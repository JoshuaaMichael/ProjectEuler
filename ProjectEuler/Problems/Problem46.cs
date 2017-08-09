using System;
using ProjectEulerLibrary;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ProjectEuler.Problems
{
    class Problem46 : Problem
    {
        public override void Run()
        {
            int[] primes = PrimeHelper.ArrayOfPrimeNumbersToMax(100000000);
            HashSet<int> primesHashSet = new HashSet<int>(primes);
            HashSet<int> squares = GetSquareNumbersHashset(100000000);

            for (int i = 3; i > 0 ; i += 2)
            {
                //odd comp
                if (!primesHashSet.Contains(i))
                {
                    bool success = false;
                    for (int j = 0; primes[j] < i; j++)
                    {
                        if(!squares.Contains((i - primes[j]) / 2))
                        {
                            success = true;
                            break;
                        }
                    }

                    if(!success)
                    {
                        Console.WriteLine("Result is: {0}", i);
                        return;
                    }
                }
            }
        }

        public HashSet<int> GetSquareNumbersHashset(int maxValue)
        {
            HashSet<int> squares = new HashSet<int>();
            for(int i = 1; i * i < maxValue; i++)
            {
                squares.Add(i * i);
            }
            return squares;
        }
    }
}
