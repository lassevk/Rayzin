namespace Rayzin.Tests;

public class RRayTests
{
    [Test]
    public void PointFromDistance()
    {
        var r = new RRay((2, 3, 4), (1, 0, 0));
        Assert.That(r.Position(0), Is.EqualTo(new RPoint(2, 3, 4)));
        Assert.That(r.Position(1), Is.EqualTo(new RPoint(3, 3, 4)));
        Assert.That(r.Position(-1), Is.EqualTo(new RPoint(1, 3, 4)));
        Assert.That(r.Position(2.5), Is.EqualTo(new RPoint(4.5, 3, 4)));    
    }

    [Test]
    public void WithNewDirection()
    {
        var r1 = new RRay((2, 3, 4), (1, 0, 0));
        RRay r2 = r1 with { Direction = (0, 1, 0) };

        Assert.That(r2, Is.EqualTo(new RRay((2, 3, 4), (0, 1, 0))));
    }
    
    [Test]
    public void WithNewOrigin()
    {
        var r1 = new RRay((2, 3, 4), (1, 0, 0));
        RRay r2 = r1 with { Origin = (7, 8, 9) };

        Assert.That(r2, Is.EqualTo(new RRay((7, 8, 9), (1, 0, 0))));
    }
}