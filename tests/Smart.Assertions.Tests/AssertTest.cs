namespace Smart.Assertions.Tests;

public class AssertTest
{
    [Fact]
    public void True_WhenConditionIsTrue_DoesNotThrow()
    {
        Assert.True(true);
    }

    [Fact]
    public void True_WhenConditionIsFalse_ThrowsAssertionException()
    {
        Xunit.Assert.Throws<AssertionException>(() => Assert.True(false));
    }
}