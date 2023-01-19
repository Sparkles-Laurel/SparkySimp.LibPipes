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
