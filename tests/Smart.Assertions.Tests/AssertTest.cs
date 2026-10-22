using System.Numerics;

namespace Smart.Assertions.Tests;

public class AssertTest
{
    #region True
    
    [Fact]
    public void True_WhenConditionIsTrue_DoesNotThrow()
    {
        // arrange
        const bool input = true;

        // assert
        Assert.True(input);
    }
    
    [Fact]
    public void True_WhenConditionIsFalse_ThrowsAssertionException()
    {
        // arrange
        const bool input = false;

        // assert
        Xunit.Assert.Throws<AssertionException>(() => Assert.True(input));
    }
    
    #endregion
    
    #region False
    
    [Fact]
    public void False_WhenConditionIsFalse_DoesNotThrow()
    {
        // arrange
        const bool input = false;

        // assert
        Assert.False(input);
    }
    
    [Fact]
    public void False_WhenConditionIsTrue_ThrowsAssertionException()
    {
        // arrange
        const bool input = true;

        // assert
        Xunit.Assert.Throws<AssertionException>(() => Assert.False(input));
    }
    
    #endregion

    #region string

    [Theory]
    [InlineData("", "", StringComparison.Ordinal)]
    [InlineData("test", "test", StringComparison.Ordinal)]
    [InlineData("TEST", "test", StringComparison.OrdinalIgnoreCase)]
    public void Equal_String_WhenEqual_DoesNotThrow(string actual, string expected, StringComparison comparison)
    {
        // assert
        Assert.Equal(expected, actual, comparison);
    }
    
    [Theory]
    [InlineData("", "x", StringComparison.Ordinal)]
    [InlineData("Test", "test", StringComparison.Ordinal)]
    [InlineData("TEST", "test2", StringComparison.OrdinalIgnoreCase)]
    public void Equal_String_WhenNotEqual_ThrowsAssertionException(string actual, string expected, StringComparison comparison)
    {
        // assert
        Xunit.Assert.Throws<AssertionException>(() => Assert.Equal(expected, actual, comparison));
    }

    #endregion
    
    #region generic
    
    [Theory]
    [InlineData("", "")]
    [InlineData("test", "test")]
    [InlineData("TEST", "TEST")]
    public void Equal_T_WhenEqual_DoesNotThrow(string actual, string expected)
    {
        // assert
        Assert.Equal(expected, actual);
    }
    
    [Theory]
    [InlineData("", "x")]
    [InlineData("Test", "test")]
    [InlineData("TEST", "test")]
    public void Equal_T_WhenNotEqual_ThrowsAssertionException(string actual, string expected)
    {
        // assert
        Xunit.Assert.Throws<AssertionException>(() => Assert.Equal(expected, actual));
    }
    
    #endregion
    
    #region numeric
    
    [Theory]
    [InlineData(0, 1)]
    [InlineData(99, 100)]
    [InlineData(999, 1000)]
    public void LessThan_Integer_WhenLess_DoesNotThrow(int actual, int expected)
    {
        // assert
        Assert.LessThan(expected, actual);
    }
    
    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 0)]
    [InlineData(100, 99)]
    public void LessThan_Integer_WhenNotLess_ThrowsAssertionException(int actual, int expected)
    {
        // assert
        Xunit.Assert.Throws<AssertionException>(() => Assert.LessThan(expected, actual));
    }
    
    #endregion
}