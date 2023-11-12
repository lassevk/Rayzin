namespace Rayzin;

public static class RTransform
{
    public static RMatrix Translate(int x, int y, int z) => new(1, 0, 0, x, 0, 1, 0, y, 0, 0, 1, z, 0, 0, 0, 1);
}