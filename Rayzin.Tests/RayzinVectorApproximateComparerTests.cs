namespace Rayzin.Tests;

public class RayzinVectorApproximateComparerTests
{
    [Fact]
    public void Equals_SameVectors_ReturnsTrue()
    {
        var vector = RayzinVector.Create(1, 2, 3);
        Assert.Equal(vector, vector, RayzinVectorApproximateComparer.Instance);
    }

    [Theory]
    [InlineData(1, 2, 3, 1 + 1E-6, 2, 3)]
    [InlineData(1, 2, 3, 1, 2 + 1E-6, 3)]
    [InlineData(1, 2, 3, 1, 2, 3 + 1E-6)]
    public void Equals_VectorsThatDifferInOneDimensionWithinEpsilon_ReturnsTrue(double x1, double y1, double z1, double x2, double y2, double z2)
    {
        var vector1 = RayzinVector.Create(x1, y1, z1);
        var vector2 = RayzinVector.Create(x2, y2, z2);

        Assert.Equal(vector1, vector2, RayzinVectorApproximateComparer.Instance);
    }

    [Theory]
    [InlineData(1, 2, 3, 1 + 1E-4, 2, 3)]
    [InlineData(1, 2, 3, 1, 2 + 1E-4, 3)]
    [InlineData(1, 2, 3, 1, 2, 3 + 1E-4)]
    public void Equals_VectorsThatDifferInOneDimensionOutsideEpsilon_ReturnsFalse(double x1, double y1, double z1, double x2, double y2, double z2)
    {
        var vector1 = RayzinVector.Create(x1, y1, z1);
        var vector2 = RayzinVector.Create(x2, y2, z2);

        Assert.NotEqual(vector1, vector2, RayzinVectorApproximateComparer.Instance);
    }

    [Fact]
    public void GetHashCode_ThrowsNotSupportedException()
    {
        var vector = RayzinVector.Create(1, 2, 3);
        Assert.Throws<NotSupportedException>(() => RayzinVectorApproximateComparer.Instance.GetHashCode(vector));
    }
}