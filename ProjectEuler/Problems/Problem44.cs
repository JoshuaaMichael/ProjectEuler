using System;
using ProjectEulerLibrary;
using System.Collections.Generic;

namespace ProjectEuler.Problems
{
	class Problem44 : Problem
	{
        public override void Run()
        {
            List<long> pentagonalNumbers = new List<long>();
            int step = 100;
            long temp;
            long answer = -1;

            for (; answer == -1;)
            {
                GetMorePentNumbers(pentagonalNumbers, step);
                Console.WriteLine("Processing set, size: {0}", pentagonalNumbers.Count);
                for (int j = 1; j < pentagonalNumbers.Count && answer == -1; j++)
                {
                    for (int k = 1; k < pentagonalNumbers.Count; k++)
                    {
                        temp = pentagonalNumbers[j] + pentagonalNumbers[k];
                        if(MathHelper.IsPentagonal(temp))
                        {
                            temp = Math.Abs(pentagonalNumbers[j] - pentagonalNumbers[k]);
                            if(MathHelper.IsPentagonal(temp))
                            {
                                answer = temp;
                                break;
                            }
                        }
                    }
                }
                Console.WriteLine("Processed set");
            }
            Console.WriteLine("Result is: {0}", answer);
        }

        private void GetMorePentNumbers(List<long> pentNums, int count)
        {
            for (int i = 0; i < count; i++)
            {
                pentNums.Add(MathHelper.CalculatePentagonalNumber(pentNums.Count));
            }
        }
    }
}
