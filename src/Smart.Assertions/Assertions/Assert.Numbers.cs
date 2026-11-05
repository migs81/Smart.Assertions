using System.Numerics;
using System.Runtime.CompilerServices;

namespace Smart.Assertions.Assertions;

public static partial class Assert
{
    #region LessThan, LessThanOrEqual
    
    /// <summary>
    /// Asserts that the actual value is less than the expected value.
    /// </summary>
    /// <param name="expected">The expected value.</param>
    /// <param name="actual">The actual value to check.</param>
    /// <param name="expectedExpression">The expression representing the expected value.</param>
    /// <param name="actualExpression">The expression representing the actual value.</param>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <exception cref="AssertionException"></exception>
    public static void LessThan<T>(T expected, T actual, 
        [CallerArgumentExpression(nameof(expected))] string? expectedExpression = null,
        [CallerArgumentExpression(nameof(actual))] string? actualExpression = null)
        where T : INumber<T>
    {
        if (actual >= expected)
            throw new AssertionException($"{nameof(Assert)}.{nameof(LessThan)}({expectedExpression}, {actualExpression}) failed.",
                $"Expected: a number less than {expected}",
                $"Actual: {actual}");
    }

    /// <summary>
    /// Asserts that the actual value is less than or equal the expected value.
    /// </summary>
    /// <param name="expected">The expected value.</param>
    /// <param name="actual">The actual value to check.</param>
    /// <param name="expectedExpression">The expression representing the expected value.</param>
    /// <param name="actualExpression">The expression representing the actual value.</param>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <exception cref="AssertionException"></exception>
    public static void LessThanOrEqual<T>(T expected, T actual, 
        [CallerArgumentExpression(nameof(expected))] string? expectedExpression = null,
        [CallerArgumentExpression(nameof(actual))] string? actualExpression = null)
        where T : INumber<T>
    {
        if (actual > expected)
            throw new AssertionException($"{nameof(Assert)}.{nameof(LessThanOrEqual)}({expectedExpression}, {actualExpression}) failed.",
                $"Expected: a number less or equal than {expected}",
                $"Actual: {actual}");
    }

    #endregion
    
    #region GreaterThan, GreaterThanOrEqual
    
    /// <summary>
    /// Asserts that the actual value is greater than the expected value.
    /// </summary>
    /// <param name="expected">The expected value.</param>
    /// <param name="actual">The actual value to check.</param>
    /// <param name="expectedExpression">The expression representing the expected value.</param>
    /// <param name="actualExpression">The expression representing the actual value.</param>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <exception cref="AssertionException"></exception>
    public static void GreaterThan<T>(T expected, T actual, 
        [CallerArgumentExpression(nameof(expected))] string? expectedExpression = null,
        [CallerArgumentExpression(nameof(actual))] string? actualExpression = null)
        where T : INumber<T>
    {
        if (actual <= expected)
            throw new AssertionException($"{nameof(Assert)}.{nameof(GreaterThan)}({expectedExpression}, {actualExpression}) failed.",
                $"Expected: a number greater than {expected}",
                $"Actual: {actual}");
    }

    /// <summary>
    /// Asserts that the actual value is greater than or equal the expected value.
    /// </summary>
    /// <param name="expected">The expected value.</param>
    /// <param name="actual">The actual value to check.</param>
    /// <param name="expectedExpression">The expression representing the expected value.</param>
    /// <param name="actualExpression">The expression representing the actual value.</param>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <exception cref="AssertionException"></exception>
    public static void GreaterThanOrEqual<T>(T expected, T actual, 
        [CallerArgumentExpression(nameof(expected))] string? expectedExpression = null,
        [CallerArgumentExpression(nameof(actual))] string? actualExpression = null)
        where T : INumber<T>
    {
        if (actual < expected)
            throw new AssertionException($"{nameof(Assert)}.{nameof(GreaterThanOrEqual)}({expectedExpression}, {actualExpression}) failed.",
                $"Expected: a number greater or equal than {expected}",
                $"Actual: {actual}");
    }

    #endregion
    
    #region Between
    
    /// <summary>
    /// Asserts that the value is within the specified range, inclusive.
    /// </summary>
    /// <param name="value">The value to check.</param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <param name="valueExpression">The expression representing the value.</param>
    /// <param name="minExpression"></param>
    /// <param name="maxExpression"></param>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <exception cref="AssertionException"></exception>
    public static void Between<T>(T value, T min, T max, 
        [CallerArgumentExpression(nameof(value))] string? valueExpression = null,
        [CallerArgumentExpression(nameof(min))] string? minExpression = null,
        [CallerArgumentExpression(nameof(max))] string? maxExpression = null)
        where T : INumber<T>
    {
        if (value < min || value > max)
            throw new AssertionException($"{nameof(Assert)}.{nameof(Between)}({valueExpression}, {minExpression}, {maxExpression}) failed.",
                $"Expected: a number between {min} and {max}",
                $"Actual: {value}");
    }
    
    #endregion
}

public static partial class AssertExtensions
{
    #region ShouldBeLessThan, ShouldBeLessThanOrEqual
    
