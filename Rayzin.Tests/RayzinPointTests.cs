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
}