using System.Diagnostics;
using System.Xml.Linq;

namespace CM2Sharp
{
    /// <summary>
    /// A point in CM2 space.
    /// </summary>
    public struct Point : IEquatable<Point>
    {
        #region Properties
        /// <summary>
        /// X axis of the point.
        /// </summary>
        public float X { get; set; }

        /// <summary>
        /// Y axis of the point.
        /// </summary>
        public float Y { get; set; }

        /// <summary>
        /// Z axis of the point.
        /// </summary>
        public float Z { get; set; }

        /// <summary>
        /// A point at the origin (0, 0, 0)
        /// </summary>
        public static Point Zero => new Point(0, 0, 0);
        #endregion
        #region Constructor
        /// <summary>
        /// Create a new instance of the Point class.
        /// </summary>
        public Point(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        #endregion
        #region Operators

        // Equals
        public bool Equals(Point other)
        {
            return X == other.X &&
                   Y == other.Y &&
                   Z == other.Z;
        }

        public override bool Equals(object? obj)
        {
            return obj is Point other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y, Z);
        }

        // Basic operators with others of the same type
        public static Point operator +(Point left, Point right) {
            return new Point(
                left.X + right.X,
                left.Y + right.Y,
                left.Z + right.Z
            );
        }

        public static Point operator -(Point left, Point right)
        {
            return new Point(
                left.X - right.X,
                left.Y - right.Y,
                left.Z - right.Z
            );
        }

        public static Point operator *(Point left, Point right)
        {
            return new Point(
                left.X * right.X,
                left.Y * right.Y,
                left.Z * right.Z
            );
        }

        public static Point operator /(Point left, Point right)
        {
            return new Point(
                left.X / right.X,
                left.Y / right.Y,
                left.Z / right.Z
            );
        }

        // Scale factor operators
        public static Point operator *(Point left, float right)
        {
            return new Point(
                left.X * right,
                left.Y * right,
                left.Z * right
            );
        }

        public static Point operator /(Point left, float right)
        {
            return new Point(
                left.X / right,
                left.Y / right,
                left.Z / right
            );
        }

        // Negative
        public static Point operator -(Point pt)
        {
            return new Point(-pt.X, -pt.Y, -pt.Z);
        }

        #endregion
        #region Casts
        // from and to Vector3
        public static implicit operator System.Numerics.Vector3(Point pt)
        {
            return new System.Numerics.Vector3(pt.X, pt.Y, pt.Z);
        }

        public static implicit operator Point (System.Numerics.Vector3 vec)
        {
            return new Point(vec.X, vec.Y, vec.Z);
        }

        // Defintion from tuple
        public static implicit operator Point((float x, float y, float z) tuple)
        {
            return new Point(tuple.x, tuple.y, tuple.z);
        }
        #endregion
        #region Methods
        public void Deconstruct(out float x, out float y, out float z)
        {
            x = X;
            y = Y;
            z = Z;
        }

        public override string ToString()
        {
            return $"{X},{Y},{Z}";
        }
        #endregion
    }
}
