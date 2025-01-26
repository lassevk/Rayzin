using System.Numerics;

namespace Rayzin;

public static class RTuple
{
    public static RTuple<T> Create<T>(T x, T y, T z, T w)
        where T : INumber<T>
        => new RTuple<T>
        {
            X = x,
            Y = y,
            Z = z,
            W = w,
        };

    public static RTuple<T> Point<T>(T x, T y, T z)
        where T : INumber<T>
        => Create(x, y, z, T.One);

    public static RTuple<T> Vector<T>(T x, T y, T z)
        where T : INumber<T>
        => Create(x, y, z, T.Zero);
}