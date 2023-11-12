namespace Rayzin;

public readonly record struct RColor(double R, double G, double B)
{
    public static readonly RColor Black = (0, 0, 0);
    public static readonly RColor White = (1, 1, 0);
    public static readonly RColor Red = (1, 0, 0);
    public static readonly RColor Green = (0, 1, 0);
    public static readonly RColor Blue = (0, 0, 1);
    
    public static implicit operator RColor(ValueTuple<double, double, double> t) => new(t.Item1, t.Item2, t.Item3);
    public static implicit operator RColor(Tuple<double, double, double> t) => new(t.Item1, t.Item2, t.Item3);

    public static RColor operator +(RColor c1, RColor c2) => new RColor(c1.R + c2.R, c1.G + c2.G, c1.B + c2.B);
    public static RColor operator -(RColor c1, RColor c2) => new RColor(c1.R - c2.R, c1.G - c2.G, c1.B - c2.B);
    public static RColor operator *(RColor c, double scalar) => new RColor(c.R * scalar, c.G * scalar, c.B * scalar);
    public static RColor operator *(RColor c1, RColor c2) => new RColor(c1.R * c2.R, c1.G * c2.G, c1.B * c2.B);
    
    public override int GetHashCode() => throw new NotSupportedException();

    public bool Equals(RColor other) => REpsilon.Equals(R, other.R) && REpsilon.Equals(G, other.G) && REpsilon.Equals(B, other.B);
}