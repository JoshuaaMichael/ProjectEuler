using System;
using System.Collections.Generic;
using JoshuaaM.PrimeSieve;
using System.Linq;
using System.Numerics;
using ProjectEulerLibrary;

namespace ProjectEuler.Problems
{
	class Problem68 : Problem
	{
        public override void Run()
        {
            List<List<int>> potentialSolutions = new List<List<int>>();

            for(int total = 6; total < 27; total++)
            {
                for(int a1 = 1; a1 <= 10; a1++)
                {
                    for (int a2 = 1; a2 <= 10; a2++)
                    {
                        int a3 = total - a1 - a2;
                        if (a3 < 1 || a3 > 10)
                            continue;

                        for (int a4 = 1; a4 <= 10; a4++)
                        {
                            int a5 = total - a3 - a4;
                            if (a5 < 1 || a5 > 10)
                                continue;

                            for (int a6 = 1; a6 <= 10; a6++)
                            {
                                int a7 = total - a6 - a5;
                                if (a7 < 1 || a7 > 10)
                                    continue;

                                for (int a8 = 1; a8 <= 10; a8++)
                                {
                                    int a9 = total - a8 - a7;
                                    if (a9 < 1 || a9 > 10)
                                        continue;
                                    int a10 = total - a9 - a2;
                                    if (a10 < 1 || a10 > 10)
                                        continue;

                                    int[] pS = new int[] { a1, a2, a3, a4, a5, a6, a7, a8, a9, a10 };

                                    if(!HasDuplicates(pS))
                                    {
                                        potentialSolutions.Add(new List<int>(pS));
                                    }
                                }
                            }
                        }
                    }
                }
            }

            List<string> results = new List<string>();

            foreach(List<int> pSol in potentialSolutions)
            {
                results.Add(GetDigitString(pSol));
            }

            results.Sort();

            Console.WriteLine("Result is: {0}", results[results.Count -1]);
        }

        private string GetDigitString(List<int> numbers)
        {
            int smallestIndex = 0;
            int smallestValue = numbers[0];
            for(int i = 3; i < numbers.Count; i+=2)
            {
                if(numbers[i] < smallestValue)
                {
                    smallestValue = numbers[i];
                    smallestIndex = i;
                }
            }

            string str1 = numbers[0].ToString() + numbers[1].ToString() + numbers[2].ToString();
            string str2 = numbers[3].ToString() + numbers[2].ToString() + numbers[4].ToString();
            string str3 = numbers[5].ToString() + numbers[4].ToString() + numbers[6].ToString();
            string str4 = numbers[7].ToString() + numbers[6].ToString() + numbers[8].ToString();
            string str5 = numbers[9].ToString() + numbers[8].ToString() + numbers[1].ToString();
            string result = "";

            if (smallestIndex == 0)
            {
                result = str1 + str2 + str3 + str4 + str5;
            }
            else if(smallestIndex == 3)
            {
                result = str2 + str3 + str4 + str5 + str1;
            }
            else if (smallestIndex == 5)
            {
                result = str3 + str4 + str5 + str1 + str2;
            }
            else if (smallestIndex == 7)
            {
                result = str4 + str5 + str1 + str2 + str3;
            }
            else if (smallestIndex == 9)
            {
                result = str5 + str1 + str2 + str3 + str4;
            }

            return result;
        }

        private bool HasDuplicates(int[] list)
        {
            HashSet<int> temp = new HashSet<int>();

            for(int i = 0; i < list.Length; i++)
            {
                if(temp.Contains(list[i]))
                {
                    return true;
                }
                temp.Add(list[i]);
            }

            return false;
        }
    }
}
