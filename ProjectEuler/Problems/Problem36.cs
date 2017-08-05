using System;
using ProjectEulerLibrary;

namespace ProjectEuler.Problems
{
	class Problem36 : Problem
	{
        public override void Run()
        {
            long total = 0;
            
            for (int i = 0; i < 1000000; i++)
            {
                if(MathHelper.IsPalindrome(i.ToString()))
                {
                    string binaryValue = Convert.ToString(i, 2);
                    if (MathHelper.IsPalindrome(binaryValue))
                    {
                        total += i;
                    }
                }
            }

            Console.WriteLine("Result is: {0}", total);
        }
    }
}
