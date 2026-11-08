using Smart.Assertions.Assertions;
using Xunit.Sdk;
using Assert = Xunit.Assert;

namespace Smart.Assertions.Tests;

public class TestTests
{
    #region test data

    public static IEnumerable<object[]> TestCases =>
    [
        [5, 10],
        [10, 20],
        [20, 40]
    ];

    #endregion

    #region tests

    [Fact]
    public void Run_WhenAssertSucceeds_DoesNotThrow()
    {
        // arrange
        var test = Test.Create(5)
            .Act(input => input + 1)
            .Assert(input => Assert.Equal(6, input));
        
        // act
        var result = Record.Exception(test.Run);
        
        // assert
        Assert.Null(result);
    }

    [Fact]
    public void Run_WhenAssertFails_Throws()
    {
        // arrange
        var test = Test.Create(5)
            .Act(input => input - 1)
            .Assert(input => Assert.Equal(6, input));
        
        // act
        var result = Record.Exception(test.Run);
            
        // assert
        Assert.NotNull(result);
        Assert.IsType<EqualException>(result);
    }
    
    [Fact]
    public void Run_ListOfTests_WhenAssertSucceeds_DoesNotThrow()
    {
        // arrange
        var tests = new List<ITest>
        {
            Test.Create(5)
                .Act(x => x * 2)
                .Assert(result => result.ShouldBe(10)),
            
            Test.Create(10)
                .Act(x => x + 5)
                .Assert(result => result.ShouldBe(15)),
            
            Test.Create(20)
                .Act(x => x / 2)
                .Assert(result => result.ShouldBe(10))
        };

        foreach (var test in tests)
        {
            // act
            var result = Record.Exception(test.Run);
            
            // assert
            Assert.Null(result);
        }
    }

    [Theory]
    [MemberData(nameof(TestCases))]
    public void Run_TestCases_WhenAssertSucceeds_DoesNotThrow(int input, int expected)
    {
        // arrange
        var test = Test.Create(input)
            .Act(x => x * 2)
            .Assert(result => result.ShouldBe(expected));
        
        // act
        var result = Record.Exception(test.Run);
        
        // assert
        Assert.Null(result);
    }
    
    #endregion
}