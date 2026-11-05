using System.Runtime.CompilerServices;

namespace Smart.Assertions.Assertions;

public static partial class Assert
{
    #region Null, NotNull
    
    /// <summary>
    /// Asserts that the specified value is null.
    /// </summary>
    /// <param name="value">The value to check.</param>
    /// <param name="expression">The expression representing the value.</param>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <exception cref="AssertionException">The value is not null.</exception>
    public static void Null<T>(T value, 
        [CallerArgumentExpression(nameof(value))] string? expression = null)
    {
        if (value is not null)
            throw new AssertionException($"{nameof(Assert)}.{nameof(Null)}({expression}) failed.",
                $"Expected: null",
                $"Actual: {value}");
    }
    
    /// <summary>
    /// Asserts that the specified value is not null.
    /// </summary>
    /// <param name="value">The value to check.</param>
    /// <param name="expression">The expression representing the value.</param>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <exception cref="AssertionException">The value is null.</exception>
    public static void NotNull<T>(T value, 
        [CallerArgumentExpression(nameof(value))] string? expression = null)
    {
        if (value is null)
            throw new AssertionException($"{nameof(Assert)}.{nameof(NotNull)}({expression}) failed.",
                $"Expected: not null",
                $"Actual: null");
    }
    
    #endregion
    
    #region Equal, NotEqual
    
    /// <summary>
    /// Asserts that the expected and actual values are equal.
    /// </summary>
    /// <param name="expected">The expected value.</param>
    /// <param name="actual">The actual value.</param>
    /// <param name="expectedExpression">The expression representing the expected value.</param>
    /// <param name="actualExpression">The expression representing the actual value.</param>
    /// <typeparam name="T">The type of the values.</typeparam>
    /// <exception cref="AssertionException">The values are not equal.</exception>
    public static void Equal<T>(T expected, T actual, 
        [CallerArgumentExpression(nameof(expected))] string? expectedExpression = null, 
        [CallerArgumentExpression(nameof(actual))] string? actualExpression = null)
    {
        if (!EqualityComparer<T>.Default.Equals(expected, actual))
            throw new AssertionException($"{nameof(Assert)}.{nameof(Equal)}({expectedExpression}, {actualExpression}) failed.",
                $"Expected: {expected}",
                $"Actual: {actual}");
    }
    
    /// <summary>
    /// Asserts that the expected and actual values are not equal.
    /// </summary>
    /// <param name="expected">The expected value.</param>
    /// <param name="actual">The actual value to check.</param>
    /// <param name="expectedExpression">The expression representing the expected value.</param>
    /// <param name="actualExpression">The expression representing the actual value.</param>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <exception cref="AssertionException">The values are equal.</exception>
    public static void NotEqual<T>(T expected, T actual, 
        [CallerArgumentExpression(nameof(expected))] string? expectedExpression = null, 
        [CallerArgumentExpression(nameof(actual))] string? actualExpression = null)
    {
        if (EqualityComparer<T>.Default.Equals(expected, actual))
            throw new AssertionException($"{nameof(Assert)}.{nameof(NotEqual)}({expectedExpression}, {actualExpression}) failed.",
                $"Expected: not {expected}",
                $"Actual: {actual}");
    }
    
    #endregion
}

public static partial class AssertExtensions
{
    #region ShouldBeNull, ShouldNotBeNull

    /// <summary>
    /// Asserts that the value is null and returns it.
    /// </summary>
    /// <param name="value">The value to check.</param>
    /// <param name="expression">The expression representing the value.</param>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <returns>The checked value.</returns>
    /// <exception cref="AssertionException">The value is not null.</exception>
    public static T ShouldBeNull<T>(this T value, 
        [CallerArgumentExpression(nameof(value))] string? expression = null)
    {
        if (value is not null)
            throw new AssertionException($"{expression}.{nameof(ShouldBeNull)}() failed.",
                $"Expected: null",
                $"Actual: {value}");
        
        return value;
    }
    
    /// <summary>
    /// Asserts that the value is not null and returns it.
    /// </summary>
    /// <param name="value">The value to check.</param>
    /// <param name="expression">The expression representing the value.</param>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <returns>The checked value.</returns>
    /// <exception cref="AssertionException">The value is null.</exception>
    public static T ShouldNotBeNull<T>(this T value, 
        [CallerArgumentExpression(nameof(value))] string? expression = null)
    {
        if (value is null)
            throw new AssertionException($"{expression}.{nameof(ShouldNotBeNull)}() failed.",
                $"Expected: not null",
                $"Actual: null");
        
        return value;
    }

    #endregion

    #region ShouldEqual, ShouldNotEqual

    /// <summary>
    /// Asserts that the expected and actual values are equal and return the actual value.
    /// </summary>
    /// <param name="actual">The actual value to check.</param>
    /// <param name="expected">The expected value.</param>
    /// <param name="expectedExpression">The expression representing the expected value.</param>
    /// <param name="actualExpression">The expression representing the actual value.</param>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <returns>The checked value.</returns>
    /// <exception cref="AssertionException">The values are not equal.</exception>
    public static T ShouldEqual<T>(this T actual, T expected, 
        [CallerArgumentExpression(nameof(expected))] string? expectedExpression = null, 
        [CallerArgumentExpression(nameof(actual))] string? actualExpression = null)
    {
        if (!EqualityComparer<T>.Default.Equals(expected, actual))
            throw new AssertionException($"{actualExpression}.{nameof(ShouldEqual)}({expectedExpression}) failed.",
                $"Expected: {expected}",
                $"Actual: {actual}");
        
        return actual;
    }
    
    /// <summary>
    /// Asserts that the expected and actual values are not equal and returns the actual value.
    /// </summary>
    /// <param name="actual">The actual value to check.</param>
    /// <param name="expected">The expected value.</param>
    /// <param name="expectedExpression">The expression representing the expected value.</param>
    /// <param name="actualExpression">The expression representing the actual value.</param>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <returns>The checked value.</returns>
    /// <exception cref="AssertionException">The values are equal.</exception>
    public static T ShouldNotEqual<T>(this T actual, T expected, 
        [CallerArgumentExpression(nameof(expected))] string? expectedExpression = null, 
        [CallerArgumentExpression(nameof(actual))] string? actualExpression = null)
    {
        if (EqualityComparer<T>.Default.Equals(expected, actual))
            throw new AssertionException($"{expectedExpression}.{nameof(ShouldNotEqual)}({expectedExpression}) failed.",
                $"Expected: not {expected}",
                $"Actual: {actual}");
        
        return actual;
    }

    #endregion
}