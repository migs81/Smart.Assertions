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
    
    #endregion
}