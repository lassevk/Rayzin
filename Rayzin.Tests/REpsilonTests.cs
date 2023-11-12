namespace Rayzin.Tests;

public class REpsilonTests
{
    [Test]
    [TestCase(0, 0, true)]
    [TestCase(1, 1, true)]
    [TestCase(1, 1.1, false)]
    [TestCase(1, 1.01, false)]
    [TestCase(1, 1.001, false)]
    [TestCase(1, 1.0001, false)]
    [TestCase(1, 1.00001, false)]
    [TestCase(1, 1.000001, true)]
    public void Equals_TestCases(double a, double b, bool expected)
    {
        var output = REpsilon.Equals(a, b);

        Assert.That(output, Is.EqualTo(expected));
    }
}