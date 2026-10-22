using System.Numerics;

namespace Smart.Assertions;

public static class Extensions
{
    #region bool

    public static bool ShouldBeTrue(this bool value)
    {
        Assert.True(value);
        return value;
    }

    public static bool ShouldBeFalse(this bool value)
    {
        Assert.False(value);
        return value;
    }

    #endregion

    #region string

    public static string ShouldEqual(this string actual, string expected, StringComparison comparison)
    {
        Assert.Equal(expected, actual, comparison);
        return actual;
    }
    
    #endregion
    
    #region generic

    public static T ShouldEqual<T>(this T actual, T expected)
    {
        Assert.Equal(expected, actual);
        return actual;
    }
    
    #endregion
    
    #region numeric
    
    public static T ShouldBeLessThan<T>(this T actual, T expected) where T : INumber<T>
    {
        Assert.LessThan(expected, actual);
        return actual;
    }
    
    public static T ShouldBeLessThanOrEqual<T>(this T actual, T expected) where T : INumber<T>
    {
        Assert.LessThanOrEqual(expected, actual);
        return actual;
    }
    
    public static T ShouldBeGreaterThan<T>(this T actual, T expected) where T : INumber<T>
    {
        Assert.GreaterThan(expected, actual);
        return actual;
    }
    
    public static T ShouldBeGreaterThanOrEqual<T>(this T actual, T expected) where T : INumber<T>
    {
        Assert.GreaterThanOrEqual(expected, actual);
        return actual;
    }
    
    #endregion
}