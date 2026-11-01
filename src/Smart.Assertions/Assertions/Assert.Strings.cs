using System.Runtime.CompilerServices;

namespace Smart.Assertions.Assertions;

public static partial class Assert
{
    #region Empty, NotEmpty

    /// <summary>
    /// Asserts that the string is empty.
    /// </summary>
    /// <param name="value">The value to check.</param>
    /// <param name="expression">The expression representing the value.</param>
    /// <exception cref="AssertionException"></exception>
    public static void Empty(string value, 
        [CallerArgumentExpression(nameof(value))] string? expression = null)
    {
        if (value.Length != 0) 
            throw new AssertionException($"{nameof(Assert)}.{nameof(Empty)}({expression}) failed.",
                $"Expected: an empty string",
                $"Actual: {value}");
    }
    
    /// <summary>
    /// Asserts that the string is not empty.
    /// </summary>
    /// <param name="value">The value to check.</param>
    /// <param name="expression">The expression representing the value.</param>
    /// <exception cref="AssertionException"></exception>
    public static void NotEmpty(string value, 
        [CallerArgumentExpression(nameof(value))] string? expression = null)
    {
        if (value.Length == 0)
            throw new AssertionException($"{nameof(Assert)}.{nameof(NotEmpty)}({expression}) failed.",
                $"Expected: not an empty string",
                $"Actual: \"\"");
    }
    
    #endregion

    #region Equal, NotEqual

    /// <summary>
    /// Asserts that the string equals the specified value.
    /// </summary>
    /// <param name="expected"></param>
    /// <param name="actual">The actual string to check.</param>
    /// <param name="comparison">The string comparison mode.</param>
    /// <param name="expectedExpression">The expression representing the expected value.</param>
    /// <param name="actualExpression">The expression representing the actual value.</param>
    /// <exception cref="AssertionException"></exception>
    public static void Equal(string expected, string actual, StringComparison comparison, 
        [CallerArgumentExpression(nameof(expected))] string? expectedExpression = null, 
        [CallerArgumentExpression(nameof(actual))] string? actualExpression = null)
    {
        if (!string.Equals(expected, actual, comparison))
            throw new AssertionException($"{nameof(Assert)}.{nameof(Equal)}({expectedExpression}, {actualExpression}) failed.",
                $"Expected: \"{expected}\"",
                $"Actual: \"{actual}\"");
    }
    
    /// <summary>
    /// Asserts that the string does not equal the specified value.
    /// </summary>
    /// <param name="expected"></param>
    /// <param name="actual">The actual string to check.</param>
    /// <param name="comparison">The string comparison mode.</param>
    /// <param name="expectedExpression">The expression representing the expected value.</param>
    /// <param name="actualExpression">The expression representing the actual value.</param>
    /// <exception cref="AssertionException"></exception>
    public static void NotEqual(string expected, string actual, StringComparison comparison, 
        [CallerArgumentExpression(nameof(expected))] string? expectedExpression = null, 
        [CallerArgumentExpression(nameof(actual))] string? actualExpression = null)
    {
        if (string.Equals(expected, actual, comparison))
            throw new AssertionException($"{nameof(Assert)}.{nameof(NotEqual)}({expectedExpression}, {actualExpression}) failed.",
                $"Expected: not \"{expected}\"",
                $"Actual: \"{actual}\"");
    }

    #endregion

    #region Starts-, EndsWith

    /// <summary>
    /// Asserts that the string starts with the specified value.
    /// </summary>
    /// <param name="value">The value to check.</param>
    /// <param name="actual">The actual string to check.</param>
    /// <param name="comparison">The string comparison mode.</param>
    /// <param name="valueExpression">The expression representing the value.</param>
    /// <param name="actualExpression">The expression representing the actual value.</param>
    /// <exception cref="AssertionException"></exception>
    public static void StartsWith(string value, string actual, StringComparison comparison = StringComparison.Ordinal, 
        [CallerArgumentExpression(nameof(value))] string? valueExpression = null, 
        [CallerArgumentExpression(nameof(actual))] string? actualExpression = null)
    {
        if (!actual.StartsWith(value, comparison))
            throw new AssertionException($"{nameof(Assert)}.{nameof(StartsWith)}({valueExpression}, {actualExpression}) failed.",
                $"Expected: string starts with \"{value}\"",
                $"Actual: \"{actual}\"");
    }
    
    /// <summary>
    /// Asserts that the string ends with the specified value.
    /// </summary>
    /// <param name="value">The value to check.</param>
    /// <param name="actual">The actual string to check.</param>
    /// <param name="comparison">The string comparison mode.</param>
    /// <param name="valueExpression">The expression representing the value.</param>
    /// <param name="actualExpression">The expression representing the actual value.</param>
    /// <exception cref="AssertionException"></exception>
    public static void EndsWith(string value, string actual, StringComparison comparison = StringComparison.Ordinal, 
        [CallerArgumentExpression(nameof(value))] string? valueExpression = null, 
        [CallerArgumentExpression(nameof(actual))] string? actualExpression = null)
    {
        if (!actual.EndsWith(value, comparison))
            throw new AssertionException($"{nameof(Assert)}.{nameof(EndsWith)}({valueExpression}, {actualExpression}) failed.",
                $"Expected: string ends with \"{value}\"",
                $"Actual: \"{actual}\"");
    }

