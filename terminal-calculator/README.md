# Terminal Calculator

An interactive console calculator with both basic and scientific modes, calculation history, memory storage, and colorized output.

## Features

### Core
- Addition, subtraction, multiplication, and division
- Powers (exponentiation)
- Input validation for numbers and operations
- Division by zero error handling
- Continuous calculation loop
- Clear console formatting
- Graceful error messages
- Decimal support
- Exit command (`exit` or `quit` at any prompt)

### Advanced
- **Square roots** — `sqrt` operation
- **Powers** — `^` operator (e.g., 2 ^ 8 = 256)
- **Calculation history** — view and clear past calculations
- **Memory storage** — store, recall (`mr`), and clear values
- **Colorized console output** — color-coded results, errors, and menus
- **Scientific mode** — toggle to enable sin, cos, tan, log, ln, abs, and factorial

## How to Run

```bash
dotnet run --project terminal-calculator
```

## Usage

```
===================================
       Terminal Calculator
===================================
  Type 'exit' or 'quit' to leave.
  Type 'mr' for memory recall.
===================================

  ┌─────────────────────────────┐
  │          Main Menu          │
  ├─────────────────────────────┤
  │  1. Calculate                │
  │  2. View History             │
  │  3. Clear History            │
  │  4. Store to Memory          │
  │  5. Recall Memory            │
  │  6. Clear Memory             │
  │  7. Scientific Mode [OFF]    │
  └─────────────────────────────┘

  Choose an option: 1

Enter an operation (+, -, *, /, ^): +
Enter the first number: 10
Enter the second number: 5

  10 + 5 = 15
```

## Project Structure

- **Program.cs** — Entry point, menu system, and calculation orchestration
- **Calculator.cs** — Core arithmetic and scientific functions
- **InputHandler.cs** — User input reading, validation, and exit/memory recall detection
- **ConsoleHelper.cs** — Colorized console output utilities
- **History.cs** — Calculation history management
- **Memory.cs** — Memory storage (store/recall/clear)
- **ExitException.cs** — Custom exception for graceful exit from any prompt
