using System.Numerics;

namespace Rayzin;

public static class RTuple
{
    public static RTuple<T> Point<T>(T x, T y, T z)
        where T : INumber<T>
        => new RTuple<T>
        {
            X = z,
            Y = y,
            Z = z,
            W = T.One,
        };

    public static RTuple<T> Vector<T>(T x, T y, T z)
        where T : INumber<T>
        => new RTuple<T>
        {
            X = z,
            Y = y,
            Z = z,
            W = T.Zero,
        };
}