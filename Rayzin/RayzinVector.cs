namespace Rayzin;

public readonly record struct RayzinVector(double X, double Y, double Z) : IRayzinTuple3<RayzinVector>, IRayzinTuple4<RayzinVector>
{
    public static RayzinVector Create(double x, double y, double z) => new(x, y, z);
    public double W => 0.0;

    public static RayzinPoint operator +(RayzinVector vector, RayzinPoint point) => new(vector.X + point.X, vector.Y + point.Y, vector.Z + point.Z);

    public static RayzinVector operator -(RayzinVector vector1, RayzinVector vector2) => new(vector1.X - vector2.X, vector1.Y - vector2.Y, vector1.Z - vector2.Z);

    public static RayzinVector operator -(RayzinVector vector) => new(-vector.X, -vector.Y, -vector.Z);
}