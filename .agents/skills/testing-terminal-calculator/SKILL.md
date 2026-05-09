---
name: testing-terminal-calculator
description: How to test the terminal-calculator C# console app end-to-end via piped shell input.
---

# Testing terminal-calculator

## How to Run

The app is interactive (reads from stdin), so test by piping input sequences:

```bash
export PATH="$HOME/.dotnet:$PATH"
echo -e "1\n1\n10\n5\nexit" | dotnet run --project terminal-calculator
```

Each `\n`-separated value corresponds to a prompt in order:
- Main menu choice (1-8)
- Operation choice (1-5 basic, 1-13 scientific, or raw operators like `+`)
- Number inputs
- `exit` to quit

## Key Test Areas

1. **Menu navigation**: Options 1-8, invalid input rejection (`Invalid choice. Please enter 1-8.`)
2. **Numbered operation selection**: Basic mode accepts 1-5, scientific mode accepts 1-13
3. **Raw operator fallback**: Typing `+`, `-`, `*`, `/`, `^` directly also works at operation prompt
4. **Scientific mode**: Toggle with option 7, verify extended operation list appears
5. **Memory**: Store (option 4), recall (option 5 or type `mr` at number prompt), clear (option 6)
6. **History**: View (option 2), clear (option 3)
7. **Division by zero**: Select divide, enter 0 as second number, expect error message
8. **Exit paths**: Option 8, typing `exit`/`quit` at any prompt
9. **Input validation**: Non-numeric input at number prompts, invalid menu choices

## Known Edge Cases

- `tan(45)` returns `0.9999999999999999` (floating-point precision, not a bug)
- Factorial of decimal silently truncates via `(int)` cast (e.g., `5.7` becomes `5`)
- `log(0)` and `ln(0)` return `-Infinity` without an error message
- `Console.Clear()` may produce escape codes when output is piped/redirected
- `double.TryParse` uses current culture for decimal separator (`.` vs `,`)
