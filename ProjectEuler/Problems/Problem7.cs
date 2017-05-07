using System;
using ProjectEulerLibrary;
using System.Collections.Generic;

namespace ProjectEuler.Problems
{
	class Problem7 : Problem
	{
		public override void Run()
		{
			int primeCount = 0;
			int maxPrimeCount = 10001;
			long latestPrime = 0;

			for(int i = 2; primeCount < maxPrimeCount; i++)
			{
				if(MathHelper.IsPrime(i))
				{
					latestPrime = i;
					primeCount++;
				}
			}

			Console.WriteLine("Result is: {0}", latestPrime);
		}
	}
}
