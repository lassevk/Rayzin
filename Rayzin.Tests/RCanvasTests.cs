namespace Rayzin.Tests;

public class RCanvasTests
{
    [Test]
    [TestCase(0, 10)]
    [TestCase(10, 0)]
    [TestCase(RCanvas.MaxWidth + 1, 10)]
    [TestCase(10, RCanvas.MaxHeight + 1)]
    public void Constructor_InvalidSizeValues_ThrowsArgumentOutOfRangeException(int width, int height)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _ = new RCanvas(width, height));
    }

    [Test]
    [TestCase(-1, 0)]
    [TestCase(0, -1)]
    [TestCase(10, 0)]
    [TestCase(0, 10)]
    public void ReadPixel_OutOfBounds_ThrowsArgumentOutOfRangeException(int x, int y)
    {
        var canvas = new RCanvas(10, 10);

        Assert.Throws<ArgumentOutOfRangeException>(() => _ = canvas[x, y]);
    }

    [Test]
    [TestCase(-1, 0)]
    [TestCase(0, -1)]
    [TestCase(10, 0)]
    [TestCase(0, 10)]
    public void WritePixel_OutOfBounds_ThrowsArgumentOutOfRangeException(int x, int y)
    {
        var canvas = new RCanvas(10, 10);

        Assert.Throws<ArgumentOutOfRangeException>(() => canvas[x, y] = RColor.Black);
    }
    
    [Test]
    public void DefaultColor_IsBlack()
    {
        var canvas = new RCanvas(10, 20);
        
        for (var x = 0; x < 10; x++)
            for (var y = 0; y < 20; y++)
                Assert.That(canvas[x, y], Is.EqualTo(RColor.Black));
    }

    [Test]
    public void Constructor_SetsCorrectProperties()
    {
        var canvas = new RCanvas(10, 20);
        
        Assert.That(canvas.Width, Is.EqualTo(10));
        Assert.That(canvas.Height, Is.EqualTo(20));
    }

    [Test]
    public void PixelsAreCorrectlyStored()
    {
        var canvas = new RCanvas(10, 20);

        canvas[2, 3] = RColor.Red;
        Assert.That(canvas[2, 3], Is.EqualTo(RColor.Red));
    }
}