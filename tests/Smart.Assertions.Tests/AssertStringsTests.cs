using Assert = Smart.Assertions.Assertions.Assert;

namespace Smart.Assertions.Tests;

public class AssertStringsTests
{
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
}