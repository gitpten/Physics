using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physics
{
    class Ball: MT
    {
        Graphics g;
        public Ball(Graphics g, double m, double d) : base(m)
        {
            this.g = g;
            this.d = d;
            A = new Vector(0, 0);
            RV = new Vector(0, 0);
            V = new Vector(0, 0);
        }

        public double d { get; set; }

            public bool Collision(Ball b2)
            {
                if ((this.RV - b2.RV).Length > this.d / 2 + b2.d / 2)
                    return false;

                double m1 = this.M;
                double m2 = b2.M;
                Vector v1 = new Vector(this.V.X, this.V.Y);
                Vector v2 = new Vector(b2.V.X, b2.V.Y);
                Vector XE = (this.RV - b2.RV).E;

                Vector v1X = v1.Proection(XE);
                Vector v2X = v2.Proection(XE);
                Vector v1Y = v1 - v1X;
                Vector v2Y = v2 - v2X;

                Vector u1X = (m1 - m2) / (m1 + m2) * v1X + 2 * m2 / (m1 + m2) * v2X;
                Vector u2X = v1X - v2X + u1X;

                this.V = u1X + v1Y;
                b2.V = u2X + v2Y;

                return true;
            }

        public void Bounce(Point[] barrier)
        {
            if (barrier.Length < 2) return;

            Vector closestPoint = ClosestPoint(barrier);
            Vector closestEdje = ClosestEdje(barrier);
            Vector closest;
            if (closestEdje == null)
            {
                closest = closestPoint;
            }
            else
            {
                closest = closestPoint < closestEdje ? closestPoint : closestEdje;
            }

            if (closest < new Vector(d, 0))
            {
                V = V.Mirror(closest.Norm);
            }
        }

        private Vector ClosestEdje(Point[] barrier)
        {
            if (barrier.Length < 2) return null;

            Vector min = null;
            for (int i = 1; i < barrier.Length; i++)
            {
                Vector v = Height(barrier[i - 1], barrier[i]);
                

                if (v != null && (min == null || (min > v)))
                {
                    min = v;
                }
            }
            Vector vv = Height(barrier[barrier.Length-1], barrier[0]);
            if (vv == null)
                return min;

            if (min == null)
                return vv;

            return min < vv ? min : vv;
        }

        private Vector Height(Point p1, Point p2)
        {
            Vector pp = new Vector(p1, p2);

            if ((RV - new Vector(p1)).Proection(pp) > pp || (RV - new Vector(p2)).Proection(pp) > pp) return null;

            return (new Vector(p1)-RV).Proection(pp.Norm);
        }

        private Vector ClosestPoint(Point[] barrier)
        {
            Vector min = new Vector(barrier[0]) - RV;


            foreach (var item in barrier)
            {
                Vector v = new Vector(item) - RV;
                
                if (v < min) min = v;
            }
            return min;
        }
    }
}
