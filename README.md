# 📚 Smart.Assertions

Smart.Assertions is a lightweight assertion library for .NET.

It provides simple assertion methods to verify conditions, compare values etc..

## ✨ Features

- Simple and readable assertion methods
- Support for common data types
- Clear assertion failure messages
- Fluent-style extension methods
- Fluent test case creation and execution

## 💻 Usage

```csharp
using Smart.Assertions;

Assert.True(condition);
Assert.Equal(expected, actual);
Assert.NotNull(value);
Assert.LessThan(actual, limit);
```

Extension methods are also available:

```csharp
condition.ShouldBeTrue();
value.ShouldNotBeNull()
     .ShouldEqual(expected);
```

If an assertion fails, an `AssertionException` is thrown.

## 🧪 Test

`Test` provides a simple way to define and run test cases using a fluent API.

It separates a test into three steps:

- **Create:** Define the input.
- **Act:** Define the action to execute.
- **Assert:** Define the assertion.

### Single test

```csharp
Test.Create(5)
    .Act(input => Calculator.Double(input))
    .Assert(result => result.ShouldBeLessThan(11))
    .Run();
```

### Multiple tests

Test cases can be stored in a collection and executed together.

```csharp
var tests = new List<ITest>
{
    Test.Create(5)
        .Act(input => Calculator.Double(input))
        .Assert(result => result.ShouldBe(10)),

    Test.Create(10)
        .Act(input => Calculator.Double(input))
        .Assert(result => result.ShouldBe(20)),

    Test.Create(15)
        .Act(input => Calculator.Double(input))
        .Assert(result => result.ShouldBe(30))
};

foreach (var test in tests)
{
    test.Run();
}
```

### Using xUnit

Test cases can also be used alongside testing frameworks such as xUnit, NUnit or MSTest.

```csharp
[Theory]
[InlineData(5, 10)]
[InlineData(10, 20)]
[InlineData(15, 30)]
public void Double_ShouldReturnExpectedResult(int input, int expected)
{
    Test.Create(input)
        .Act(value => Calculator.Double(value))
        .Assert(result => result.ShouldBe(expected))
        .Run();
}
```

The types are automatically inferred by the compiler. The action is executed only when `Run()` is called.

## ⚙️ Requirements

- .NET 8.0 or later

## 📂 Project Structure

```
Smart.ValueTypes/
├── src/
│   ├── Smart.Assertions/              # Core library
├── tests/                       
│   └── Smart.Assertions.Tests         # Unit tests
└── README.md                          # This file
```

## 📄 License

This project is licensed under the [MIT License](LICENSE).