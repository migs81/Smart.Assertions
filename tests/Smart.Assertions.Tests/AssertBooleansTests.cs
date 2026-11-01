using Smart.Assertions.Assertions;
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

        // act
        var result = Record.Exception(() => Assert.True(input));
            
        // assert
        Xunit.Assert.Null(result);
    }
    
    [Fact]
    public void True_WhenConditionIsFalse_Throws()
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

        // act
        var result = Record.Exception(() => Assert.False(input));
            
        // assert
        Xunit.Assert.Null(result);
    }
    
    [Fact]
    public void False_WhenConditionIsTrue_Throws()
    {
        // arrange
        const bool input = true;

        // assert
        Xunit.Assert.Throws<AssertionException>(() => Assert.False(input));
    }
    
    #endregion
    
    #region ShouldBeTrue
    
    [Fact]
    public void ShouldBeTrue_WhenConditionIsTrue_DoesNotThrow()
    {
        // arrange
        const bool input = true;

        // act
        var result = Record.Exception(() => input.ShouldBeTrue());
            
        // assert
        Xunit.Assert.Null(result);
    }
    
    [Fact]
    public void ShouldBeTrue_WhenConditionIsFalse_Throws()
    {
        // arrange
        const bool input = false;

        // assert
        Xunit.Assert.Throws<AssertionException>(() => input.ShouldBeTrue());
    }
    
    #endregion
    
    #region ShouldBeFalse
    
    [Fact]
    public void ShouldBeFalse_WhenConditionIsFalse_DoesNotThrow()
    {
        // arrange
        const bool input = false;

        // act
        var result = Record.Exception(() => input.ShouldBeFalse());
            
        // assert
        Xunit.Assert.Null(result);
    }
    
    [Fact]
    public void ShouldBeFalse_WhenConditionIsTrue_Throws()
    {
        // arrange
        const bool input = true;

        // assert
        Xunit.Assert.Throws<AssertionException>(() => input.ShouldBeFalse());
    }
    
    #endregion
}