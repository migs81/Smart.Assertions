namespace Smart.Assertions;

public static class Test
{
    /// <summary>
    /// Creates a new test case with the specified input.
    /// </summary>
    /// <param name="input">The input value for the test case.</param>
    /// <typeparam name="TInput">The type of the input value.</typeparam>
    /// <returns>A new test case.</returns>
    public static ITest<TInput> Create<TInput>(TInput input) => new Test<TInput>(input);
}

internal sealed class Test<TInput>(TInput input) : ITest<TInput>
{
    /// <summary>
    /// Defines the action to execute using the test case input.
    /// </summary>
    /// <param name="action">The action to execute.</param>
    /// <typeparam name="TResult">The type of the action result.</typeparam>
    /// <returns>A test case configured with the specified action.</returns>
    /// <exception cref="ArgumentNullException">The action is null.</exception>
    public ITest<TInput, TResult> Act<TResult>(Func<TInput, TResult> action) => action is null
        ? throw new ArgumentNullException(nameof(action))
        : new Test<TInput, TResult>(input, action);
}

internal sealed class Test<TInput, TResult>(TInput input, Func<TInput, TResult> action) : ITest<TInput, TResult>
{
    #region fields

    private Action<TResult>? _assertion;

    #endregion

    #region public methods

    /// <summary>
    /// Defines the assertion to execute against the action result.
    /// </summary>
    /// <param name="assertion">The assertion to execute.</param>
    /// <returns>The current test case.</returns>
    /// <exception cref="ArgumentNullException">The assertion is null.</exception>
    public ITest<TInput, TResult> Assert(Action<TResult> assertion)
    {
        _assertion = assertion ?? throw new ArgumentNullException(nameof(assertion));
        return this;
    }

    /// <summary>
    /// Executes the configured action and evaluates the result using the defined assertion.
    /// </summary>
    /// <exception cref="InvalidOperationException">No assertion has been defined.</exception>
    public void Run()
    {
        if (_assertion is null)
            throw new InvalidOperationException("No assertion has been defined.");

        var result = action(input);
        _assertion(result);
    }

    #endregion
}