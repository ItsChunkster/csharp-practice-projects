---
name: testing-terminal-calculator
description: Test the terminal-calculator C# console app end-to-end. Use when verifying calculator features after code changes.
---

# Testing terminal-calculator

This is a .NET 8.0 C# console application. It is interactive (stdin/stdout) so testing is done via piped input.

## Prerequisites

- .NET 8.0 SDK installed (`dotnet` on PATH)
- No secrets or external services required

## Build

```bash
dotnet build terminal-calculator/terminal-calculator.csproj
```

Expect: `Build succeeded. 0 Warning(s) 0 Error(s)`

## Run

```bash
dotnet run --project terminal-calculator
```

The app is interactive and menu-driven. It cannot be tested via browser — use piped shell input instead.

## Testing Approach

Pipe input via `echo -e` with `\n`-separated values:

```bash
echo -e "1\n+\n5\n3\nexit" | dotnet run --project terminal-calculator
```

The app uses a main menu (options 1-7). To test a feature, first select the menu option, then provide the inputs for that feature.

### Menu Options
- `1` — Calculate (then: operation, number(s))
- `2` — View History
- `3` — Clear History
- `4` — Store to Memory (then: number)
- `5` — Recall Memory
- `6` — Clear Memory
- `7` — Toggle Scientific Mode

### Scientific Mode
Scientific mode must be toggled ON (option `7`) before scientific operations are available. Scientific operations are unary (single input): `sqrt`, `sin`, `cos`, `tan`, `log`, `ln`, `abs`, `!`

Example: `echo -e "7\n1\nsqrt\n16\nexit" | dotnet run --project terminal-calculator`

### Memory Recall
Type `mr` or `recall` at any number prompt to use the stored memory value.

Example: `echo -e "4\n99\n1\n+\nmr\n1\nexit" | dotnet run --project terminal-calculator`

### Exit Command
`exit` or `quit` works at any prompt (menu, operation, number). Always prints `Goodbye!` and exits with code 0.

## Key Test Cases

1. **Basic arithmetic**: +, -, *, / with integers and decimals
2. **Power**: `^` operator (e.g., `2 ^ 8 = 256`)
3. **Division by zero**: Should show error, not crash
4. **Scientific functions**: sqrt, sin, cos, tan, log, ln, abs, factorial
5. **Factorial edge cases**: Negative numbers should show error
6. **History**: Calculate, then view (option 2) — entries should be numbered
7. **History clear**: Option 3, then view — should show "No calculations yet"
8. **Memory**: Store (option 4), recall (option 5), clear (option 6)
9. **Memory at prompt**: Type `mr` during number input to use stored value
10. **Input validation**: Invalid numbers and operations should show errors and re-prompt
11. **Exit at every prompt**: exit/quit should work at menu, operation, and number prompts

## Notes

- `Console.Clear()` produces escape codes when output is piped — this is expected and does not affect testing
- Trig functions accept degrees (not radians)
- `tan(45)` returns `0.9999999999999999` due to floating-point precision — this is correct
- Colorized output uses ANSI escape codes, visible as escape sequences in piped output
- No recording needed — this is a CLI-only app, test via shell
