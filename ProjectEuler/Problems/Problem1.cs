using System;
using ProjectEulerLibrary;

namespace ProjectEuler.Problems
{
    class Problem1 : Problem
    {
        public override void Run()
        {
            int sum = 0;
            for(int i = 1; i < 1000; i++)
            {
                if(MathHelper.IsMultiple(i, 3) || MathHelper.IsMultiple(i, 5))
                {
                    sum += i;
                }
            }

            Console.WriteLine("Result is: {0}", sum);
        }
    }
}
