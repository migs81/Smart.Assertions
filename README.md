# 📚 Smart.Assertions

Smart.Assertions is a lightweight assertion library for .NET.

It provides simple assertion methods to verify conditions, compare values etc..

## ✨ Features

- Simple and readable assertion methods
- Support for common data types
- Clear assertion failure messages
- Fluent-style extension methods

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