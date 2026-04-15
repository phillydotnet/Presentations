# Philly.NET - March 18, 2026

# Everything New in C# 14

Short Link to this content: https://tinyurl.com/pdn260318

## [Meetup site](https://www.meetup.com/philly-net/events/305135880) for this event

### Overview
C# 14 pushes the language forward with features that make code clearer, cleaner, and more expressive. This release continues to expand what developers can do, giving engineers practical new tools that make everyday work smoother and support more thoughtful design.

We will explore every new feature in C# 14, including the `field` keyword for properties, updated extension syntax, null-conditional assignment, and further integration of span types. You will learn when and how to apply these features effectively so you can bring the new capabilities into real projects with confidence.

## Scott Kay
Scott Kay is a Principal Engineering Manager at Microsoft AI, where he leads the development of high-scale programmatic advertising systems. He has been working with C# and .NET since their earliest days and has built software across a wide range of industries, including financial services, food delivery, bioscience, banking, and psychology research. Scott is also deeply involved in the advertising ecosystem, helping shape industry standards through leadership roles with the IAB and the Prebid community.

## Notes

### Compiler Source Code
Ever wanted to look at the compiler source code? Look here: https://github.com/dotnet/roslyn
A while ago, the C# compiler was rewritten using C# 5.  Today the team is updating it yearly and releasing new features alongside new versions of .NET

### Language Design
The language design repository is at: https://github.com/dotnet/csharplang.  Think of this as a *meta-repository* where discussions and documents are stored and iterated upon as new features are proposed, championed, selected, and implemented.

[What's new In CSharp 14](https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-14) - Official Documentation

[Introducing C# 14](https://devblogs.microsoft.com/dotnet/introducing-csharp-14/) - Blog post discussing the changes as C# 14 was being launched at .NET Conf 2025.

C# 14 is supported on .NET 10, so you'll need to use a .NET 10 version of the SDK to use these features.

### Features

#### Lambda Modifiers

[Feature summary](https://github.com/dotnet/csharplang/blob/main/proposals/csharp-14.0/simple-lambda-parameters-with-modifiers.md) from the csharplang repository.

[Simple lambda parameters with modifiers](https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-14#simple-lambda-parameters-with-modifiers) - Direct link to the feature in the Learn documentation.

Given this delegate:
```csharp
delegate bool TryParse<T>(string text, out T result);
```

Today you can only do this:
```csharp
TryParse<int> parse2 = (string text, out int result) => Int32.TryParse(text, out result);
```

Now you can simplify to this:
```csharp
TryParse<int> parse1 = (text, out result) => Int32.TryParse(text, out result);
```

#### Null conditional assignment
[From Learn documentation](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-14.0/null-conditional-assignment)

You can guard some assignments that could potentially be made to a null reference.

## C# 15 (Previews as of this writing)
You can already see what is being planned for release in C# 15

[What's new in C# 15](https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-15)

# Philly.NET - March 18, 2026

## Everything New in C# 14

## Social Links
[X (Twitter)](https://x.com/phillydotnet)

[Facebook](https://www.facebook.com/groups/phillynet)

[GitHub](https://github.com/phillydotnet)

[YouTube](https://www.youtube.com/phillydotnet)

[Discord](https://discord.gg/j7mFC6H8jE)

[LinkedIn](https://www.linkedin.com/groups/137867/)

[Instagram](https://www.instagram.com/phillydotnet)

[Mastodon](https://jawns.club/@phillydotnet)

[Threads](https://www.threads.com/@phillydotnet)
