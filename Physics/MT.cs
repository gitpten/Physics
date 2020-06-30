using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physics
{
    class MT
    {
        public MT(double m)
        {
            M = m;
        }

        public double M { get; set; }
        public Vector V { get; set; }
        public Vector A { get; set; }
        public Vector RV { get; set; }
    }
}
