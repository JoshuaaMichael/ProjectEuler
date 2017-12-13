using System;
using System.Collections.Generic;
using JoshuaaM.PrimeSieve;

namespace ProjectEuler.Problems
{
	class Problem315 : Problem
	{
		private Dictionary<int, Tuple<int, bool[]>> segmentLookup;
		public override void Run()
		{
			int[] primesGenerated = PrimeSieve.GeneratePrimesToMax(20000000, true);
			List<int> primes = new List<int>();
			for(int i = 0; i < primesGenerated.Length; i++)
			{
				if(primesGenerated[i] > 10000000)
				{
					primes.Add(primesGenerated[i]);
				}
			}

			segmentLookup = new Dictionary<int, Tuple<int, bool[]>>();

			segmentLookup.Add(0, new Tuple<int, bool[]>(6, new bool[] { true, true, true, true, true, true, false }));
			segmentLookup.Add(1, new Tuple<int, bool[]>(2, new bool[] { false, true, true, false, false, false, false }));
			segmentLookup.Add(2, new Tuple<int, bool[]>(5, new bool[] { true, true, false, true, true, false, true }));
			segmentLookup.Add(3, new Tuple<int, bool[]>(5, new bool[] { true, true, true, true, false, false, true }));
			segmentLookup.Add(4, new Tuple<int, bool[]>(4, new bool[] { false, true, true, false, false, true, true }));
			segmentLookup.Add(5, new Tuple<int, bool[]>(5, new bool[] { true, false, true, true, false, true, true }));
			segmentLookup.Add(6, new Tuple<int, bool[]>(6, new bool[] { true, false, true, true, true, true, true }));
			segmentLookup.Add(7, new Tuple<int, bool[]>(4, new bool[] { true, true, true, false, false, true, false }));
			segmentLookup.Add(8, new Tuple<int, bool[]>(7, new bool[] { true, true, true, true, true, true, true }));
			segmentLookup.Add(9, new Tuple<int, bool[]>(6, new bool[] { true, true, true, true, false, true, true }));

			long samCounter = 0, maxsCounter = 0;

			foreach(int prime in primes)
			{
				int lastNumber = 0;
				int digitalRoot = prime; //Default value to go in loop
				bool breakFlag = false;
				while (!breakFlag)
				{
					if(digitalRoot <= 9)
					{
						breakFlag = true;
					}

					samCounter += SamsClockCost(digitalRoot) * 2;
					maxsCounter += MaxsClockCost(digitalRoot, lastNumber);
					lastNumber = digitalRoot;

					digitalRoot = CalculateDigitalSum(digitalRoot);
				}
				maxsCounter += SamsClockCost(digitalRoot); //Turn the lights off on your way out
			}

			Console.WriteLine("Result is: {0}, {1}, diff: {2}", samCounter, maxsCounter, samCounter - maxsCounter);
		}

		private int CalculateDigitalSum(int num)
		{
			int root = 0;

			while (num != 0)
			{
				root += num % 10;
				num /= 10;
			}

			return root;				
		}

		private int SamsClockCost(int number)
		{
			int cost = 0;

			while (number != 0)
			{
				int lastDigit = number % 10;
				cost += segmentLookup[lastDigit].Item1;
				number /= 10;
			}

			return cost;
		}

		private int MaxsClockCost(int currentNumber, int lastNumber)
		{
			if(lastNumber == 0)
			{
				return SamsClockCost(currentNumber);
			}

			int cost = 0;

			while (lastNumber != 0)
			{
				int lastDigitCurrentNumber = currentNumber % 10; //The last digit in the current number
				int lastDigitLastNumber = lastNumber % 10; //The last digit in the last number
				if (currentNumber == 0)
				{
					cost += segmentLookup[lastDigitLastNumber].Item1; //This will turn off those lights
				}
				else
				{
					for (int i = 0; i < 7; i++)
					{
						cost += (segmentLookup[lastDigitCurrentNumber].Item2[i] ^ segmentLookup[lastDigitLastNumber].Item2[i]) ? 1 : 0;
					}
				}
				currentNumber /= 10;
				lastNumber /= 10;
			}

			return cost;
		}
	}
}
