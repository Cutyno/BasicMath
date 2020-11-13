using System;
using BasicMath.Single.Linear;

namespace BasicMath.Single.Vector
{
    /// <summary>
    /// Representation of a three dimensional Vector using <see cref="float"/> values.
    /// </summary>
    [Serializable]
    public class Vec3f
    {
        /// <summary>
        /// The x coordinate of the current <see cref="Vec3f"/>.
        /// Forward direction.
        /// </summary>
        public float X { get; set; }

        /// <summary>
        /// The y coordinate of the current <see cref="Vec3f"/>.
        /// Left right-angled to forward direction.
        /// </summary>
        public float Y { get; set; }

        /// <summary>
        /// The z coordinate of the current <see cref="Vec3f"/>.
        /// Upwards
        /// </summary>
        public float Z { get; set; }

        public float this[int index]
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
        /// Squared Length of this <see cref="Vec3f"/>.
        /// </summary>
        /// <returns>The squared length.</returns>
        public float SqrtLength => (this * this).Reduce;

        /// <summary>
        /// Length of this <see cref="Vec3f"/>.
        /// </summary>
        /// <returns>The length.</returns>
        public float Length => MathF.Sqrt(SqrtLength);

        /// <summary>
        /// Normalize this <see cref="Vec3f"/>.
        /// </summary>
        /// <returns>The <see cref="Vec3f"/> 
        /// in the same direction but with the length of 1.</returns>
        public Vec3f Normalize => this / Length;

        /// <summary>
        /// Reduce the current vector to a <see cref="float"/> value by adding all components together.
        /// </summary>
        /// <returns></returns>
        public float Reduce => X + Y + Z;


        /// <summary>
        /// The zero Vector.
        /// </summary>
        public static Vec3f Zero => new Vec3f(0.0f, 0.0f, 0.0f);

        /// <summary>
        /// The global up <see cref="Vec3f"/>
        /// </summary>
        public static Vec3f Up => new Vec3f(0.0f, 0.0f, 1.0f);

        /// <summary>
        /// The global forward <see cref="Vector"/>
        /// </summary>
        public static Vec3f Forward => new Vec3f(1.0f, 0.0f, 0.0f);

        /// <summary>
        /// The global left <see cref="Vec3f"/>
        /// </summary>
        public static Vec3f Left => new Vec3f(0.0f, 1.0f, 0.0f);

        /// <summary>
        /// The global right <see cref="Vec3f"/>
        /// </summary>
        public static Vec3f Right => -Left;

        /// <summary>
        /// The global down <see cref="Vec3f"/>
        /// </summary>
        public static Vec3f Down => -Up;

        /// <summary>
        /// The global back <see cref="Vec3f"/>
        /// </summary>
        public static Vec3f Back => -Forward;

        /// <summary>
        /// The vector contains no valid values and should only be used as error output.
        /// See "<see cref="null"/>".
        /// </summary>
        public static Vec3f Error => new Vec3f(float.NaN, float.NaN, float.NaN);

        /// <summary>
        /// Initializes a new instance of the <see cref="Vec3f"/>.
        /// </summary>
        /// <param name="x">The x coordinate</param>
        /// <param name="y">The y coordinate</param>
        /// <param name="z">The z coordinate. Default value is 0</param>
        public Vec3f(float x, float y, float z = 0.0f)
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
        public static Vec3f operator *(Vec3f a, Vec3f b) => new Vec3f(a.X * b.X, a.Y * b.Y, a.Z * b.Z);

        /// <summary>
        /// Computes the product of the <see cref="Vec3f"/> <c>a</c> and 
        /// the <see cref="float"/> scalar <c>b</c>, yielding a new <see cref="Vec3f"/>.
        /// </summary>
        /// <param name="a">The <see cref="Vec3f"/> to multiply.</param>
        /// <param name="b">The <see cref="float"/> scalar to multiply.</param>
        /// <returns>The <see cref="Vec3f"/> that is the <c>a</c> * <c>b</c>.</returns>
        public static Vec3f operator *(Vec3f a, float b) => new Vec3f(a.X * b, a.Y * b, a.Z * b);

