namespace Smart.Assertions.Assertions;

public static partial class Assert
{
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
}

public static partial class AssertExtensions
{
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
}