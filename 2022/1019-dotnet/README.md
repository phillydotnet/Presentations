# Philly.NET
## October 19, 2022
## C# Nuget Packages and Kubernetes Zarf

Meetup Site: https://www.meetup.com/philly-net/events/288013319/

## Step up your C# game with 5 popular NuGets
Louis Berman

- Guard Clauses
- Vogen
- Stateless
- Bogus
- SquidEyes.Testing

### Guard Clauses
On NuGet.org: https://www.nuget.org/packages/Ardalis.GuardClauses/

From the [GitHub README.md](https://github.com/ardalis/guardclauses): "A guard clause is a software pattern that simplifies complex functions by "failing fast", checking for invalid inputs up front and immediately failing if any are found."

You write this boilerplate code over and over.  This is a more readable, fluent style way to express your guards so that no one has to read the code and decompile it in their brain.

Example:
``` C#
Guard.Against.Null(order, nameof(order));
```
### Bogus
On NuGet.org: https://www.nuget.org/packages/Bogus

"Bogus is a simple fake data generator for .NET languages like C#, F# and VB.NET."

### Stateless
From [GitHub README.md](https://github.com/dotnet-state-machine/stateless#stateless----)"Create state machines and lightweight state machine-based workflows directly in .NET code"

On NuGet.org: https://www.nuget.org/packages/Stateless/

### SquidEyes.Testing
On NuGet.org: https://www.nuget.org/packages/SquidEyes.Testing

### Vogen
On NuGet.org: https://www.nuget.org/packages/vogen/

From the [GitHub README.md](https://github.com/SteveDunn/Vogen#vogen-cure-your-primitive-obsession): "Cure your primitive obsession"

Vogen allows you to create boundaries or restrictions on your objects so that you don't have to validate and write guard clauses all over the place for that object.  The idea is to stop using primitives (like string) when you have rules you can apply to the data to be stored (like a US Zip Code).

Vogen will generate business objects based on your declarative code.

Recommended YouTube Channel:

[Nick Chapsas YouTube](https://www.youtube.com/user/ElfocrashDev) - You'll find many NuGet focused videos with recommended packages (and just plain great C# videos).

Examples:
- [20 Nuget packages that every .NET developer should be familiar with](https://www.youtube.com/watch?v=qapJwFY9y2Y&t=28s)
- [The electrical pattern that will keep your .NET services alive](https://www.youtube.com/watch?v=3U_TJZU06Ag) - About the popular package [Polly](https://github.com/App-vNext/Polly)



## Kubernetes Zarf
Jason van Brackel
