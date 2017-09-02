using System;
using ProjectEulerLibrary;

namespace ProjectEuler.Problems
{
    class Problem2 : Problem
    {
        public override void Run()
        {
            int sum = 0;
            int first = 1, second = 2;

            sum += second; //1 is not needed, 2 is needed in sum, 3 is not needed

            for(int fibNum = 3; fibNum < 4000000; )
            {

                if(MathHelper.IsMultiple(fibNum, 2))
                {
                    sum += fibNum;
                }

                //take next step
                first = second;
                second = fibNum;
                fibNum = first + second;
            }

            Console.WriteLine("Result is: {0}", sum);
        }
    }
}
