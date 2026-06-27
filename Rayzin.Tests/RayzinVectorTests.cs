namespace Rayzin.Tests;

public class RayzinVectorTests
{
    [Fact]
    public void RayzinVector_Create_CreatesPointWithWEqualTo0()
    {
        var vector = RayzinVector.Create(1, 2, 3);
        Assert.Equal(0.0, vector.W);
    }
}