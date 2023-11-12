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

    [Test]
    [TestCase(1, 0, 0, 1)]
    [TestCase(0, 1, 0, 1)]
    [TestCase(0, 0, 1, 1)]
    [TestCase(1, 2, 3, 3.74165738677)]
    [TestCase(-1, -2, -3, 3.74165738677)]
    public void Magnitude_WithTestCases(double x, double y, double z, double expected)
    {
        RVector v = (x, y, z);
        var magnitude = v.Magnitude;

        Assert.That(magnitude, Is.EqualTo(expected).Within(REpsilon.Threshold));
    }

    [Test]
    [TestCase(4, 0, 0, 1, 0, 0)]
    [TestCase(-4, 0, 0, -1, 0, 0)]
    [TestCase(0, 4, 0, 0, 1, 0)]
    [TestCase(0, -4, 0, 0, -1, 0)]
    [TestCase(0, 0, 4, 0, 0, 1)]
    [TestCase(0, 0, -4, 0, 0, -1)]
    [TestCase(1, 2, 3, 0.26726, 0.53452, 0.80178)]
    public void Normalize_WithTestCases(double x, double y, double z, double expectedX, double expectedY, double expectedZ)
    {
        RVector v = (x, y, z);
        RVector output = v.Normalize();

        Assert.That(output, Is.EqualTo(new RVector(expectedX, expectedY, expectedZ)));
    }

    [Test]
    public void DotProduct()
    {
        RVector a = (1, 2, 3);
        RVector b = (2, 3, 4);

        var dot = a * b;

        Assert.That(dot, Is.EqualTo(20));
    }

    [Test]
    [TestCase(1, 2, 3, 2, 3, 4, -1, 2, -1)]
    [TestCase(2, 3, 4, 1, 2, 3, 1, -2, 1)]
    public void CrossProduct(double x1, double y1, double z1, double x2, double y2, double z2, double expectedX, double expectedY, double expectedZ)
    {
        RVector a = (x1, y1, z1);
        RVector b = (x2, y2, z2);
        RVector cross = a.Cross(b);

        Assert.That(cross, Is.EqualTo(new RVector(expectedX, expectedY, expectedZ)));
    }
}