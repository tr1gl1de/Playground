using CodeWarsExc;
using Xunit;

namespace ExercisesTests.Tests;

public class MaskifyTests
{
    [Theory]
    [InlineData("2202201733027005","############7005")]
    [InlineData("289582","##9582")]
    [InlineData("John Week","#####Week")]
    [InlineData("45567","#5567")]
    public static void Maskify_SameTextGreaterFourCharacters_ReturnsMaskifyText(string input, string expected)
    {
        // Arrange
        // Act
        var actual = Exercises.Maskify(input);
        // Assert
        Assert.Equal(expected, actual);
    }
    
    [Theory]
    [InlineData("123","123")]
    [InlineData("","")]
    [InlineData("test","test")]
    public static void Maskify_SameTextLessFourCharacters_ReturnsNotMaskifyText(string input, string expected)
    {
        // Arrange
        // Act
        var actual = Exercises.Maskify(input);
        // Assert
        Assert.Equal(expected, actual);
    }
}