using System.Diagnostics.CodeAnalysis;

namespace Smart.Assertions.Assertions;

public static partial class Assert
{
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
}

public static partial class AssertExtensions
{
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
}