using ProjectEulerLibrary;
using System;
using System.Collections.Generic;

namespace ProjectEuler.Problems
{
	class Problem39 : Problem
	{
        public override void Run()
        {
            int winnerValue = 0;
            int winner = 3;

            for (int i = winner; i <= 1000; i++)
            {
                int temp = FindCountSolutionsForTriangle(i);
                if (temp > winnerValue) {
                    winnerValue = temp;
                    winner = i;
                }
            }

            Console.WriteLine("Result is: {0}", winner);
        }

        private int FindCountSolutionsForTriangle(int p)
        {
            List<List<int>> results = new List<List<int>>();
            int countOfResults = 0;

            for (int a = 1; a <= (p - 2) ; a++)
            {
                for (int b = 1; (a + b + 1 <= p) ; b++)
                {
                    for (int c = 1; (a + b + c <= p) ; c++)
                    {
                        if (a + b + c == p && IsRightAngledTriangle(a, b, c))
                        {
                            List<int> tempArray = new List<int>(new int[] { a, b, c });
                            tempArray.Sort();
                            bool found = false;
                            for (int i = 0; i < results.Count; i++)
                            {
                                if ((results[i][0] == tempArray[0]) &&
                                      (results[i][1] == tempArray[1]) &&
                                      (results[i][2] == tempArray[2]))
                                {
                                    found = true;
                                    break;
                                }
                            }

                            if (!found) {
                                countOfResults++;       
                                results.Add(tempArray);
                            }
                        }
                    }
                }
            }

            return countOfResults;
        }

        private bool IsRightAngledTriangle(int a, int b, int c)
        {
            if (a * a + b * b == c * c) { return true; }
            if (b * b + c * c == a * a) { return true; }
            if (c * c + a * a == b * b) { return true; }

            return false;
        }
    }
}
