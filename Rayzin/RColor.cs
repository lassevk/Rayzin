namespace Rayzin;

public record RColor(double R, double G, double B)
{
    public static implicit operator RColor(ValueTuple<double, double, double> t) => new(t.Item1, t.Item2, t.Item3);
    public static implicit operator RColor(Tuple<double, double, double> t) => new(t.Item1, t.Item2, t.Item3);
}