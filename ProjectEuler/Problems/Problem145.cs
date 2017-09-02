using System;
using ProjectEulerLibrary;

namespace ProjectEuler.Problems
{
    class Problem145 : Problem
    {
        public override void Run()
        {
            int count = 0;
            const int max = 100000000; //No reversible in 9 digits, anecdotal evidence
            //const int max = 1000;

            for (int i = 1; i <= max; i++)
            {
                count += (IsReversable(i)) ? 1 : 0;
            }

            Console.WriteLine("Result is: {0}", count);
        }

        private static bool IsReversable(int num)
        {
            int sum = num + ReverseNumber(num);

            if (OnlyOdd(sum) && num % 10 != 0)
            {
                return true;
            }

            return false;
        }

        private static int ReverseNumber(int num)
        {
            int returnNum = 0, temp;

            while (num != 0)
            {
                temp = num % 10;
                num /= 10;
                returnNum = returnNum * 10 + temp;
            }

            return returnNum; 
        }

        private static bool OnlyOdd(int num)
        {
            int temp;

            while (num != 0)
            {
                temp = num % 10;
                if(temp % 2 == 0)
                {
                    return false;
                }
                num /= 10;
            }

            return true;
        }
    }
}
