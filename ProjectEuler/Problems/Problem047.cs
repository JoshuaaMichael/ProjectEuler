using ProjectEulerLibrary;
using System;
using System.Collections.Generic;

namespace ProjectEuler.Problems
{
	class Problem47 : Problem
	{
        public override void Run()
        {
            List<long> preComputedPrimes = MathHelper.ListOfPrimes(10000);
            int lastConsecutive = 0;
            int consecutive = 0;
            for (int i = 16; consecutive < 4; i++)
            {
                if(MathHelper.CountDistinctPrimeFactors(preComputedPrimes, i) == 4)
                {
                    lastConsecutive = i;
                    consecutive += 1;
                }
                else
                {
                    consecutive = 0;
                }
            }

            Console.WriteLine("Result is: {0}, {1}, {2}, {3}", lastConsecutive - 3, lastConsecutive - 2, lastConsecutive - 1, lastConsecutive);
        }
    }
}
