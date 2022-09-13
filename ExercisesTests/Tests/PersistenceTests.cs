using CodeWarsExc;
using ExercisesTests.Utils;
using Xunit;

namespace ExercisesTests;

public class PersistenceTests
{
    [Theory]
    [InlineData(39,3)]
    [InlineData(4,0)]
    [InlineData(25,2)]
    [InlineData(999,4)]
    public void PersistenceMySolution_InputPositiveInt_ReturnCountOfMultiples(long input, int expected)
    {
        // Arrange
        // Act
        int actual = 0;
        TestUtils.CompletesIn(3, () =>
        {
            actual = Exercises.PersistenceMySolution(input);
        });
        // Assert
        Assert.Equal(expected, actual);
    }
    
    [Theory]
    [InlineData(39,3)]
    [InlineData(4,0)]
    [InlineData(25,2)]
    [InlineData(999,4)]
    public void PersistenceOtherSolution_InputPositiveInt_ReturnCountOfMultiples(long input, int expected)
    {
        // Arrange
        // Act
        var actual = Exercises.PersistenceOtherSolution(input);
        // Assert
        Assert.Equal(expected, actual);
    }
    
    [Theory]
    [InlineData(39,3)]
    [InlineData(4,0)]
    [InlineData(25,2)]
    [InlineData(999,4)]
    public void PersistenceWithRecursiveSolution_InputPositiveInt_ReturnCountOfMultiples(long input, int expected)
    {
        // Arrange
        // Act
        var actual = Exercises.PersistenceWithRecursiveSolution(input);
        // Assert
        Assert.Equal(expected, actual);
    }
    
    
}