namespace Rayzin.Tests;

public class DoubleExtensionsTests
{
    [Theory]
    [InlineData(1.0, 1.0, 0)]
    [InlineData(1.0, 1.1, 0.2)]
    public void ApproximatelyEquals_WhenWithinEpsilon_ReturnsTrue(double a, double b, double epsilon)
    {
        bool result = a.ApproximatelyEquals(b, epsilon);
        Assert.True(result);
    }

    [Theory]
    [InlineData(1.0, 1.1, 0)]
    [InlineData(1.0, 1.1, 0.1)]
    public void ApproximatelyEquals_WhenOutsideEpsilon_ReturnsFalse(double a, double b, double epsilon)
    {
        bool result = a.ApproximatelyEquals(b, epsilon);
        Assert.False(result);
    }
}