using System.Text;

namespace Rayzin;

public readonly record struct RayzinVector(double X, double Y, double Z) : IRayzinTuple3<RayzinVector>, IRayzinTuple4<RayzinVector>
{
    public static RayzinVector Create(double x, double y, double z) => new(x, y, z);
    public double W => 0.0;

    public bool ApproximatelyEquals(RayzinVector other) => RayzinVectorApproximateComparer.Instance.Equals(this, other);

    public static RayzinPoint operator +(RayzinVector vector, RayzinPoint point) => new(vector.X + point.X, vector.Y + point.Y, vector.Z + point.Z);

    public static RayzinVector operator -(RayzinVector vector1, RayzinVector vector2) => new(vector1.X - vector2.X, vector1.Y - vector2.Y, vector1.Z - vector2.Z);

    public static RayzinVector operator -(RayzinVector vector) => new(-vector.X, -vector.Y, -vector.Z);

    public static RayzinVector operator *(RayzinVector vector, double scalar) => new(vector.X * scalar, vector.Y * scalar, vector.Z * scalar);
    public static RayzinVector operator *(double scalar, RayzinVector vector) => new(vector.X * scalar, vector.Y * scalar, vector.Z * scalar);

    public double Magnitude => Math.Sqrt(X * X + Y * Y + Z * Z);

    private bool PrintMembers(StringBuilder builder)
    {
        builder.Append($"X = {X}, Y = {Y}, Z = {Z}");
        return true;
    }

    public RayzinVector Normalized
    {
        get
        {
            double magnitude = Magnitude;
            return new RayzinVector(X / magnitude, Y / magnitude, Z / magnitude);
        }
    }

    public double DotProduct(RayzinVector other) => X * other.X + Y * other.Y + Z * other.Z;
    public RayzinVector CrossProduct(RayzinVector other) => new(Y * other.Z - Z * other.Y, Z * other.X - X * other.Z, X * other.Y - Y * other.X);
}