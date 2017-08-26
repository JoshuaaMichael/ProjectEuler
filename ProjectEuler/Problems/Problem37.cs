using System;
using ProjectEulerLibrary;
using System.Collections.Generic;

namespace ProjectEuler.Problems
{
    class Problem37 : Problem
    {
        public override void Run()
        {
            int[] primeArray = PrimeHelper.ArrayOfPrimeNumbersToMax(10000000);
            HashSet<int> primeHashSet = new HashSet<int>(primeArray);

            int sumResult = 0;

            for(int i = 4; i < primeArray.Length; i++)
            {
                if(IsTruncatable(primeArray[i], primeHashSet))
                {
                    sumResult += primeArray[i];
                    Console.WriteLine("Prime {0} is truncatable, sum now {1}", primeArray[i], sumResult);
                }
            }

            Console.WriteLine("Result is: {0}", sumResult);
        }

        private bool IsTruncatable(int number, HashSet<int> primeHashSet)
        {
            string numberStr = number.ToString();

            for(int i = 1; i < numberStr.Length; i++)
            {
                string testStrForward = numberStr.Remove(0, i);
                int testNumForward = int.Parse(testStrForward);

                string testStrBackward = numberStr.Remove(numberStr.Length - i);
                int testNumBackward = int.Parse(testStrBackward);

                if (!primeHashSet.Contains(testNumForward) || !primeHashSet.Contains(testNumBackward))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
