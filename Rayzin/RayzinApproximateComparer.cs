namespace Rayzin;

public class RayzinApproximateComparer<T> : IEqualityComparer<T>
    where T : struct, IRayzinTuple3<T>
{
    protected RayzinApproximateComparer() { }

    public bool Equals(T x, T y) => x.X.ApproximatelyEquals(y.X) && x.Y.ApproximatelyEquals(y.Y) && x.Z.ApproximatelyEquals(y.Z);

    public int GetHashCode(T obj) => throw new NotSupportedException("Approximate comparison does not have a valid hashcode");
}