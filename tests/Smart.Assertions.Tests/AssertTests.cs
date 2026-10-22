using Assert = Smart.Assertions.Assertions.Assert;

namespace Smart.Assertions.Tests;

public class AssertTest
{
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
}