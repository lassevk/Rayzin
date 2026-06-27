namespace Rayzin.Tests;

public class RayzinVectorTests
{
    [Fact]
    public void RayzinVector_Create_CreatesPointWithWEqualTo0()
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

        var output = -vector;

        Assert.Equal(new RayzinVector(-1, 2, -3), output);
    }
}