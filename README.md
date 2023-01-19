# SparkySimp.LibPipes

Implements a simple pipe mechanism.

## Example
### With LibPipes
```csharp
using System;
using SparkySimp.LibPipes;

long result = (-1L).Pipe(BitConverter.GetBytes)
     .Pipe(a => BitConverter.ToDouble(a, 0))
     .Pipe(BitConverter.GetBytes)
     .Pipe(a => BitConverter.ToInt64(a, 0));
```
### Without LibPipes
```csharp
using System;
long result = BitConverter.ToInt64(BitConverter.GetBytes(BitConverter.ToDouble(BitConverter.GetBytes(-1L), 0)), 0);
```

LibPipes is basically designed to help with cascading conversion operations, and abuses the power of the lambda expressions/anonymous methods.

## How it works (for nerds)

In C#, there are numerous different ways to instantiate a delegate:
```csharp
delegate int Hyperact(int x);

int Decrement(int x)
{
     return x - 1;
}

Hyperact h1 = new Hyperact(Decrement); // explicit declaration.
Hyperact h2 = Decrement; // automatically generated delegate, converts to above.
Hyperact h3 = delegate(int x) { return x - 1;}; // anonymous method.
Hyperact h4 = x => x - 1; // Lambda, converts to above.
```

Pipes basically take in two parameters; an object to operate on, and a funtion that describes the operation:
```csharp
public static TOut Pipe<TOut, TIn>(this TIn self, Func<TOut, TIn> func) => func(self);
```

The `Pipe` extension method expects an object to operate on, and a `Func<TOut, TIn>`(a single parameter function which represents the operation).
The fact that it is an extension method on `TIn` lets you use it in a chain call.
```csharp
Console.WriteLine(16.Pipe(Math.Sqrt).Pipe(Math.Sin).Pipe(Math.Tan).Pipe(z => z - 1m));
```

This was actually inspired by Elixir's pipe operator `|>`:
```elixir
"pipes" |> String.graphemes() |> Enum.frequencies() |> IO.inspect()
```
