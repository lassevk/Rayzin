namespace Rayzin;

public sealed class RayzinColorApproximateComparer : RayzinApproximateComparer<RayzinColor>
{
    private RayzinColorApproximateComparer() { }
    public static RayzinColorApproximateComparer Instance { get; } = new();
}