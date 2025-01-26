using System.Numerics;
using System.Security.AccessControl;

namespace Rayzin;

public readonly record struct RTuple<T>
    where T : INumber<T>
{
    public required T X { get; init; }
    public required T Y { get; init; }
    public required T Z { get; init; }

    public required T W { get; init; }

    public bool IsPoint => W == T.One;
    public bool IsVector => W == T.Zero;

    public static RTuple<T> operator +(RTuple<T> left, RTuple<T> right)
    {
        if (left.IsPoint && right.IsPoint)
        {
            throw new InvalidOperationException("Cannot add two points.");
        }

        return new RTuple<T>
        {
            X = left.X + right.X, Y = left.Y + right.Y, Z = left.Z + right.Z, W = left.W + right.W,
        };
    }

    public static RTuple<T> operator -(RTuple<T> left, RTuple<T> right)
    {
        if (left.IsVector && right.IsPoint)
        {
            throw new InvalidOperationException("Cannot subtract a point from a vector.");
        }

        return new RTuple<T>
        {
            X = left.X - right.X, Y = left.Y - right.Y, Z = left.Z - right.Z, W = left.W - right.W,
        };
    }

    public static RTuple<T> operator -(RTuple<T> operand)
        => new RTuple<T>
        {
            X = -operand.X, Y = -operand.Y, Z = -operand.Z, W = -operand.W,
        };
}