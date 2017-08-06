using ProjectEulerLibrary;
using System;
using System.Collections.Generic;

namespace ProjectEuler.Problems
{
	class Problem32 : Problem
	{
        public override void Run()
        {
            HashSet<int> products = new HashSet<int>();
            int total = 0;

            for (int a = 0; a < 2000; a++)
            {
                //Originally showed 5000 was larger than possible highest multiplicand. Reduced for performance after first run.
                for (int b = 0; b <= a; b++)
                {
                    string temp = a.ToString() + b.ToString() + (a * b).ToString() + "";

                    if (temp.Length == 9 && MathHelper.IsPandigital(temp))
                    {
                        if (!products.Contains(a * b))
                        {
                            products.Add(a * b);
                            total += a * b;
                            Console.WriteLine("Case: {0} * {1} = {2}", a, b, a * b);
                        }
                    }
                }
            }

            Console.WriteLine("Result is: {0}", total);
        }

    }
}
