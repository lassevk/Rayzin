namespace Rayzin;

public readonly record struct RayzinVector(double X, double Y, double Z)
    : IRayzinTuple3<RayzinVector>, IRayzinTuple4<RayzinVector>
{
    public static RayzinVector Create(double x, double y, double z) => new(x, y, z);
    public double W => 0.0;
}