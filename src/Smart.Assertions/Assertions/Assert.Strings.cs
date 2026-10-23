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

    public static void StartsWith(string value, string actual, StringComparison comparison = StringComparison.Ordinal)
    {
        if (!actual.StartsWith(value, comparison))
            throw new AssertionException("Assert.StartsWith() failed.");
    }
    
    public static void EndsWith(string value, string actual, StringComparison comparison = StringComparison.Ordinal)
    {
        if (!actual.EndsWith(value, comparison))
            throw new AssertionException("Assert.EndsWith() failed.");
    }
    
    public static void Contains(string value, string actual, StringComparison comparison = StringComparison.Ordinal)
    {
        if (!actual.Contains(value, comparison))
            throw new AssertionException("Assert.Contains() failed.");
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
    
    public static string ShouldEqual(this string actual, string expected, StringComparison comparison = StringComparison.Ordinal)
    {
        Assert.Equal(expected, actual, comparison);
        return actual;
    }
    
    public static string ShouldNotEqual(this string actual, string expected, StringComparison comparison = StringComparison.Ordinal)
    {
        Assert.NotEqual(expected, actual, comparison);
        return actual;
    }

    public static string ShouldStartWith(this string actual, string value, StringComparison comparison = StringComparison.Ordinal)
    {
        Assert.StartsWith(value, actual, comparison);
        return actual;
    }
    
    public static string ShouldEndWith(this string actual, string value, StringComparison comparison = StringComparison.Ordinal)
    {
        Assert.EndsWith(value, actual, comparison);
        return actual;
    }
    
    public static string ShouldContain(this string actual, string value, StringComparison comparison = StringComparison.Ordinal)
    {
        Assert.Contains(value, actual, comparison);
        return actual;
    }
}