        /// <summary>
        /// Computes the product of the <see cref="float"/> scalar <c>a</c> and 
        /// the <see cref="Vector"/> <c>b</c>, yielding a new <see cref="Vector"/>.
        /// </summary>
        /// <param name="a">The <see cref="float"/> scalar to multiply.</param>
        /// <param name="b">The <see cref="Vec3f"/> to multiply.</param>
        /// <returns>The <see cref="Vec3f"/> that is the <c>a</c> * <c>b</c>.</returns>
        public static Vec3f operator *(float a, Vec3f b) => b * a;

        /// <summary>
        /// Computes the division of the <see cref="Vec3f"/> <c>a</c> and 
        /// the <see cref="float"/> scalar <c>b</c>, yielding a new <see cref="Vec3f"/>.
        /// </summary>
        /// <param name="a">The <see cref="Vec3f"/> to divide (the divident).</param>
        /// <param name="b">The <see cref="float"/> scalar to divide (the divisor).</param>
        /// <returns>The <see cref="Vec3f"/> that is the <c>a</c> / <c>b</c>.</returns>
        public static Vec3f operator /(Vec3f a, float b) => new Vec3f(a.X / b, a.Y / b, a.Z / b);

        /// <summary>
        /// Computes the division of the <see cref="float"/> scalar <c>a</c> and the
        /// <see cref="Vec3f"/> <c>b</c>, yielding a new <see cref="Vec3f"/>.
        /// </summary>
        /// <param name="a">The <see cref="float"/> scalar to divide (the divident).</param>
        /// <param name="b">The <see cref="Vec3f"/> to divide (the divisor).</param>
        /// <returns></returns>
        public static Vec3f operator /(float a, Vec3f b) => new Vec3f(a / b.X, a / b.Y, a / b.Z);

        /// <summary>
        /// Adds a <see cref="Vec3f"/> to a <see cref="Vec3f"/>, 
        /// yielding a new <see cref="Vec3f"/>.
        /// </summary>
        /// <param name="a">The first <see cref="Vec3f"/> to add.</param>
        /// <param name="b">The second <see cref="Vec3f"/> to add.</param>
        /// <c>a</c> and <c>b</c>.</returns>
        public static Vec3f operator +(Vec3f a, Vec3f b) => new Vec3f(a.X + b.X, a.Y + b.Y, a.Z + b.Z);

        /// <summary>
        /// Subtracts a <see cref="Vec3f"/> from a
        /// <see cref="Vec3f"/>, yielding a new <see cref="Vec3f"/>.
        /// </summary>
        /// <param name="a">The <see cref="Vec3f"/> to subtract from (the minuend).</param>
        /// <param name="b">The <see cref="Vec3f"/> to subtract (the subtrahend).</param>
        /// <returns>The <see cref="Vec3f"/> that is the <c>a</c> minus <c>b</c>.</returns>
        public static Vec3f operator -(Vec3f a, Vec3f b) => new Vec3f(a.X - b.X, a.Y - b.Y, a.Z - b.Z);

        /// <summary>
        /// Calculate the negative <see cref="Vec3f"/> by inverting every coordinate.
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Vec3f operator -(Vec3f a) => new Vec3f(-a.X, -a.Y, -a.Z);

        /// <summary>
        /// The Identity of the <see cref="Vec3f"/>.
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Vec3f operator +(Vec3f a) => a;

        /// <summary>
        /// Determines whether a specified instance of <see cref="Vec3f"/> is equal to
        /// another specified <see cref="Vec3f"/>.
        /// </summary>
        /// <param name="a">The first <see cref="Vec3f"/> to compare.</param>
        /// <param name="b">The second <see cref="Vec3f"/> to compare.</param>
        /// <returns><c>true</c> if <c>a</c> and <c>b</c> are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(Vec3f a, Vec3f b)
        {
            if (a is null || b is null)
            {
                return false;
            }
            return a.Equals(b);
        }

