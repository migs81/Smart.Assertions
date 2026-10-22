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