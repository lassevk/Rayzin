namespace Rayzin;

public readonly record struct RPoint(double X, double Y, double Z)
{
    public double W => 1;

    public static RPoint operator +(RPoint p, RVector v) => new RPoint(p.X + v.X, p.Y + v.Y, p.Z + v.Z);
    public static RPoint operator +(RVector v, RPoint p) => new RPoint(p.X + v.X, p.Y + v.Y, p.Z + v.Z);
}