using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Smart.Assertions.Assertions;

public static partial class Assert
{
    public static void True([DoesNotReturnIf(false)] bool condition, 
        [CallerArgumentExpression(nameof(condition))] string? expression = null)
    {
        if (!condition)
            throw new AssertionException($"{nameof(Assert)}.{nameof(True)}({expression}) failed.",
                "Expected: true",
                $"Actual: false");
    }
    
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
    public static bool ShouldBeTrue(this bool value, 
        [CallerArgumentExpression(nameof(value))] string? expression = null)
    {
        if (!value)
            throw new AssertionException($"{expression}.{nameof(ShouldBeTrue)}() failed.",
                "Expected: true",
                $"Actual: false");

        return value;
    }

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