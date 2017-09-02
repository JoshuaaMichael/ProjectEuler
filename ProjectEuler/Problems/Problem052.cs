using System;
using ProjectEulerLibrary;
using System.Collections.Generic;

namespace ProjectEuler.Problems
{
	class Problem52 : Problem
	{
		public override void Run()
		{
            for(int i = 1; ; i++)
            {
                bool foundSameDigits = true;
                for (int j = 6; j >= 2; j--)
                {
                    if(!IsSameDigits(i, j * i))
                    {
                        foundSameDigits = false;
                    }
                }
                if(foundSameDigits)
                {
                    Console.WriteLine("Result is: {0}", i);
                    return;
                }
            }
		}

        private bool IsSameDigits(int num1, int num2)
        {
            string str1 = num1.ToString();
            string str2 = num2.ToString();

            if(str1.Length != str2.Length)
            {
                return false;
            }

            char[] charArray1 = str1.ToCharArray();
            char[] charArray2 = str2.ToCharArray();

            Array.Sort(charArray1);
            Array.Sort(charArray2);

            for(int i = 0; i < charArray1.Length; i++)
            {
                if(charArray1[i] != charArray2[i])
                {
                    return false;
                }
            }

            return true;
        }
	}
}
