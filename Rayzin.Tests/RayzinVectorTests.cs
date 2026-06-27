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
}