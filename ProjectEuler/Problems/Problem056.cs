using System;
using ProjectEulerLibrary;
using System.Collections.Generic;
using System.Numerics;

namespace ProjectEuler.Problems
{
    class Problem56 : Problem
    {
        public override void Run()
        {
            long maxDigitalSum = 0;

            for (int a = 1; a < 100; a++)
            {
                for (int b = 1; b < 100; b++)
                {
                    long digitSum = CalculateDigitSum(BigInteger.Pow(a, b));
                    if(digitSum > maxDigitalSum)
                    {
                        maxDigitalSum = digitSum;
                    }
                }
            }

            Console.WriteLine("Result is: {0}", maxDigitalSum);
        }

        private long CalculateDigitSum(BigInteger num)
        {
            long total = 0;
            string numStr = num.ToString();

            for(int i = 0; i < numStr.Length; i++)
            {
                total += numStr[i] - 48;
            }

            return total;
        }
    }
}
