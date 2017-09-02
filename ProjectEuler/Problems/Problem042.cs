using ProjectEulerLibrary;
using System;
using System.Collections.Generic;
using System.IO;

namespace ProjectEuler.Problems
{
	class Problem42 : Problem
	{
        public override void Run()
        {
            string data = File.ReadAllText("./Resources/p042_words.txt");
            data = data.Replace("\"", "");
            string[] lines = data.Split(',');
            List<string> words = new List<string>(lines);

            int count = 0;

            for(int i = 0; i < words.Count; i++)
            {
                int temp = 0;
                for (int j = 0; j < words[i].Length; j++)
                {
                    temp += words[i][j] - 64;
                }

                if(MathHelper.IsTriangle(temp))
                {
                    count++;
                }
            }

            Console.WriteLine("Result is: {0}", count);
        }
    }
}
