using System;
using ProjectEulerLibrary;
using System.Collections.Generic;
using System.Numerics;

namespace ProjectEuler.Problems
{
	class Problem55 : Problem
	{
		public override void Run()
		{
            int count = 0;
            for (int number = 1; number < 10000; number++)
            {
                if(IsLychrel(number))
                {
                    Console.WriteLine("Found Lychrel: {0}", number);
                    count++;
                }
            }

            Console.WriteLine("Result is: {0}", count);
		}

        private bool IsLychrel(BigInteger num)
        {
            BigInteger temp = num;
            for (int i = 1; i < 50; i++)
            {
                temp += BigInteger.Parse(ReverseString(temp.ToString()));
                if (IsPalindrome(temp.ToString()))
                {
                    return false;
                }

            }
            return true;
        }

        private bool IsPalindrome(string str)
        {
            for(int i = 0; i < str.Length / 2; i++)
            {
                if(str[i] != str[str.Length - i - 1])
                {
                    return false;
                }
            }

            return true;
        }

        private string ReverseString(string str)
        {
            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
