using System;
using BasicMath.Double.Linear;

namespace BasicMath.Double.Vector
{
    /// <summary>
    /// Representation of a three dimensional Vector using <see cref="double"/> values.
    /// </summary>
    [Serializable]
    public class Vec3d
    {
        /// <summary>
        /// The x coordinate of the current <see cref="Vec3d"/>.
        /// Forward direction.
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// The y coordinate of the current <see cref="Vec3d"/>.
        /// Left right-angled to forward direction.
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// The z coordinate of the current <see cref="Vec3d"/>.
        /// Upwards
        /// </summary>
        public double Z { get; set; }

        public double this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return X;
                    case 1:
                        return Y;
                    case 2:
                        return Z;
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
            set
            {
                switch (index)
                {
                    case 0:
                        X = value;
                        break;
                    case 1:
                        Y = value;
                        break;
                    case 2:
                        Z = value;
                        break;
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
        }

        /// <summary>
        /// Squared Length of this <see cref="Vec3d"/>.
        /// </summary>
        /// <returns>The squared length.</returns>
        public double SqrtLength => (this * this).Reduce;

        /// <summary>
        /// Length of this <see cref="Vec3d"/>.
        /// </summary>
        /// <returns>The length.</returns>
        public double Length => Math.Sqrt(SqrtLength);

        /// <summary>
        /// Normalize this <see cref="Vec3d"/>.
        /// </summary>
        /// <returns>The <see cref="Vec3d"/> 
        /// in the same direction but with the length of 1.</returns>
        public Vec3d Normalize => this / Length;

        /// <summary>
        /// Reduce the current vector to a <see cref="double"/> value by adding all components together.
        /// </summary>
        /// <returns></returns>
        public double Reduce => X + Y + Z;


        /// <summary>
        /// The zero Vector.
        /// </summary>
        public static Vec3d Zero => new Vec3d(0.0, 0.0, 0.0);

        /// <summary>
        /// The global up <see cref="Vec3d"/>
        /// </summary>
        public static Vec3d Up => new Vec3d(0.0, 0.0, 1.0);

        /// <summary>
        /// The global forward <see cref="Vector"/>
        /// </summary>
        public static Vec3d Forward => new Vec3d(1.0, 0.0, 0.0);

        /// <summary>
        /// The global left <see cref="Vec3d"/>
        /// </summary>
        public static Vec3d Left => new Vec3d(0.0, 1.0, 0.0);

        /// <summary>
        /// The global right <see cref="Vec3d"/>
        /// </summary>
        public static Vec3d Right => -Left;

        /// <summary>
        /// The global down <see cref="Vec3d"/>
        /// </summary>
        public static Vec3d Down => -Up;

        /// <summary>
        /// The global back <see cref="Vec3d"/>
        /// </summary>
        public static Vec3d Back => -Forward;

        /// <summary>
        /// The vector contains no valid values and should only be used as error output.
        /// See "<see cref="null"/>".
        /// </summary>
        public static Vec3d Error => new Vec3d(double.NaN, double.NaN, double.NaN);

        /// <summary>
        /// Initializes a new instance of the <see cref="Vec3d"/>.
        /// </summary>
        /// <param name="x">The x coordinate</param>
        /// <param name="y">The y coordinate</param>
        /// <param name="z">The z coordinate. Default value is 0</param>
        public Vec3d(double x, double y, double z = 0.0)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Computes the product of two Vectors, element by element.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vec3d operator *(Vec3d a, Vec3d b) => new Vec3d(a.X * b.X, a.Y * b.Y, a.Z * b.Z);

        /// <summary>
        /// Computes the product of the <see cref="Vec3d"/> <c>a</c> and 
        /// the <see cref="double"/> scalar <c>b</c>, yielding a new <see cref="Vec3d"/>.
        /// </summary>
        /// <param name="a">The <see cref="Vec3d"/> to multiply.</param>
        /// <param name="b">The <see cref="double"/> scalar to multiply.</param>
        /// <returns>The <see cref="Vec3d"/> that is the <c>a</c> * <c>b</c>.</returns>
        public static Vec3d operator *(Vec3d a, double b) => new Vec3d(a.X * b, a.Y * b, a.Z * b);

        /// <summary>
        /// Computes the product of the <see cref="double"/> scalar <c>a</c> and 
        /// the <see cref="Vector"/> <c>b</c>, yielding a new <see cref="Vector"/>.
        /// </summary>
        /// <param name="a">The <see cref="double"/> scalar to multiply.</param>
        /// <param name="b">The <see cref="Vec3d"/> to multiply.</param>
        /// <returns>The <see cref="Vec3d"/> that is the <c>a</c> * <c>b</c>.</returns>
        public static Vec3d operator *(double a, Vec3d b) => b * a;

        /// <summary>
        /// Computes the division of the <see cref="Vec3d"/> <c>a</c> and 
        /// the <see cref="double"/> scalar <c>b</c>, yielding a new <see cref="Vec3d"/>.
        /// </summary>
        /// <param name="a">The <see cref="Vec3d"/> to divide (the divident).</param>
        /// <param name="b">The <see cref="double"/> scalar to divide (the divisor).</param>
        /// <returns>The <see cref="Vec3d"/> that is the <c>a</c> / <c>b</c>.</returns>
        public static Vec3d operator /(Vec3d a, double b) => new Vec3d(a.X / b, a.Y / b, a.Z / b);

        /// <summary>
        /// Computes the division of the <see cref="double"/> scalar <c>a</c> and the
        /// <see cref="Vec3d"/> <c>b</c>, yielding a new <see cref="Vec3d"/>.
        /// </summary>
        /// <param name="a">The <see cref="double"/> scalar to divide (the divident).</param>
        /// <param name="b">The <see cref="Vec3d"/> to divide (the divisor).</param>
        /// <returns></returns>
        public static Vec3d operator /(double a, Vec3d b) => new Vec3d(a / b.X, a / b.Y, a / b.Z);

        /// <summary>
        /// Adds a <see cref="Vec3d"/> to a <see cref="Vec3d"/>, 
        /// yielding a new <see cref="Vec3d"/>.
        /// </summary>
        /// <param name="a">The first <see cref="Vec3d"/> to add.</param>
        /// <param name="b">The second <see cref="Vec3d"/> to add.</param>
        /// <c>a</c> and <c>b</c>.</returns>
        public static Vec3d operator +(Vec3d a, Vec3d b) => new Vec3d(a.X + b.X, a.Y + b.Y, a.Z + b.Z);

        /// <summary>
        /// Subtracts a <see cref="Vec3d"/> from a
        /// <see cref="Vec3d"/>, yielding a new <see cref="Vec3d"/>.
        /// </summary>
        /// <param name="a">The <see cref="Vec3d"/> to subtract from (the minuend).</param>
        /// <param name="b">The <see cref="Vec3d"/> to subtract (the subtrahend).</param>
        /// <returns>The <see cref="Vec3d"/> that is the <c>a</c> minus <c>b</c>.</returns>
        public static Vec3d operator -(Vec3d a, Vec3d b) => new Vec3d(a.X - b.X, a.Y - b.Y, a.Z - b.Z);

        /// <summary>
        /// Calculate the negative <see cref="Vec3d"/> by inverting every coordinate.
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Vec3d operator -(Vec3d a) => new Vec3d(-a.X, -a.Y, -a.Z);

        /// <summary>
        /// The Identity of the <see cref="Vec3d"/>.
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Vec3d operator +(Vec3d a) => a;

        /// <summary>
        /// Determines whether a specified instance of <see cref="Vec3d"/> is equal to
        /// another specified <see cref="Vec3d"/>.
        /// </summary>
        /// <param name="a">The first <see cref="Vec3d"/> to compare.</param>
        /// <param name="b">The second <see cref="Vec3d"/> to compare.</param>
        /// <returns><c>true</c> if <c>a</c> and <c>b</c> are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(Vec3d a, Vec3d b)
        {
            if (a is null || b is null)
            {
                return false;
            }
            return a.Equals(b);
        }

        /// <summary>
        /// Determines whether a specified instance of <see cref="Vec3d"/> is not equal
        /// to another specified <see cref="Vec3d"/>.
        /// </summary>
        /// <param name="a">The first <see cref="Vec3d"/> to compare.</param>
        /// <param name="b">The second <see cref="Vec3d"/> to compare.</param>
        /// <returns><c>true</c> if <c>a</c> and <c>b</c> are not equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(Vec3d a, Vec3d b)
        {
            if (a is null || b is null)
            {
                return false;
            }
            return !a.Equals(b);
        }

        public static bool operator <(Vec3d a, Vec3d b) => a.SqrtLength < b.SqrtLength;

        public static bool operator >(Vec3d a, Vec3d b) => a.SqrtLength > b.SqrtLength;

        public static bool operator <(Vec3d a, double b) => a.SqrtLength < (b * b);

        public static bool operator <(double a, Vec3d b) => (a * a) < b.SqrtLength;

        public static bool operator >(Vec3d a, double b) => a.SqrtLength > (b * b);

        public static bool operator >(double a, Vec3d b) => (a * a) > b.SqrtLength;

        public static bool operator <=(Vec3d a, Vec3d b) => a.SqrtLength <= b.SqrtLength;

        public static bool operator >=(Vec3d a, Vec3d b) => a.SqrtLength >= b.SqrtLength;

        public static bool operator <=(Vec3d a, double b) => a.SqrtLength <= (b * b);

        public static bool operator <=(double a, Vec3d b) => (a * a) <= b.SqrtLength;

        public static bool operator >=(Vec3d a, double b) => a.SqrtLength >= (b * b);

        public static bool operator >=(double a, Vec3d b) => (a * a) >= b.SqrtLength;

        /// <summary>
        /// Center <see cref="Vec3d"/> between two <see cref="Vec3d"/>.
        /// </summary>
        /// <returns>The center point.</returns>
        /// <param name="a">Vector a.</param>
        /// <param name="b">Vector b.</param>
        public static Vec3d Center(Vec3d a, Vec3d b) => (a + b) * 0.5;

        /// <summary>
        /// Returns the center <see cref="Vec3d"/> between 
        /// the current <see cref="Vec3d"/> and 
        /// another <see cref="Vec3d"/> B.
        /// </summary>
        /// <returns>The center point.</returns>
        /// <param name="b">Vector b.</param>
        public Vec3d Center(Vec3d b) => Center(this, b);

        /// <summary>
        /// Returns the <see cref="double"/> distance between two <see cref="Vec3d"/>.
        /// </summary>
        /// <returns>The distance.</returns>
        /// <param name="a">Start vector a.</param>
        /// <param name="b">End vector b.</param>
		public static double Distance(Vec3d a, Vec3d b) => (a - b).Length;

        /// <summary>
        /// Returns the <see cref="double"/> distance between this and another <see cref="Vec3d"/>
        /// </summary>
        /// <returns>The distance.</returns>
        /// <param name="b">End vector b.</param>
        public double Distance(Vec3d pointB) => Distance(this, pointB);

        /// <summary>
        /// Computes the dot product of the <see cref="Vec3d"/> <c>a</c> 
        /// and the <see cref="Vec3d"/> <c>b</c>, yielding 
        /// a new <see cref="Vec3d"/>.
        /// </summary>
        /// <returns>The <see cref="Vec3d"/> that is the <c>a</c> * <c>b</c>.</returns>
        /// <param name="a">The <see cref="Vec3d"/> to multiply.</param>
        /// <param name="b">The <see cref="Vec3d"/> to multiply.</param>
		public static double Dot(Vec3d a, Vec3d b) => (a * b).Reduce;

        /// <summary>
        /// Computes the dot product of this <see cref="Vec3d"/> 
        /// and the <see cref="Vec3d"/> <c>b</c>, yielding 
        /// a new <see cref="Vec3d"/>.
        /// </summary>
        /// <returns>The <see cref="Vec3d"/> that is this * <c>b</c>.</returns>
        /// <param name="b">The <see cref="Vec3d"/> to multiply.</param>
        public double Dot(Vec3d b) => Dot(this, b);

        /// <summary>
        /// Computes the cross product of the <see cref="Vec3d"/> <c>a</c> 
        /// and the <see cref="Vec3d"/> <c>b</c>, yielding 
        /// a new <see cref="Vec3d"/>.
        /// </summary>
        /// <returns>The <see cref="Vec3d"/> that is the <c>a</c> x <c>b</c>.</returns>
        /// <param name="b">The second <see cref="Vec3d"/> to multiply.</param>
        public static Vec3d Cross(Vec3d a, Vec3d b) => new Vec3d(a.Y * b.Z - a.Z * b.Y, a.Z * b.X - a.X * b.Z, a.X * b.Y - a.Y * b.X);

        /// <summary>
        /// Computes the cross product of this <see cref="Vec3d"/> 
        /// and the <see cref="Vec3d"/> <c>b</c>, yielding 
        /// a new <see cref="Vec3d"/>.
        /// </summary>
        /// <returns>The <see cref="Vec3d"/> that is this x <c>b</c>.</returns>
        /// <param name="a">The first <see cref="Vec3d"/> to multiply.</param>
        /// <param name="b">The second <see cref="Vec3d"/> to multiply.</param>
        public Vec3d Cross(Vec3d b) => Cross(this, b);

        /// <summary>
        /// Determine the angle between two <see cref="Vec3d"/>.
        /// </summary>
        /// <returns>The angle.</returns>
        /// <param name="from">From <see cref="Vec3d"/>.</param>
        /// <param name="to">To <see cref="Vec3d"/>.</param>
        public static double Angle(Vec3d from, Vec3d to)
        {
            double denominator = Math.Sqrt(from.SqrtLength * to.SqrtLength);
            if (denominator < 0.1f)
                return 0F;
            double dot = Dot(from, to) / denominator;
            if (dot < -1.0)
                dot = -1.0;
            if (dot > 1.0)
                dot = 1.0;
            return (Math.Acos(dot) * 1.0 / (Math.PI * 2.0 / 360.0));
        }

        /// <summary>
        /// Determine the signed angle between two <see cref="Vec3d"/>.
        /// </summary>
        /// <returns>The signed angle.</returns>
        /// <param name="from">From <see cref="Vec3d"/>.</param>
        /// <param name="to">To <see cref="Vec3d"/>.</param>
        /// <param name="axis">Axis <see cref="Vec3d"/>.</param>
        public static double SignedAngle(Vec3d from, Vec3d to, Vec3d axis) => Angle(from, to) * Dot(axis, Cross(from, to)) >= 0.0 ? 1.0 : -1.0;

        public static Vec3d Lerp(Vec3d from, Vec3d to, double value) => new Vec3d(
            Utility.Lerp(from.X, to.X, value),
            Utility.Lerp(from.Y, to.Y, value),
            Utility.Lerp(from.Z, to.Z, value)
            );

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to 
        /// the current <see cref="Vec3d"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with 
        /// the current <see cref="Vec3d"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="object"/> is equal to the current
        /// <see cref="Vec3d"/>; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is Vec3d))
                return false;
            Vec3d b = (Vec3d)obj;
            return
                (X == b.X || (double.IsNaN(X) && double.IsNaN(b.X))) &&
                (Y == b.Y || (double.IsNaN(Y) && double.IsNaN(b.Y))) &&
                (Z == b.Z || (double.IsNaN(Z) && double.IsNaN(b.Z)));
        }

        /// <summary>
        /// Serves as a hash function for a <see cref="Vector"/> object.
        /// </summary>
        /// <returns>A hash code for this instance that is suitable for use in hashing algorithms and data structures such as a
        /// hash table.</returns>
        public override int GetHashCode() => base.GetHashCode();

        /// <summary>
        /// Generate a <see cref="string"/> which represents the class and the current values.
        /// </summary>
        /// <returns><see cref="string"/> which represents the class and the current values.</returns>
        public override string ToString() => "Si3mulator.Essentials.Geometry " + ToShortString();

        public string ToShortString() => "[" + X + ", " + Y + ", " + Z + "]";

        public bool Intersect2DQuadrant(Vec3d point, byte quadrant)
        {
            switch (quadrant)
            {
                case 1:
                    return X > point.X && Y < point.Y;
                case 2:
                    return X < point.X && Y < point.Y;
                case 3:
                    return X < point.X && Y > point.Y;
                case 4:
                    return X > point.X && Y > point.Y;
                default:
                    return false;
            }
        }
    }
}
