using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public abstract class Problem
    {
        public virtual void Setup() { }
        public abstract void Run();
        public virtual void Cleanup() { }
    }
}
