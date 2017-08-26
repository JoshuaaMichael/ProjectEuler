using System;
using System.Numerics;
using ProjectEulerLibrary;
using System.IO;

namespace ProjectEuler.Problems
{
	class Problem79 : Problem
	{
        public override void Run()
        {
            string[] rules = File.ReadAllLines(@".\Resources\p079_keylog.txt");
            int i = 0;
            for (i = 10000000; i < 99999999; i++)
            {
                if (PassesAllRules(i.ToString(), rules))
                {
                    break;
                }
            }

            Console.WriteLine("Result is: {0}", i);
        }

        private bool PassesAllRules(string value, string[] rules)
        {
            //Doesn't need to contain 4 or 5

            for(int i = 0; i <= 9; i++)
            {
                if(i == 4 || i == 5)
                {
                    continue;
                }
                if(value.IndexOf(i.ToString()) == -1)
                {
                    return false;
                }
            }

            foreach(string str in rules)
            {
                int firstIndex = value.IndexOf(str[0]);
                int secondIndex = value.IndexOf(str[1]);
                int thirdIndex = value.IndexOf(str[2]);

                if(secondIndex < firstIndex || thirdIndex < secondIndex)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
