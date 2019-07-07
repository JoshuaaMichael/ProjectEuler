using ProjectEulerLibrary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler.Problems
{
    internal class Problem75 : Problem
	{
        //  https://en.wikipedia.org/wiki/Pythagorean_triple#Generating_a_triple

        private const int MaxL = 1500000;
	    private Dictionary<int, int> _map;

        public override void Run()
        {
            _map = new Dictionary<int, int>();

            //  Solving quadratic: 2*m*(m+1) < MaxL
            int maxM = (int)Math.Ceiling(0.5 * (-1 + Math.Sqrt(1 + 2 * MaxL)));

            for (int m = 1; m < maxM; m++)   
            {
                for (int n = 1; n < m; n++)
                {
                    //  Both not odd
                    if(m % 2 == 1 && n % 2 == 1) continue;
                    //  Coprime
                    if (MathHelper.GreatestCommonDenominator(m, n) != 1) continue;

                    // a + b + c
                    int abc = 2 * m * (m + n);

                    for (int k = 1; k*abc < MaxL; k++)
                    {
                        AddOrIncr(k*abc);
                    }
                }
            }

            Console.WriteLine("Result is: {0}", _map.Count(x => x.Value == 1));
        }

	    private void AddOrIncr(int l)
	    {
            if (_map.ContainsKey(l))
	        {
	            _map[l]++;
	        }
	        else
	        {
                _map.Add(l, 1);
	        }
	    }
    }
}
