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
	}
}
