using System;
using ProjectEulerLibrary;
using System.Collections.Generic;

namespace ProjectEuler.Problems
{
	class Problem10 : Problem
	{
		public override void Run()
		{
			long sum = 2;

			for(int i = 3; i < 2000000; i++)
			{
				if(MathHelper.IsPrime(i))
				{
					sum += i;
				}
			}

			Console.WriteLine("Result is: {0}", sum);
		}
	}
}
