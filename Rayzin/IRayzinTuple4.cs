namespace Rayzin;

public interface IRayzinTuple4<T>
    where T : IRayzinTuple4<T>, IRayzinTuple3<T>
{
    double W { get; }
}