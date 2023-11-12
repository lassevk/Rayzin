namespace Rayzin;

public readonly record struct RMatrix
{
    private readonly double[] _values;

    public RMatrix(params double[] values)
    {
        _values = values ?? throw new ArgumentNullException(nameof(values));
        if (values.Length == 4)
            Size = 2;
        else if (values.Length == 9)
            Size = 3;
        else if (values.Length == 16)
            Size = 4;
        else
            throw new ArgumentOutOfRangeException(nameof(values), "values must have exactly 4, 9, or 16 items");
    }
    
    public int Size { get; }

    public double this[int x, int y]
    {
        get
        {
            if (x < 0 || x >= Size)
                throw new ArgumentOutOfRangeException(nameof(x), $"x must be in the range of 0..{Size}");
            if (y < 0 || y >= Size)
                throw new ArgumentOutOfRangeException(nameof(y), $"y must be in the range of 0..{Size}");

            return _values[x * Size + y];
        }
    }

    public bool Equals(RMatrix other)
    {
        if (Size != other.Size)
            return false;
        
        for (var index = 0; index < Size*Size; index++)
            if (!REpsilon.Equals(_values[index], other._values[index]))
                return false;

        return true;
    }
}