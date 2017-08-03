using System;
using ProjectEulerLibrary;
using System.Collections.Generic;
using System.Numerics;

namespace ProjectEuler.Problems
{
	class Problem20 : Problem
	{
		public override void Run()
		{
            BigInteger factorialValue = 100;

            for(int i = 100; i > 0; i--)
            {
                factorialValue *= i;
            }

            Console.WriteLine("Result is: {0}", factorialValue);

            int sumDigitValue = 0;
            string powerTwoValueString = factorialValue.ToString();

            for(int i = 0; i < powerTwoValueString.Length; i++)
            {
                sumDigitValue += int.Parse(powerTwoValueString[i] + "");
            }

			Console.WriteLine("Result is: {0}", sumDigitValue);
		}
	}
}
