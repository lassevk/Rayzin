namespace Rayzin;

public class RCanvas
{
    public const int MaxWidth = 20480;
    public const int MaxHeight = 20480;
    
    private readonly RColor[,] _pixels;
    
    public RCanvas(int width, int height)
    {
        if (width < 1 || width > MaxWidth)
            throw new ArgumentOutOfRangeException(nameof(width), $"width must be in the range of 1..{MaxWidth}");
        
        if (height < 1 || height > MaxHeight)
            throw new ArgumentOutOfRangeException(nameof(height), $"height must be in the range of 1..{MaxHeight}");

        Width = width;
        Height = height;
        _pixels = new RColor[height, width];
    }
    
    public int Width { get; }
    public int Height { get; }

    public RColor this[int x, int y]
    {
        get
        {
            if (x < 0 || x >= Width)
                throw new ArgumentOutOfRangeException(nameof(x), $"x must be in the range of 0..{Width - 1}");
            if (y < 0 || y >= Height)
                throw new ArgumentOutOfRangeException(nameof(y), $"y must be in the range of 0..{Height - 1}");

            return _pixels[y, x];
        }

        set
        {
            if (x < 0 || x >= Width)
                throw new ArgumentOutOfRangeException(nameof(x), $"x must be in the range of 0..{Width - 1}");
            if (y < 0 || y >= Height)
                throw new ArgumentOutOfRangeException(nameof(y), $"y must be in the range of 0..{Height - 1}");

            _pixels[y, x] = value;
        }
    }
    
    public void Save(TextWriter writer, RCanvasFileFormat format = RCanvasFileFormat.PPM8)
    {
        writer.WriteLine("P3");
        writer.WriteLine($"{Width} {Height}");

        var max = format switch
        {
            RCanvasFileFormat.PPM8 => 255,
            RCanvasFileFormat.PPM16 => 65535,
            _ => throw new NotSupportedException()
        };

        writer.WriteLine(max.ToString());

        for (var y = 0; y < Height; y++)
        {
            var totalLength = 0;
            for (var x = 0; x < Width; x++)
            {
                RColor pixel = this[x, y];
                for (var channel = 0; channel < 3; channel++)
                {
                    var colorValue = channel switch
                    {
                        0 => pixel.R,
                        1 => pixel.G,
                        2 => pixel.B,
                        _ => 0
                    };

                    var outputValue = (int)(colorValue * max + 0.5);
                    if (outputValue < 0)
                        outputValue = 0;
                    else if (outputValue > max)
                        outputValue = max;

                    var outputString = outputValue.ToString();
                    
                    int space = totalLength > 0 ? 1 : 0;
                    if (totalLength + space + outputString.Length > 70)
                    {
                        writer.WriteLine();
                        totalLength = outputString.Length;
                    }
                    else
                    {
                        if (totalLength > 0)
                        {
                            writer.Write(" ");
                            totalLength++;
                        }

                        totalLength += outputString.Length;
                    }
                    writer.Write(outputString);
                }
            }

            writer.WriteLine();
        }

        return;

        int ToInt(double value)
        {
            return Math.Min(max, Math.Max(0, (int)(value * max +  0.5)));
        }
    }

    public void Save(string filename, RCanvasFileFormat format = RCanvasFileFormat.PPM8)
    {
        using StreamWriter writer = File.CreateText(filename);
        Save(writer, format);
    }

    public void Clear(RColor color)
    {
        for (var y = 0; y < Height; y++)
            for (var x = 0; x < Width; x++)
                _pixels[y, x] = color;
    }
}