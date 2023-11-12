namespace Rayzin;

public readonly record struct RPoint(double X, double Y, double Z)
{
    public double W => 1;

    public static implicit operator RPoint(ValueTuple<double, double, double> t) => new RPoint(t.Item1, t.Item2, t.Item3);
    public static implicit operator RPoint(Tuple<double, double, double> t) => new RPoint(t.Item1, t.Item2, t.Item3);

    public static RPoint operator +(RPoint p, RVector v) => new RPoint(p.X + v.X, p.Y + v.Y, p.Z + v.Z);
    public static RPoint operator +(RVector v, RPoint p) => new RPoint(p.X + v.X, p.Y + v.Y, p.Z + v.Z);
    
    public static RPoint operator -(RPoint p, RVector v) => new RPoint(p.X - v.X, p.Y - v.Y, p.Z - v.Z);

    public static RVector operator -(RPoint p1, RPoint p2) => new RVector(p1.X - p2.X, p1.Y - p2.Y, p1.Z - p2.Z);
}