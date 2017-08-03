using System;
using ProjectEulerLibrary;
using System.Collections.Generic;
using System.Numerics;

namespace ProjectEuler.Problems
{
	class Problem25 : Problem
	{
		public override void Run()
		{
            long pos = 2;
            BigInteger fib1 = 1, fib2 = 1;

            while(true)
            {
                fib2 = fib1 + fib2;
                fib1 = fib2 - fib1;

                pos += 1;

                if(fib2.ToString().Length == 1000)
                {
                    break;
                }
            }           

			Console.WriteLine("Result is: {0}", pos);
		}
	}
}
