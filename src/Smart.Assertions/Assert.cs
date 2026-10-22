namespace Smart.Assertions;

public static class Assert
{
    public static void True(bool condition)
    {
        if (!condition)
            throw new AssertionException("Assert.IsTrue() failed.");
    }
    
    public static void False(bool condition)
    {
        if (condition)
            throw new AssertionException("Assert.IsFalse() failed.");
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

    public static void LowerThan(int expected, int actual)
    {
        if (actual < expected)
            throw new AssertionException("Assert.LowerThan() failed.");
    }
}