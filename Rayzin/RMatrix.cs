using System.Globalization;
using System.Text;

namespace Rayzin;

public readonly record struct RMatrix
{
    private readonly double[] _values;

    public static readonly RMatrix Identity2X2 = new RMatrix(1, 0, 0, 1);
    public static readonly RMatrix Identity3X3 = new RMatrix(1, 0, 0, 0, 1, 0, 0, 0, 1);
    public static readonly RMatrix Identity4X4 = new RMatrix(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1);

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

    public static RMatrix operator *(RMatrix a, RMatrix b)
    {
        var values = new double[a.Size * a.Size];

        for (var y = 0; y < a.Size; y++)
        {
            for (var x = 0; x < a.Size; x++)
            {
                double sum = 0;

                for (var index = 0; index < a.Size; index++)
                {
                    sum += a[y, index] * b[index, x];
                }

                values[y * a.Size + x] = sum;
            }
        }

        return new RMatrix(values);
    }

    public static double[] operator *(RMatrix m, double[] t)
    {
        var values = new double[m.Size];

        for (var y = 0; y < m.Size; y++)
        {
            double sum = 0;

            for (var index = 0; index < m.Size; index++)
            {
                sum += m[y, index] * t[index];
            }

            values[y] = sum;
        }

        return values;
    }

    public static RPoint operator *(RMatrix m, RPoint p)
    {
        if (m.Size != 4)
            throw new InvalidOperationException("Can only multiply 4x4 matrices with points");
        
        var tuple = new[] { p.X, p.Y, p.Z, p.W };
        var result = m * tuple;

        if (!REpsilon.Equals(result[3], 1))
            throw new InvalidOperationException("Cannot multiply matrix with point, as the result is not a new point");

        return new RPoint(result[0], result[1], result[2]);
    }
    
    public static RVector operator *(RMatrix m, RVector v)
    {
        if (m.Size != 4)
            throw new InvalidOperationException("Can only multiply 4x4 matrices with vectors");
        
        var tuple = new[] { v.X, v.Y, v.Z, v.W };
        var result = m * tuple;

        if (!REpsilon.Equals(result[3], 0))
            throw new InvalidOperationException("Cannot multiply matrix with vector, as the result is not a new point");

        return new RVector(result[0], result[1], result[2]);
    }

    public RMatrix Transpose()
    {
        var values = new double[Size * Size];
        for (var y = 0; y < Size; y++)
            for (var x = 0; x < Size; x++)
                values[x * Size + y] = _values[y * Size + x];

        return new RMatrix(values);
    }

    public RMatrix SubMatrix(int row, int column)
    {
        if (row < 0 || row >= Size)
            throw new ArgumentOutOfRangeException(nameof(row), $"row must be in the range of 0..{Size - 1}");
        if (column < 0 || column >= Size)
            throw new ArgumentOutOfRangeException(nameof(column), $"row must be in the range of 0..{Size - 1}");
        if (Size == 2)
            throw new NotSupportedException("SubMatrix is not supported for 2x2 matrices");

        var values = new double[(Size - 1) * (Size - 1)];
        var yOut = 0;
        for (var y = 0; y < Size; y++)
        {
            if (y == row)
                continue;
            
            var xOut = 0;
            for (var x = 0; x < Size; x++)
            {
                if (x == column)
                    continue;

                values[yOut * (Size - 1) + xOut] = _values[y * Size + x];
                xOut++;
            }

            yOut++;
        }

        return new RMatrix(values);
    }

    private bool PrintMembers(StringBuilder builder)
    {
        for (var y = 0; y < Size; y++)
        {
            if (y > 0)
                builder.Append(' ');
            
            builder.Append('[');
            for (var x = 0; x < Size; x++)
            {
                if (x > 0)
                    builder.Append(' ');
                
                builder.Append(this[y, x].ToString("0.#####", CultureInfo.InvariantCulture));
            }
            builder.Append(']');
        }

        return true;
    }

    public double Determinant()
    {
        if (Size == 2)
            return _values[0] * _values[3] - _values[1] * _values[2];

        var sum = 0.0;
        for (var x = 0; x < Size; x++)
            sum += _values[x] * CoFactor(0, x);

        return sum;
    }

    public double Minor(int row, int column) => SubMatrix(row, column).Determinant();

    public double CoFactor(int row, int column)
    {
        var minor = Minor(row, column);
        if ((row + column) % 2 != 0)
            minor = -minor;

        return minor;
    }
}