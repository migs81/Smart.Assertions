using System.Numerics;
using Smart.Assertions.Assertions;
using Assert = Smart.Assertions.Assertions.Assert;

namespace Smart.Assertions.Tests;

public class AssertNumbersTests
{
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
}