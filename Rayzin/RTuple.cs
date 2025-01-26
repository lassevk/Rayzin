using System.Numerics;

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
}