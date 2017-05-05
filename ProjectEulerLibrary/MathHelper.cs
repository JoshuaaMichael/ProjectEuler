using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerLibrary
{
    public static class MathHelper
    {
        public static bool IsMultiple(int value, int multipleOf)
        {
            return (value % multipleOf == 0);
        }

        //https://www.khanacademy.org/math/pre-algebra/pre-algebra-factors-multiples/pre-algebra-prime-factorization-prealg/v/prime-factorization
        public static long MaxPrimeFactor(long value)
        {
            long k = 2;

            while(k * k <= value) 
            {
                if(value % k == 0)
                {
                    value /= k;
                }
                else
                {
                    ++k;
                }
            }

            return value;
        }
    }
}