        /// <summary>
        /// Determines whether a specified instance of <see cref="Vec3f"/> is not equal
        /// to another specified <see cref="Vec3f"/>.
        /// </summary>
        /// <param name="a">The first <see cref="Vec3f"/> to compare.</param>
        /// <param name="b">The second <see cref="Vec3f"/> to compare.</param>
        /// <returns><c>true</c> if <c>a</c> and <c>b</c> are not equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(Vec3f a, Vec3f b)
        {
            if (a is null || b is null)
            {
                return false;
            }
            return !a.Equals(b);
        }

        public static bool operator <(Vec3f a, Vec3f b) => a.SqrtLength < b.SqrtLength;

        public static bool operator >(Vec3f a, Vec3f b) => a.SqrtLength > b.SqrtLength;

        public static bool operator <(Vec3f a, float b) => a.SqrtLength < (b * b);

        public static bool operator <(float a, Vec3f b) => (a * a) < b.SqrtLength;

        public static bool operator >(Vec3f a, float b) => a.SqrtLength > (b * b);

        public static bool operator >(float a, Vec3f b) => (a * a) > b.SqrtLength;

        public static bool operator <=(Vec3f a, Vec3f b) => a.SqrtLength <= b.SqrtLength;

        public static bool operator >=(Vec3f a, Vec3f b) => a.SqrtLength >= b.SqrtLength;

        public static bool operator <=(Vec3f a, float b) => a.SqrtLength <= (b * b);

        public static bool operator <=(float a, Vec3f b) => (a * a) <= b.SqrtLength;

        public static bool operator >=(Vec3f a, float b) => a.SqrtLength >= (b * b);

        public static bool operator >=(float a, Vec3f b) => (a * a) >= b.SqrtLength;

        /// <summary>
        /// Center <see cref="Vec3f"/> between two <see cref="Vec3f"/>.
        /// </summary>
        /// <returns>The center point.</returns>
        /// <param name="a">Vector a.</param>
        /// <param name="b">Vector b.</param>
        public static Vec3f Center(Vec3f a, Vec3f b) => (a + b) * 0.5f;

        /// <summary>
        /// Returns the center <see cref="Vec3f"/> between 
        /// the current <see cref="Vec3f"/> and 
        /// another <see cref="Vec3f"/> B.
        /// </summary>
        /// <returns>The center point.</returns>
        /// <param name="b">Vector b.</param>
        public Vec3f Center(Vec3f b) => Center(this, b);

        /// <summary>
        /// Returns the <see cref="float"/> distance between two <see cref="Vec3f"/>.
        /// </summary>
        /// <returns>The distance.</returns>
        /// <param name="a">Start vector a.</param>
        /// <param name="b">End vector b.</param>
		public static float Distance(Vec3f a, Vec3f b) => (a - b).Length;

        /// <summary>
        /// Returns the <see cref="float"/> distance between this and another <see cref="Vec3f"/>
        /// </summary>
        /// <returns>The distance.</returns>
        /// <param name="b">End vector b.</param>
        public float Distance(Vec3f pointB) => Distance(this, pointB);

        /// <summary>
        /// Computes the dot product of the <see cref="Vec3f"/> <c>a</c> 
        /// and the <see cref="Vec3f"/> <c>b</c>, yielding 
        /// a new <see cref="Vec3f"/>.
        /// </summary>
        /// <returns>The <see cref="Vec3f"/> that is the <c>a</c> * <c>b</c>.</returns>
        /// <param name="a">The <see cref="Vec3f"/> to multiply.</param>
        /// <param name="b">The <see cref="Vec3f"/> to multiply.</param>
		public static float Dot(Vec3f a, Vec3f b) => (a * b).Reduce;

