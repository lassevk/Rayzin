using NUnit.Framework.Interfaces;

namespace Rayzin.Tests;

public class RMatrixTests
{
    [Test]
    public void Constructor_2x3Matrix_ThrowsArgumentOutOfRangeException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _ = new RMatrix(1, 2, 3, 4, 5, 6));
    }

    [Test]
    public void Constructor_NullMatrix_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => _ = new RMatrix(null!));
    }
    
    [Test]
    public void Constructor_4x4Matrix_CreatesCorrectMatrix()
    {
        var matrix = new RMatrix(1, 2, 3, 4, 5.5, 6.5, 7.5, 8.5, 9, 10, 11, 12, 13.5, 14.5, 15.5, 16.5);
        Assert.That(matrix[0, 0], Is.EqualTo(1));
        Assert.That(matrix[0, 3], Is.EqualTo(4));
        Assert.That(matrix[1, 0], Is.EqualTo(5.5));
        Assert.That(matrix[1, 2], Is.EqualTo(7.5));
        Assert.That(matrix[2, 2], Is.EqualTo(11));
        Assert.That(matrix[3, 0], Is.EqualTo(13.5));
        Assert.That(matrix[3, 2], Is.EqualTo(15.5));
    }
    
    [Test]
    public void Constructor_3x3Matrix_CreatesCorrectMatrix()
    {
        var matrix = new RMatrix(-3, 5, 0, 1, -2, -7, 0, 1, 1);
        Assert.That(matrix[0, 0], Is.EqualTo(-3));
        Assert.That(matrix[1, 1], Is.EqualTo(-2));
        Assert.That(matrix[2, 2], Is.EqualTo(1));
    }
    
    [Test]
    public void Constructor_2x2Matrix_CreatesCorrectMatrix()
    {
        var matrix = new RMatrix(-3, 5, 1, -2);
        Assert.That(matrix[0, 0], Is.EqualTo(-3));
        Assert.That(matrix[0, 1], Is.EqualTo(5));
        Assert.That(matrix[1, 0], Is.EqualTo(1));
        Assert.That(matrix[1, 1], Is.EqualTo(-2));
    }

    [Test]
    [TestCase(-1, 0)]
    [TestCase(0, -1)]
    [TestCase(2, 0)]
    [TestCase(0, 2)]
    public void ReadValue_OutOfBounds_ThrowsArgumentOutOfRangeException(int x, int y)
    {
        var matrix = new RMatrix(1, 2, 3, 4);

        Assert.Throws<ArgumentOutOfRangeException>(() => _ = matrix[y, x]);
    }

    [Test]
    public void Equals_EqualMatrices_ReturnsTrue()
    {
        var a = new RMatrix(1, 2, 3, 4, 5, 6, 7, 8, 9, 8, 7, 6, 5, 4, 3, 2);
        var b = new RMatrix(1, 2, 3, 4, 5, 6, 7, 8, 9, 8, 7, 6, 5, 4, 3, 2);

        Assert.That(a, Is.EqualTo(b));
    }
    
    [Test]
    public void Equals_DifferentMatrices_ReturnsFalse()
    {
        var a = new RMatrix(1, 2, 3, 4, 5, 6, 7, 8, 9, 8, 7, 6, 5, 4, 3, 2);
        var b = new RMatrix(2, 3, 4, 5, 6, 7, 8, 9, 8, 7, 6, 5, 4, 3, 2, 1);

        Assert.That(a, Is.Not.EqualTo(b));
    }

    [Test]
    public void Equals_DifferentSizedMatrices_ReturnsFalse()
    {
        var a = new RMatrix(1, 2, 3, 4, 5, 6, 7, 8, 9);
        var b = new RMatrix(1, 2, 3, 4);

        Assert.That(a, Is.Not.EqualTo(b));
    }
}