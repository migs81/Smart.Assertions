using Assert = Smart.Assertions.Assertions.Assert;

namespace Smart.Assertions.Tests;

public class AssertCollectionsTests
{
    #region Empty
    
    [Fact]
    public void Empty_WhenEmpty_DoesNotThrow()
    {
        // arrange
        var list = new List<string>();
        
        // act
        var result = Record.Exception(() => Assert.Empty(list));
            
        // assert
        Xunit.Assert.Null(result);
    }
    
    [Fact]
    public void Empty_WhenNotEmpty_DoesThrowAssertionException()
    {
        // arrange
        var list = new List<string> { "test" };
        
        // assert
        Xunit.Assert.Throws<AssertionException>(() => Assert.Empty(list));
    }

    #endregion

    #region NotEmpty

    [Fact]
    public void NotEmpty_WhenNotEmpty_DoesNotThrow()
    {
        // arrange
        var list = new List<string>{ "test"};
        
        // act
        var result = Record.Exception(() => Assert.NotEmpty(list));
            
        // assert
        Xunit.Assert.Null(result);
    }
    
    [Fact]
    public void NotEmpty_WhenEmpty_DoesThrowAssertionException()
    {
        // arrange
        var list = new List<string>();
        
        // assert
        Xunit.Assert.Throws<AssertionException>(() => Assert.NotEmpty(list));
    }

    #endregion

    #region Contains

    [Fact]
    public void Contains_WhenItemExists_DoesNotThrow()
    {
        // arrange
        const string item = "test";
        var list = new List<string>{ item };
        
        // act
        var result = Record.Exception(() => Assert.Contains(list, item));
            
        // assert
        Xunit.Assert.Null(result);
    }

    [Fact]
    public void Contains_WhenItemNotExists_DoesThrowAssertionException()
    {
        // arrange
        const string item = "test";
        const string item2 = "test2";
        var list = new List<string>{ item };
        
        // assert
        Xunit.Assert.Throws<AssertionException>(() => Assert.Contains(list, item2));
    }

    #endregion
    
    #region DoesNotContain
    
    [Fact]
    public void DoesNotContain_WhenItemNotExists_DoesNotThrow()
    {
        // arrange
        const string item = "test";
        const string item2 = "test2";
        var list = new List<string>{ item };
        
        // act
        var result = Record.Exception(() => Assert.DoesNotContain(list, item2));
            
        // assert
        Xunit.Assert.Null(result);
    }

    [Fact]
    public void DoesNotContain_WhenItemExists_DoesThrowAssertionException()
    {
        // arrange
        const string item = "test";
        var list = new List<string>{ item };
        
        // assert
        Xunit.Assert.Throws<AssertionException>(() => Assert.DoesNotContain(list, item));
    }
    
    #endregion
}