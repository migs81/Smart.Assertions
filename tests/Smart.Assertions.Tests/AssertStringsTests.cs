using Smart.Assertions.Assertions;
using Assert = Smart.Assertions.Assertions.Assert;

namespace Smart.Assertions.Tests;

public class AssertStringsTests
{
    #region Empty

    [Fact]
    public void Empty_WhenEmpty_DoesNotThrow()
    {
        // arrange
        const string input = "";
        
        // act
        var result = Record.Exception(() => Assert.Empty(input));
        
        // assert
        Xunit.Assert.Null(result);
    }
    
    [Fact]
    public void Empty_WhenNotEmpty_Throws()
    {
        // arrange
        const string input = "test";

        // assert
        Xunit.Assert.Throws<AssertionException>(() => Assert.Empty(input));
    }
    
    #endregion
    
    #region NotEmpty

    [Fact]
    public void NotEmpty_WhenNotEmpty_DoesNotThrow()
    {
        // arrange
        var input = "test";
        
        // act
        var result = Record.Exception(() => Assert.NotEmpty(input));
        
        // assert
        Xunit.Assert.Null(result);
    }
    
    [Fact]
    public void NotEmpty_WhenEmpty_Throws()
    {
        // arrange
        var input = "";
        
        // assert
        Xunit.Assert.Throws<AssertionException>(() => Assert.NotEmpty(input));
    }
    
    #endregion
    
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
    
    #region ShouldBeEmpty

    [Fact]
    public void ShouldBeEmpty_WhenEmpty_DoesNotThrow()
    {
        // arrange
        const string input = "";
        
        // act
        var result = Record.Exception(() => input.ShouldBeEmpty());
        
        // assert
        Xunit.Assert.Null(result);
    }
    
    [Fact]
    public void ShouldBeEmpty_WhenNotEmpty_Throws()
    {
        // arrange
        var input = "test";
        
        // assert
        Xunit.Assert.Throws<AssertionException>(() => input.ShouldBeEmpty());
    }
    
    #endregion
    
    #region ShouldNotBeEmpty

    [Fact]
    public void ShouldNotBeEmpty_WhenNotEmpty_DoesNotThrow()
    {
        // arrange
        const string input = "test";
        
        // act
        var result = Record.Exception(() => input.ShouldNotBeEmpty());
        
        // assert
        Xunit.Assert.Null(result);
    }
    
    [Fact]
    public void ShouldNotBeEmpty_WhenEmpty_Throws()
    {
        // arrange
        const string input = "";

        // assert
        Xunit.Assert.Throws<AssertionException>(() => input.ShouldNotBeEmpty());
    }
    
    #endregion
    
    #region ShouldEqual

    [Theory]
    [InlineData("", "", StringComparison.Ordinal)]
    [InlineData("test", "test", StringComparison.Ordinal)]
    [InlineData("TEST", "test", StringComparison.OrdinalIgnoreCase)]
    public void ShouldEqual_WhenEqual_DoesNotThrow(string actual, string expected, StringComparison comparison)
    {
        // act
        var result = Record.Exception(() => actual.ShouldEqual(expected, comparison));
        
        // assert
        Xunit.Assert.Null(result);
    }
    
    [Theory]
    [InlineData("", "x", StringComparison.Ordinal)]
    [InlineData("Test", "test", StringComparison.Ordinal)]
    [InlineData("TEST", "test2", StringComparison.OrdinalIgnoreCase)]
    public void ShouldEqual_WhenNotEqual_Throws(string actual, string expected, StringComparison comparison)
    {
        // assert
        Xunit.Assert.Throws<AssertionException>(() => actual.ShouldEqual(expected, comparison));
    }
    
    #endregion

    #region ShouldStartWith
    
