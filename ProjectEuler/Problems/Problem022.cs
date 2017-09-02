using System;
using ProjectEulerLibrary;
using System.Collections.Generic;
using System.Numerics;
using System.IO;

namespace ProjectEuler.Problems
{
	class Problem22 : Problem
	{
		public override void Run()
		{

            string data = File.ReadAllText("./Resources/p022_names.txt");
            data = data.Replace("\"", "");
            string[] lines = data.Split(',');
            List<string> names = new List<string>(lines);
            names.Sort();

            long total = 0;

            for(int i = 0; i < names.Count; i++)
            {
                string currentName = names[i];
                int temp = 0;
                for (int j = 0; j < currentName.Length; j++)
                {
                    temp += currentName[j] - 64;
                }
                temp *= i + 1;
                total += temp;
            }

            Console.WriteLine("Result is: {0}", total);
		}
	}
}
