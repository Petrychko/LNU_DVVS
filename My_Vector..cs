using System;
using System.Collections.Generic;
using System.Linq;


namespace calculator_1
{
    class My_Vector
    {
        private double x;
        private double y;
        private double z;

        public double X
        {
            set { x = value; }
            get { return x; }
        }

        public double Y
        {
            set { y = value; }
            get { return y; }
        }

        public double Z
        {
            set { z = value; }
            get { return z; }
        }

        public My_Vector()
        {
            X = 0;
            Y = 0;
            Z = 0;
        }
        public My_Vector(double x_1,double y_1, double z_1)
        {
            X = x_1;
            Y = y_1;
            Z = z_1;
        }
        public static My_Vector operator +(My_Vector a, My_Vector b)
        {
            return new My_Vector(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        public static My_Vector operator -(My_Vector a, My_Vector b)
        {
            return new My_Vector(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }

        public static My_Vector operator *(My_Vector a, double b)
        {
            return new My_Vector(a.X * b, a.Y * b, a.Z * b);
        }

        public static double operator *(My_Vector a, My_Vector b)
        {
            return (a.X*b.X+a.Y*b.Y+a.Z*b.Z)*Math.Cos(a.GetAngle(b));
        }

        public double GetNorm()
        {
            return Math.Sqrt(X*X+Y*Y+Z*Z);
        }

        public double GetAngle( My_Vector b)
        {
            return Math.Acos((X*b.X+Y * b.Y+Z*b.Z) / (GetNorm() * b.GetNorm()));
        }
        
        public static My_Vector operator ^(My_Vector a,My_Vector b)//векторне множення
        {
            return new My_Vector(a.Y *b.Z - a.Z *b.Y,a.Z*b.X*b.Z,a.X*b.Y-a.Y*b.X );
        }

        public My_Vector ProjectionX()
        {
            return new My_Vector(X, 0, 0);
        }

        public My_Vector ProjectionY()
        {
            return new My_Vector(0, Y, 0);
        }

        public My_Vector ProjectionZ()
        {
            return new My_Vector(0, 0, Z);
        }

        public override string ToString()
        {
            return (String.Format("({0}, {1}, {2})", X, Y, Z));
        }
    }

    static class VectorExtension
    {
        public static double MixedProduct(this My_Vector a, My_Vector b, My_Vector c)
        {
            return c*(a ^ b) ;
        }

        public static My_Vector Norming(this My_Vector a)
        {
            return a * (1.0/ a.GetNorm());
        }
    }
}
