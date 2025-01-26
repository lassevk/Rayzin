﻿namespace Rayzin.Tests;

public class RTupleTests
{
    [Test]
    public void Point_CreatesTupleWithWeq1()
    {
        var tuple = RTuple.Point(4.3, -4.2, 3.1);

        Assert.That(tuple.W, Is.EqualTo(1.0));
        Assert.That(tuple.IsPoint, Is.True);
        Assert.That(tuple.IsVector, Is.False);
    }

    [Test]
    public void Vector_CreatesTupleWithWeq0()
    {
        var tuple = RTuple.Vector(4.3, -4.2, 3.1);

        Assert.That(tuple.W, Is.EqualTo(0.0));
        Assert.That(tuple.IsPoint, Is.False);
        Assert.That(tuple.IsVector, Is.True);
    }

    [Test]
    public void AddOperator_TwoPoints_ThrowsInvalidOperationException()
    {
        var p1 = RTuple.Point(3, -2, 5);
        var p2 = RTuple.Point(-2, 3, 1);

        Assert.Throws<InvalidOperationException>(() => _ = p1 + p2);
    }

    [Test]
    public void AddOperator_TwoVectors_ReturnsVector()
    {
        var p1 = RTuple.Vector(3, -2, 5);
        var p2 = RTuple.Vector(-2, 3, 1);

        RTuple<int> p3 = p1 + p2;

        Assert.That(p3, Is.EqualTo(RTuple.Vector(1, 1, 6)));
    }

    [Test]
    public void AddOperator_PointAndVector_ReturnsPoint()
    {
        var p1 = RTuple.Point(3, -2, 5);
        var p2 = RTuple.Vector(-2, 3, 1);

        RTuple<int> p3 = p1 + p2;

        Assert.That(p3, Is.EqualTo(RTuple.Point(1, 1, 6)));
    }

    [Test]
    public void AddOperator_VectorAndPoint_ReturnsPoint()
    {
        var p1 = RTuple.Vector(3, -2, 5);
        var p2 = RTuple.Point(-2, 3, 1);

        RTuple<int> p3 = p1 + p2;

        Assert.That(p3, Is.EqualTo(RTuple.Point(1, 1, 6)));
    }
}