using System;
using System.Numerics;
using ProjectEulerLibrary;

namespace ProjectEuler.Problems
{
	class Problem48 : Problem
	{
        public override void Run()
        {
            BigInteger total = 0;

            for(int i = 1; i <= 1000; i++)
            {
                total += MathHelper.Pow(i, (uint)i);
            }

            string tempStr = total.ToString();

            Console.WriteLine("Result is: {0}", tempStr.Substring(tempStr.Length - 10));
        }
    }
}
