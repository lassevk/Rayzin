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
}