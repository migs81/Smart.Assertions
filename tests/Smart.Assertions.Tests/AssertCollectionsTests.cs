using System.Runtime.CompilerServices;
using Smart.Assertions.Assertions;
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
    
    #region ShouldBeEmpty
    
    [Fact]
    public void ShouldBeEmpty_WhenEmpty_DoesNotThrow()
    {
        // arrange
        var list = new List<string>();
        
        // act
        var result = Record.Exception(() => list.ShouldBeEmpty());
            
        // assert
        Xunit.Assert.Null(result);
    }
    
    [Fact]
    public void ShouldBeEmpty_WhenNotEmpty_DoesThrowAssertionException()
    {
        // arrange
        var list = new List<string> { "test" };
        
        // assert
        Xunit.Assert.Throws<AssertionException>(() => list.ShouldBeEmpty());
    }

    #endregion

    #region ShouldNotBeEmpty

    [Fact]
    public void ShouldNotBeEmpty_WhenNotEmpty_DoesNotThrow()
    {
        // arrange
        var list = new List<string>{ "test"};
        
        // act
        var result = Record.Exception(() => list.ShouldNotBeEmpty());
            
        // assert
        Xunit.Assert.Null(result);
    }
    
    [Fact]
    public void ShouldNotBeEmpty_WhenEmpty_DoesThrowAssertionException()
    {
        // arrange
        var list = new List<string>();
        
        // assert
        Xunit.Assert.Throws<AssertionException>(() => list.ShouldNotBeEmpty());
    }

    #endregion

    #region ShouldContain

    [Fact]
    public void ShouldContain_WhenItemExists_DoesNotThrow()
    {
        // arrange
        const string item = "test";
        var list = new List<string>{ item };
        
        // act
        var result = Record.Exception(() => list.ShouldContain(item));
            
        // assert
        Xunit.Assert.Null(result);
    }

    [Fact]
    public void ShouldContain_WhenItemNotExists_DoesThrowAssertionException()
    {
        // arrange
        const string item = "test";
        const string item2 = "test2";
        var list = new List<string>{ item };
        
        // assert
        Xunit.Assert.Throws<AssertionException>(() => list.ShouldContain(item2));
    }

    #endregion
    
    #region ShouldNotContain
    
    [Fact]
    public void ShouldNotContain_WhenItemNotExists_DoesNotThrow()
    {
        // arrange
        const string item = "test";
        const string item2 = "test2";
        var list = new List<string>{ item };
        
        // act
        var result = Record.Exception(() => list.ShouldNotContain(item2));
            
        // assert
        Xunit.Assert.Null(result);
    }

    [Fact]
    public void ShouldNotContain_WhenItemExists_DoesThrowAssertionException()
    {
        // arrange
        const string item = "test";
        var list = new List<string>{ item };
        
        // assert
        Xunit.Assert.Throws<AssertionException>(() => list.ShouldNotContain(item));
    }
    
    #endregion
}