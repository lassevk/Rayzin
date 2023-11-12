namespace Rayzin;

public readonly record struct RRay(RPoint Origin, RVector Direction)
{
    public RPoint Position(double t) => Origin + Direction * t;

    public static RRay operator *(RMatrix transform, RRay ray) => new RRay(transform * ray.Origin, transform * ray.Direction);
}