    [Theory]
    [InlineData("Test", "Te", StringComparison.Ordinal)]
    [InlineData("Test", "Tes", StringComparison.Ordinal)]
    [InlineData("TEST", "TEST", StringComparison.OrdinalIgnoreCase)]
    public void ShouldStartWith_WhenMatching_DoesNotThrow(string actual, string value, StringComparison comparison)
    {
        // act
        var result = Record.Exception(() => actual.ShouldStartWith(value, comparison));
            
        // assert
        Xunit.Assert.Null(result);
    }
    
    [Theory]
    [InlineData("Test", "est", StringComparison.Ordinal)]
    [InlineData("Test", "TES", StringComparison.Ordinal)]
    [InlineData("TEST", "ST", StringComparison.OrdinalIgnoreCase)]
    public void ShouldStartWith_WhenNotMatching_Throws(string actual, string value, StringComparison comparison)
    {
        // assert
        Xunit.Assert.Throws<AssertionException>(() => actual.ShouldStartWith(value, comparison));
    }
    
    #endregion
    
    #region ShouldEndWith
    
    [Theory]
    [InlineData("Test", "st", StringComparison.Ordinal)]
    [InlineData("Test", "Test", StringComparison.Ordinal)]
    [InlineData("TEST", "st", StringComparison.OrdinalIgnoreCase)]
    public void ShouldEndWith_WhenMatching_DoesNotThrow(string actual, string value, StringComparison comparison)
    {
        // act
        var result = Record.Exception(() => actual.ShouldEndWith(value, comparison));
            
        // assert
        Xunit.Assert.Null(result);
    }
    
    [Theory]
    [InlineData("Test", "EST", StringComparison.Ordinal)]
    [InlineData("Test", "Tes", StringComparison.Ordinal)]
    [InlineData("TEST", "STE", StringComparison.OrdinalIgnoreCase)]
    public void ShouldEndWith_WhenNotMatching_Throws(string actual, string value, StringComparison comparison)
    {
        // assert
        Xunit.Assert.Throws<AssertionException>(() => actual.ShouldEndWith(value, comparison));
    }
    
    #endregion
    
    #region ShouldContain
    
    [Theory]
    [InlineData("Test", "es", StringComparison.Ordinal)]
    [InlineData("Test", "Te", StringComparison.Ordinal)]
    [InlineData("TEST", "es", StringComparison.OrdinalIgnoreCase)]
    public void ShouldContain_WhenMatching_DoesNotThrow(string actual, string value, StringComparison comparison)
    {
        // act
        var result = Record.Exception(() => actual.ShouldContain(value, comparison));
            
        // assert
        Xunit.Assert.Null(result);
    }
    
    [Theory]
    [InlineData("Test", "tes", StringComparison.Ordinal)]
    [InlineData("Test", "TE", StringComparison.Ordinal)]
    [InlineData("TEST", "STE", StringComparison.OrdinalIgnoreCase)]
    public void ShouldContain_WhenNotMatching_Throws(string actual, string value, StringComparison comparison)
    {
        // assert
        Xunit.Assert.Throws<AssertionException>(() => actual.ShouldContain(value, comparison));
    }
    
    #endregion
    
    #region ShouldNotContain
    
    [Theory]
    [InlineData("Test", "tes", StringComparison.Ordinal)]
    [InlineData("Test", "TE", StringComparison.Ordinal)]
    [InlineData("TEST", "STE", StringComparison.OrdinalIgnoreCase)]
    public void ShouldNotContain_WhenNotMatching_DoesNotThrow(string actual, string value, StringComparison comparison)
    {
        // act
        var result = Record.Exception(() => actual.ShouldNotContain(value, comparison));
            
        // assert
        Xunit.Assert.Null(result);
    }
    
    [Theory]
    [InlineData("Test", "es", StringComparison.Ordinal)]
    [InlineData("Test", "Te", StringComparison.Ordinal)]
    [InlineData("TEST", "es", StringComparison.OrdinalIgnoreCase)]
    public void ShouldNotContain_WhenMatching_Throws(string actual, string value, StringComparison comparison)
    {
        // assert
        Xunit.Assert.Throws<AssertionException>(() => actual.ShouldNotContain(value, comparison));
    }
    
    #endregion
}