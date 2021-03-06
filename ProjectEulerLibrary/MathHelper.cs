﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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

		public static int CollatzSequenceChainCount(int start)
		{
			long value = start; //Figuring out this arithmetic overflow sucked, has to be long
			int count = 0;
			while(value != 1)
			{
				count++;
				if(value % 2 == 0) //even
				{
					value /= 2;
				}
				else //odd
				{
					value = 3 * value + 1;
				}
			}

			return count + 1; //Adding the 1 step
		}

        public static long CalculatePentagonalNumber(int n)
        {
            return (n * (3*n - 1)) / 2;
        }

        public static bool IsTriangle(long value)
        {
            double n = (Math.Sqrt((8 * value) + 1) - 1) / 2;
            return n % 1 == 0;
        }

        public static bool IsPentagonal(long value)
        {
            double n = (Math.Sqrt((24 * value) + 1) + 1) / 6;
            return n % 1 == 0;
        }

        public static bool IsHexagonal(long value)
        {
            double n = (Math.Sqrt((8 * value) + 1) + 1) / 4;
            return n % 1 == 0;
        }

        public static bool IsSquare(long value)
        {
            double n = (Math.Sqrt(value));
            return n % 1 == 0;
        }

        public static bool IsHeptagonal(long value)
        {
            double n = (Math.Sqrt(40 * value + 9) + 3) / 10;
            return n % 1 == 0;
        }

        public static bool IsOctagonal(long value)
        {
            double n = (Math.Sqrt(3 * value + 1) + 1) / 3;
            return n % 1 == 0;
        }

        public static long CalculateTriangleNumber(int n)
        {
            return (n * (n + 1)) / 2;
        }

        public static bool Balance(int n)
        {
            long tri = n * (n + 1) / 2;
            long pent = n * ((3 * n) - 1) / 2;
            long hex = n * ((2 * n) - 1);

            return (tri == pent && pent == hex);
        }

        public static long SumOfDivisors(long number)
        {
            long total = 1;
            long max = (long)Math.Sqrt(number);
            for (int factor = 2; factor <= max; factor++)
            {
                if (number % factor == 0)
                {
                    total += factor;
                    total += number / factor;
                }
            }
            return total;
        }

        public static bool IsAmicable(int number)
        {
            //d(a) = b and d(b) = a, where a ≠ b
            long sum1 = SumOfDivisors(number);
            long sum2 = SumOfDivisors(sum1);
            return sum2 == number && sum1 != sum2;
        }

        public static int ConsecutivePrimesQuadratic(int a, int b)
        {
            int n = 0;
            while (IsPrime((n * n) + (a * n) + b))
            {
                n++;
            }

            return n;
        }

        public static HashSet<long> HashsetOfPrimeNumbers(long max)
        {
            List<long> primes = ListOfPrimeNumbers(max);
            return new HashSet<long>(primes);
        }

        public static List<long> ListOfPrimeNumbers(long max)
        {
            List<long> primes = new List<long>();
            if (max < 2)
            {
                return primes;
            }

            primes.Add(2);
            for (int i = 3; i < max; i += 2)
            {
                if (IsPrime(i))
                {
                    primes.Add(i);
                }
            }
            return primes;
        }

        public static List<long> ListOfPrimes(int count)
        {
            List<long> primes = new List<long>();

            if(count < 1)
            {
                throw new ArgumentException("Count too low");
            }
            primes.Add(2);
            for (int i = 3; primes.Count < count; i += 2)
            {
                if (IsPrime(i))
                {
                    primes.Add(i);
                }
            }
            return primes;
        }

        public static string ShiftString(string str)
        {
            return str.Substring(1, str.Length - 1) + str.Substring(0, 1);
        }

        public static List<string> ListAllRotations(string str)
        {
            List<string> list = new List<string>();
            list.Add(str);
            string tempShift = str;
            for(int i = 0; i < str.Length - 1; i++)
            {
                tempShift = ShiftString(tempShift);
                list.Add(tempShift);
            }
            return list;
        }

        public static bool AreAllPrime(List<long> numbers)
        {
            if(numbers.Count == 0)
            {
                throw new ArgumentException("Empty list");
            }
            for(int i = 0; i < numbers.Count; i++)
            {
                if(!IsPrime(numbers[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public static List<long> ListAllProperFactors(long number)
        {
            List<long> factors = new List<long>();
            factors.Add(1);
            for (int factor = 2; factor < number; factor++)
            {
                if (number % factor == 0)
                {
                    factors.Add(factor);
                }
            }
            return factors;
        }


        public static int CountDistinctPrimeFactors(List<long> preComputedPrimes, long num)
        {
            int count = 0;
            for(int i = 0; num != 1 && i < preComputedPrimes.Count; i++)
            {
                if (num % preComputedPrimes[i] == 0)
                {
                    count += 1;
                    while (num % preComputedPrimes[i] == 0)
                    {
                        num /= preComputedPrimes[i];
                    }
                }
            }

            return count;
        }

        public static bool IsPandigital9DigitNumber(string num)
        {
            if(num.Length != 9)
            {
                return false;
            }

            List<char> chars = new List<char>(num.ToArray());
            chars.Sort();

            for(int i = 0; i < chars.Count; i++)
            {
                if(chars[i] != i + 49)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsPandigital10DigitNum(string num)
        {
            if (num.Length != 10)
            {
                return false;
            }

            List<char> chars = new List<char>(num.ToArray());
            chars.Sort();

            for (int i = 0; i < chars.Count; i++)
            {
                if (chars[i] != i + 48)
                {
                    return false;
                }
            }
            return true;
        }

        public static BigInteger Pow(int x, uint y)
        {
            BigInteger total = x;
            for (int i = 1; i < y; i++)
            {
                total *= x;
            }
            return total;
        }

        public static bool IsSquare(int num)
        {
            if (num % 10 == 2 || num % 10 == 3 || num % 10 == 7 || num % 10 == 8)
                return false;

            long root = (long)Math.Round(Math.Sqrt(num));

            return root * root == num;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="results">Blank list for results</param>
        /// <param name="elements">Char array of string to permute</param>
        /// <param name="maxDepth">arr.Length - 1</param>
        /// <param name="recursionDepth">Leave default, 0</param>
        public static void Permute(List<string> results, char[] elements, int maxDepth, int recursionDepth = 0)
        {
            if (recursionDepth == maxDepth)
            {
                results.Add(new string(elements));
                return;
            }

            for (int i = recursionDepth; i <= maxDepth; i++)
            {
                Swap(ref elements[recursionDepth], ref elements[i]);
                Permute(results, elements, maxDepth, recursionDepth + 1);
                // backtrack
                Swap(ref elements[recursionDepth], ref elements[i]);
            }
        }

        private static void Swap(ref char a, ref char b)
        {
            char tmp = a;
            a = b;
            b = tmp;
        }

        /// <summary>
        /// Euler's totient function
        /// </summary>
        /// <param name="x">Given value to test</param>
        /// <param name="primes">List of primes must contain all primes up to sqrt of x</param>
        /// <returns></returns>
        public static int Totient(int x, int[] primes)
        {
            if(primes[primes.Length - 1] < x)
            {
                throw new ArgumentException("Primes list must contain all primes up to and including sqrt(x)");
            }

            int phiResult = 1;
            int sqrtX = (int)Math.Sqrt(x);
            int p = 0;
            for(int i = 0; primes[i] <= sqrtX; i++)
            {
                p = primes[i];
                if (x % p == 0)
                {
                    phiResult *= (p - 1);
                    x /= p;
                }
                while (x % p == 0)
                {
                    phiResult *= p;
                    x /= p;
                }
            }

            if(x != 1)
                phiResult *= (x - 1);

            return phiResult;
        }

        public static string SortString(string str)
        {
            char[] tCharArray = str.ToCharArray();
            Array.Sort(tCharArray);
            return new string(tCharArray);
        }

        public static bool IsPermutation(string str1, string str2)
        {
            return SortString(str1).CompareTo(SortString(str2)) == 0;
        }

        //  https://codereview.stackexchange.com/a/173419/99715
        public static int GreatestCommonDenominator(int x, int y)
        {
            while (y != 0)
            {
                int tmp = x % y;
                x = y;
                y = tmp;
            }

            return x;
        }
    }
}
