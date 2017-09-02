using System;
using ProjectEulerLibrary;
using System.Collections.Generic;

namespace ProjectEuler.Problems
{
	class Problem23 : Problem
	{
		public override void Run()
		{
            List<int> abundantNumbers = new List<int>();

            for (int i = 1; i <= 28123; i++)
            {
                List<long> properFactors = MathHelper.ListAllProperFactors(i);
                long totalOfProperFactors = SumOfList(properFactors);
                if(totalOfProperFactors > i)
                {
                    abundantNumbers.Add(i);
                }
            }

            List<int> abundantNumbersHashset = new List<int>(abundantNumbers);
            long total = 0;

            for (int i = 1; i <= 28123; i++)
            {
                if(i == 16)
                {
                    Console.WriteLine("HALT");
                }
                bool isSumTwoAbundantNumbers = false;

                for (int j = 0; abundantNumbers[j] < i && j < abundantNumbers.Count; j++)
                {
                    if (abundantNumbersHashset.Contains(i - abundantNumbers[j]))
                    {
                        isSumTwoAbundantNumbers = true;
                        break;
                    }
                    
                }

                if (!isSumTwoAbundantNumbers)
                {
                    total += i;
                }
            }

			Console.WriteLine("Result is: {0}", total);
		}

        private long SumOfList(List<long> values)
        {
            long total = 0;

            for (int i = 0; i < values.Count; i++)
            {
                total += values[i];
            }

            return total;
        }
	}
}
