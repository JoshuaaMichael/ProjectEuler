using ProjectEulerLibrary;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace ProjectEuler.Problems
{
	class Problem30 : Problem
	{
        public override void Run()
        {
            int sum, totalSum = 0, num;

            for(int i = 10; i < 200000 ; i++)
            {
                sum = 0;
                num = i;


                while (num != 0)
                {
                    sum += (int)Math.Pow(num % 10, 5);
                    num /= 10;
                }

                if (sum == i)
                {
                    totalSum += sum;
                }
            }

            Console.WriteLine("Result is: {0}", totalSum);
        }
    }
}
