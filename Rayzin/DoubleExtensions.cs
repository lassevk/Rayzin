namespace Rayzin;

public static class DoubleExtensions
{
    extension(double value)
    {
        public bool ApproximatelyEquals(double other, double epsilon = RayzinConstants.Epsilon) => Math.Abs(value - other) <= epsilon;
    }
}