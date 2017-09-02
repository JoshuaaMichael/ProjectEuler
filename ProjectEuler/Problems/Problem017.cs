using System;
using ProjectEulerLibrary;
using System.Collections.Generic;

namespace ProjectEuler.Problems
{
	class Problem17 : Problem
	{
		public override void Run()
		{
            string[] singleDigit = new string[] { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            string[] teens = new string[] { "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            string[] doubleDigit = new string[] { "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

            int totalChars = 0;
            int totalSingleDigitDigits = 0;
            for(int i = 0; i < singleDigit.Length; i++)
            {
                totalChars += singleDigit[i].Length;
            }
            totalSingleDigitDigits = totalChars;
            totalChars *= 9; //This is for all the twenty ONE, twenty TWO, etc

            for (int i = 0; i < teens.Length; i++)
            {
                totalChars += teens[i].Length;
            }

            for (int i = 0; i < doubleDigit.Length; i++)
            {
                totalChars += doubleDigit[i].Length * 10;
            }

            totalChars *= 10; //This is for all the one hundred and NINETYNINE

            totalChars += totalSingleDigitDigits * 100;

            totalChars += "hundred".Length * 9;

            totalChars += "hundredand".Length * 99 * 9;

            totalChars += "onethousand".Length;

            Console.WriteLine("Result is: {0}", totalChars);
		}
	}
}
