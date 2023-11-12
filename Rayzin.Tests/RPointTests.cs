namespace Rayzin.Tests;

public class RPointTests
{
    [Test]
    public void Construct_FromValueTuple()
    {
        var p = (RPoint)new ValueTuple<double, double, double>(1, 2, 3);

        Assert.That(p.X, Is.EqualTo(1));
        Assert.That(p.Y, Is.EqualTo(2));
        Assert.That(p.Z, Is.EqualTo(3));
    }

    [Test]
    public void Construct_FromTuple()
    {
        var p = (RPoint)new Tuple<double, double, double>(1, 2, 3);

        Assert.That(p.X, Is.EqualTo(1));
        Assert.That(p.Y, Is.EqualTo(2));
        Assert.That(p.Z, Is.EqualTo(3));
    }
    
    [Test]
    [TestCase(0, 0, 0)]
    [TestCase(1, 1, 1)]
    [TestCase(1.5, 2.5, 3.5)]
    [TestCase(4.3, -4.2, 3.1)]
    public void Constructor_TestCases(double x, double y, double z)
    {
        var point = new RPoint(x, y, z);
        
        Assert.That(point.X, Is.EqualTo(x));
        Assert.That(point.Y, Is.EqualTo(y));
        Assert.That(point.Z, Is.EqualTo(z));
        Assert.That(point.W, Is.EqualTo(1));
    }

    [Test]
    public void WithX()
    {
        var p1 = new RPoint(4.3, -4.2, 3.1);
        RPoint p2 = p1 with { X = 8.3 };

        Assert.That(p2, Is.EqualTo(new RPoint(8.3, -4.2, 3.1)));
    }
    
    [Test]
    public void WithY()
    {
        var p1 = new RPoint(4.3, -4.2, 3.1);
        RPoint p2 = p1 with { Y = 8.3 };

        Assert.That(p2, Is.EqualTo(new RPoint(4.3, 8.3, 3.1)));
    }
    
    [Test]
    public void WithZ()
    {
        var p1 = new RPoint(4.3, -4.2, 3.1);
        RPoint p2 = p1 with { Z = 8.3 };

        Assert.That(p2, Is.EqualTo(new RPoint(4.3, -4.2, 8.3)));
    }

    [Test]
    public void Add_PointAndVector()
    {
        var a1 = new RPoint(3, -2, 5);
        var a2 = new RVector(-2, 3, 1);

        RPoint sum = a1 + a2;

        Assert.That(sum, Is.EqualTo(new RPoint(1, 1, 6)));
    }
    
    [Test]
    public void Add_VectorAndPoint()
    {
        RPoint a1 = (3, -2, 5);
        RVector a2 = (-2, 3, 1);

        RPoint sum = a2 + a1;

        Assert.That(sum, Is.EqualTo(new RPoint(1, 1, 6)));
    }

    [Test]
    public void Subtract_Points_GivesAVector()
    {
        RPoint p1 = (3, 2, 1);
        RPoint p2 = (5, 6, 7);

        RVector result = p1 - p2;

        Assert.That(result, Is.EqualTo(new RVector(-2, -4, -6)));
    }

    [Test]
    public void Subtract_VectorFromPoint()
    {
        RPoint p = (3, 2, 1);
        RVector v = (5, 6, 7);

        RPoint result = p - v;
        Assert.That(result, Is.EqualTo(new RPoint(-2, -4, -6)));
    }
}