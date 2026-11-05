namespace Smart.Assertions;

public interface ITestCase<TInput>
{
    ITestCase<TInput, TResult> Act<TResult>(Func<TInput, TResult> action);
}

public interface ITestCase<TInput, out TResult>
{
    ITestCase<TInput, TResult> Assert(Action<TResult> assertion);

    void Run();
}