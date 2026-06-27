namespace Rayzin;

public interface IRayzinTuple3<out T>
    where T : IRayzinTuple3<T>
{
    double X { get; }
    double Y { get; }
    double Z { get; }

    static abstract T Create(double x, double y, double z);
}