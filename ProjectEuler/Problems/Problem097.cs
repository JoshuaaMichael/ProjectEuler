using System;
using System.Collections.Generic;
using JoshuaaM.PrimeSieve;
using System.Linq;
using System.Numerics;

namespace ProjectEuler.Problems
{
	class Problem97 : Problem
	{
        public override void Run()
        {
            List<int> powersOfTwo = new List<int>();

            for(int i = 0; ; i++)
            {
                int temp = (int)Math.Pow(2, i);
                if(temp > 7830457)
                {
                    break;
                }
                powersOfTwo.Add(temp);
            }

            int currentValue = 7830457;
            List<int> chops = new List<int>();
            for(int i = powersOfTwo.Count - 1; i >= 0; i--)
            {
                if(currentValue - powersOfTwo[i]  >= 0)
                {
                    currentValue = currentValue - powersOfTwo[i];
                    chops.Add(i);
                }
            }

            BigInteger target = new BigInteger(1);

            for (int i = 0; i < chops.Count; i++)
            {
                target *= BigInteger.Pow(2, powersOfTwo[chops[i]]);
                if (target > 10000000000) //Without this, will not return, need to work on smaller numbers
                {
                    target %= 10000000000;
                }
            }

            target = (target * 28433) + 1;
            target %= 10000000000;



            Console.WriteLine("Result is: {0}", target);
        }
    }
}
