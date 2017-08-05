using System;

namespace ProjectEuler.Problems
{
	class Problem31 : Problem
	{
        public override void Run()
        {
            //1p, 2p, 5p, 10p, 20p, 50p, £1 (100p) and £2 (200p).
            int count = 1; //1 for 2pound by itself

            for (int b = 0; b <= 2; b++) //1 pound
            {
                for (int c = 0; c <= 4; c++) //50 pence
                {
                    for (int d = 0; d <= 10; d++) //20 pence
                    {
                        for (int e = 0; e <= 20; e++) //10 pence
                        {
                            for (int f = 0; f <= 40; f++) //5 pence
                            {
                                for (int g = 0; g <= 100; g++) //2 pence
                                {
                                    for (int h = 0; h <= 200; h++) //1 pence
                                    {
                                        int totalPence = 0;
                                        totalPence += b * 100;
                                        totalPence += c * 50;
                                        totalPence += d * 20;
                                        totalPence += e * 10;
                                        totalPence += f * 5;
                                        totalPence += g * 2;
                                        totalPence += h * 1;

                                        if (totalPence == 200)
                                        {
                                            count += 1;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine("Result is: {0}", count);
        }
    }
}
