namespace Rayzin.Tests;

public class RVectorTests
{
    [Test]
    public void GetHashCode_ThrowsNotSupportedException()
    {
        RVector v = (1, 2, 3);

        Assert.Throws<NotSupportedException>(() => _ = v.GetHashCode());
    }

    [Test]
    public void DefaultConstructor()
    {
        RVector v = default;
        Assert.That(v, Is.EqualTo(new RVector(0, 0, 0)));
    }

    [Test]
    public void Construct_FromValueTuple()
    {
        var v = (RVector)new ValueTuple<double, double, double>(1, 2, 3);

        Assert.That(v.X, Is.EqualTo(1));
        Assert.That(v.Y, Is.EqualTo(2));
        Assert.That(v.Z, Is.EqualTo(3));
    }

    [Test]
    public void Construct_FromTuple()
    {
        var v = (RVector)new Tuple<double, double, double>(1, 2, 3);

        Assert.That(v.X, Is.EqualTo(1));
        Assert.That(v.Y, Is.EqualTo(2));
        Assert.That(v.Z, Is.EqualTo(3));
    }

    [Test]
    [TestCase(0, 0, 0)]
    [TestCase(1, 1, 1)]
    [TestCase(1.5, 2.5, 3.5)]
    [TestCase(4.3, -4.2, 3.1)]
    public void Constructor_TestCases(double x, double y, double z)
    {
        var vector = new RVector(x, y, z);

        Assert.That(vector.X, Is.EqualTo(x));
        Assert.That(vector.Y, Is.EqualTo(y));
        Assert.That(vector.Z, Is.EqualTo(z));
        Assert.That(vector.W, Is.EqualTo(0));
    }

    [Test]
    public void WithX()
    {
        var v1 = new RVector(4.3, -4.2, 3.1);
        RVector v2 = v1 with { X = 8.3 };

        Assert.That(v2.X, Is.EqualTo(8.3));
        Assert.That(v2.Y, Is.EqualTo(-4.2));
        Assert.That(v2.Z, Is.EqualTo(3.1));
        Assert.That(v2.W, Is.EqualTo(0.0));
    }
    
    [Test]
    public void WithY()
    {
        var v1 = new RVector(4.3, -4.2, 3.1);
        RVector v2 = v1 with { Y = 8.3 };

        Assert.That(v2.X, Is.EqualTo(4.3));
        Assert.That(v2.Y, Is.EqualTo(8.3));
        Assert.That(v2.Z, Is.EqualTo(3.1));
        Assert.That(v2.W, Is.EqualTo(0.0));
    }
    
    [Test]
    public void WithZ()
    {
        var v1 = new RVector(4.3, -4.2, 3.1);
        RVector v2 = v1 with { Z = 8.3 };

        Assert.That(v2.X, Is.EqualTo(4.3));
        Assert.That(v2.Y, Is.EqualTo(-4.2));
        Assert.That(v2.Z, Is.EqualTo(8.3));
        Assert.That(v2.W, Is.EqualTo(0.0));
    }

    [Test]
    public void Add_Vectors()
    {
        var v1 = new RVector(3, -2, 5);
        var v2 = new RVector(-2, 3, 1);

        RVector sum = v1 + v2;

        Assert.That(sum, Is.EqualTo(new RVector(1, 1, 6)));
    }

    [Test]
    public void Subtract_Vectors()
    {
        RVector v1 = (3, 2, 1);
        RVector v2 = (5, 6, 7);

        RVector result = v1 - v2;

        Assert.That(result, Is.EqualTo(new RVector(-2, -4, -6)));
    }

    [Test]
    public void Negate_Vector()
    {
        RVector v1 = (1, -2, 3);
        RVector v2 = -v1;

        Assert.That(v2, Is.EqualTo(new RVector(-1, 2, -3)));
    }

    [Test]
    [TestCase(1, -2, 3, 3.5, 3.5, -7, 10.5)]
    public void Multiply_WithTestCases(double x, double y, double z, double scalar, double expectedX, double expectedY, double expectedZ)
    {
        RVector a = (x, y, z);
        RVector b = a * scalar;

        Assert.That(b, Is.EqualTo(new RVector(expectedX, expectedY, expectedZ)));
    }
    
    [Test]
    [TestCase(3.5, -7, 10.5, 3.5, 1, -2, 3)]
    [TestCase(1, -2, 3, 2, 0.5, -1, 1.5)]
    public void Divide_WithTestCases(double x, double y, double z, double scalar, double expectedX, double expectedY, double expectedZ)
    {
        RVector a = (x, y, z);
        RVector b = a / scalar;

        Assert.That(b, Is.EqualTo(new RVector(expectedX, expectedY, expectedZ)));
    }
}