    /// <summary>
    /// Asserts that the actual value is less than the expected value and returns the value.
    /// </summary>
    /// <param name="actual">The actual value to check.</param>
    /// <param name="expected">The expected value.</param>
    /// <param name="expectedExpression">The expression representing the expected value.</param>
    /// <param name="actualExpression">The expression representing the actual value.</param>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <returns>The checked value.</returns>
    /// <exception cref="AssertionException"></exception>
    public static T ShouldBeLessThan<T>(this T actual, T expected, 
        [CallerArgumentExpression(nameof(expected))] string? expectedExpression = null,
        [CallerArgumentExpression(nameof(actual))] string? actualExpression = null)
        where T : INumber<T>
    {
        if (actual >= expected)
            throw new AssertionException($"{actualExpression}.{nameof(ShouldBeLessThan)}({expectedExpression}) failed.",
                $"Expected: a number less than {expected}",
                $"Actual: {actual}");

        return actual;
    }
    
    /// <summary>
    /// Asserts that the actual value is less than or equal the expected value and returns the value.
    /// </summary>
    /// <param name="actual">The actual value to check.</param>
    /// <param name="expected">The expected value.</param>
    /// <param name="expectedExpression">The expression representing the expected value.</param>
    /// <param name="actualExpression">The expression representing the actual value.</param>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <returns>The checked value.</returns>
    /// <exception cref="AssertionException"></exception>
    public static T ShouldBeLessThanOrEqual<T>(this T actual, T expected, 
        [CallerArgumentExpression(nameof(expected))] string? expectedExpression = null,
        [CallerArgumentExpression(nameof(actual))] string? actualExpression = null)
        where T : INumber<T>
    {
        if (actual > expected)
            throw new AssertionException($"{actualExpression}.{nameof(ShouldBeLessThanOrEqual)}({expectedExpression}) failed.",
                $"Expected: a number less or equal than {expected}",
                $"Actual: {actual}");
        
        return actual;
    }
    
    #endregion
    
    #region ShouldBeGreaterThan, ShouldBeGreaterThanOrEqual
    
    /// <summary>
    /// Asserts that the actual value is greater than the expected value and returns the value.
    /// </summary>
    /// <param name="actual">The actual value to check.</param>
    /// <param name="expected">The expected value.</param>
    /// <param name="expectedExpression">The expression representing the expected value.</param>
    /// <param name="actualExpression">The expression representing the actual value.</param>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <returns>The checked value.</returns>
    /// <exception cref="AssertionException"></exception>
    public static T ShouldBeGreaterThan<T>(this T actual, T expected, 
        [CallerArgumentExpression(nameof(expected))] string? expectedExpression = null,
        [CallerArgumentExpression(nameof(actual))] string? actualExpression = null)
        where T : INumber<T>
    {
        if (actual <= expected)
            throw new AssertionException($"{actualExpression}.{nameof(ShouldBeGreaterThan)}({expectedExpression}) failed.",
                $"Expected: a number greater than {expected}",
                $"Actual: {actual}");
        
        return actual;
    }
    
    /// <summary>
    /// Asserts that the actual value is greater than or equal the expected value and returns the value.
    /// </summary>
    /// <param name="actual">The actual value to check.</param>
    /// <param name="expected">The expected value.</param>
    /// <param name="expectedExpression">The expression representing the expected value.</param>
    /// <param name="actualExpression">The expression representing the actual value.</param>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <returns>The checked value.</returns>
    /// <exception cref="AssertionException"></exception>
    public static T ShouldBeGreaterThanOrEqual<T>(this T actual, T expected, 
        [CallerArgumentExpression(nameof(expected))] string? expectedExpression = null,
        [CallerArgumentExpression(nameof(actual))] string? actualExpression = null)
        where T : INumber<T>
    {
        if (actual < expected)
            throw new AssertionException($"{actualExpression}.{nameof(ShouldBeGreaterThanOrEqual)}({expectedExpression}) failed.",
                $"Expected: a number greater or equal than {expected}",
                $"Actual: {actual}");
        
        return actual;
    }
    
    #endregion
    
    #region ShouldBeBetween
    
    /// <summary>
    /// Asserts that the value is within the specified range, inclusive and returns the value.
    /// </summary>
    /// <param name="value">The value to check.</param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <param name="valueExpression">The expression representing the value.</param>
    /// <param name="minExpression"></param>
    /// <param name="maxExpression"></param>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <returns>The checked value.</returns>
    /// <exception cref="AssertionException"></exception>
    public static T ShouldBeBetween<T>(this T value, T min, T max, 
        [CallerArgumentExpression(nameof(value))] string? valueExpression = null,
        [CallerArgumentExpression(nameof(min))] string? minExpression = null,
        [CallerArgumentExpression(nameof(max))] string? maxExpression = null)
        where T : INumber<T>
    {
        if (value < min || value > max)
            throw new AssertionException($"{valueExpression}.{nameof(ShouldBeBetween)}({minExpression}, {maxExpression}) failed.",
                $"Expected: a number between {min} and {max}",
                $"Actual: {value}");
        
        return value;
    }
    
    #endregion
}