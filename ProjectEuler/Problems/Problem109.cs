using System;
using ProjectEulerLibrary;
using System.Collections.Generic;
using System.IO;
using System.Numerics;

namespace ProjectEuler.Problems
{
	class Problem109 : Problem
	{
		static int[] pandigitalPrecompute = { 3, 5, 6, 11, 13, 17, 19, 23, 29 };

		static HashSet<string> all9DigitPandigitals = null;

		public override void Run()
		{
			BigInteger a = 1, b = 1, temp;
			int k = 2;
			//string bStr;

			while (k < 30000)
			{
				temp = b;
				b = a + b;
				a = temp;
				k++;

				if (b <= 99999999)
					continue;

				string firstNineDigits, lastNineDigits;
				bool isFirstNineDigitsPandigital = false, isLastNineDigitalPandigital = false;

				firstNineDigits = GetFirst9Digits(b).ToString();
				isFirstNineDigitsPandigital = MathHelper.IsPandigital9DigitNumber(firstNineDigits);

				if (!isFirstNineDigitsPandigital)
					continue;

				lastNineDigits = ((int)(b % 1000000000)).ToString();
				isLastNineDigitalPandigital = MathHelper.IsPandigital9DigitNumber(lastNineDigits);

				if (!isLastNineDigitalPandigital)
					continue;

				break;
			}

			Console.WriteLine("Result is: {0}", k);
		}

		private static int GetFirst9Digits(BigInteger number)
		{
			while(number > 999999999)
			{
				number /= 10;

			}

			return (int)(number);
		}

		public static bool IsPandigital9DigitNumber_test(string num)
		{
			if (num.Length != 9)
			{
				return false;
			}

			long tempSum = 1;
			for (int i = 0; i < 9; i++) //Go through each character and add the digit's corresponding prime
			{
				int temp = num[i] - '1';
				if(temp == -1) //-1 when num[i] == 0, we're only looking for 1 through 9 inclusive, not 0
				{
					return false;
				}
				tempSum *= pandigitalPrecompute[temp];
			}

			return tempSum == 2772725670; //2772725670 is the known result if all numbers used once
		}

		public static bool IsPandigital9DigitNumber_test2(string num)
		{
			bool[] present = new bool[10];
			
			for(int i = 0; i < num.Length; i++)
			{
				int digit = (int)(num[i] - '0');
				
				if (digit == 0 || present[digit])
				{
					return false;
				}
				
				present[digit] = true;
			}

			return true;
		}

		public static bool IsPandigital(string number)
		{
			if(all9DigitPandigitals != null)
			{
				return all9DigitPandigitals.Contains(number);
			}

			List<string> permutations = new List<string>();
			MathHelper.Permute(permutations, "123456789".ToCharArray(), 8);
			all9DigitPandigitals = new HashSet<string>(permutations);

			return IsPandigital(number);
		}
	}
}
