using System;
using ProjectEulerLibrary;
using JoshuaaM.PrimeSieve;
using System.Collections.Generic;

namespace ProjectEuler.Problems
{
	class Problem70 : Problem
	{
		public override void Run()
		{
            int[] primes = PrimeSieve.GeneratePrimesToMax(50000000, true);

            double min = double.PositiveInfinity;
            int minN = 0;

            for(int n = 2; n < 10000000; n++)
            {
                int t = MathHelper.Totient(n, primes);

                if (MathHelper.IsPermutation(t.ToString(), n.ToString()))
                {
                    double temp = (double)n / (double)t;
                    if (temp < min)
                    {
                        min = temp;
                        minN = n;
                    }
                }
            }

            Console.WriteLine("Result is: {0}", minN);
		}
	}
}
