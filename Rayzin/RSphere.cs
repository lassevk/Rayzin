namespace Rayzin;

public class RSphere : RObject
{
    public override RIntersection[] Intersect(RRay ray)
    {
        ray = Transformation.Invert() * ray;
        
        RVector sphereToRay = ray.Origin - RPoint.Origin;
        var a = ray.Direction * ray.Direction;
        var b = 2 * (ray.Direction * sphereToRay);
        var c = sphereToRay * sphereToRay - 1;
        var discriminant = b * b - 4 * a * c;
        if (discriminant < 0)
            return Array.Empty<RIntersection>();

        var dSqrt = Math.Sqrt(discriminant);
        var a2 = 2 * a;
        var t1 = (-b - dSqrt) / a2;
        var t2 = (-b + dSqrt) / a2;
        if (REpsilon.Equals(t1, t2))
            return new[] { new RIntersection(t1, this) };
        
        return new[] { new RIntersection(t1, this), new RIntersection(t2, this) };
    }
}