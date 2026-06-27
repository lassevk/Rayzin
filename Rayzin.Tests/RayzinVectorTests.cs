namespace Rayzin.Tests;

public class RayzinVectorTests
{
    [Fact]
    public void Constructor_CreatesPointWithCorrectValues()
    {
        var vector = new RayzinVector(4.3, -4.2, 3.1);

        Assert.Equal(4.3, vector.X, RayzinConstants.Epsilon);
        Assert.Equal(-4.2, vector.Y, RayzinConstants.Epsilon);
        Assert.Equal(3.1, vector.Z, RayzinConstants.Epsilon);
        Assert.Equal(0.0, vector.W);
    }

    [Fact]
    public void RayzinVector_Create_CreatesVectorWithWEqualTo0()
    {
        var vector = RayzinVector.Create(1, 2, 3);
        Assert.Equal(0.0, vector.W);
    }

    [Fact]
    public void RayzinVector_AddPoint_ProducesNewPoint()
    {
        var vector = new RayzinVector(-2, 3, 1);
        var point = new RayzinPoint(3, -2, 5);

        RayzinPoint output = vector + point;

        Assert.Equal(new RayzinPoint(1, 1, 6), output);
    }

    [Fact]
    public void RayzinVector_SubtractVector_ProducesVector()
    {
        var vector1 = new RayzinVector(3, 2, 1);
        var vector2 = new RayzinVector(5, 6, 7);

        RayzinVector output = vector1 - vector2;

        Assert.Equal(new RayzinVector(-2, -4, -6), output);
    }

    [Fact]
    public void RayzinVector_Negate_ProducesNegativeVector()
    {
        var vector = new RayzinVector(1, -2, 3);

        RayzinVector output = -vector;

        Assert.Equal(new RayzinVector(-1, 2, -3), output);
    }

    [Fact]
    public void RayzinVector_MultiplyByScalar_ProducesScaledVector()
    {
        var vector = new RayzinVector(1, -2, 3);

        RayzinVector output = vector * 3.5;

        Assert.Equal(new RayzinVector(3.5, -7, 10.5), output, RayzinVectorApproximateComparer.Instance);
    }

    [Fact]
    public void Scalar_MultiplyByVector_ProducesScaledVector()
    {
        var vector = new RayzinVector(1, -2, 3);

        RayzinVector output = 3.5 * vector;

        Assert.Equal(new RayzinVector(3.5, -7, 10.5), output, RayzinVectorApproximateComparer.Instance);
    }

    [Theory]
    [InlineData(1, 0, 0, 1)]
    [InlineData(0, 1, 0, 1)]
    [InlineData(0, 0, 1, 1)]
    [InlineData(1, 2, 3, 3.741657386773941)]
    [InlineData(-1, -2, -3, 3.741657386773941)]
    public void Magnitude_ReturnsEuclidianLength(double x, double y, double z, double expected)
    {
        var vector = new RayzinVector(x, y, z);

        double magnitude = vector.Magnitude;

        Assert.Equal(expected, magnitude, RayzinConstants.Epsilon);
    }

    [Theory]
    [InlineData(4, 0, 0)]
    [InlineData(1, 2, 3)]
    public void Normalized_ReturnsUnitVector_WithMagnitude1(double x, double y, double z)
    {
        var vector = new RayzinVector(x, y, z);
        RayzinVector normalized = vector.Normalized;

        Assert.Equal(1, normalized.Magnitude, RayzinConstants.Epsilon);
    }

    [Theory]
    [InlineData(4, 0, 0, 1, 0, 0)]
    [InlineData(1, 2, 3, 0.2672612419124244, 0.5345224838248488, 0.8017837257372732)]
    public void Normalized_ReturnsUnitVector(double x, double y, double z, double expectedX, double expectedY, double expectedZ)
    {
        var vector = new RayzinVector(x, y, z);
        var expected = new RayzinVector(expectedX, expectedY, expectedZ);
        RayzinVector normalized = vector.Normalized;

        Assert.Equal(expected, normalized, RayzinVectorApproximateComparer.Instance);
    }

    [Theory]
    [InlineData(1, 2, 3, 2, 3, 4, 20)]
    public void DotProduct_ReturnsSumOfComponentProducts(double x1, double y1, double z1, double x2, double y2, double z2, double expected)
    {
        var vector1 = new RayzinVector(x1, y1, z1);
        var vector2 = new RayzinVector(x2, y2, z2);

        double output = vector1.DotProduct(vector2);

        Assert.Equal(expected, output, RayzinConstants.Epsilon);
    }

    [Theory]
    [InlineData(1, 2, 3, 2, 3, 4, -1, 2, -1)]
    [InlineData(2, 3, 4, 1, 2, 3, 1, -2, 1)]
    public void CrossProduct_ReturnsExpectedVector(double x1, double y1, double z1, double x2, double y2, double z2, double expectedX, double expectedY, double expectedZ)
    {
        // Expected vector is perpendicular to both vectors, but this test hardcodes the expected result

        var vector1 = new RayzinVector(x1, y1, z1);
        var vector2 = new RayzinVector(x2, y2, z2);

        var expected = new RayzinVector(expectedX, expectedY, expectedZ);
        RayzinVector output = vector1.CrossProduct(vector2);

        Assert.Equal(expected, output, RayzinVectorApproximateComparer.Instance);
    }

    [Theory]
    [InlineData(1, 2, 3, "RayzinVector { X = 1, Y = 2, Z = 3 }")]
    [InlineData(6, 5, 4, "RayzinVector { X = 6, Y = 5, Z = 4 }")]
    public void ToString_ReturnsExpectedString(double x, double y, double z, string expected)
    {
        var vector = new RayzinVector(x, y, z);

        string output = vector.ToString();

        Assert.Equal(expected, output);
    }

    [Theory]
    [InlineData(1, 2, 3, 1 + 1E-6, 2, 3)]
    [InlineData(1, 2, 3, 1, 2 + 1E-6, 3)]
    [InlineData(1, 2, 3, 1, 2, 3 + 1E-6)]
    public void ApproximatelyEquals_WithinEpsilon_ReturnsTrue(double x1, double y1, double z1, double x2, double y2, double z2)
    {
        var vector1 = new RayzinVector(x1, y1, z1);
        var vector2 = new RayzinVector(x2, y2, z2);

        bool output = vector1.ApproximatelyEquals(vector2);

        Assert.True(output);
    }

    [Theory]
    [InlineData(1, 2, 3, 1 + 1E-4, 2, 3)]
    [InlineData(1, 2, 3, 1, 2 + 1E-4, 3)]
    [InlineData(1, 2, 3, 1, 2, 3 + 1E-4)]
    public void ApproximatelyEquals_OutsideEpsilon_ReturnsFalse(double x1, double y1, double z1, double x2, double y2, double z2)
    {
        var vector1 = new RayzinVector(x1, y1, z1);
        var vector2 = new RayzinVector(x2, y2, z2);

        bool output = vector1.ApproximatelyEquals(vector2);

        Assert.False(output);
    }
}