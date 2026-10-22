namespace Smart.Assertions;

public static class Extensions
{
    public static bool True(this bool value)
    {
        if (!value)
            throw new AssertionException("Assert.True() failed.");

        return value;
    }

    public static bool False(this bool value)
    {
        if (value)
            throw new AssertionException("Assert.True() failed.");

        return value;
    }
}