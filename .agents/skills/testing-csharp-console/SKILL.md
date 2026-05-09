---
name: testing-csharp-console
description: Test interactive C# console applications end-to-end. Use when verifying console app behavior via piped input/output.
---

# Testing C# Console Applications

## Prerequisites

- .NET 8 SDK installed (via `dotnet-install.sh` or environment config)
- `dotnet` on PATH: `export PATH="$HOME/.dotnet:$PATH"`

## Build

```bash
dotnet build <project-dir>/<project-name>.csproj
```

Verify 0 warnings, 0 errors before testing.

## Running Tests for Interactive Console Apps

Console apps that read from stdin can be tested by piping input:

```bash
echo -e "input1\ninput2\ninput3" | dotnet run --project <project-dir>
```

Each `\n` simulates pressing Enter. Verify expected output appears in stdout.

## Test Categories to Cover

1. **Happy path**: Valid inputs for each operation
2. **Edge cases**: Negative numbers, decimals, large numbers
3. **Error handling**: Invalid input (non-numeric, unsupported operations), division by zero
4. **Input validation loops**: Invalid input followed by valid input — verify recovery
5. **Flow control**: Continue/exit loops (e.g., y/n prompts)
6. **Exit behavior**: Verify clean exit message and return code 0

## Project Structure Convention

Projects in this repo use lowercase directory names (e.g., `calculator/`) and separate concerns into multiple files:
- `Program.cs` — Entry point and main loop
- Domain-specific classes (e.g., `Calculator.cs`, `InputHandler.cs`)
- `README.md` — Project documentation

## Notes

- No browser/GUI needed — all testing is shell-only, so no recording is necessary
- Check return code (`$?`) to confirm the app did not crash
- For floating-point results, large numbers may display in scientific notation (e.g., `9.99999998E+17`) — this is expected .NET `double` behavior
- `double.TryParse` uses the current locale/culture — decimal separator might be `,` instead of `.` in some environments
- Run tests in parallel across separate shell IDs for speed
