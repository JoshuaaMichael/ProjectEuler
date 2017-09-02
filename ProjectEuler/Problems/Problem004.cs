using System;
using ProjectEulerLibrary;
using System.Collections.Generic;

namespace ProjectEuler.Problems
{
    class Problem4 : Problem
    {
        public override void Run()
        {
            int max = 0;
            for(int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    if(MathHelper.IsPalindrome((i * j).ToString()))
                    {
                        if(i * j > max)
                        {
                            max = i * j;
                        }
                    }
                }
            }

            Console.WriteLine("Result is: {0}", max);
        }
    }
}
