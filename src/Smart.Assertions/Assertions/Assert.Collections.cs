using System.Diagnostics.CodeAnalysis;

namespace Smart.Assertions.Assertions;

public static partial class Assert
{
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
}