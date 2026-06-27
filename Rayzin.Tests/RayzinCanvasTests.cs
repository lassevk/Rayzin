namespace Rayzin.Tests;

public class RayzinCanvasTests
{
    [Theory]
    [InlineData(32, 33)]
    [InlineData(33, 32)]
    [InlineData(16, 200)]
    [InlineData(200, 16)]
    public void Constructor_WithWidthAndHeightInsideOfLegalRange_ConstructsCanvasWithCorrectWidthAndHeight(int width, int height)
    {
        var canvas = new RayzinCanvas(width, height);

        Assert.Equal(width, canvas.Width);
        Assert.Equal(height, canvas.Height);
    }

    [Theory]
    [InlineData(9, 16)]
    [InlineData(16, 9)]
    [InlineData(0, 16)]
    [InlineData(9, 200)]
    [InlineData(200, 9)]
    public void Constructor_WithWidthOrHeightOutsideOfLegalRange_ThrowsArgumentOutOfRangeException(int width, int height)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new RayzinCanvas(width, height));
    }

    [Fact]
    public void WritePixelToCanvas_PixelCanBeReadBack()
    {
        var canvas = new RayzinCanvas(10, 20)
        {
            [2, 3] = RayzinColor.Red,
        };

        RayzinColor pixel = canvas[2, 3];

        Assert.Equal(RayzinColor.Red, pixel);
    }
}