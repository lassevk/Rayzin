namespace Rayzin;

public record RColor(double R, double G, double B)
{
    public static implicit operator RColor(ValueTuple<double, double, double> t) => new(t.Item1, t.Item2, t.Item3);
    public static implicit operator RColor(Tuple<double, double, double> t) => new(t.Item1, t.Item2, t.Item3);

    public static RColor operator +(RColor c1, RColor c2) => new RColor(c1.R + c2.R, c1.G + c2.G, c1.B + c2.B);
    public static RColor operator -(RColor c1, RColor c2) => new RColor(c1.R - c2.R, c1.G - c2.G, c1.B - c2.B);
    public static RColor operator *(RColor c, double scalar) => new RColor(c.R * scalar, c.G * scalar, c.B * scalar);
    public static RColor operator *(RColor c1, RColor c2) => new RColor(c1.R * c2.R, c1.G * c2.G, c1.B * c2.B);
}