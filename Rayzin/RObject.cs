namespace Rayzin;

public abstract class RObject
{
    public abstract RIntersection[] Intersect(RRay ray);

    public RMatrix Transformation { get; set; } = RMatrix.Identity4X4;
}