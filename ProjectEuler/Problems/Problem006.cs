using System;
using ProjectEulerLibrary;
using System.Collections.Generic;

namespace ProjectEuler.Problems
{
	class Problem6 : Problem
	{
		public override void Run()
		{
			long sumOfSquares = MathHelper.SumOfSquares(1, 100);
			long squareOfSums = MathHelper.SquareOfSums(1, 100);

			long diff = squareOfSums - sumOfSquares;

			Console.WriteLine("Result is: {0}", diff);
		}
	}
}
