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

    [Test]
    [TestCase(0.9, 0.6, 0.75, 0.7, 0.1, 0.25, 1.6, 0.7, 1.0)]
    public void Add_WithTestCases(double r1, double g1, double b1, double r2, double g2, double b2, double expectedR, double expectedG, double expectedB)
    {
        RColor c1 = (r1, g1, b1);
        RColor c2 = (r2, g2, b2);
        RColor expected = (expectedR, expectedG, expectedB);

        RColor output = c1 + c2;

        Assert.That(output, Is.EqualTo(expected));
    }
    
    [Test]
    [TestCase(0.9, 0.6, 0.75, 0.7, 0.1, 0.25, 0.2, 0.5, 0.5)]
    public void Subtract_WithTestCases(double r1, double g1, double b1, double r2, double g2, double b2, double expectedR, double expectedG, double expectedB)
    {
        RColor c1 = (r1, g1, b1);
        RColor c2 = (r2, g2, b2);
        RColor expected = (expectedR, expectedG, expectedB);

        RColor output = c1 - c2;

        Assert.That(output, Is.EqualTo(expected));
    }
    
    [Test]
    [TestCase(0.2, 0.3, 0.4, 2, 0.4, 0.6, 0.8)]
    public void Multiply_ByScalar_WithTestCases(double r, double g, double b, double scalar, double expectedR, double expectedG, double expectedB)
    {
        RColor c = (r, g, b);
        RColor expected = (expectedR, expectedG, expectedB);

        RColor output = c * scalar;

        Assert.That(output, Is.EqualTo(expected));
    }
    
    [Test]
    [TestCase(1, 0.2, 0.4, 0.9, 1, 0.1, 0.9, 0.2, 0.04)]
    public void Subtract_TwoColors_WithTestCases(double r1, double g1, double b1, double r2, double g2, double b2, double expectedR, double expectedG, double expectedB)
    {
        RColor c1 = (r1, g1, b1);
        RColor c2 = (r2, g2, b2);
        RColor expected = (expectedR, expectedG, expectedB);

        RColor output = c1 * c2;

        Assert.That(output, Is.EqualTo(expected));
    }
}