using System.Diagnostics;

namespace Rayzin;

public class RayzinCanvas
{
    private readonly RayzinColor[] _pixels;

    public RayzinCanvas(int width, int height)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(width, 1);
        ArgumentOutOfRangeException.ThrowIfLessThan(height, 1);

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

    public void SavePpmToStream(Stream target)
    {
        using var writer = new StreamWriter(target);
        SavePpmToTextWriter(writer);
    }

    public void SavePpmToTextWriter(TextWriter target)
    {
        target.WriteLine("P3");
        target.WriteLine($"{Width} {Height}");
        target.WriteLine("255");

        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                RayzinColor color = this[x, y].Clamp();

                target.Write($"{(int)(color.X * 255 + 0.5)} {(int)(color.Y * 255 + 0.5)} {(int)(color.Z * 255 + 0.5)}");
                if (x < Width - 1)
                {
                    target.Write(" ");
                }
            }
            target.WriteLine();

        }
    }

    public void SavePpmToFile(string path)
    {
        using var writer = new StreamWriter(path);
        SavePpmToTextWriter(writer);
    }

    public string AsPpm()
    {
        var writer = new StringWriter();
        SavePpmToTextWriter(writer);
        return writer.ToString();
    }
}