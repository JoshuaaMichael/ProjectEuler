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
    }
}
