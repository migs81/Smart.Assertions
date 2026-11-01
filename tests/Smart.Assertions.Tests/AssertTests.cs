using Smart.Assertions.Assertions;
using Assert = Smart.Assertions.Assertions.Assert;

namespace Smart.Assertions.Tests;

public class AssertTest
{
    #region Null, NotNull
    
    [Fact]
    public void Null_WhenNull_DoesNotThrow()
    {
        // arrange
        object? value = null;
        
        // act
        var result = Record.Exception(() => Assert.Null(value));
            
        // assert
        Xunit.Assert.Null(result);
    }
    
    [Fact]
    public void Null_WhenNotNull_Throws()
    {
        // arrange
        object? value = "";
        
        // assert
        Xunit.Assert.Throws<AssertionException>(() => Assert.Null(value));
    }
    
    [Fact]
    public void NotNull_WhenNotNull_DoesNotThrow()
    {
        // arrange
        object? value = "";
        
        // act
        var result = Record.Exception(() => Assert.NotNull(value));
            
        // assert
        Xunit.Assert.Null(result);
    }
    
    [Fact]
    public void NotNull_WhenNull_Throws()
    {
        // arrange
        object? value = null;
        
        // assert
        Xunit.Assert.Throws<AssertionException>(() => Assert.NotNull(value));
    }
    
    #endregion
    
    #region Equal, NotEqual
    
    [Fact]
    public void Equal_WhenEqual_DoesNotThrow()
    {
        // arrange
        var guid1 = Guid.NewGuid();
        var guid2 = guid1;
        
        // act
        var result = Record.Exception(() => Assert.Equal(guid1, guid2));
            
        // assert
        Xunit.Assert.Null(result);
    }
    
    [Fact]
    public void Equal_WhenNotEqual_Throws()
    {
        // arrange
        var guid1 = Guid.NewGuid();
        var guid2 = Guid.NewGuid();

        // assert
        Xunit.Assert.Throws<AssertionException>(() => Assert.Equal(guid1, guid2));
    }
    
    [Fact]
    public void NotEqual_WhenNotEqual_DoesNotThrow()
    {
        // arrange
        var guid1 = Guid.NewGuid();
        var guid2 = Guid.NewGuid();
        
        // act
        var result = Record.Exception(() => Assert.NotEqual(guid1, guid2));
            
        // assert
        Xunit.Assert.Null(result);
    }
    
    [Fact]
    public void NotEqual_WhenEqual_Throws()
    {
        // arrange
        var guid1 = Guid.NewGuid();
        var guid2 = guid1;

        // assert
        Xunit.Assert.Throws<AssertionException>(() => Assert.NotEqual(guid1, guid2));
    }
    
    #endregion
    
    #region ShouldBeNull, ShouldNotBeNull
    
    [Fact]
    public void ShouldBeNull_WhenNull_DoesNotThrow()
    {
        // arrange
        object? value = null;
        
        // act
        var result = Record.Exception(() => value.ShouldBeNull());
            
        // assert
        Xunit.Assert.Null(result);
    }
    
    [Fact]
    public void ShouldBeNull_WhenNotNull_Throws()
    {
        // arrange
        object? value = "";
        
        // assert
        Xunit.Assert.Throws<AssertionException>(() => value.ShouldBeNull());
    }
    
    [Fact]
    public void ShouldNotBeNull_WhenNotNull_DoesNotThrow()
    {
        // arrange
        object? value = "";
        
        // act
        var result = Record.Exception(() => value.ShouldNotBeNull());
            
        // assert
        Xunit.Assert.Null(result);
    }
    
    [Fact]
    public void ShouldNotBeNull_WhenNull_Throws()
    {
        // arrange
        object? value = null;
        
        // assert
        Xunit.Assert.Throws<AssertionException>(() => value.ShouldNotBeNull());
    }
    
    #endregion
    
    #region ShouldEqual, ShouldNotEqual
    
    [Fact]
    public void ShouldEqual_WhenEqual_DoesNotThrow()
    {
        // arrange
        var guid1 = Guid.NewGuid();
        var guid2 = guid1;
        
        // act
        var result = Record.Exception(() => guid1.ShouldEqual(guid2));
            
        // assert
        Xunit.Assert.Null(result);
    }
    
    [Fact]
    public void ShouldEqual_WhenNotEqual_Throws()
    {
        // arrange
        var guid1 = Guid.NewGuid();
        var guid2 = Guid.NewGuid();

        // assert
        Xunit.Assert.Throws<AssertionException>(() => guid1.ShouldEqual(guid2));
    }
    
    
    [Fact]
    public void ShouldNotEqual_WhenNotEqual_DoesNotThrow()
    {
        // arrange
        var guid1 = Guid.NewGuid();
        var guid2 = Guid.NewGuid();
        
        // act
        var result = Record.Exception(() => guid1.ShouldNotEqual(guid2));
            
        // assert
        Xunit.Assert.Null(result);
    }
    
    [Fact]
    public void ShouldNotEqual_WhenEqual_Throws()
    {
        // arrange
        var guid1 = Guid.NewGuid();
        var guid2 = guid1;

        // assert
        Xunit.Assert.Throws<AssertionException>(() => guid1.ShouldNotEqual(guid2));
    }

    #endregion
}