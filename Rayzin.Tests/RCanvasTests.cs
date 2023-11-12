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
        var canvas = new RCanvas(10, 20) { [2, 3] = RColor.Red };

        Assert.That(canvas[2, 3], Is.EqualTo(RColor.Red));
    }

    [Test]
    public void Save_PPM8()
    {
        var canvas = new RCanvas(5, 3)
        {
            [0, 0] = (1.5, 0, 0),
            [2, 1] = (0, 0.5, 0),
            [4, 2] = (-0.5, 0, 1)
        };

        using var writer = new StringWriter();
        canvas.Save(writer, RCanvasFileFormat.PPM8);

        var expected = Utils.SplitLines(
            """
            P3
            5 3
            255
            255 0 0 0 0 0 0 0 0 0 0 0 0 0 0
            0 0 0 0 0 0 0 128 0 0 0 0 0 0 0
            0 0 0 0 0 0 0 0 0 0 0 0 0 0 255
            """);

        var output = Utils.SplitLines(writer.ToString());

        Assert.That(output, Is.EqualTo(expected));
    }
    
    [Test]
    public void Save_PPM16()
    {
        var canvas = new RCanvas(5, 3)
        {
            [0, 0] = (1.5, 0, 0),
            [2, 1] = (0, 0.5, 0),
            [4, 2] = (-0.5, 0, 1)
        };

        using var writer = new StringWriter();
        canvas.Save(writer, RCanvasFileFormat.PPM16);

        var expected = Utils.SplitLines(
            """
            P3
            5 3
            65535
            65535 0 0 0 0 0 0 0 0 0 0 0 0 0 0
            0 0 0 0 0 0 0 32768 0 0 0 0 0 0 0
            0 0 0 0 0 0 0 0 0 0 0 0 0 0 65535
            """);

        var output = Utils.SplitLines(writer.ToString());

        Assert.That(output, Is.EqualTo(expected));
    }

    [Test]
    public void Save_ToFile_PPM16()
    {
        var canvas = new RCanvas(5, 3)
        {
            [0, 0] = (1.5, 0, 0),
            [2, 1] = (0, 0.5, 0),
            [4, 2] = (-0.5, 0, 1)
        };

        var tempFileName = Path.GetTempFileName();
        canvas.Save(tempFileName, RCanvasFileFormat.PPM16);

        var expected = Utils.SplitLines(
            """
            P3
            5 3
            65535
            65535 0 0 0 0 0 0 0 0 0 0 0 0 0 0
            0 0 0 0 0 0 0 32768 0 0 0 0 0 0 0
            0 0 0 0 0 0 0 0 0 0 0 0 0 0 65535
            """);

        var output = File.ReadAllLines(tempFileName);
        File.Delete(tempFileName);

        Assert.That(output, Is.EqualTo(expected));
    }
    
    [Test]
    [TestCase(RCanvasFileFormat.PPM8)]
    [TestCase(RCanvasFileFormat.PPM16)]
    public void Save_NoLineLongerThan70(RCanvasFileFormat format)
    {
        var canvas = new RCanvas(500, 30);
        for (var y = 0; y < canvas.Height; y++)
            for (var x = 0; x < canvas.Width; x++)
                canvas[x, y] = RColor.White;

        using var writer = new StringWriter();
        canvas.Save(writer, format);

        var output = Utils.SplitLines(writer.ToString());

        foreach (string line in output)
            Assert.That(line.Length, Is.LessThanOrEqualTo(70));
    }

    [Test]
    public void Save_UnknownFileFormat_ThrowsNotSupportedException()
    {
        var canvas = new RCanvas(5, 3);
        using var writer = new StringWriter();
        Assert.Throws<NotSupportedException>(() => canvas.Save(writer, (RCanvasFileFormat)65535));
    }
    
    [Test]
    public void Save_PPM8_WithLinesLessThan70()
    {
        var canvas = new RCanvas(10, 2);
        canvas.Clear((1, 0.8, 0.6));

        using var writer = new StringWriter();
        canvas.Save(writer, RCanvasFileFormat.PPM8);

        var expected = Utils.SplitLines(
            """
            P3
            10 2
            255
            255 204 153 255 204 153 255 204 153 255 204 153 255 204 153 255 204
            153 255 204 153 255 204 153 255 204 153 255 204 153
            255 204 153 255 204 153 255 204 153 255 204 153 255 204 153 255 204
            153 255 204 153 255 204 153 255 204 153 255 204 153
            """);

        var output = Utils.SplitLines(writer.ToString());

        Assert.That(output, Is.EqualTo(expected));
    }
}