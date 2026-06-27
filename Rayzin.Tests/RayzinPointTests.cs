namespace Rayzin.Tests;

public class RayzinPointTests
{
    [Fact]
    public void Constructor_CreatesPointWithCorrectValues()
    {
        var point = new RayzinPoint(4.3, -4.2, 3.1);

        Assert.Equal(4.3, point.X, RayzinConstants.Epsilon);
        Assert.Equal(-4.2, point.Y, RayzinConstants.Epsilon);
        Assert.Equal(3.1, point.Z, RayzinConstants.Epsilon);
        Assert.Equal(1.0, point.W);
    }

    [Fact]
    public void RayzinPoint_Create_CreatesPointWithWEqualTo1()
    {
        var point = RayzinPoint.Create(1, 2, 3);
        Assert.Equal(1.0, point.W);
    }

    [Fact]
    public void RayzinPoint_AddVector_ProducesNewPoint()
    {
        var point = new RayzinPoint(3, -2, 5);
        var vector = new RayzinVector(-2, 3, 1);

        RayzinPoint output = point + vector;

        Assert.Equal(new RayzinPoint(1, 1, 6), output);
    }

    [Fact]
    public void RayzinPoint_SubtractPoint_ProducesVector()
    {
        var point1 = new RayzinPoint(3, 2, 1);
        var point2 = new RayzinPoint(5, 6, 7);

        RayzinVector output = point1 - point2;

        Assert.Equal(new RayzinVector(-2, -4, -6), output);
    }

    [Fact]
    public void RayzinPoint_SubtractVector_ProducesNewPoint()
    {
        var point = new RayzinPoint(3, 2, 1);
        var vector = new RayzinVector(5, 6, 7);

        RayzinPoint output = point - vector;

        Assert.Equal(new RayzinPoint(-2, -4, -6), output);
    }

    [Theory]
    [InlineData(1, 2, 3, "RayzinPoint { X = 1, Y = 2, Z = 3 }")]
    [InlineData(6, 5, 4, "RayzinPoint { X = 6, Y = 5, Z = 4 }")]
    public void ToString_ReturnsExpectedString(double x, double y, double z, string expected)
    {
        var point = new RayzinPoint(x, y, z);

        string output = point.ToString();

        Assert.Equal(expected, output);
    }

    [Theory]
    [InlineData(1, 2, 3, 1 + 1E-6, 2, 3)]
    [InlineData(1, 2, 3, 1, 2 + 1E-6, 3)]
    [InlineData(1, 2, 3, 1, 2, 3 + 1E-6)]
    public void ApproximatelyEquals_WithinEpsilon_ReturnsTrue(double x1, double y1, double z1, double x2, double y2, double z2)
    {
        var point1 = new RayzinPoint(x1, y1, z1);
        var point2 = new RayzinPoint(x2, y2, z2);

        bool output = point1.ApproximatelyEquals(point2);

        Assert.True(output);
    }

    [Theory]
    [InlineData(1, 2, 3, 1 + 1E-4, 2, 3)]
    [InlineData(1, 2, 3, 1, 2 + 1E-4, 3)]
    [InlineData(1, 2, 3, 1, 2, 3 + 1E-4)]
    public void ApproximatelyEquals_OutsideEpsilon_ReturnsFalse(double x1, double y1, double z1, double x2, double y2, double z2)
    {
        var point1 = new RayzinPoint(x1, y1, z1);
        var point2 = new RayzinPoint(x2, y2, z2);

        bool output = point1.ApproximatelyEquals(point2);

        Assert.False(output);
    }
}