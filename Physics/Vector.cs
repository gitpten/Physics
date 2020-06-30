using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physics
{
    public class Vector : IComparable<Vector>,IComparer<Vector>
    {
        public Vector(double x, double y)
        {
            X = x;
            Y = y;
        }

        public Vector(Point p1, Point p2)
        {
            X = p2.X - p1.X;
            Y = p2.Y - p1.Y;
        }

        public Vector(Point p)
        {
            X = p.X; Y = p.Y;
        }

        public double X { get; set; }
        public double Y { get; set; }

        public double Length
        {
            get { return Math.Sqrt(X * X + Y * Y); }

        }

        public double SquareLength
        {
            get { return X * X + Y * Y; }

        }

        public Vector E
        {
            get
            {
                return this / Length;
            }
        }

        public Vector Norm
        {
            get
            {
                return new Vector(-Y, X);
            }
        }

        public Point ToPoint()
        {
            return new Point((int)X, (int)Y);
        }

        public static double operator *(Vector v1, Vector v2)
        {
            return v1.X * v2.X + v1.Y * v2.Y;
        }

        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(v1.X + v2.X, v1.Y + v2.Y);
        }

        public static Point operator +(Point p, Vector v)
        {
            return new Point((int)(p.X + v.X), (int)(p.Y + v.Y));
        }

        public static Point operator +(Vector v, Point p)
        {
            return p + v;
        }
        public static Vector operator -(Vector v1, Vector v2)
        {
            return v1 + -v2;
        }

        public static Vector operator -(Vector v)
        {
            return -1 * v;
        }


        public static Vector operator *(Vector v1, double n)
        {
            return new Vector(v1.X * n, v1.Y * n);
        }

        public static Vector operator /(Vector v, double n)
        {
            return v * (1 / n);
        }

        public static Vector operator *(double n, Vector v1)
        {
            return v1 * n;
        }

        public static bool operator >(Vector v1, Vector v2) => v1.SquareLength > v2.SquareLength;
        public static bool operator <(Vector v1, Vector v2) => v1.SquareLength < v2.SquareLength;
        public static bool operator <=(Vector v1, Vector v2) => v1.SquareLength <= v2.SquareLength;
        public static bool operator >=(Vector v1, Vector v2) => v1.SquareLength >= v2.SquareLength;
 //       public static bool operator ==(Vector v1, Vector v2) => v1.SquareLength == v2.SquareLength;
  //      public static bool operator !=(Vector v1, Vector v2) => !(v1 == v2);


        public Vector Proection(Vector OnVector)
        {
            return (this * OnVector) / (OnVector * OnVector) * OnVector;
        }

        public Vector Mirror(Vector onVector)
        {
            return this - 2 * this.Proection(onVector.Norm);
        }

        public void Draw(Graphics g, Pen pen, Point p1)
        {
            int h = 7; int w = 3;
            Point p2 = p1 + this;
            g.DrawLine(pen, p1, p2);
            Vector e = -this.E;
            g.DrawLine(pen, p2, p2 + (e * h + e.Norm * w));
            g.DrawLine(pen, p2, p2 + (e * h - e.Norm * w));
        }

        public int CompareTo(Vector other)
        {
            return SquareLength.CompareTo(other.SquareLength);
        }

        public int Compare(Vector x, Vector y)
        {
            if (x.SquareLength > y.SquareLength)
            {
                return 1;
            }
            else if (x.SquareLength < y.SquareLength)
            {
                return -1;
            }
            else return 0;
        }
    }
}
