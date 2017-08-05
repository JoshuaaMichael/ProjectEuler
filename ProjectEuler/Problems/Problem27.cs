using ProjectEulerLibrary;
using System;

namespace ProjectEuler.Problems
{
	class Problem27 : Problem
	{
        public override void Run()
        {
            int bestConsecutiveCount = 0;
            int abTotal = 0;
            for (int a = -1000; a < 1000; a++)
            {
                for (int b = -1000; b <= 1000; b++)
                {
                    int consecutiveCount = MathHelper.ConsecutivePrimesQuadratic(a, b);
                    if(consecutiveCount > bestConsecutiveCount)
                    {
                        Console.WriteLine("New best: {0} consec, {1} a, {2} b, {3} total", consecutiveCount, a, b, a * b);
                        bestConsecutiveCount = consecutiveCount;
                        abTotal = a * b;
                    }
                }
            }

            Console.WriteLine("Result is: {0}", abTotal);
        }
    }
}
