### Step 9b - Refactoring the Web API
**Step 9b of 9** - [🔝 Go to top](#-net-school) [⬆ Previous step](#step-9---implement-web-api)

When writing applications i F#, we often have to utilize libraries and frameworks written with C# as the intended target language. While it's always possible to use those libraries and frameworks in F#-applications, we're often required to write C#-style F#. In order to make our F# code more idiomatic, it's sometimes beneficial to write a small number of adapter functions, smoothing over the rougher parts of the library.

In [step 8](#step-8---set-up-shell-for-api) and [step 9](#step-9---implement-web-api), we created a simple API i F#, using the ASP.NET minimal APIs. When implementing the API, we intentionally wrote the F# code in a somewhat C#-style, retaining a close resemblance to the examples in the [minimal APIs documentation](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis). In this section we'll explore some techniques that can be used to refactor this code into more idiomatic F#.

_**Step 9b of 9:** This section is an optional extension, and can be left out if you're more interested in the topics presented in section 10. The next section will not continue with the code produced by the end of this section, so it can be safely left out._

#### Rewriting method calls to chainable functions
_TODO: This section focuses on rewriting the `WebApplication` setup._


#### Something about request endpoints
_TODO: This section focuses on rewriting `MapGet(...)` and working with `Func<>()`._

#### Something about using libraries like Giraffe
_TODO: This section mentions the existence of F# libraries, that can be used as an alternative to writing your own adaptors._

#### Something more perhaps?
_TODO: Partial application as DI could be nice to explore here. We'll see what comes up!_