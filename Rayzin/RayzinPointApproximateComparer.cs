namespace Rayzin;

public sealed class RayzinPointApproximateComparer : RayzinApproximateComparer<RayzinPoint>
{
    private RayzinPointApproximateComparer() { }
    public static RayzinPointApproximateComparer Instance { get; } = new();
}