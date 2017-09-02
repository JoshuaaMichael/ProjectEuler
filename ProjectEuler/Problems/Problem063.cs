using System;
using System.Collections.Generic;
using System.Numerics;
using ProjectEulerLibrary;

namespace ProjectEuler.Problems
{
	class Problem63 : Problem
	{
        public override void Run()
        {
            //  10^(n-1) <= a^n < 10^n restricts a^n to exactly n digits
            //  It follows, from WolframAlpha solving of equations:
            //  1 <= a <= 9
            //  1 <= n <= 22

            int count = 0;

            for(int a = 1; a <= 9; a++)
            {
                for (int n = 1; n <= 22; n++)
                {
                    BigInteger value = BigInteger.Pow(a, n);
                    if(value.ToString().Length == n)
                    {
                        count += 1;
                    }
                }
            }

            Console.WriteLine("Result is: {0}", count);
        }
    }
}
