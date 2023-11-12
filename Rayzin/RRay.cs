namespace Rayzin;

public readonly record struct RRay(RPoint Origin, RVector Direction)
{
    public RPoint Position(double t) => Origin + Direction * t;
}