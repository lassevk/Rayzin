namespace Rayzin.Tests;

public class RTransformTests
{
    [Test]
    public void Translate()
    {
        RMatrix transform = RTransform.Translate(5, -3, 2);
        RPoint p = (-3, 4, 5);
        Assert.That(transform * p, Is.EqualTo(new RPoint(2, 1, 7)));
    }
    
    [Test]
    public void Translate_Inverse()
    {
        RMatrix transform = RTransform.Translate(5, -3, 2);
        RMatrix inv = transform.Invert();
        RPoint p = (-3, 4, 5);
        Assert.That(inv * p, Is.EqualTo(new RPoint(-8, 7, 3)));
    }

    [Test]
    public void Translate_Vector()
    {
        RMatrix transform = RTransform.Translate(5, -3, 2);
        RVector v = (-3, 4, 5);
        Assert.That(transform * v, Is.EqualTo(v));
    }
}