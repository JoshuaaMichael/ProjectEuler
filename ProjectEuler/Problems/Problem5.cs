using System;
using ProjectEulerLibrary;
using System.Collections.Generic;

namespace ProjectEuler.Problems
{
    class Problem5 : Problem
    {
        public override void Run()
        {
            int max = 20;
            int value = 0;
            for(int i = 2; value == 0; i++)
            {
                for(int j = 1; j <= max; j++)
                {
                    if(i % j != 0)
                    {
                        break;
                    }
                    if (j == max)
                    {
                        value = i;
                        break;
                    }
                }
            }

            Console.WriteLine("Result is: {0}", value);
        }
    }
}
