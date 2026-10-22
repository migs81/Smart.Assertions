using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace Smart.Assertions;

public static class Assert
{
    #region bool
    
    public static void True([DoesNotReturnIf(false)] bool condition)
    {
        if (!condition)
            throw new AssertionException("Assert.IsTrue() failed.");
    }
    
    public static void False([DoesNotReturnIf(true)] bool condition)
    {
        if (condition)
            throw new AssertionException("Assert.IsFalse() failed.");
    }
    
    #endregion
    
    #region string

    public static void Empty(string value)
    {
        if (value?.Length != 0) 
            throw new AssertionException("Assert.Empty() failed.");
    }
    
    public static void NotEmpty(string value)
    {
        if (value?.Length == 0)
            throw new AssertionException("Assert.Empty() failed.");
        
    }
    
    public static void Equal(string expected, string actual, StringComparison comparison)
    {
        if (!string.Equals(expected, actual, comparison))
            throw new AssertionException("Assert.Equal() failed.");
    }
    
    public static void NotEqual(string expected, string actual, StringComparison comparison)
    {
        if (string.Equals(expected, actual, comparison))
            throw new AssertionException("Assert.NotEqual() failed.");
    }
    
    #endregion
    
    #region generic

    public static void Null<T>(T value)
    {
        if (value is not null)
            throw new AssertionException("Assert.Null() failed.");
    }
    
    public static void NotNull<T>(T value)
    {
        if (value is null)
            throw new AssertionException("Assert.NotNull() failed.");
    }
    
    public static void Equal<T>(T expected, T actual)
    {
        if (!EqualityComparer<T>.Default.Equals(expected, actual))
            throw new AssertionException("Assert.Equal() failed.");
    }
    
    public static void NotEqual<T>(T expected, T actual)
    {
        if (EqualityComparer<T>.Default.Equals(expected, actual))
            throw new AssertionException("Assert.NotEqual() failed.");
    }

    #endregion
    
    #region numeric
    
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
    
    #endregion
    
    #region collections

    public static void Empty<T>(ICollection<T> collection)
    {
        if (collection?.Count != 0)
            throw new AssertionException("Assert.Empty() failed.");
    }
    
    public static void NotEmpty<T>(ICollection<T> collection)
    {
        if (collection?.Count == 0)
            throw new AssertionException("Assert.NotEmpty() failed.");
    }
    
    public static void Contains<T>(ICollection<T> collection, T item) where T : IEquatable<T>
    {
        if (collection?.Contains(item) != true)
            throw new AssertionException("Assert.Contains() failed.");
    }
    
    public static void DoesNotContain<T>(ICollection<T> collection, T item) where T : IEquatable<T>
    {
        if (collection?.Contains(item) == true)
            throw new AssertionException("Assert.DoesNotContain() failed.");
    }
    
    #endregion
}