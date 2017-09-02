using System;
using ProjectEulerLibrary;
using System.Collections.Generic;
using System.Numerics;

namespace ProjectEuler.Problems
{
    class Problem58 : Problem
    {
        public override void Run()
        {
            int totalDiagonalNumbers = 1;
            int totalPrimes = 0;

            for (int i = 3; ; i += 2)
            {
                totalDiagonalNumbers += 4;
                for (int j = 0; j < 4; j++)
                {
                    if(MathHelper.IsPrime((i * i) - j * (i-1)))
                    {
                        totalPrimes += 1;
                    }
                }

                if((double)totalPrimes / (double)totalDiagonalNumbers < 0.1)
                {
                    Console.WriteLine("Result: {0}", i);
                    return;
                }
            }
        }
    }
}
