namespace Rayzin.Tests;

public class RTupleTests
{
    [Test]
    public void Point_CreatesTupleWithWeq1()
    {
        var tuple = RTuple.Point(4.3, -4.2, 3.1);

        Assert.That(tuple.W, Is.EqualTo(1.0));
    }

    [Test]
    public void Vector_CreatesTupleWithWeq0()
    {
        var tuple = RTuple.Vector(4.3, -4.2, 3.1);

        Assert.That(tuple.W, Is.EqualTo(0.0));
    }
}