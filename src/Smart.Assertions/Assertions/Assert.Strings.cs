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