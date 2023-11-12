namespace Rayzin.Tests;

public class RShereTests
{
    [Test]
    public void IntersectWithRay()
    {
        var r = new RRay((0, 0, -5), (0, 0, 1));
        var s = new RSphere();
        var xs = s.Intersect(r);

        CollectionAssert.AreEqual(new[]
        {
            new RIntersection(4, s),
            new RIntersection(6, s)
        }, xs);
    }
    
    [Test]
    public void IntersectWithRayAtATangent()
    {
        var r = new RRay((0, 1, -5), (0, 0, 1));
        var s = new RSphere();
        RIntersection[] xs = s.Intersect(r);

        CollectionAssert.AreEqual(new[]
        {
            new RIntersection(5, s),
            new RIntersection(5, s)
        }, xs);
    }
    
    [Test]
    public void RayMissesSphere()
    {
        var r = new RRay((0, 2, -5), (0, 0, 1));
        var s = new RSphere();
        RIntersection[] xs = s.Intersect(r);
        CollectionAssert.IsEmpty(xs);
    }
    
    [Test]
    public void RayStartsInsideSphere()
    {
        var r = new RRay((0, 0, 0), (0, 0, 1));
        var s = new RSphere();
        RIntersection[] xs = s.Intersect(r);

        CollectionAssert.AreEqual(new[]
        {
            new RIntersection(-1, s),
            new RIntersection(1, s)
        }, xs);
    }
    
    [Test]
    public void RayMovesAwayFromSphere()
    {
        var r = new RRay((0, 0, 5), (0, 0, 1));
        var s = new RSphere();
        RIntersection[] xs = s.Intersect(r);

        CollectionAssert.AreEqual(new[]
        {
            new RIntersection(-6.0, s),
            new RIntersection(-4.0, s)
        }, xs);
    }
}