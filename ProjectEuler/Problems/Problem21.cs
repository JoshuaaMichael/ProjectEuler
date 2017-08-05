using ProjectEulerLibrary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler.Problems
{
	class Problem21 : Problem
	{
        public override void Run()
        {
            List<int> amicableNumbers = new List<int>();

            for(int i = 1; i < 10000; i++)
            {
                if(MathHelper.IsAmicable(i))
                {
                    amicableNumbers.Add(i);
                }
            }

            Console.WriteLine("Result is: {0}", amicableNumbers.Sum());
        }
    }
}
