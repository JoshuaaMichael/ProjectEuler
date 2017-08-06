using ProjectEulerLibrary;
using System;

namespace ProjectEuler.Problems
{
	class Problem28 : Problem
	{
        public override void Run()
        {
            long total = 1;

            for(int i = 3; i <= 1001; i+=2)
            {
                total += (4 * i * i) - 6 * (i - 1);
            }

            Console.WriteLine("Result is: {0}", total);
        }
    }
}
