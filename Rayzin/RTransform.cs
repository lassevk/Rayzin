namespace Rayzin;

public static class RTransform
{
    public static RMatrix Translate(double x, double y, double z) => new(1, 0, 0, x, 0, 1, 0, y, 0, 0, 1, z, 0, 0, 0, 1);
    public static RMatrix Scale(double x, double y, double z) => new(x, 0, 0, 0, 0, y, 0, 0, 0, 0, z, 0, 0, 0, 0, 1);

    public static RMatrix RotateX(double radians)
    {
        var s = Math.Sin(radians);
        var c = Math.Cos(radians);
        return new RMatrix(1, 0, 0, 0, 0, c, -s, 0, 0, s, c, 0, 0, 0, 0, 1);
    }
    
    public static RMatrix RotateY(double radians)
    {
        var s = Math.Sin(radians);
        var c = Math.Cos(radians);
        return new RMatrix(c, 0, s, 0, 0, 1, 0, 0, -s, 0, c, 0, 0, 0, 0, 1);
    }
    
    public static RMatrix RotateZ(double radians)
    {
        var s = Math.Sin(radians);
        var c = Math.Cos(radians);
        return new RMatrix(c, -s, 0, 0, s, c, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1);
    }

    public static RMatrix Shear(double xy, double xz, double yx, double yz, double zx, double zy)
        => new(1, xy, xz, 0, yx, 1, yz, 0, zx, zy, 1, 0, 0, 0, 0, 1);
}