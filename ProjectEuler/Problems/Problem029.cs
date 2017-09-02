using ProjectEulerLibrary;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace ProjectEuler.Problems
{
	class Problem29 : Problem
	{
        public override void Run()
        {
            HashSet<BigInteger> results = new HashSet<BigInteger>();

            for(int a = 2; a <= 100; a++)
            {
                for (int b = 2; b <= 100; b++)
                {
                    BigInteger temp = MathHelper.Pow(a, (uint)b);
                    if(!results.Contains(temp))
                    {
                        results.Add(temp);
                    }
                }
            }

            Console.WriteLine("Result is: {0}", results.Count);
        }
    }
}
