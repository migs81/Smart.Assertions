using Assert = Smart.Assertions.Assertions.Assert;

namespace Smart.Assertions.Tests;

public class AssertStringsTests
{
    #region Equal

    [Theory]
    [InlineData("", "", StringComparison.Ordinal)]
    [InlineData("test", "test", StringComparison.Ordinal)]
    [InlineData("TEST", "test", StringComparison.OrdinalIgnoreCase)]
    public void Equal_WhenEqual_DoesNotThrow(string actual, string expected, StringComparison comparison)
    {
        // act
        var result = Record.Exception(() => Assert.Equal(expected, actual, comparison));
            
        // assert
        Xunit.Assert.Null(result);
    }
    
    [Theory]
    [InlineData("", "x", StringComparison.Ordinal)]
    [InlineData("Test", "test", StringComparison.Ordinal)]
    [InlineData("TEST", "test2", StringComparison.OrdinalIgnoreCase)]
    public void Equal_WhenNotEqual_Throws(string actual, string expected, StringComparison comparison)
    {
        // assert
        Xunit.Assert.Throws<AssertionException>(() => Assert.Equal(expected, actual, comparison));
    }
    
    #endregion

    #region StartsWith
    
    [Theory]
    [InlineData("Test", "Te", StringComparison.Ordinal)]
    [InlineData("Test", "Tes", StringComparison.Ordinal)]
    [InlineData("TEST", "TEST", StringComparison.OrdinalIgnoreCase)]
    public void StartsWith_WhenMatching_DoesNotThrow(string actual, string value, StringComparison comparison)
    {
        // act
        var result = Record.Exception(() => Assert.StartsWith(value, actual, comparison));
            
        // assert
        Xunit.Assert.Null(result);
    }
    
    [Theory]
    [InlineData("Test", "est", StringComparison.Ordinal)]
    [InlineData("Test", "TES", StringComparison.Ordinal)]
    [InlineData("TEST", "ST", StringComparison.OrdinalIgnoreCase)]
    public void StartsWith_WhenNotMatching_Throws(string actual, string value, StringComparison comparison)
    {
        // assert
        Xunit.Assert.Throws<AssertionException>(() => Assert.StartsWith(value, actual, comparison));
    }
    
    #endregion
    
    #region EndsWith
    
    [Theory]
    [InlineData("Test", "st", StringComparison.Ordinal)]
    [InlineData("Test", "Test", StringComparison.Ordinal)]
    [InlineData("TEST", "st", StringComparison.OrdinalIgnoreCase)]
    public void EndsWith_WhenMatching_DoesNotThrow(string actual, string value, StringComparison comparison)
    {
        // act
        var result = Record.Exception(() => Assert.EndsWith(value, actual, comparison));
            
        // assert
        Xunit.Assert.Null(result);
    }
    
    [Theory]
    [InlineData("Test", "EST", StringComparison.Ordinal)]
    [InlineData("Test", "Tes", StringComparison.Ordinal)]
    [InlineData("TEST", "STE", StringComparison.OrdinalIgnoreCase)]
    public void EndsWith_WhenNotMatching_Throws(string actual, string value, StringComparison comparison)
    {
        // assert
        Xunit.Assert.Throws<AssertionException>(() => Assert.EndsWith(value, actual, comparison));
    }
    
    #endregion
    
    #region Contains
    
    [Theory]
    [InlineData("Test", "es", StringComparison.Ordinal)]
    [InlineData("Test", "Te", StringComparison.Ordinal)]
    [InlineData("TEST", "es", StringComparison.OrdinalIgnoreCase)]
    public void Contains_WhenMatching_DoesNotThrow(string actual, string value, StringComparison comparison)
    {
        // act
        var result = Record.Exception(() => Assert.Contains(value, actual, comparison));
            
        // assert
        Xunit.Assert.Null(result);
    }
    
    [Theory]
    [InlineData("Test", "tes", StringComparison.Ordinal)]
    [InlineData("Test", "TE", StringComparison.Ordinal)]
    [InlineData("TEST", "STE", StringComparison.OrdinalIgnoreCase)]
    public void Contains_WhenNotMatching_Throws(string actual, string value, StringComparison comparison)
    {
        // assert
        Xunit.Assert.Throws<AssertionException>(() => Assert.Contains(value, actual, comparison));
    }
    
    #endregion
}