    #endregion

    #region Contains, DoesNotContain
    
    /// <summary>
    /// Asserts that the actual value contains the expected value.
    /// </summary>
    /// <param name="value">The value to check.</param>
    /// <param name="actual">The actual string to check.</param>
    /// <param name="comparison">The string comparison mode.</param>
    /// <param name="valueExpression">The expression representing the value.</param>
    /// <param name="actualExpression">The expression representing the actual value.</param>
    /// <exception cref="AssertionException"></exception>
    public static void Contains(string value, string actual, StringComparison comparison = StringComparison.Ordinal, 
        [CallerArgumentExpression(nameof(value))] string? valueExpression = null, 
        [CallerArgumentExpression(nameof(actual))] string? actualExpression = null)
    {
        if (!actual.Contains(value, comparison))
            throw new AssertionException($"{nameof(Assert)}.{nameof(Contains)}({valueExpression}, {actualExpression}) failed.",
                $"Expected: string contains \"{value}\"",
                $"Actual: \"{actual}\"");
    }
    
    /// <summary>
    /// Asserts that the actual value does not contain the specified value.
    /// </summary>
    /// <param name="value">The value to check.</param>
    /// <param name="actual">The actual string to check.</param>
    /// <param name="comparison">The string comparison mode.</param>
    /// <param name="valueExpression">The expression representing the value.</param>
    /// <param name="actualExpression">The expression representing the actual value.</param>
    /// <exception cref="AssertionException"></exception>
    public static void DoesNotContain(string value, string actual, StringComparison comparison = StringComparison.Ordinal, 
        [CallerArgumentExpression(nameof(value))] string? valueExpression = null, 
        [CallerArgumentExpression(nameof(actual))] string? actualExpression = null)
    {
        if (actual.Contains(value, comparison))
            throw new AssertionException($"{nameof(Assert)}.{nameof(DoesNotContain)}({valueExpression}, {actualExpression}) failed.",
                $"Expected: string does not contain \"{value}\"",
                $"Actual: \"{actual}\"");
    }
    
    #endregion
}

public static partial class AssertExtensions
{
    #region ShouldBeEmpty, ShouldNotBeEmpty
    
    /// <summary>
    /// Asserts that the string is empty and returns the string.
    /// </summary>
    /// <param name="value">The value to check.</param>
    /// <param name="expression">The expression representing the value.</param>
    /// <returns>The checked string.</returns>
    /// <exception cref="AssertionException"></exception>
    public static string ShouldBeEmpty(this string value,
        [CallerArgumentExpression(nameof(value))] string? expression = null)
    {
        if (value.Length != 0) 
            throw new AssertionException($"{expression}.{nameof(ShouldBeEmpty)}() failed.",
                $"Expected: an empty string",
                $"Actual: {value}");

        return value;
    }
    
    /// <summary>
    /// Asserts that the string is not empty and returns the string.
    /// </summary>
    /// <param name="value">The value to check.</param>
    /// <param name="expression">The expression representing the value.</param>
    /// <returns>The checked string.</returns>
    /// <exception cref="AssertionException"></exception>
    public static string ShouldNotBeEmpty(this string value, 
        [CallerArgumentExpression(nameof(value))] string? expression = null)
    {
        if (value.Length == 0) 
            throw new AssertionException($"{expression}.{nameof(ShouldNotBeEmpty)}() failed.",
                $"Expected: not an empty string",
                $"Actual: {value}");

        return value;
    }
    
    #endregion
    
    #region ShouldEqual, ShouldNotEqual
    
    /// <summary>
    /// Asserts that the string equals the specified value and returns the string.
    /// </summary>
    /// <param name="actual">The actual string to check.</param>
    /// <param name="expected"></param>
    /// <param name="comparison">The string comparison mode.</param>
    /// <param name="actualExpression">The expression representing the actual value.</param>
    /// <param name="expectedExpression">The expression representing the expected value.</param>
    /// <returns>The checked string.</returns>
    /// <exception cref="AssertionException"></exception>
    public static string ShouldEqual(this string actual, string expected, StringComparison comparison = StringComparison.Ordinal, 
        [CallerArgumentExpression(nameof(actual))] string? actualExpression = null, 
        [CallerArgumentExpression(nameof(expected))] string? expectedExpression = null)
    {
        if (!string.Equals(expected, actual, comparison))
            throw new AssertionException($"{actualExpression}.{nameof(ShouldEqual)}({expectedExpression}, {comparison}) failed.",
                $"Expected: \"{expected}\"",
                $"Actual: \"{actual}\"");
        
        return actual;
    }
    
