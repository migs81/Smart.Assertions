using System.Numerics;
using Smart.Assertions.Assertions;
using Assert = Smart.Assertions.Assertions.Assert;

namespace Smart.Assertions.Tests;

public class AssertNumbersTests
{
    #region LessThan
    
    [Theory]
    [InlineData(0, 1)]
    [InlineData(99, 100)]
    [InlineData(999, 1000)]
    public void LessThan_Integer_WhenLess_DoesNotThrow(int actual, int expected)
    {
        // act
        var result = Record.Exception(() => Assert.LessThan(expected, actual));
            
        // assert
        Xunit.Assert.Null(result);
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
    
    #region LessThanOrEqual
    
    [Theory]
    [InlineData(0, 0)]
    [InlineData(0, 1)]
    [InlineData(99, 100)]
    public void LessThanOrEqual_Integer_WhenLessOrEqual_DoesNotThrow(int actual, int expected)
    {
        // act
        var result = Record.Exception(() => Assert.LessThanOrEqual(expected, actual));
            
        // assert
        Xunit.Assert.Null(result);
    }
    
    [Theory]
    [InlineData(0, -1)]
    [InlineData(1, 0)]
    [InlineData(100, 99)]
    public void LessThanOrEqual_Integer_WhenNotLessOrEqual_ThrowsAssertionException(int actual, int expected)
    {
        // assert
        Xunit.Assert.Throws<AssertionException>(() => Assert.LessThanOrEqual(expected, actual));
    }
    
    #endregion
    
    #region GreaterThan
    
    [Theory]
    [InlineData(1, 0)]
    [InlineData(100, 99)]
    [InlineData(1000, 999)]
    public void GreaterThan_Integer_WhenGreater_DoesNotThrow(int actual, int expected)
    {
        // act
        var result = Record.Exception(() => Assert.GreaterThan(expected, actual));
            
        // assert
        Xunit.Assert.Null(result);
    }
    
    [Theory]
    [InlineData(0, 0)]
    [InlineData(0, 1)]
    [InlineData(99, 100)]
    public void GreaterThan_Integer_WhenNotGreater_ThrowsAssertionException(int actual, int expected)
    {
        // assert
        Xunit.Assert.Throws<AssertionException>(() => Assert.GreaterThan(expected, actual));
    }
    
    #endregion
    
    #region GreaterThanOrEqual
    
    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 0)]
    [InlineData(100, 99)]
    public void GreaterThanOrEqual_Integer_WhenGreaterOrEqual_DoesNotThrow(int actual, int expected)
    {
        // act
        var result = Record.Exception(() => Assert.GreaterThanOrEqual(expected, actual));
            
        // assert
        Xunit.Assert.Null(result);
    }
    
    [Theory]
    [InlineData(0, 1)]
    [InlineData(99, 100)]
    [InlineData(999, 1000)]
    public void GreaterThanOrEqual_Integer_WhenNotGreaterOrEqual_ThrowsAssertionException(int actual, int expected)
    {
        // assert
        Xunit.Assert.Throws<AssertionException>(() => Assert.GreaterThanOrEqual(expected, actual));
    }
    
    #endregion
    
    #region Between
    
    [Theory]
    [InlineData(2, 1, 3)]
    [InlineData(1, 1, 1)]
    [InlineData(10, 5, 15)]
    public void Between_Integer_WhenGreaterOrEqual_DoesNotThrow(int value, int min, int max)
    {
        // act
        var result = Record.Exception(() => Assert.Between(value, min, max));
            
        // assert
        Xunit.Assert.Null(result);
    }
    
    [Theory]
    [InlineData(0, 1, 3)]
    [InlineData(1, 0, 0)]
    [InlineData(10, 11, 5)]
    public void Between_Integer_WhenNotGreaterOrEqual_ThrowsAssertionException(int value, int min, int max)
    {
        // assert
        Xunit.Assert.Throws<AssertionException>(() => Assert.Between(value, min , max));
    }
    
    #endregion
}