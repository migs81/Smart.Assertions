using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace Smart.Assertions.Assertions;

public static partial class Assert
{
    public static void LessThan<T>(T expected, T actual) where T : INumber<T>
    {
        if (actual >= expected)
            throw new AssertionException("Assert.LessThan() failed.");
    }

    public static void LessThanOrEqual<T>(T expected, T actual) where T : INumber<T>
    {
        if (actual > expected)
            throw new AssertionException("Assert.LessThan() failed.");
    }

    public static void GreaterThan<T>(T expected, T actual) where T : INumber<T>
    {
        if (actual <= expected)
            throw new AssertionException("Assert.GreaterThan() failed.");
    }

    public static void GreaterThanOrEqual<T>(T expected, T actual) where T : INumber<T>
    {
        if (actual < expected)
            throw new AssertionException("Assert.GreaterThan() failed.");
    }

    public static void Between<T>(T value, T min, T max) where T : INumber<T>
    {
        if (value < min || value > max)
            throw new AssertionException("Assert.Between() failed.");
    }
}

public static partial class AssertExtensions
{
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
    
    public static T ShouldBeBetween<T>(this T value, T low, T high) where T : INumber<T>
    {
        Assert.Between(value, low, high);
        return value;
    }
}