namespace Rayzin.Tests;

public class RayzinPointApproximateComparerTests
{
    [Fact]
    public void Equals_SameVectors_ReturnsTrue()
    {
        var point = RayzinPoint.Create(1, 2, 3);
        Assert.Equal(point, point, RayzinPointApproximateComparer.Instance);
    }

    [Theory]
    [InlineData(1, 2, 3, 1 + 1E-6, 2, 3)]
    [InlineData(1, 2, 3, 1, 2 + 1E-6, 3)]
    [InlineData(1, 2, 3, 1, 2, 3 + 1E-6)]
    public void Equals_VectorsThatDifferInOneDimensionWithinEpsilon_ReturnsTrue(double x1, double y1, double z1, double x2, double y2, double z2)
    {
        var point1 = RayzinPoint.Create(x1, y1, z1);
        var point2 = RayzinPoint.Create(x2, y2, z2);

        Assert.Equal(point1, point2, RayzinPointApproximateComparer.Instance);
    }

    [Theory]
    [InlineData(1, 2, 3, 1 + 1E-4, 2, 3)]
    [InlineData(1, 2, 3, 1, 2 + 1E-4, 3)]
    [InlineData(1, 2, 3, 1, 2, 3 + 1E-4)]
    public void Equals_VectorsThatDifferInOneDimensionOutsideEpsilon_ReturnsFalse(double x1, double y1, double z1, double x2, double y2, double z2)
    {
        var point1 = RayzinPoint.Create(x1, y1, z1);
        var point2 = RayzinPoint.Create(x2, y2, z2);

        Assert.NotEqual(point1, point2, RayzinPointApproximateComparer.Instance);
    }

    [Fact]
    public void GetHashCode_ThrowsNotSupportedException()
    {
        var point = RayzinPoint.Create(1, 2, 3);
        Assert.Throws<NotSupportedException>(() => RayzinPointApproximateComparer.Instance.GetHashCode(point));
    }
}