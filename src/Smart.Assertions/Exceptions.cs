namespace Smart.Assertions;

public class AssertionException : Exception
{
    public AssertionException(string message) : base(message)
    {
    }

    public AssertionException(string message, string expected, string actual) : base(
        $"{message}{Environment.NewLine}{expected}{Environment.NewLine}{actual}")
    {
    }
}