        /// <summary>
        /// Computes the dot product of this <see cref="Vec3f"/> 
        /// and the <see cref="Vec3f"/> <c>b</c>, yielding 
        /// a new <see cref="Vec3f"/>.
        /// </summary>
        /// <returns>The <see cref="Vec3f"/> that is this * <c>b</c>.</returns>
        /// <param name="b">The <see cref="Vec3f"/> to multiply.</param>
        public float Dot(Vec3f b) => Dot(this, b);

        /// <summary>
        /// Computes the cross product of the <see cref="Vec3f"/> <c>a</c> 
        /// and the <see cref="Vec3f"/> <c>b</c>, yielding 
        /// a new <see cref="Vec3f"/>.
        /// </summary>
        /// <returns>The <see cref="Vec3f"/> that is the <c>a</c> x <c>b</c>.</returns>
        /// <param name="b">The second <see cref="Vec3f"/> to multiply.</param>
        public static Vec3f Cross(Vec3f a, Vec3f b) => new Vec3f(a.Y * b.Z - a.Z * b.Y, a.Z * b.X - a.X * b.Z, a.X * b.Y - a.Y * b.X);

        /// <summary>
        /// Computes the cross product of this <see cref="Vec3f"/> 
        /// and the <see cref="Vec3f"/> <c>b</c>, yielding 
        /// a new <see cref="Vec3f"/>.
        /// </summary>
        /// <returns>The <see cref="Vec3f"/> that is this x <c>b</c>.</returns>
        /// <param name="a">The first <see cref="Vec3f"/> to multiply.</param>
        /// <param name="b">The second <see cref="Vec3f"/> to multiply.</param>
        public Vec3f Cross(Vec3f b) => Cross(this, b);

        /// <summary>
        /// Determine the angle between two <see cref="Vec3f"/>.
        /// </summary>
        /// <returns>The angle.</returns>
        /// <param name="from">From <see cref="Vec3f"/>.</param>
        /// <param name="to">To <see cref="Vec3f"/>.</param>
        public static float Angle(Vec3f from, Vec3f to)
        {
            float denominator = MathF.Sqrt(from.SqrtLength * to.SqrtLength);
            if (denominator < 0.1f)
                return 0f;
            float dot = Dot(from, to) / denominator;
            if (dot < -1.0f)
                dot = -1.0f;
            if (dot > 1.0f)
                dot = 1.0f;
            return (MathF.Acos(dot) * 1.0f / (MathF.PI * 2.0f / 360.0f));
        }

        /// <summary>
        /// Determine the signed angle between two <see cref="Vec3f"/>.
        /// </summary>
        /// <returns>The signed angle.</returns>
        /// <param name="from">From <see cref="Vec3f"/>.</param>
        /// <param name="to">To <see cref="Vec3f"/>.</param>
        /// <param name="axis">Axis <see cref="Vec3f"/>.</param>
        public static float SignedAngle(Vec3f from, Vec3f to, Vec3f axis) => Angle(from, to) * Dot(axis, Cross(from, to)) >= 0.0f ? 1.0f : -1.0f;

        public static Vec3f Lerp(Vec3f from, Vec3f to, float value) => new Vec3f(
            Utility.Lerp(from.X, to.X, value),
            Utility.Lerp(from.Y, to.Y, value),
            Utility.Lerp(from.Z, to.Z, value)
            );

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to 
        /// the current <see cref="Vec3f"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with 
        /// the current <see cref="Vec3f"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="object"/> is equal to the current
        /// <see cref="Vec3f"/>; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is Vec3f))
                return false;
            Vec3f b = (Vec3f)obj;
            return
                (X == b.X || (float.IsNaN(X) && float.IsNaN(b.X))) &&
                (Y == b.Y || (float.IsNaN(Y) && float.IsNaN(b.Y))) &&
                (Z == b.Z || (float.IsNaN(Z) && float.IsNaN(b.Z)));
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

        public bool Intersect2DQuadrant(Vec3f point, byte quadrant)
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
