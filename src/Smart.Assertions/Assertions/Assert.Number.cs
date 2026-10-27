using System.Numerics;
using System.Runtime.CompilerServices;

namespace Smart.Assertions.Assertions;

public static partial class Assert
{
    public static void LessThan<T>(T expected, T actual, 
        [CallerArgumentExpression(nameof(expected))] string? expectedExpression = null,
        [CallerArgumentExpression(nameof(actual))] string? actualExpression = null)
        where T : INumber<T>
    {
        if (actual >= expected)
            throw new AssertionException($"{nameof(Assert)}.{nameof(LessThan)}({expectedExpression}, {actualExpression}) failed.",
                $"Expected: {expected}",
                $"Actual: {actual}");
    }

    public static void LessThanOrEqual<T>(T expected, T actual, 
        [CallerArgumentExpression(nameof(expected))] string? expectedExpression = null,
        [CallerArgumentExpression(nameof(actual))] string? actualExpression = null)
        where T : INumber<T>
    {
        if (actual > expected)
            throw new AssertionException($"{nameof(Assert)}.{nameof(LessThanOrEqual)}({expectedExpression}, {actualExpression}) failed.",
                $"Expected: {expected}",
                $"Actual: {actual}");
    }

    public static void GreaterThan<T>(T expected, T actual, 
        [CallerArgumentExpression(nameof(expected))] string? expectedExpression = null,
        [CallerArgumentExpression(nameof(actual))] string? actualExpression = null)
        where T : INumber<T>
    {
        if (actual <= expected)
            throw new AssertionException($"{nameof(Assert)}.{nameof(GreaterThan)}({expectedExpression}, {actualExpression}) failed.",
                $"Expected: {expected}",
                $"Actual: {actual}");
    }

    public static void GreaterThanOrEqual<T>(T expected, T actual, 
        [CallerArgumentExpression(nameof(expected))] string? expectedExpression = null,
        [CallerArgumentExpression(nameof(actual))] string? actualExpression = null)
        where T : INumber<T>
    {
        if (actual < expected)
            throw new AssertionException($"{nameof(Assert)}.{nameof(GreaterThanOrEqual)}({expectedExpression}, {actualExpression}) failed.",
                $"Expected: {expected}",
                $"Actual: {actual}");
    }

    public static void Between<T>(T value, T min, T max, 
        [CallerArgumentExpression(nameof(value))] string? valueExpression = null,
        [CallerArgumentExpression(nameof(min))] string? minExpression = null,
        [CallerArgumentExpression(nameof(max))] string? maxExpression = null)
        where T : INumber<T>
    {
        if (value < min || value > max)
            throw new AssertionException($"{nameof(Assert)}.{nameof(Between)}({valueExpression}, {minExpression}, {maxExpression}) failed.",
                $"Expected: value between {min} and {max}",
                $"Actual: {value}");
    }
}

public static partial class AssertExtensions
{
    public static T ShouldBeLessThan<T>(this T actual, T expected, 
        [CallerArgumentExpression(nameof(expected))] string? expectedExpression = null,
        [CallerArgumentExpression(nameof(actual))] string? actualExpression = null)
        where T : INumber<T>
    {
        if (actual >= expected)
            throw new AssertionException($"{expectedExpression}.{nameof(ShouldBeLessThan)}({actualExpression}) failed.",
                $"Expected: {expected}",
                $"Actual: {actual}");

        return actual;
    }
    
    public static T ShouldBeLessThanOrEqual<T>(this T actual, T expected, 
        [CallerArgumentExpression(nameof(expected))] string? expectedExpression = null,
        [CallerArgumentExpression(nameof(actual))] string? actualExpression = null)
        where T : INumber<T>
    {
        if (actual > expected)
            throw new AssertionException($"{expectedExpression}.{nameof(ShouldBeLessThanOrEqual)}({actualExpression}) failed.",
                $"Expected: {expected}",
                $"Actual: {actual}");
        
        return actual;
    }
    
    public static T ShouldBeGreaterThan<T>(this T actual, T expected, 
        [CallerArgumentExpression(nameof(expected))] string? expectedExpression = null,
        [CallerArgumentExpression(nameof(actual))] string? actualExpression = null)
        where T : INumber<T>
    {
        if (actual <= expected)
            throw new AssertionException($"{expectedExpression}.{nameof(ShouldBeGreaterThan)}({actualExpression}) failed.",
                $"Expected: {expected}",
                $"Actual: {actual}");
        
        return actual;
    }
    
    public static T ShouldBeGreaterThanOrEqual<T>(this T actual, T expected, 
        [CallerArgumentExpression(nameof(expected))] string? expectedExpression = null,
        [CallerArgumentExpression(nameof(actual))] string? actualExpression = null)
        where T : INumber<T>
    {
        if (actual < expected)
            throw new AssertionException($"{expectedExpression}.{nameof(ShouldBeGreaterThanOrEqual)}({actualExpression}) failed.",
                $"Expected: {expected}",
                $"Actual: {actual}");
        
        return actual;
    }
    
    public static T ShouldBeBetween<T>(this T value, T min, T max, 
        [CallerArgumentExpression(nameof(value))] string? valueExpression = null,
        [CallerArgumentExpression(nameof(min))] string? minExpression = null,
        [CallerArgumentExpression(nameof(max))] string? maxExpression = null)
        where T : INumber<T>
    {
        if (value < min || value > max)
            throw new AssertionException($"{valueExpression}.{nameof(ShouldBeBetween)}({minExpression}, {maxExpression}) failed.",
                $"Expected: value between {min} and {max}",
                $"Actual: {value}");
        
        return value;
    }
}