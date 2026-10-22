using System.Diagnostics.CodeAnalysis;

namespace Smart.Assertions.Assertions;

public static partial class Assert
{
    public static void True([DoesNotReturnIf(false)] bool condition)
    {
        if (!condition)
            throw new AssertionException("Assert.IsTrue() failed.");
    }
    
    public static void False([DoesNotReturnIf(true)] bool condition)
    {
        if (condition)
            throw new AssertionException("Assert.IsFalse() failed.");
    }
}