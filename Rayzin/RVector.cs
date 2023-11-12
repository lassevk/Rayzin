namespace Rayzin;

public readonly record struct RVector(double X, double Y, double Z)
{
    public double W => 0;
    
    public static implicit operator RVector(ValueTuple<double, double, double> t) => new RVector(t.Item1, t.Item2, t.Item3);
    public static implicit operator RVector(Tuple<double, double, double> t) => new RVector(t.Item1, t.Item2, t.Item3);

    
    public static RVector operator +(RVector v1, RVector v2) => new RVector(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);

    public static RVector operator -(RVector v1, RVector v2) => new RVector(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
}