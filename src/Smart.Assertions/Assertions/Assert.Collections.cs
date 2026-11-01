using System.Runtime.CompilerServices;

namespace Smart.Assertions.Assertions;

public static partial class Assert
{
    #region Empty, NotEmpty

    public static void Empty<T>(ICollection<T> collection, 
        [CallerArgumentExpression(nameof(collection))] string? expression = null)
    {
        if (collection.Count != 0)
            throw new AssertionException($"{nameof(Assert)}.{nameof(Empty)}({expression}) failed.",
                "Expected: empty collection",
                $"Actual: collection contains {collection.Count} element(s)");
    }

    public static void NotEmpty<T>(ICollection<T> collection, 
        [CallerArgumentExpression(nameof(collection))] string? expression = null)
    {
        if (collection.Count == 0)
            throw new AssertionException($"{nameof(Assert)}.{nameof(NotEmpty)}({expression}) failed.",
                "Expected: not an empty collection",
                $"Actual: an empty collection");
    }

    #endregion

    #region Contains, DoesNotContain

    public static void Contains<T>(ICollection<T> collection, T item, 
        [CallerArgumentExpression(nameof(collection))] string? collectionExpression = null,
        [CallerArgumentExpression(nameof(item))] string? itemExpression = null)
    {
        if (!collection.Contains(item))
            throw new AssertionException($"{nameof(Assert)}.{nameof(Contains)}({collectionExpression}, {itemExpression}) failed.",
                $"Expected: {item}",
                $"Actual: does not contain {item}");
    }
    
    public static void DoesNotContain<T>(ICollection<T> collection, T item, 
        [CallerArgumentExpression(nameof(collection))] string? collectionExpression = null,
        [CallerArgumentExpression(nameof(item))] string? itemExpression = null)
    {
        if (collection.Contains(item))
            throw new AssertionException($"{nameof(Assert)}.{nameof(Contains)}({collectionExpression}, {itemExpression}) failed.",
                $"Expected: does not contain {item}",
                $"Actual: contains {item}");
    }

    #endregion    
}

public static partial class AssertExtensions
{
    #region Empty, NotEmpty
    
    public static ICollection<T> ShouldBeEmpty<T>(this ICollection<T> collection,
        [CallerArgumentExpression(nameof(collection))] string? expression = null)
    {
        if (collection.Count != 0)
            throw new AssertionException($"{expression}.{nameof(ShouldBeEmpty)}() failed.",
                "Expected: empty collection",
                $"Actual: collection contains {collection.Count} element(s)");
        
        return collection;
    }

    public static ICollection<T> ShouldNotBeEmpty<T>(this ICollection<T> collection,
        [CallerArgumentExpression(nameof(collection))] string? expression = null)
    {
        if (collection.Count == 0)
            throw new AssertionException($"{expression}.{nameof(ShouldNotBeEmpty)}() failed.",
                "Expected: not an empty collection",
                $"Actual: an empty collection");
        
        return collection;
    }

    #endregion
        
    #region Contains, DoesNotContain

    public static ICollection<T> ShouldContain<T>(this ICollection<T> collection, T item,
        [CallerArgumentExpression(nameof(collection))] string? collectionExpression = null,
        [CallerArgumentExpression(nameof(item))] string? itemExpression = null)
    {
        if (!collection.Contains(item))
            throw new AssertionException($"{collectionExpression}.{nameof(ShouldContain)}({itemExpression}) failed.",
                $"Expected: {item}",
                $"Actual: does not contain {item}");

        return collection;
    }

    public static ICollection<T> ShouldNotContain<T>(this ICollection<T> collection, T item,
        [CallerArgumentExpression(nameof(collection))] string? collectionExpression = null,
        [CallerArgumentExpression(nameof(item))] string? itemExpression = null)
    {
        if (collection.Contains(item))
            throw new AssertionException($"{collectionExpression}.{nameof(ShouldNotContain)}({itemExpression}) failed.",
                "Expected: not an empty collection",
                $"Actual: an empty collection");

        return collection;
    }

    #endregion
}