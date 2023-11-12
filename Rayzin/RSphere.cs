namespace Rayzin;

public class RSphere : RObject
{
    public override RIntersection[] Intersect(RRay ray)
    {
        RVector sphereToRay = ray.Origin - RPoint.Origin;
        var a = ray.Direction * ray.Direction;
        var b = 2 * (ray.Direction * sphereToRay);
        var c = (sphereToRay * sphereToRay) - 1;
        var discriminant = b * b - 4 * a * c;
        if (discriminant < 0)
            return Array.Empty<RIntersection>();

        var t1 = (-b - Math.Sqrt(discriminant)) / (2 * a);
        var t2 = (-b + Math.Sqrt(discriminant)) / (2 * a);
        return new[] { new RIntersection(t1, this), new RIntersection(t2, this) };
    }
}