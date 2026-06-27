namespace Rayzin;

public sealed class RayzinVectorApproximateComparer : RayzinApproximateComparer<RayzinVector>
{
    private RayzinVectorApproximateComparer() { }
    public static RayzinVectorApproximateComparer Instance { get; } = new();
}