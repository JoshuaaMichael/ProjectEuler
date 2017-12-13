using System;
using ProjectEulerLibrary;
using System.Collections.Generic;
using System.IO;

namespace ProjectEuler.Problems
{
    class Problem112 : Problem
    {
        public override void Run()
        {
            int countBouncy = 0;
            double targetBouncy = 0.99;
            int result = 0;

            for (int i = 100; i <= 1587000; i++)
            {
                if (IsBouncyNumber(i))
                {
                    countBouncy++;
                }

                if (countBouncy / (double)i == targetBouncy)
                {
                    result = i;
                    break;
                }
            }
            Console.WriteLine("Result is: {0}", result);
        }

        private bool IsBouncyNumber(int number)
        {
            //Goes through the number's digits backwards checking if the the digits are in order
            //Going through backwards is computationally cheaper

            bool increasing = false;
            bool decreasing = false;

            int lastDigit = number % 10;
            number /= 10;

            while (number > 0)
            {
                int secondLastDigit = number % 10;
                number /= 10;

                if (secondLastDigit < lastDigit)
                {
                    increasing = true;
                }
                else if(secondLastDigit > lastDigit)
                {
                    decreasing = true;
                }

                if(increasing && decreasing)
                {
                    //We've flip flopped/bounced somewhere
                    return true;
                }

                lastDigit = secondLastDigit;
            }

            return false; //Never flipped/bounced, always went the same direction
        }
    }
}
