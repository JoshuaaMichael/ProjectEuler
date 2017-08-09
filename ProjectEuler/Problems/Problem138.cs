using System;
using ProjectEulerLibrary;
using System.Collections.Generic;

namespace ProjectEuler.Problems
{
	class Problem138 : Problem
	{
		public override void Run()
		{
            int sum = 0, count = 0;
            long bLower, bUpper;

            for (int L = 2; count != 12; L++)
            {
                if (IsSquare(5 * L * L - 1)) // bigInt issue here!
                {
                    bLower = (long)(4 * (-2 + Math.Sqrt(5 * L * L - 1)));
                    bUpper = (long)(4 * (+2 + Math.Sqrt(5 * L * L - 1)));
                    Console.WriteLine("{0} {1}", bLower, bUpper);
                    if (bLower % 10 == 0 || bUpper % 10 == 0)
                    {
                        sum += L;
                        count++;
                        Console.WriteLine("EstimatedArea: {0}", 1 / 2.0 * bLower * bLower);
                    }
                }
            }
            Console.WriteLine("Sum: {0}", sum);
		}

        bool IsSquare(int num)
        {
            if (num % 10 == 2 || num % 10 == 3 || num % 10 == 7 || num % 10 == 8)
                return false;

            long root = (long)Math.Round(Math.Sqrt(num));
            return (root * root == num);
        }
    }
}
