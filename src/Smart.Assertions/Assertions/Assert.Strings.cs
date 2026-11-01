using System.Runtime.CompilerServices;

namespace Smart.Assertions.Assertions;

public static partial class Assert
{
    #region Empty, NotEmpty

    public static void Empty(string value, 
        [CallerArgumentExpression(nameof(value))] string? expression = null)
    {
        if (value.Length != 0) 
            throw new AssertionException($"{nameof(Assert)}.{nameof(Empty)}({expression}) failed.",
                $"Expected: an empty string",
                $"Actual: {value}");
    }
    
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

    public static void Equal(string expected, string actual, StringComparison comparison, 
        [CallerArgumentExpression(nameof(expected))] string? expectedExpression = null, 
        [CallerArgumentExpression(nameof(actual))] string? actualExpression = null)
    {
        if (!string.Equals(expected, actual, comparison))
            throw new AssertionException($"{nameof(Assert)}.{nameof(Equal)}({expectedExpression}, {actualExpression}) failed.",
                $"Expected: \"{expected}\"",
                $"Actual: \"{actual}\"");
    }
    
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

    public static void StartsWith(string value, string actual, StringComparison comparison = StringComparison.Ordinal, 
        [CallerArgumentExpression(nameof(value))] string? valueExpression = null, 
        [CallerArgumentExpression(nameof(actual))] string? actualExpression = null)
    {
        if (!actual.StartsWith(value, comparison))
            throw new AssertionException($"{nameof(Assert)}.{nameof(StartsWith)}({valueExpression}, {actualExpression}) failed.",
                $"Expected: string starts with \"{value}\"",
                $"Actual: \"{actual}\"");
    }
    
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
    
    public static void Contains(string value, string actual, StringComparison comparison = StringComparison.Ordinal, 
        [CallerArgumentExpression(nameof(value))] string? valueExpression = null, 
        [CallerArgumentExpression(nameof(actual))] string? actualExpression = null)
    {
        if (!actual.Contains(value, comparison))
            throw new AssertionException($"{nameof(Assert)}.{nameof(Contains)}({valueExpression}, {actualExpression}) failed.",
                $"Expected: string contains \"{value}\"",
                $"Actual: \"{actual}\"");
    }
    
    #endregion
}

public static partial class AssertExtensions
{
    #region ShouldBeEmpty, ShouldNotBeEmpty
    
    public static string ShouldBeEmpty(this string value,
        [CallerArgumentExpression(nameof(value))] string? expression = null)
    {
        if (value.Length != 0) 
            throw new AssertionException($"{expression}.{nameof(ShouldBeEmpty)}() failed.",
                $"Expected: an empty string",
                $"Actual: {value}");

        return value;
    }
    
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
    
    #endregion
}