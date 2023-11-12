namespace Rayzin.Tests;

public class RSphereTests
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

    [Test]
    public void DefaultSphereTranslationMatrix()
    {
        var s = new RSphere();
        Assert.That(s.Transformation, Is.EqualTo(RMatrix.Identity4X4));
    }

    [Test]
    public void ChangingSphereTransformation()
    {
        var s = new RSphere { Transformation = RTransform.Translate(2, 3, 4) };

        Assert.That(s.Transformation, Is.EqualTo(RTransform.Translate(2, 3, 4)));
    }

    [Test]
    public void IntersectScaledSphereWithRay()
    {
        var r = new RRay((0, 0, -5), (0, 0, 1));
        var s = new RSphere { Transformation = RTransform.Scale(2, 2, 2) };
        RIntersection[] xs = s.Intersect(r);

        CollectionAssert.AreEqual(new[] { new RIntersection(3, s), new RIntersection(7, s) }, xs);
    }
    
    [Test]
    public void IntersectTranslatedSphereWithRay()
    {
        var r = new RRay((0, 0, -5), (0, 0, 1));
        var s = new RSphere { Transformation = RTransform.Translate(5, 0, 0) };
        RIntersection[] xs = s.Intersect(r);

        CollectionAssert.IsEmpty(xs);
    }
}