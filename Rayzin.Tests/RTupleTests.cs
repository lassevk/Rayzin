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

    [Test]
    public void SubtractOperator_PointAndVector_ReturnsPoint()
    {
        var p1 = RTuple.Point(3, 2, 1);
        var p2 = RTuple.Vector(5, 6, 7);

        RTuple<int> p3 = p1 - p2;

        Assert.That(p3, Is.EqualTo(RTuple.Point(-2, -4, -6)));
    }

    [Test]
    public void SubtractOperator_VectorAndPoint_ThrowsInvalidOperationException()
    {
        var p1 = RTuple.Vector(3, 2, 1);
        var p2 = RTuple.Point(5, 6, 7);

        Assert.Throws<InvalidOperationException>(() => _ = p1 - p2);
    }

    [Test]
    public void SubtractOperator_PointAndPoint_ReturnsVector()
    {
        var p1 = RTuple.Point(3, 2, 1);
        var p2 = RTuple.Point(5, 6, 7);

        RTuple<int> p3 = p1 - p2;

        Assert.That(p3, Is.EqualTo(RTuple.Vector(-2, -4, -6)));
    }

    [Test]
    public void SubtractOperator_VectorAndVector_ReturnsVector()
    {
        var p1 = RTuple.Vector(3, 2, 1);
        var p2 = RTuple.Vector(5, 6, 7);

        RTuple<int> p3 = p1 - p2;

        Assert.That(p3, Is.EqualTo(RTuple.Vector(-2, -4, -6)));
    }

    [Test]
    public void NegateOperator_Tuple_ReturnsNegatedTuple()
    {
        var t = RTuple.Create(1, -2, 3, -4);

        RTuple<int> n = -t;

        Assert.That(n, Is.EqualTo(RTuple.Create(-1, 2, -3, 4)));
    }

    [Test]
    public void Multiply_TupleByScalar_ReturnsTuple()
    {
        var t = RTuple.Create<double>(1, -2, 3, -4);

        RTuple<double> output = t * 3.5;

        Assert.That(output, Is.EqualTo(RTuple.Create<double>(3.5, -7, 10.5, -14)));
    }

    [Test]
    public void Multiply_ScalarByTuple_ReturnsTuple()
    {
        var t = RTuple.Create<double>(1, -2, 3, -4);

        RTuple<double> output = 3.5 * t;

        Assert.That(output, Is.EqualTo(RTuple.Create<double>(3.5, -7, 10.5, -14)));
    }

    [Test]
    public void Divide_TupleByScalar_ReturnsTuple()
    {
        var t = RTuple.Create<double>(1, -2, 3, -4);

        RTuple<double> output = t / 2.0;

        Assert.That(output, Is.EqualTo(RTuple.Create<double>(0.5, -1, 1.5, -2)));
    }

    [TestCase(1, 0, 0, 0, 1)]
    [TestCase(0, 1, 0, 0, 1)]
    [TestCase(0, 0, 1, 0, 1)]
    [TestCase(1, 2, 3, 0, 3.7416573867739413)]
    [TestCase(-1, -2, -3, 0, 3.7416573867739413)]
    public void Magnitude_WithTestCases(double x, double y, double z, double w, double expected)
    {
        var tuple = RTuple.Create(x, y, z, w);

        double output = tuple.Magnitude();

        Assert.That(output, Is.EqualTo(expected).Within(1E-5));
    }

    [TestCase(4, 0, 0, 1, 0, 0)]
    [TestCase(0, 4, 0, 0, 1, 0)]
    [TestCase(0, 0, 4, 0, 0, 1)]
    [TestCase(1, 2, 3, 0.2672612419124244, 0.5345224838248488, 0.8017837257372732)]
    public void Normalize_WithTestCases(double x, double y, double z, double expectedX, double expectedY, double expectedZ)
    {
        var vector = RTuple.Vector(x, y, z);

        RTuple<double> output = vector.Normalize();

        Assert.That(output, Is.EqualTo(RTuple.Vector(expectedX, expectedY, expectedZ)));
        Assert.That(output.Magnitude(), Is.EqualTo(1.0).Within(1E-5));
    }
}