using System.Text;

namespace Rayzin;

public readonly record struct RayzinPoint(double X, double Y, double Z)
    : IRayzinTuple3<RayzinPoint>, IRayzinTuple4<RayzinPoint>
{
    public static RayzinPoint Create(double x, double y, double z) => new(x, y, z);
    public double W => 1.0;

    public bool ApproximatelyEquals(RayzinPoint other) => RayzinPointApproximateComparer.Instance.Equals(this, other);

    public static RayzinPoint operator +(RayzinPoint point, RayzinVector vector)
        => new(point.X + vector.X, point.Y + vector.Y, point.Z + vector.Z);

    public static RayzinPoint operator -(RayzinPoint point1, RayzinVector vector)
        => new(point1.X - vector.X, point1.Y - vector.Y, point1.Z - vector.Z);

    public static RayzinVector operator -(RayzinPoint point1, RayzinPoint point2)
        => new(point1.X - point2.X, point1.Y - point2.Y, point1.Z - point2.Z);

    private bool PrintMembers(StringBuilder builder)
    {
        builder.Append($"X = {X}, Y = {Y}, Z = {Z}");
        return true;
    }
}