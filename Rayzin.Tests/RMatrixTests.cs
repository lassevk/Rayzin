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

    [Test]
    public void Multiply_Matrices()
    {
        var a = new RMatrix(1, 2, 3, 4, 5, 6, 7, 8, 9, 8, 7, 6, 5, 4, 3, 2);
        var b = new RMatrix(-2, 1, 2, 3, 3, 2, 1, -1, 4, 3, 6, 5, 1, 2, 7, 8);

        RMatrix output = a * b;
        Assert.That(output, Is.EqualTo(new RMatrix(20, 22, 50, 48, 44, 54, 114, 108, 40, 58, 110, 102, 16, 26, 46, 42)));
    }

    [Test]
    public void Multiply_MatrixWithPoint()
    {
        var a = new RMatrix(1, 2, 3, 4, 2, 4, 4, 2, 8, 6, 4, 1, 0, 0, 0, 1);
        var b = new RPoint(1, 2, 3);

        RPoint result = a * b;

        Assert.That(result, Is.EqualTo(new RPoint(18, 24, 33)));
    }
    
    [Test]
    public void Multiply_3x3MatrixWithPoint_ThrowsInvalidOperationException()
    {
        var a = new RMatrix(1, 2, 3, 4, 5, 6, 7, 8, 9);
        var b = new RPoint(1, 2, 3);

        Assert.Throws<InvalidOperationException>(() => _ = a * b);
    }
    
    [Test]
    public void Multiply_MatrixWithPoint_ThatDoesNotProduceAPoint_ThrowsInvalidOperationException()
    {
        var a = new RMatrix(1, 2, 3, 4, 2, 4, 4, 2, 8, 6, 4, 1, 0, 0, 1, 1);
        var b = new RPoint(1, 2, 3);

        Assert.Throws<InvalidOperationException>(() => _ = a * b);
    }
    
    [Test]
    public void Multiply_MatrixWithVector()
    {
        var a = new RMatrix(1, 2, 3, 4, 2, 4, 4, 2, 8, 6, 4, 1, 0, 0, 0, 1);
        var b = new RVector(1, 2, 3);

        RVector result = a * b;

        Assert.That(result, Is.EqualTo(new RVector(14, 22, 32)));
    }
    
    [Test]
    public void Multiply_3x3MatrixWithVector_ThrowsInvalidOperationException()
    {
        var a = new RMatrix(1, 2, 3, 4, 5, 6, 7, 8, 9);
        var b = new RVector(1, 2, 3);

        Assert.Throws<InvalidOperationException>(() => _ = a * b);
    }
    
    [Test]
    public void Multiply_MatrixWithVector_ThatDoesNotProduceAPoint_ThrowsInvalidOperationException()
    {
        var a = new RMatrix(1, 2, 3, 4, 2, 4, 4, 2, 8, 6, 4, 1, 0, 0, 1, 1);
        var b = new RVector(1, 2, 3);

        Assert.Throws<InvalidOperationException>(() => _ = a * b);
    }

    [Test]
    public void Multiply_4x4MatrixWithIdentityMatrix_ReturnsOriginalMatrix()
    {
        var a = new RMatrix(0, 1, 2, 4, 1, 2, 4, 8, 2, 4, 8, 16, 4, 8, 16, 32);
        RMatrix output = a * RMatrix.Identity4X4;

        Assert.That(a, Is.EqualTo(output));
    }
    
    [Test]
    public void Multiply_3x3MatrixWithIdentityMatrix_ReturnsOriginalMatrix()
    {
        var a = new RMatrix(0, 1, 2, 1, 3, 6, 2, 12, 24);
        RMatrix output = a * RMatrix.Identity3X3;

        Assert.That(a, Is.EqualTo(output));
    }
    
    [Test]
    public void Multiply_2x2MatrixWithIdentityMatrix_ReturnsOriginalMatrix()
    {
        var a = new RMatrix(0, 1, 2, 4);
        RMatrix output = a * RMatrix.Identity2X2;

        Assert.That(a, Is.EqualTo(output));
    }

    [Test]
    public void Transpose()
    {
        var a = new RMatrix(0, 9, 3, 0, 9, 8, 0, 8, 1, 8, 5, 3, 0, 0, 5, 8);
        RMatrix output = a.Transpose();

        Assert.That(output, Is.EqualTo(new RMatrix(0, 9, 1, 0, 9, 8, 8, 0, 3, 0, 5, 5, 0, 8, 3, 8)));
    }
    
    [Test]
    public void Transpose_IdentityMatrix()
    {
        RMatrix a = RMatrix.Identity4X4;
        RMatrix output = a.Transpose();

        Assert.That(output, Is.EqualTo(RMatrix.Identity4X4));
    }

    [Test]
    public void SubMatrix_3x3()
    {
        var a = new RMatrix(1, 5, 0, -3, 2, 7, 0, 6, -3);
        RMatrix output = a.SubMatrix(0, 2);

        Assert.That(output, Is.EqualTo(new RMatrix(-3, 2, 0, 6)));
    }
    
    [Test]
    public void SubMatrix_4x4()
    {
        var a = new RMatrix(-6, 1, 1, 6, -8, 5, 8, 6, -1, 0, 8, 2, -7, 1, -1, 1);
        RMatrix output = a.SubMatrix(2, 1);

        Assert.That(output, Is.EqualTo(new RMatrix(-6, 1, 6, -8, 8, 6, -7, -1, 1)));
    }

    [Test]
    public void Determinant_2x2()
    {
        var a = new RMatrix(1, 5, -3, 2);
        var output = a.Determinant();

        Assert.That(output, Is.EqualTo(17));
    }

    [Test]
    public void Minor_3x3()
    {
        var a = new RMatrix(3, 5, 0, 2, -1, -7, 6, -1, 5);
        RMatrix b = a.SubMatrix(1, 0);

        var det = b.Determinant();
        Assert.That(det, Is.EqualTo(25));

        var minor = a.Minor(1, 0);
        Assert.That(minor, Is.EqualTo(25));
    }

    [Test]
    public void Cofactors_3x3()
    {
        var a = new RMatrix(3, 5, 0, 2, -1, -7, 6, -1, 5);

        Assert.That(a.Minor(0, 0), Is.EqualTo(-12));
        Assert.That(a.CoFactor(0, 0), Is.EqualTo(-12));
        
        Assert.That(a.Minor(1, 0), Is.EqualTo(25));
        Assert.That(a.CoFactor(1, 0), Is.EqualTo(-25));
    }

    [Test]
    public void Determinant_3x3()
    {
        var a = new RMatrix(1, 2, 6, -5, 8, -4, 2, 6, 4);
        Assert.That(a.CoFactor(0, 0), Is.EqualTo(56));
        Assert.That(a.CoFactor(0, 2), Is.EqualTo(-46));
        Assert.That(a.Determinant(), Is.EqualTo(-196));
    }
    
    [Test]
    public void Determinant_4x4()
    {
        var a = new RMatrix(-2, -8, 3, 5, -3, 1, 7, 3, 1, 2, -9, 6, -6, 7, 7, -9);
        Assert.That(a.CoFactor(0, 0), Is.EqualTo(690));
        Assert.That(a.CoFactor(0, 1), Is.EqualTo(447));
        Assert.That(a.CoFactor(0, 2), Is.EqualTo(210));
        Assert.That(a.CoFactor(0, 3), Is.EqualTo(51));
        Assert.That(a.Determinant(), Is.EqualTo(-4071));
    }
}