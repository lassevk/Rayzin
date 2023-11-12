namespace Rayzin;

public abstract class RObject
{
    public abstract RIntersection[] Intersect(RRay ray);
}