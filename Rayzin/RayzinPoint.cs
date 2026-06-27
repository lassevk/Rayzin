namespace Rayzin;

public readonly record struct RayzinPoint(double X, double Y, double Z)
    : IRayzinTuple3<RayzinPoint>, IRayzinTuple4<RayzinPoint>
{
    public static RayzinPoint Create(double x, double y, double z) => new(x, y, z);
    public double W => 1.0;

    public static RayzinPoint operator +(RayzinPoint point, RayzinVector vector)
        => new(point.X + vector.X, point.Y + vector.Y, point.Z + vector.Z);

    public static RayzinPoint operator -(RayzinPoint point, RayzinVector vector)
        => new(point.X - vector.X, point.Y - vector.Y, point.Z - vector.Z);
}