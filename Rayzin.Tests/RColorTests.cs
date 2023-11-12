namespace Rayzin.Tests;

public class RColorTests
{
    [Test]
    public void GetHashCode_ThrowsNotSupportedException()
    {
        RColor c = (1, 2, 3);

        Assert.Throws<NotSupportedException>(() => _ = c.GetHashCode());
    }

    // [Test]
    // public void DefaultConstructor()
    // {
    //     RColor c = default;
    //     Assert.That(c, Is.EqualTo(RPoint.Origin));
    // }
    
    [Test]
    [TestCase(0, 0, 0, true)]
    [TestCase(1e-6, 0, 0, true)]
    [TestCase(0, 1e-6, 0, true)]
    [TestCase(0, 0, 1e-6, true)]
    [TestCase(1e-4, 0, 0, false)]
    [TestCase(0, 1e-4, 0, false)]
    [TestCase(0, 0, 1e-4, false)]
    public void Equals(double r, double g, double b, bool expected)
    {
        RPoint p1 = (0, 0, 0);
        RPoint p2 = (r, g, b);

        if (expected)
            Assert.That(p1, Is.EqualTo(p2));
        else
            Assert.That(p1, Is.Not.EqualTo(p2));
    }
    
    [Test]
    public void Construct_FromValueTuple()
    {
        var c = (RColor)new ValueTuple<double, double, double>(1, 2, 3);

        Assert.That(c.R, Is.EqualTo(1));
        Assert.That(c.G, Is.EqualTo(2));
        Assert.That(c.B, Is.EqualTo(3));
    }

    [Test]
    public void Construct_FromTuple()
    {
        var c = (RColor)new Tuple<double, double, double>(1, 2, 3);

        Assert.That(c.R, Is.EqualTo(1));
        Assert.That(c.G, Is.EqualTo(2));
        Assert.That(c.B, Is.EqualTo(3));
    }
    
    [Test]
    [TestCase(0, 0, 0)]
    [TestCase(1, 1, 1)]
    [TestCase(1.5, 2.5, 3.5)]
    [TestCase(4.3, -4.2, 3.1)]
    public void Constructor_TestCases(double r, double g, double b)
    {
        var color = new RColor(r, g, b);
        
        Assert.That(color.R, Is.EqualTo(r));
        Assert.That(color.G, Is.EqualTo(g));
        Assert.That(color.B, Is.EqualTo(b));
    }

    [Test]
    public void WithR()
    {
        var c1 = new RColor(4.3, -4.2, 3.1);
        RColor c2 = c1 with { R = 8.3 };

        Assert.That(c2, Is.EqualTo(new RColor(8.3, -4.2, 3.1)));
    }
    
    [Test]
    public void WithG()
    {
        var c1 = new RColor(4.3, -4.2, 3.1);
        RColor c2 = c1 with { G = 8.3 };

        Assert.That(c2, Is.EqualTo(new RColor(4.3, 8.3, 3.1)));
    }
    
    [Test]
    public void WithB()
    {
        var c1 = new RColor(4.3, -4.2, 3.1);
        RColor c2 = c1 with { B = 8.3 };

        Assert.That(c2, Is.EqualTo(new RColor(4.3, -4.2, 8.3)));
    }
}