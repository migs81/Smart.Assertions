namespace Smart.Assertions;

public interface ITest
{
    void Run();
}

public interface ITest<TInput>
{
    ITest<TInput, TResult> Act<TResult>(Func<TInput, TResult> action);
}

public interface ITest<TInput, out TResult> : ITest
{
    ITest<TInput, TResult> Assert(Action<TResult> assertion);
}