namespace Rayzin.Tests;

public class RayzinPointTests
{
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
}