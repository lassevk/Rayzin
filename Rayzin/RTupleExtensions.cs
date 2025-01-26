using System.Numerics;

namespace Rayzin;

public static class RTupleExtensions
{
    public static double Magnitude(this RTuple<double> tuple) => Math.Sqrt(tuple.X * tuple.X + tuple.Y * tuple.Y + tuple.Z * tuple.Z + tuple.W * tuple.W);
}