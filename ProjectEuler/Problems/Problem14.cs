using System;
using ProjectEulerLibrary;
using System.Collections.Generic;
using System.Numerics;

namespace ProjectEuler.Problems
{
	class Problem14 : Problem
	{
		public override void Run()
		{
			int largestChainLength = 0;
			int targetStartNumber = 0;

			for (int i = 1; i < 1000000 ; i++)
			{
				int chainLength = MathHelper.CollatzSequenceChainCount(i);
				if (chainLength > largestChainLength)
				{
					largestChainLength = chainLength;
					targetStartNumber = i;
				}
			}

			Console.WriteLine("Result is: {0}", targetStartNumber);
		}
	}
}
