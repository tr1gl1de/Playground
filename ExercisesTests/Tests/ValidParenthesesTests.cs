using CodeWarsExc;
using Xunit;

namespace ExercisesTests.Tests;

public class ValidParenthesesTests
{
    [Theory]
    [InlineData("()()()")]
    [InlineData("((()))()()(())((()))")]
    public void ValidaParentheses_ValidInput_ReturnTrue(string value)
    {
        Assert.True(Exercises.ValidParentheses(value));
    }
    
    [Theory]
    [InlineData("()()()(")]
    [InlineData(")(")]
    public void ValidaParentheses_InvalidInput_ReturnFalse(string value)
    {
        Assert.False(Exercises.ValidParentheses(value));
    }

    [Theory]
    [InlineData("")]
    [InlineData("sjfiuwehgiuehgwhrgihweriughweiruhwiu")]
    public void ValidaParentheses_InputWithoutBraces_ReturnTrue(string value)
    {
        Assert.True(Exercises.ValidParentheses(value));
    }
}