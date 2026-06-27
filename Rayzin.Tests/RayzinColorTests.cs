namespace Rayzin.Tests;

public class RayzinColorTests
{
    [Fact]
    public void Constructor_CreatesColorWithCorrectValues()
    {
        var color = new RayzinColor(-0.5, 0.4, 1.7);

        Assert.Equal(-0.5, color.X, RayzinConstants.Epsilon);
        Assert.Equal(0.4, color.Y, RayzinConstants.Epsilon);
        Assert.Equal(1.7, color.Z, RayzinConstants.Epsilon);
    }

    [Fact]
    public void Add_AddsColorComponents()
    {
        var color1 = new RayzinColor(0.9, 0.6, 0.75);
        var color2 = new RayzinColor(0.7, 0.1, 0.25);

        RayzinColor output = color1 + color2;

        Assert.Equal(new RayzinColor(1.6, 0.7, 1.0), output, RayzinColorApproximateComparer.Instance);
    }

    [Fact]
    public void Subtract_SubtractsColorComponents()
    {
        var color1 = new RayzinColor(0.9, 0.6, 0.75);
        var color2 = new RayzinColor(0.7, 0.1, 0.25);

        RayzinColor output = color1 - color2;

        Assert.Equal(new RayzinColor(0.2, 0.5, 0.5), output, RayzinColorApproximateComparer.Instance);
    }

    [Fact]
    public void MultiplyWithScalar_MultipliesColorComponents()
    {
        var color = new RayzinColor(0.2, 0.3, 0.4);

        RayzinColor output = color * 2;

        Assert.Equal(new RayzinColor(0.4, 0.6, 0.8), output, RayzinColorApproximateComparer.Instance);
    }

    [Fact]
    public void MultiplyScalarWithColor_MultipliesColorComponents()
    {
        var color = new RayzinColor(0.2, 0.3, 0.4);

        RayzinColor output = 2 * color;

        Assert.Equal(new RayzinColor(0.4, 0.6, 0.8), output, RayzinColorApproximateComparer.Instance);
    }

    [Fact]
    public void MultiplyTwoColors_MultipliesColorComponents()
    {
        var color1 = RayzinColor.Create(1, 0.2, 0.4);
        var color2 = RayzinColor.Create(0.9, 1, 0.1);

        RayzinColor output = color1 * color2;

        Assert.Equal(new RayzinColor(0.9, 0.2, 0.04), output, RayzinColorApproximateComparer.Instance);
    }

    [Theory]
    [InlineData(1, 2, 3, "RayzinColor { X = 1, Y = 2, Z = 3 }")]
    [InlineData(6, 5, 4, "RayzinColor { X = 6, Y = 5, Z = 4 }")]
    public void ToString_ReturnsExpectedString(double x, double y, double z, string expected)
    {
        var vector = new RayzinColor(x, y, z);

        string output = vector.ToString();

        Assert.Equal(expected, output);
    }

    [Theory]
    [InlineData(1, 2, 3, 1 + 1E-6, 2, 3)]
    [InlineData(1, 2, 3, 1, 2 + 1E-6, 3)]
    [InlineData(1, 2, 3, 1, 2, 3 + 1E-6)]
    public void ApproximatelyEquals_WithinEpsilon_ReturnsTrue(double x1, double y1, double z1, double x2, double y2, double z2)
    {
        var vector1 = new RayzinColor(x1, y1, z1);
        var vector2 = new RayzinColor(x2, y2, z2);

        bool output = vector1.ApproximatelyEquals(vector2);

        Assert.True(output);
    }

    [Theory]
    [InlineData(1, 2, 3, 1 + 1E-4, 2, 3)]
    [InlineData(1, 2, 3, 1, 2 + 1E-4, 3)]
    [InlineData(1, 2, 3, 1, 2, 3 + 1E-4)]
    public void ApproximatelyEquals_OutsideEpsilon_ReturnsFalse(double x1, double y1, double z1, double x2, double y2, double z2)
    {
        var vector1 = new RayzinColor(x1, y1, z1);
        var vector2 = new RayzinColor(x2, y2, z2);

        bool output = vector1.ApproximatelyEquals(vector2);

        Assert.False(output);
    }
}