    /// <summary>
    /// Asserts that the string does not equal the specified value and returns the string.
    /// </summary>
    /// <param name="actual">The actual string to check.</param>
    /// <param name="expected"></param>
    /// <param name="comparison">The string comparison mode.</param>
    /// <param name="actualExpression">The expression representing the actual value.</param>
    /// <param name="expectedExpression">The expression representing the expected value.</param>
    /// <returns>The checked string.</returns>
    /// <exception cref="AssertionException"></exception>
    public static string ShouldNotEqual(this string actual, string expected, StringComparison comparison = StringComparison.Ordinal, 
        [CallerArgumentExpression(nameof(actual))] string? actualExpression = null, 
        [CallerArgumentExpression(nameof(expected))] string? expectedExpression = null)
    {
        if (string.Equals(expected, actual, comparison))
            throw new AssertionException($"{actualExpression}.{nameof(ShouldNotEqual)}({expectedExpression}, {comparison}) failed.",
                $"Expected: not \"{expected}\"",
                $"Actual: \"{actual}\"");

        return actual;
    }

    #endregion
    
    #region ShouldStartWith, ShouldEndWith
    
    /// <summary>
    /// Asserts that the string starts with the specified value and returns the string.
    /// </summary>
    /// <param name="actual">The actual string to check.</param>
    /// <param name="value">The value to check.</param>
    /// <param name="comparison">The string comparison mode.</param>
    /// <param name="valueExpression">The expression representing the value.</param>
    /// <param name="actualExpression">The expression representing the actual value.</param>
    /// <returns>The checked string.</returns>
    /// <exception cref="AssertionException"></exception>
    public static string ShouldStartWith(this string actual, string value, StringComparison comparison = StringComparison.Ordinal, 
        [CallerArgumentExpression(nameof(value))] string? valueExpression = null, 
        [CallerArgumentExpression(nameof(actual))] string? actualExpression = null)
    {
        if (!actual.StartsWith(value, comparison))
            throw new AssertionException($"{actualExpression}.{nameof(ShouldStartWith)}({valueExpression}, {comparison}) failed.",
                $"Expected: string starts with \"{value}\"",
                $"Actual: \"{actual}\"");
        
        return actual;
    }
    
    /// <summary>
    /// Asserts that the string ends with the specified value and returns the string.
    /// </summary>
    /// <param name="actual">The actual string to check.</param>
    /// <param name="value">The value to check.</param>
    /// <param name="comparison">The string comparison mode.</param>
    /// <param name="valueExpression">The expression representing the value.</param>
    /// <param name="actualExpression">The expression representing the actual value.</param>
    /// <returns>The checked string.</returns>
    /// <exception cref="AssertionException"></exception>
    public static string ShouldEndWith(this string actual, string value, StringComparison comparison = StringComparison.Ordinal, 
        [CallerArgumentExpression(nameof(value))] string? valueExpression = null, 
        [CallerArgumentExpression(nameof(actual))] string? actualExpression = null)
    {
        if (!actual.EndsWith(value, comparison))
            throw new AssertionException($"{actualExpression}.{nameof(ShouldEndWith)}({valueExpression}, {comparison}) failed.",
                $"Expected: string ends with \"{value}\"",
                $"Actual: \"{actual}\"");
        
        return actual;
    }
    
    #endregion
    
    #region ShouldContain, ShouldNotContain
    
    /// <summary>
    /// Asserts that the string contains the specified value and returns the string.
    /// </summary>
    /// <param name="actual">The actual string to check.</param>
    /// <param name="value">The value to check.</param>
    /// <param name="comparison">The string comparison mode.</param>
    /// <param name="valueExpression">The expression representing the value.</param>
    /// <param name="actualExpression">The expression representing the actual value.</param>
    /// <returns>The checked string.</returns>
    /// <exception cref="AssertionException"></exception>
    public static string ShouldContain(this string actual, string value, StringComparison comparison = StringComparison.Ordinal, 
        [CallerArgumentExpression(nameof(value))] string? valueExpression = null, 
        [CallerArgumentExpression(nameof(actual))] string? actualExpression = null)
    {
        if (!actual.Contains(value, comparison))
            throw new AssertionException($"{actualExpression}.{nameof(ShouldContain)}({valueExpression}, {comparison}) failed.",
                $"Expected: string contains \"{value}\"",
                $"Actual: {actual}");
        
        return actual;
    }
    
    /// <summary>
    /// Asserts that the string does not contain the specified value and returns the string.
    /// </summary>
    /// <param name="actual">The actual string to check.</param>
    /// <param name="value">The value to check.</param>
    /// <param name="comparison">The string comparison mode.</param>
    /// <param name="valueExpression">The expression representing the value.</param>
    /// <param name="actualExpression">The expression representing the actual value.</param>
    /// <returns>The checked string.</returns>
    /// <exception cref="AssertionException"></exception>
    public static string ShouldNotContain(this string actual, string value, StringComparison comparison = StringComparison.Ordinal, 
        [CallerArgumentExpression(nameof(value))] string? valueExpression = null, 
        [CallerArgumentExpression(nameof(actual))] string? actualExpression = null)
    {
        if (actual.Contains(value, comparison))
            throw new AssertionException($"{actualExpression}.{nameof(ShouldNotContain)}({valueExpression}, {comparison}) failed.",
                $"Expected: string does not contain \"{value}\"",
                $"Actual: {actual}");
        
        return actual;
    }
    
    #endregion
}