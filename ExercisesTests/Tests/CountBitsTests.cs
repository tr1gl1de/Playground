using CodeWarsExc;
using Xunit;

namespace ExercisesTests;

public class CountBitsTests
{
    [Theory]
    [InlineData(0, 0)]
    [InlineData(int.MaxValue, 31)]
    public static void CountBits_InputInt_ReturnCountOfBitsEquals1(int value, int expected)
    {
        // Arrange
        // Act
        var actual = Exercises.CountBits(value);
        // Assert
        Assert.Equal(expected, actual);
    }
    
    [Theory]
    [InlineData(0, 0)]
    [InlineData(int.MaxValue, 31)]
    public static void CountBitsWithoutCycle_InputInt_ReturnCountOfBitsEquals1(int value, int expected)
    {
        // Arrange
        // Act
        var actual = Exercises.CountBitsWithoutCycle(value);
        // Assert
        Assert.Equal(expected, actual);
    }
}