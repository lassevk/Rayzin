namespace Rayzin;

public static class RayzinEpsilon
{
    public const double Value = 1E-5;

    public static bool Equals(double a, double b) => Math.Abs(a - b) < Value;
}