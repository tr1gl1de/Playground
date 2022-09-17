using CodeWarsExc;
using Xunit;

namespace ExercisesTests;

public class RgbToHexTests
{
    [Theory]
    [InlineData(255, 255 , 255, "FFFFFF")]
    [InlineData(255,255,300, "FFFFFF")]
    [InlineData(148,0,211, "9400D3")]
    [InlineData(148,-20,211, "9400D3")]
    public void RgbToHexMySolution_AnyInts_ReturnHexString(int r, int g, int b, string expected)
    {
        // Arrange
        // Act
        var result = Exercises.RgbToHexMySolution(r, g, b);
        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(255, 255, 255, "FFFFFF")]
    [InlineData(255, 255, 300, "FFFFFF")]
    [InlineData(148, 0, 211, "9400D3")]
    [InlineData(148, -20, 211, "9400D3")]
    public void RgbToHexWithMath_AnyInts_ReturnHexString(int r, int g, int b, string expected)
    {
        // Arrange
        // Act
        var result = Exercises.RgbToHexWithMathMax(r, g, b);
        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(255, 255, 255, "FFFFFF")]
    [InlineData(255, 255, 300, "FFFFFF")]
    [InlineData(148, 0, 211, "9400D3")]
    [InlineData(148, -20, 211, "9400D3")]
    public void RgbToHexWithFunc_AnyInts_ReturnHexString(int r, int g, int b, string expected)
    {
        // Arrange
        // Act
        var result = Exercises.RgbToHexWithIfFunc(r, g, b);
        // Assert
        Assert.Equal(expected, result);
    }
}