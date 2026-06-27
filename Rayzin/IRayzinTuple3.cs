namespace Rayzin;

public interface IRayzinTuple3<T>
    where T : IRayzinTuple3<T>
{
    double X { get; }
    double Y { get; }
    double Z { get; }

    static abstract T Create(double x, double y, double z);
}