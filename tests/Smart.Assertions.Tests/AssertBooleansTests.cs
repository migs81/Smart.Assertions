using Assert = Smart.Assertions.Assertions.Assert;

namespace Smart.Assertions.Tests;

public class AssertBooleansTests
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
}