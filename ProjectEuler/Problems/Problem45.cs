using System;
using ProjectEulerLibrary;

namespace ProjectEuler.Problems
{
	class Problem45 : Problem
	{
        public override void Run()
        {
            for(int i = 144; ; i++)
            {
                long num = i * (2 * i - 1);
                if(MathHelper.IsPentagonal(num))
                {
                    Console.WriteLine("Result is: {0}", num);
                    break;
                }
            }
        }
    }
}
