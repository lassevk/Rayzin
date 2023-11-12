namespace Rayzin;

public readonly record struct RMatrix
{
    private readonly double[] _values;
    private readonly int _size;

    public RMatrix(params double[] values)
    {
        _values = values ?? throw new ArgumentNullException(nameof(values));
        if (values.Length == 4)
            _size = 2;
        else if (values.Length == 9)
            _size = 3;
        else if (values.Length == 16)
            _size = 4;
        else
            throw new ArgumentOutOfRangeException(nameof(values), "values must have exactly 4, 9, or 16 items");
    }

    public double this[int x, int y]
    {
        get
        {
            if (x < 0 || x >= _size)
                throw new ArgumentOutOfRangeException(nameof(x), $"x must be in the range of 0..{_size}");
            if (y < 0 || y >= _size)
                throw new ArgumentOutOfRangeException(nameof(y), $"y must be in the range of 0..{_size}");

            return _values[x * _size + y];
        }
    }
}