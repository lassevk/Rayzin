namespace Rayzin.Tests;

public class RayzinPointTests
{
    [Fact]
    public void RayzinPoint_Create_CreatesPointWithWEqualTo1()
    {
        var point = RayzinPoint.Create(1, 2, 3);
        Assert.Equal(1.0, point.W);
    }
}