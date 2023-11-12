namespace Rayzin.Tests;

public class RIntersectionTests
{
    [Test]
    public void HitWhenAllIntersectionsHavePositiveT()
    {
        var s = new RSphere();
        var i1 = new RIntersection(1, s);
        var i2 = new RIntersection(2, s);
        RIntersection[] xs = { i1, i2 };
        RIntersection? i = xs.Hit();
        Assert.That(i, Is.EqualTo(i1));
    }
    
    [Test]
    public void HitWhenSomeIntersectionsHaveNegativeT()
    {
        var s = new RSphere();
        var i1 = new RIntersection(-1, s);
        var i2 = new RIntersection(1, s);
        RIntersection[] xs = { i1, i2 };
        RIntersection? i = xs.Hit();
        Assert.That(i, Is.EqualTo(i2));
    }
    
    [Test]
    public void HitWhenAllIntersectionsHaveNegativeT()
    {
        var s = new RSphere();
        var i1 = new RIntersection(-2, s);
        var i2 = new RIntersection(-1, s);
        RIntersection[] xs = { i1, i2 };
        RIntersection? i = xs.Hit();
        Assert.That(i, Is.Null);
    }

    [Test]
    public void TheHitIsAlwaysTheLowestNonNegativeIntersection()
    {
        var s = new RSphere();
        var i1 = new RIntersection(5, s);
        var i2 = new RIntersection(7, s);
        var i3 = new RIntersection(-3, s);
        var i4 = new RIntersection(2, s);
        RIntersection[] xs = new[] { i1, i2, i3, i4 };
        RIntersection? i = xs.Hit();
        Assert.That(i, Is.EqualTo(i4));
    }
}