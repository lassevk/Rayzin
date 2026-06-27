using System.Diagnostics;

namespace Rayzin;

public class RayzinCanvas
{
    private readonly RayzinColor[] _pixels;

    public RayzinCanvas(int width, int height)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(width, 10);
        ArgumentOutOfRangeException.ThrowIfLessThan(height, 10);

        Width = width;
        Height = height;
        _pixels = new RayzinColor[width * height];
    }

    public int Width { get; }
    public int Height { get; }

    public RayzinColor this[int x, int y] {
        get
        {
            ArgumentOutOfRangeException.ThrowIfLessThan(x, 0);
            ArgumentOutOfRangeException.ThrowIfLessThan(y, 0);
            ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(x, Width);
            ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(y, Height);

            return _pixels[y * Width + x];
        }
        set
        {
            ArgumentOutOfRangeException.ThrowIfLessThan(x, 0);
            ArgumentOutOfRangeException.ThrowIfLessThan(y, 0);
            ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(x, Width);
            ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(y, Height);

            _pixels[y * Width + x] = value;
        }
    }
}