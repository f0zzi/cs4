using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs4
{
    class Vector
    {
        public double x { get; set; }
        public double y { get; set; }
        public Vector(double x = 0, double y = 0) { this.x = x; this.y = y; }
        public override string ToString()
        {
            return $"X: {x} Y: {y}";
        }
        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.x + b.x, a.y + b.y);
        }
        public static Vector operator -(Vector a, Vector b)
        {
            return new Vector(a.x - b.x, a.y - b.y);
        }
        public static Vector operator *(Vector a, double number)
        {
            return new Vector(a.x * number, a.y * number);
        }
        public static Vector operator *(double number, Vector a)
        {
            return a * number;
        }
        public static double operator *(Vector a, Vector b)
        {
            return a.x * a.y + b.x * b.y;
        }
        public static implicit operator Vector(double number)
        {
            return new Vector(number, 0);
        }
        public static Vector operator ++(Vector a)
        {
            return new Vector(++a.x, ++a.y);
        }
        public static Vector operator --(Vector a)
        {
            return new Vector(--a.x, --a.y);
        }
        public static Vector operator -(Vector a)
        {
            return new Vector(-a.x, -a.y);
        }
        public double Length
        {
            get => Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
        }
        public static explicit operator double(Vector a)
        {
            return a.Length;
        }
        public static bool operator >(Vector a, Vector b)
        {
            return a.Length > b.Length;
        }
        public static bool operator <(Vector a, Vector b)
        {
            return a.Length < b.Length;
        }
        public static bool operator true(Vector a)
        {
            return (a.x != 0 && a.y != 0);
        }
        public static bool operator false(Vector a)
        {
            return (a.x == 0 && a.y == 0);
        }
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Vector))
                return false;
            if (this.x != ((Vector)obj).x)
                return false;
            return this.y == ((Vector)obj).y;
        }
        public override int GetHashCode()
        {
            return x.GetHashCode() ^ y.GetHashCode();
        }
        public static bool operator ==(Vector a, Vector b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if ((object)a == null)
                return false;
            return a.Equals(b);
        }
        public static bool operator !=(Vector a, Vector b)
        {
            return !(a == b);
        }
        public double this[int index]
        {
            get
            {
                if (index == 0 || index == 1)
                    return (index == 0 ? x : y);
                else
                    throw new IndexOutOfRangeException("Bad index: " + index);
            }
            set
            {
                switch (index)
                {
                    case 0:
                        x = value;
                        break;
                    case 1:
                        y = value;
                        break;
                    default:
                        throw new IndexOutOfRangeException("Bad index: " + index);
                }
            }
        }
    }
}
