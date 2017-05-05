using System;
using ProjectEulerLibrary;
using System.Collections.Generic;

namespace ProjectEuler.Problems
{
    class Problem3 : Problem
    {
        public override void Run()
        {

            long maxPrime = MathHelper.MaxPrimeFactor(600851475143);

            Console.WriteLine("Result is: {0}", maxPrime);
        }
    }
}
