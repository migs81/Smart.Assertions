namespace Smart.Assertions;

public static class Extensions
{
    public static bool True(this bool value)
    {
        Assert.True(value);
        return value;
    }

    public static bool False(this bool value)
    {
        Assert.False(value);
        return value;
    }
}