using System.Numerics;
using Smart.Assertions.Assertions;

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

    public static string Empty(this string value)
    {
        Assert.Empty(value);
        return value;
    }
    
    public static string NotEmpty(this string value)
    {
        Assert.NotEmpty(value);
        return value;
    }
    
    public static string ShouldEqual(this string actual, string expected, StringComparison comparison)
    {
        Assert.Equal(expected, actual, comparison);
        return actual;
    }
    
    public static string ShouldNotEqual(this string actual, string expected, StringComparison comparison)
    {
        Assert.NotEqual(expected, actual, comparison);
        return actual;
    }
    
    #endregion
    
    #region generic

    public static T ShouldBeNull<T>(this T value)
    {
        Assert.Null(value);
        return value;
    }
    
    public static T ShouldNotBeNull<T>(this T value)
    {
        Assert.NotNull(value);
        return value;
    }
    
    public static T ShouldEqual<T>(this T actual, T expected)
    {
        Assert.Equal(expected, actual);
        return actual;
    }
    
    public static T ShouldNotEqual<T>(this T actual, T expected)
    {
        Assert.NotEqual(expected, actual);
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
    
    public static T ShouldBeBetween<T>(this T value, T low, T high) where T : INumber<T>
    {
        Assert.Between(value, low, high);
        return value;
    }
    
    #endregion
    
    #region collections

    public static ICollection<T> ShouldBeEmpty<T>(this ICollection<T> collection)
    {
        Assert.Empty(collection);
        return collection;
    }
    
    public static ICollection<T> ShouldNotBeEmpty<T>(this ICollection<T> collection)
    {
        Assert.NotEmpty(collection);
        return collection;
    }
    
    public static ICollection<T> ShouldContain<T>(this ICollection<T> collection, T item) where T : IEquatable<T>
    {
        Assert.Contains(collection, item);
        return collection;
    }
    
    public static ICollection<T> ShouldNotContain<T>(this ICollection<T> collection, T item) where T : IEquatable<T>
    {
        Assert.DoesNotContain(collection, item);
        return collection;
    }
    
    #endregion
}