using System;
using ProjectEulerLibrary;
using System.Collections.Generic;

namespace ProjectEuler.Problems
{
	class Problem34 : Problem
	{
        public override void Run()
        {
            int[] precomputedFactorials = precomputeFactorials(0, 9);

            long sum = 0;

            for(int i = 3; ; i++)
            {
                string iStr = i.ToString();
                long tempSum = 0;

                for(int j = 0; j < iStr.Length; j++) //Go through each digit
                {
                    tempSum += precomputedFactorials[iStr[j] - 48];
                }

                if(tempSum == i)
                {
                    sum += tempSum;
                    Console.WriteLine("Found another: {0}, total sum: {1}", tempSum, sum);
                }
            }

            Console.WriteLine("Result is: {0}", 0);
        }

        private int[] precomputeFactorials(int start, int finish)
        {
            int[] results = new int[Math.Abs(finish - start) + 1]; //+1 for inclusive, should check if code works for negative numbers

            for (int i = start; i <= finish; i++)
            {
                int tempTotal = 1; //12
                for(int j = i; j > 1; j--)
                {
                    tempTotal *= j;
                }
                results[i - start] = tempTotal;
            }

            return results;
        }
    }
}
