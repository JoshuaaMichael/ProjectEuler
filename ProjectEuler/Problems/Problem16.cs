using System;
using ProjectEulerLibrary;
using System.Collections.Generic;
using System.Numerics;

namespace ProjectEuler.Problems
{
	class Problem16 : Problem
	{
		public override void Run()
		{
            BigInteger powerTwoValue = 2;

            for(int i = 0; i < 999; i++)
            {
                powerTwoValue *= 2;
            }

            int sumDigitValue = 0;
            string powerTwoValueString = powerTwoValue.ToString();

            for(int i = 0; i < powerTwoValueString.Length; i++)
            {
                sumDigitValue += int.Parse(powerTwoValueString[i] + "");
            }

			Console.WriteLine("Result is: {0}", sumDigitValue);
		}
	}
}
