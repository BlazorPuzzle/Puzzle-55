# Blazor Puzzle #55

## Coding the Code-Behind

YouTube Video: https://youtu.be/5lWZXPPYnbk

Blazor Puzzle Home Page: https://blazorpuzzle.com

### The Challenge:

Welcome to Puzzle 55.  In this puzzle, we've started working more and more with moving our Blazor code to a code-behind partial class.  We've already moved the @code block from the Weather page into a code-behind partial class.  This way, our Weather.razor file only contains the HTML along with some if and for loops.

We also want to remove those pesky @ directives from the top of the file, so that all of the business logic to present the page is in the code-behind partial class.  We already have moved the injected HttpClient and set the `[Inject]` attribute on it.  The last directive is the @@page directive.  Help us remove that directive from the top of the Weather page so that we can have a clean HTML file.

### The Solution:

The solution we chose was a 2 step process:

1) Remove the @page directive from the top of *Weather.razor*
2) Add the following attribute to the code-behind file (*Weather.razor.cs*):

```c#
[Route("/weather")]
```

This may seem like a hold-over from MVC, and it is. The @page directive is really a wrapper around the route attribute, which Blazor uses to find routable components.

Boom!
