using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerLibrary
{
    public static class MathHelper
    {
        public static bool IsMultiple(int value, int multipleOf)
        {
            return (value % multipleOf == 0);
        }

        //https://www.khanacademy.org/math/pre-algebra/pre-algebra-factors-multiples/pre-algebra-prime-factorization-prealg/v/prime-factorization
        public static long MaxPrimeFactor(long value)
        {
            long k = 2;

            while(k * k <= value) 
            {
                if(value % k == 0)
                {
                    value /= k;
                }
                else
                {
                    ++k;
                }
            }

            return value;
        }

        public static bool IsPalindrome(string value)
        {
            int start = 0;
            int end = value.Length - 1;
            while (true)
            {
                if (start > end)
                {
                    return true;
                }
                char a = value[start];
                char b = value[end];
                if (char.ToLower(a) != char.ToLower(b))
                {
                    return false;
                }
                start++;
                end--;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="start">Inclusive</param>
		/// <param name="finish">Inclusive</param>
		/// <returns></returns>
		public static long SumOfSquares(int start, int finish)
		{
			long total = 0;
			for(int i = start; i <= finish; i++)
			{
				total += i * i;
			}

			return total;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="start">Inclusive</param>
		/// <param name="finish">Inclusive</param>
		/// <returns></returns>
		public static long SquareOfSums(int start, int finish)
		{
			long total = 0;
			for (int i = start; i <= finish; i++)
			{
				total += i;
			}

			total *= total;

			return total;
		}

		public static bool IsPrime(long number)
		{
			if (number < 2) return false; //1 doesn't count, and negatives don't count

			long boundary = (long)Math.Floor(Math.Sqrt(number));

			for (int i = 2; i <= boundary; i++)
			{
				if (number % i == 0) return false;
			}

			return true;
		}

		public static long MultiplySingleDigits(string numbers)
		{
			long sum = int.Parse(numbers[0] + "");

			for(int i = 1; i < numbers.Length; i++)
			{
				sum *= int.Parse(numbers[i] + ""); //Throws on NaN
			}

			return sum;
		}

		public static int SumOfInt(params int[] values)
		{
			int sum = 0;

			foreach (int value in values)
			{
				sum += value;
			}
			
			return sum;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="index">Starting from 1(1), thus 2(3), 3(6), 4(10)</param>
		/// <returns></returns>
		public static int GetTriangleNumber(int index)
		{
			int sum = 0;
			for(int i = 1; i <= index; i++)
			{
				sum += i;
			}

			return sum;
		}

		public static int CountFactors(long number)
		{
			int numFactors = 0;
			long max = (long)Math.Sqrt(number);
			for (int factor = 1; factor <= max; factor++)
			{
				if (number % factor == 0)
				{
					numFactors += 2;
				}
			}
			return numFactors;
		}
	}
}
