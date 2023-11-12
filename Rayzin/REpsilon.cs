namespace Rayzin;

public static class REpsilon
{
    public const double Threshold = 1.0e-5;
    
    public static bool Equals(double a, double b) => Math.Abs(a - b) <= Threshold;
}