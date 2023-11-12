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

    [Test]
    public void Scale_Point()
    {
        RMatrix transform = RTransform.Scale(2, 3, 4);
        RPoint p = (-4, 6, 8);
        Assert.That(transform * p, Is.EqualTo(new RPoint(-8, 18, 32)));
    }
    
    [Test]
    public void Scale_Vector()
    {
        RMatrix transform = RTransform.Scale(2, 3, 4);
        RVector v = (-4, 6, 8);
        Assert.That(transform * v, Is.EqualTo(new RVector(-8, 18, 32)));
    }
    
    [Test]
    public void ScaleInverse_Vector()
    {
        RMatrix transform = RTransform.Scale(2, 3, 4);
        RMatrix inv = transform.Invert();
        RVector v = (-4, 6, 8);
        Assert.That(inv * v, Is.EqualTo(new RVector(-2, 2, 2)));
    }

    [Test]
    public void ScaleReflection_Point()
    {
        RMatrix transform = RTransform.Scale(-1, 1, 1);
        RPoint p = (2, 3, 4);
        Assert.That(transform * p, Is.EqualTo(new RPoint(-2, 3, 4)));
    }

    [Test]
    public void RotateX_Point()
    {
        RPoint p = (0, 1, 0);
        RMatrix halfQuarter = RTransform.RotateX(Math.PI / 4);
        RMatrix fullQuarter = RTransform.RotateX(Math.PI / 2);
        Assert.That(halfQuarter * p, Is.EqualTo(new RPoint(0, Math.Sqrt(2) / 2, Math.Sqrt(2) / 2)));
        Assert.That(fullQuarter * p, Is.EqualTo(new RPoint(0, 0, 1)));
    }
    
    [Test]
    public void RotateXInverse_Point()
    {
        RPoint p = (0, 1, 0);
        RMatrix halfQuarter = RTransform.RotateX(Math.PI / 4);
        RMatrix inv = halfQuarter.Invert();
        Assert.That(inv * p, Is.EqualTo(new RPoint(0, Math.Sqrt(2) / 2, -Math.Sqrt(2) / 2)));
    }
    
    [Test]
    public void RotateY_Point()
    {
        RPoint p = (0, 0, 1);
        RMatrix halfQuarter = RTransform.RotateY(Math.PI / 4);
        RMatrix fullQuarter = RTransform.RotateY(Math.PI / 2);
        Assert.That(halfQuarter * p, Is.EqualTo(new RPoint(Math.Sqrt(2) / 2, 0, Math.Sqrt(2) / 2)));
        Assert.That(fullQuarter * p, Is.EqualTo(new RPoint(1, 0, 0)));
    }
    
    [Test]
    public void RotateZ_Point()
    {
        RPoint p = (0, 1, 0);
        RMatrix halfQuarter = RTransform.RotateZ(Math.PI / 4);
        RMatrix fullQuarter = RTransform.RotateZ(Math.PI / 2);
        Assert.That(halfQuarter * p, Is.EqualTo(new RPoint(-Math.Sqrt(2) / 2, Math.Sqrt(2) / 2, 0)));
        Assert.That(fullQuarter * p, Is.EqualTo(new RPoint(-1, 0, 0)));
    }
}