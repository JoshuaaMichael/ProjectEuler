using System;
using ProjectEulerLibrary;
using System.Collections.Generic;

namespace ProjectEuler.Problems
{
	class Problem41 : Problem
	{
        public override void Run()
        {
            //(9+8+7+6+5+4+3+2+1 = 45), since divisable by 3, not going to check
            //8, not worth checking
            //7 can be checked
            //6,5 not worth checking
            //4, worth checking
            //3 not worth checking

            // list of 1-7

            List<int> options = new List<int>();
            List<int> results = new List<int>();

            for (int i = 1; i <= 7; i++)
            {
                options.Add(i);
            }

            GeneratePermutations(0, options, results);

            for(int i = results.Count - 1; i >= 0; i--)
            {
                if(MathHelper.IsPrime(results[i]))
                {
                    Console.WriteLine("Result is: {0}", results[i]);
                    break;
                }
            }
        }

        private void GeneratePermutations(int number, List<int> options, List<int> results)
        {
            if(options.Count == 0)
            {
                results.Add(number);
                return;
            }

            for (int i = 0; i < options.Count; i++)
            {
                List<int> tempOptionsList = new List<int>(options);
                int tempInt = tempOptionsList[i];
                tempOptionsList.RemoveAt(i);
                GeneratePermutations(10 * number + tempInt, tempOptionsList, results);
            }
        }
    }
}
