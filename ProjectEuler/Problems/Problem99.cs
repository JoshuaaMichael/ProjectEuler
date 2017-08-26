using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;

namespace ProjectEuler.Problems
{
	class Problem99 : Problem
	{
		public override void Run()
		{
            string[] lines = File.ReadAllLines(@".\Resources\p099_base_exp.txt");

            List<Tuple<int, int>> combos = new List<Tuple<int, int>>();

            foreach(string line in lines)
            {
                string[] components = line.Split(',');
                int baseNum = int.Parse(components[0]);
                int expNum = int.Parse(components[1]);

                Tuple<int, int> combo = new Tuple<int, int>(baseNum, expNum);
                combos.Add(combo);
            }

            int largestLineNumber = 0;
            double maxValue = 0;
         

            for(int i = 1; i <= combos.Count; i++)
            {
                Console.WriteLine("i - {0}", i);
                Tuple<int, int> comboUnderTest = combos[i - 1];
                double result = comboUnderTest.Item2 * Math.Log(comboUnderTest.Item1); //a^b < x^y  ->  b*ln(a) > y*ln(x) (log rule)
                if (result > maxValue)
                {
                    maxValue = result;
                    largestLineNumber = i;
                }
            }

			Console.WriteLine("Result is: {0}", largestLineNumber);
		}
	}
}
