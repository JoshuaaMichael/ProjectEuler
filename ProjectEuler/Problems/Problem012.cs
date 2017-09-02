using System;
using ProjectEulerLibrary;
using System.Collections.Generic;

namespace ProjectEuler.Problems
{
	class Problem12 : Problem
	{
		public override void Run()
		{
			long triangleNumberTarget = 0;
			for(int i = 0; ; i++)
			{
				long triangleNumber = MathHelper.GetTriangleNumber(i);
				int numberOfFactors = MathHelper.CountFactors(triangleNumber);
				if(numberOfFactors > 500)
				{
					triangleNumberTarget = triangleNumber;
					break;
				}
			}

			Console.WriteLine("Result is: {0}", triangleNumberTarget);
		}
	}
}
