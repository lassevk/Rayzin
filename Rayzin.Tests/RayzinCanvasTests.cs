namespace Rayzin.Tests;

public class RayzinCanvasTests
{
    [Theory]
    [InlineData(32, 33)]
    [InlineData(33, 32)]
    [InlineData(1, 200)]
    [InlineData(200, 1)]
    public void Constructor_WithWidthAndHeightInsideOfLegalRange_ConstructsCanvasWithCorrectWidthAndHeight(int width, int height)
    {
        var canvas = new RayzinCanvas(width, height);

        Assert.Equal(width, canvas.Width);
        Assert.Equal(height, canvas.Height);
    }

    [Theory]
    [InlineData(0, 16)]
    [InlineData(16, 0)]
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

    [Fact]
    public void SaveToPpm_CorrectHeader()
    {
        var canvas = new RayzinCanvas(5, 3);
        string ppm = canvas.AsPpm();

        string[] lines = ppm.Split('\n', '\r').Where(l => !string.IsNullOrWhiteSpace(l)).ToArray();
        Assert.Equal("P3", lines[0]);
        Assert.Equal("5 3", lines[1]);
        Assert.Equal("255", lines[2]);
    }

    [Fact]
    public void SaveToPpm_CorrectPixelData()
    {
        var canvas = new RayzinCanvas(5, 3);
        canvas[0, 0] = new RayzinColor(1.5, 0, 0);
        canvas[2, 1] = new RayzinColor(0, 0.5, 0);
        canvas[4, 2] = new RayzinColor(-0.5, 0, 1);

        string ppm = canvas.AsPpm();
        string[] lines = ppm.Split('\n', '\r').Where(l => !string.IsNullOrWhiteSpace(l)).ToArray();

        Assert.Equal("255 0 0 0 0 0 0 0 0 0 0 0 0 0 0", lines[3]);
        Assert.Equal("0 0 0 0 0 0 0 128 0 0 0 0 0 0 0", lines[4]);
        Assert.Equal("0 0 0 0 0 0 0 0 0 0 0 0 0 0 255", lines[5]);
    }

    [Fact]
    public void SaveToPpm_NoLineExceeds70Characters()
    {
        var canvas = new RayzinCanvas(10, 2);
        for (int y = 0; y < 2; y++)
        {
            for (int x = 0; x < 10; x++)
            {
                canvas[x, y] = new RayzinColor(1, 0.8, 0.6);
            }
        }

        string ppm = canvas.AsPpm();
        string[] lines = ppm.Split('\n', '\r').Where(l => !string.IsNullOrWhiteSpace(l)).ToArray();

        Assert.Equal("255 204 153 255 204 153 255 204 153 255 204 153 255 204 153 255 204", lines[3]);
        Assert.Equal("153 255 204 153 255 204 153 255 204 153 255 204 153", lines[4]);
        Assert.Equal("255 204 153 255 204 153 255 204 153 255 204 153 255 204 153 255 204", lines[5]);
        Assert.Equal("153 255 204 153 255 204 153 255 204 153 255 204 153", lines[6]);
    }
}