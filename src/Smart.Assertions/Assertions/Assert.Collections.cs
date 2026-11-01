using System.Runtime.CompilerServices;

namespace Smart.Assertions.Assertions;

public static partial class Assert
{
    #region Empty, NotEmpty

    /// <summary>
    /// Asserts that the collection is empty.
    /// </summary>
    /// <param name="collection"></param>
    /// <param name="expression">The expression representing the value.</param>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <exception cref="AssertionException"></exception>
    public static void Empty<T>(ICollection<T> collection, 
        [CallerArgumentExpression(nameof(collection))] string? expression = null)
    {
        if (collection.Count != 0)
            throw new AssertionException($"{nameof(Assert)}.{nameof(Empty)}({expression}) failed.",
                "Expected: empty collection",
                $"Actual: collection contains {collection.Count} element(s)");
    }

    /// <summary>
    /// Asserts that the collection is not empty.
    /// </summary>
    /// <param name="collection"></param>
    /// <param name="expression">The expression representing the value.</param>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <exception cref="AssertionException"></exception>
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

    /// <summary>
    /// Asserts that the collection contains the specified item.
    /// </summary>
    /// <param name="collection"></param>
    /// <param name="item"></param>
    /// <param name="collectionExpression"></param>
    /// <param name="itemExpression"></param>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <exception cref="AssertionException"></exception>
    public static void Contains<T>(ICollection<T> collection, T item, 
        [CallerArgumentExpression(nameof(collection))] string? collectionExpression = null,
        [CallerArgumentExpression(nameof(item))] string? itemExpression = null)
    {
        if (!collection.Contains(item))
            throw new AssertionException($"{nameof(Assert)}.{nameof(Contains)}({collectionExpression}, {itemExpression}) failed.",
                $"Expected: {item}",
                $"Actual: does not contain {item}");
    }
    
    /// <summary>
    /// Asserts that the collection does not contain the specified item.
    /// </summary>
    /// <param name="collection"></param>
    /// <param name="item"></param>
    /// <param name="collectionExpression"></param>
    /// <param name="itemExpression"></param>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <exception cref="AssertionException"></exception>
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
    
    /// <summary>
    /// Asserts that the collection is empty and returns the collection.
    /// </summary>
    /// <param name="collection"></param>
    /// <param name="expression">The expression representing the value.</param>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <returns>The checked collection.</returns>
    /// <exception cref="AssertionException"></exception>
    public static ICollection<T> ShouldBeEmpty<T>(this ICollection<T> collection,
        [CallerArgumentExpression(nameof(collection))] string? expression = null)
    {
        if (collection.Count != 0)
            throw new AssertionException($"{expression}.{nameof(ShouldBeEmpty)}() failed.",
                "Expected: empty collection",
                $"Actual: collection contains {collection.Count} element(s)");
        
        return collection;
    }

    /// <summary>
    /// Asserts that the collection is not empty and returns the collection.
    /// </summary>
    /// <param name="collection"></param>
    /// <param name="expression">The expression representing the value.</param>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <returns>The checked collection.</returns>
    /// <exception cref="AssertionException"></exception>
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

    /// <summary>
    /// Asserts that the collection contains the specified item and returns the collection.
    /// </summary>
    /// <param name="collection"></param>
    /// <param name="item"></param>
    /// <param name="collectionExpression"></param>
    /// <param name="itemExpression"></param>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <returns>The checked collection.</returns>
    /// <exception cref="AssertionException"></exception>
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

    /// <summary>
    /// Asserts that the collection does not contain the specified item and returns the collection.
    /// </summary>
    /// <param name="collection"></param>
    /// <param name="item"></param>
    /// <param name="collectionExpression"></param>
    /// <param name="itemExpression"></param>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <returns>The checked collection.</returns>
    /// <exception cref="AssertionException"></exception>
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