using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Smart.Assertions.Assertions;

public static partial class Assert
{
    /// <summary>
    /// Asserts that the specified condition is true.
    /// </summary>
    /// <param name="condition"></param>
    /// <param name="expression">The expression representing the value.</param>
    /// <exception cref="AssertionException"></exception>
    public static void True([DoesNotReturnIf(false)] bool condition, 
        [CallerArgumentExpression(nameof(condition))] string? expression = null)
    {
        if (!condition)
            throw new AssertionException($"{nameof(Assert)}.{nameof(True)}({expression}) failed.",
                "Expected: true",
                $"Actual: false");
    }
    
    /// <summary>
    /// Asserts that the specified condition is false.
    /// </summary>
    /// <param name="condition"></param>
    /// <param name="expression">The expression representing the value.</param>
    /// <exception cref="AssertionException"></exception>
    public static void False([DoesNotReturnIf(true)] bool condition, 
        [CallerArgumentExpression(nameof(condition))] string? expression = null)
    {
        if (condition)
            throw new AssertionException($"{nameof(Assert)}.{nameof(False)}({expression}) failed.",
                "Expected: false",
                $"Actual: true");
    }
}

public static partial class AssertExtensions
{
    /// <summary>
    /// Asserts that the specified condition is true and returns the condition.
    /// </summary>
    /// <param name="value">The value to check.</param>
    /// <param name="expression">The expression representing the value.</param>
    /// <returns>The checked value.</returns>
    /// <exception cref="AssertionException"></exception>
    public static bool ShouldBeTrue(this bool value, 
        [CallerArgumentExpression(nameof(value))] string? expression = null)
    {
        if (!value)
            throw new AssertionException($"{expression}.{nameof(ShouldBeTrue)}() failed.",
                "Expected: true",
                $"Actual: false");

        return value;
    }

    /// <summary>
    /// Asserts that the specified condition is false and returns the condition.
    /// </summary>
    /// <param name="value">The value to check.</param>
    /// <param name="expression">The expression representing the value.</param>
    /// <returns>The checked value.</returns>
    /// <exception cref="AssertionException"></exception>
    public static bool ShouldBeFalse(this bool value, 
        [CallerArgumentExpression(nameof(value))] string? expression = null)
    {
        if (value)
            throw new AssertionException($"{expression}.{nameof(ShouldBeFalse)}() failed.",
                "Expected: false",
                $"Actual: true");

        return value;
    }
}