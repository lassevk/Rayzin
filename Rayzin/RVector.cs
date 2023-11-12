using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;

namespace Rayzin;

public readonly record struct RVector(double X, double Y, double Z)
{
    public double W => 0;

    public double Magnitude => Math.Sqrt(X * X + Y * Y + Z * Z);

    public RVector Normalize()
    {
        var m = Magnitude;
        return new RVector(X / m, Y / m, Z / m);
    }

    public static implicit operator RVector(ValueTuple<double, double, double> t) => new RVector(t.Item1, t.Item2, t.Item3);
    public static implicit operator RVector(Tuple<double, double, double> t) => new RVector(t.Item1, t.Item2, t.Item3);

    
    public static RVector operator +(RVector v1, RVector v2) => new RVector(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);

    public static RVector operator -(RVector v1, RVector v2) => new RVector(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);

    public static RVector operator -(RVector v) => new RVector(-v.X, -v.Y, -v.Z);
    
    public override int GetHashCode() => throw new NotSupportedException();

    public bool Equals(RVector other) => REpsilon.Equals(X, other.X) && REpsilon.Equals(Y, other.Y) && REpsilon.Equals(Z, other.Z);

    public static RVector operator *(RVector v, double scalar) => new RVector(v.X * scalar, v.Y * scalar, v.Z * scalar);
    public static RVector operator /(RVector v, double scalar) => new RVector(v.X / scalar, v.Y / scalar, v.Z / scalar);

    public static double operator *(RVector v1, RVector v2) => v1.X * v1.Y + v1.Y * v2.Y + v1.Z * v2.Z;

    public RVector Cross(RVector other) => new RVector(Y * other.Z - Z * other.Y, Z * other.X - X * other.Z, X * other.Y - Y * other.X);

    [ExcludeFromCodeCoverage]
    private bool PrintMembers(StringBuilder builder)
    {
        builder.AppendFormat(X.ToString("#.#####", CultureInfo.InvariantCulture));
        builder.Append(' ');
        builder.AppendFormat(Y.ToString("#.#####", CultureInfo.InvariantCulture));
        builder.Append(' ');
        builder.AppendFormat(Z.ToString("#.#####", CultureInfo.InvariantCulture));
        return true;
    }
}