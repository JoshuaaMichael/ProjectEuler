using ProjectEulerLibrary;
using System;
using System.Collections.Generic;

namespace ProjectEuler.Problems
{
	class Problem43 : Problem
	{
        public override void Run()
        {
            // loop through second 999,999 (6 digits)
            List<long> firstSemiFinals = new List<long>();
            for (int i = 102345; i <= 987654; i++)
            {
                int test17 = (i % 1000); //102345->345
                if (test17 % 17 != 0)
                {
                    continue;
                }

                int test13 = (i % 10000) / 10; //102357->235
                if (test13 % 13 != 0)
                {
                    continue;
                }

                int test11 = (i % 100000) / 100; //102476->24
                if (test11 % 11 != 0)
                {
                    continue;
                }

                int test7 = i / 1000; //104425->104
                if (test7 % 7 != 0)
                {
                    continue;
                }

                //Checking correct arithmetic 102345->
                //d4d5d6=635 is divisible by 5
                //Since we're here at the moment, we can do this test
                int test5 = (i / 10000) % 10;
                if (test5 % 5 != 0)
                {
                    continue;
                }

                firstSemiFinals.Add(i);
            }

            // loop through first 999,999 (6 digits)
            List<long> secondSemiFinals = new List<long>();
            for (int i = 102345; i <= 987654; i++)
            {
                int test5 = (i % 1000); //102345->345
                if (test5 % 5 != 0)
                {
                    continue;
                }

                int test3 = (i % 10000) / 10; //102345->234
                if (test3 % 3 != 0)
                {
                    continue;
                }

                int test2 = (i % 100000) / 100; //102345->23
                if (test2 % 2 != 0)
                {
                    continue;
                }

                secondSemiFinals.Add(i);
            }

            List<long> finals = new List<long>();

            foreach(long firstHalf in secondSemiFinals)
            {
                foreach (long secondHalf in firstSemiFinals)
                {
                    if(firstHalf % 100 == secondHalf / 10000)
                    {
                        finals.Add((firstHalf / 100) * 1000000 + secondHalf);
                    }
                }
            }

            List<long> winners = new List<long>();
            long sum = 0;
            foreach(long panDigitalToTest in finals)
            {
                if(MathHelper.IsPandigital10DigitNum(panDigitalToTest + ""))
                {
                    winners.Add(panDigitalToTest);
                    sum += panDigitalToTest;
                }
            }

            Console.WriteLine("Result is: {0}", sum);
        }
    }
}
