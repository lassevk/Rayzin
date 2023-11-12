namespace Rayzin;

public readonly record struct RVector(double X, double Y, double Z)
{
    public double W => 0;
    
    public static RVector operator +(RVector v1, RVector v2) => new RVector(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
}