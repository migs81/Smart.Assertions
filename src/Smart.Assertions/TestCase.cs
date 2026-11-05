namespace Smart.Assertions;

public static class TestCase
{
    public static ITestCase<TInput> Create<TInput>(TInput input) => new TestCase<TInput>(input);
}

internal sealed class TestCase<TInput>(TInput input) : ITestCase<TInput>
{
    public ITestCase<TInput, TResult> Act<TResult>(Func<TInput, TResult> action) => action is null
        ? throw new ArgumentNullException(nameof(action))
        : new TestCase<TInput, TResult>(input, action);
}

internal sealed class TestCase<TInput, TResult>(TInput input, Func<TInput, TResult> action) : ITestCase<TInput, TResult>
{
    #region fields

    private Action<TResult>? _assertion;

    #endregion

    #region public methods

    public ITestCase<TInput, TResult> Assert(Action<TResult> assertion)
    {
        _assertion = assertion ?? throw new ArgumentNullException(nameof(assertion));
        return this;
    }

    public void Run()
    {
        if (_assertion is null)
            throw new InvalidOperationException("No assertion has been defined.");

        var result = action(input);

        _assertion(result);
    }

    #endregion
}