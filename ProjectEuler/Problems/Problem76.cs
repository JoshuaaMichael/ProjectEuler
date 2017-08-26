using System;
using ProjectEulerLibrary;
using System.Collections.Generic;

namespace ProjectEuler.Problems
{
	class Problem76 : Problem
	{
		public override void Run()
		{
            int countOfWays = 0;

            RecursiveSummationCounter(ref countOfWays, 100);
            countOfWays--;

            Console.WriteLine("Result is: {0}", countOfWays);
		}

        private void RecursiveSummationCounter(ref int countOfWays, int remainder, int minimum = 1)
        {
            if (remainder == 0)
            {
                countOfWays++;
                return;
            }

            for(int i = minimum; i <= remainder; i++)
            {
                RecursiveSummationCounter(ref countOfWays, remainder - i, i);
            }
        }
	}
}
