using ProjectEulerLibrary;
using System;
using System.Collections.Generic;

namespace ProjectEuler.Problems
{
	class Problem38 : Problem
	{
        public override void Run()
        {
            long max = 0;
            for(int a = 1; a < 9876; a++)
            {
                string str = "";
                for(int b = 1; str.Length < 9; b++)
                {
                    str += (a * b);
                }
                if(str.Length == 9 && long.Parse(str) > max)
                {
                    if(MathHelper.IsPandigital9DigitNumber(str))
                    {
                        max = long.Parse(str);
                    }                  
                }
            }

            Console.WriteLine("Result is: {0}", max);
        }

    }
}
