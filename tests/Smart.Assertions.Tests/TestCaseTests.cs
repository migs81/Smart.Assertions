using Xunit.Sdk;
using Assert = Xunit.Assert;

namespace Smart.Assertions.Tests;

public class TestCaseTests
{
    [Fact]
    public void Create_WhenAssertSucceeds_DoesNotThrow()
    {
        // arrange
        var testCase = TestCase.Create(5)
            .Act(input => input + 1)
            .Assert(input => Assert.Equal(6, input));
        
        // act
        var result = Record.Exception(testCase.Run);
            
        // assert
        Assert.Null(result);
    }

    [Fact]
    public void Create_WhenAssertFails_Throws()
    {
        // arrange
        var testCase = TestCase.Create(5)
            .Act(input => input - 1)
            .Assert(input => Assert.Equal(6, input));
        
        // act
        var result = Record.Exception(testCase.Run);
            
        // assert
        Assert.NotNull(result);
        Assert.IsType<EqualException>(result);
    }
}