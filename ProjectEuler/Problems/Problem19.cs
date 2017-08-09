using System;
using ProjectEulerLibrary;
using System.Collections.Generic;

namespace ProjectEuler.Problems
{
	class Problem19 : Problem
	{
		public override void Run()
		{
            int count = 0;
            for(int i = 1901; i <= 2000; i++)
            {
                for (int j = 1; j <= 12; j++)
                {
                    DateTime t = new DateTime(i, j, 1);
                    if(t.DayOfWeek == DayOfWeek.Sunday)
                    {
                        count += 1;
                    }
                }
            }

            Console.WriteLine("Result is: {0}", count);
		}
	}
}
