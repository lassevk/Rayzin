namespace Rayzin;

public readonly record struct RayzinColor(double X, double Y, double Z)
    : IRayzinTuple3<RayzinColor>
{
    public static RayzinColor Create(double x, double y, double z) => new(x, y, z);

    public bool ApproximatelyEquals(RayzinColor other) => RayzinColorApproximateComparer.Instance.Equals(this, other);

    public static RayzinColor operator +(RayzinColor color1, RayzinColor color2) => new(color1.X + color2.X, color1.Y + color2.Y, color1.Z + color2.Z);
    public static RayzinColor operator -(RayzinColor color1, RayzinColor color2) => new(color1.X - color2.X, color1.Y - color2.Y, color1.Z - color2.Z);

    public static RayzinColor operator *(RayzinColor color, double scalar) => new(color.X * scalar, color.Y * scalar, color.Z * scalar);
    public static RayzinColor operator *(double scalar, RayzinColor color) => new(color.X * scalar, color.Y * scalar, color.Z * scalar);
    public static RayzinColor operator *(RayzinColor color1, RayzinColor color2) => new(color1.X * color2.X, color1.Y * color2.Y, color1.Z * color2.Z);
}