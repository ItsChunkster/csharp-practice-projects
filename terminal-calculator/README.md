# Terminal Calculator

A polished C# command-line calculator featuring modular architecture, robust input validation, and clean terminal interaction.

---

## Table of Contents

- [Features](#features)
- [Requirements](#requirements)
- [Getting Started](#getting-started)
- [Usage](#usage)
- [Supported Operations](#supported-operations)
- [Project Structure](#project-structure)
- [Architecture](#architecture)
- [License](#license)

---

## Features

| Category | Feature |
|----------|---------|
| Arithmetic | Addition, subtraction, multiplication, division, exponentiation |
| Scientific | Square root, sine, cosine, tangent, log, ln, absolute value, factorial |
| History | View numbered list of past calculations, clear history |
| Memory | Store a value, recall with `mr` at any number prompt, clear memory |
| UX | Colorized output, input validation, division-by-zero protection, graceful error messages |
| Navigation | Interactive menu, exit/quit from any prompt, continuous calculation loop |

---

## Requirements

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or later

---

## Getting Started

### Build

```bash
dotnet build terminal-calculator/terminal-calculator.csproj
```

### Run

```bash
dotnet run --project terminal-calculator
```

---

## Usage

On launch, the app clears the screen and displays a header and main menu:

```
==============================
     TERMINAL CALCULATOR
==============================

  Type 'exit' or 'quit' to leave.
  Type 'mr' for memory recall.

Select an option:
  1. Calculate
  2. View History
  3. Clear History
  4. Store to Memory
  5. Recall Memory
  6. Clear Memory
  7. Scientific Mode [OFF]
  8. Exit

Choice:
```

### Basic Calculation

```
Choice: 1

Select an operation:
  1. Add (+)
  2. Subtract (-)
  3. Multiply (*)
  4. Divide (/)
  5. Power (^)

Choice: 1
Enter the first number: 10
Enter the second number: 5

  10 + 5 = 15
```

### Scientific Mode

Toggle scientific mode on (option `7`), then select a scientific operation:

```
Choice: 7
  Scientific mode: ON

Choice: 1

Select an operation:
  1. Add (+)
  2. Subtract (-)
  3. Multiply (*)
  4. Divide (/)
  5. Power (^)
  6. Square Root (sqrt)
  7. Sine (sin)
  8. Cosine (cos)
  9. Tangent (tan)
  10. Log Base 10 (log)
  11. Natural Log (ln)
  12. Absolute Value (abs)
  13. Factorial (!)

Choice: 6
Enter the value: 16

  sqrt(16) = 4
```

### Memory Recall

Store a value (option `4`), then type `mr` at any number prompt to recall it:

```
Choice: 4
Enter value to store: 99
  Stored 99 in memory.

Choice: 1

Select an operation:
  1. Add (+)
  ...

Choice: 1
Enter the first number: mr
  Memory: 99
Enter the second number: 1

  99 + 1 = 100
```

---

## Supported Operations

### Basic (always available)

| Operator | Description | Example |
|----------|-------------|---------|
| `+` | Addition | `10 + 5 = 15` |
| `-` | Subtraction | `10 - 3 = 7` |
| `*` | Multiplication | `4 * 6 = 24` |
| `/` | Division | `20 / 4 = 5` |
| `^` | Power | `2 ^ 8 = 256` |

### Scientific (toggle with option 7)

| Operation | Description | Example |
|-----------|-------------|---------|
| `sqrt` | Square root | `sqrt(16) = 4` |
| `sin` | Sine (degrees) | `sin(90) = 1` |
| `cos` | Cosine (degrees) | `cos(0) = 1` |
| `tan` | Tangent (degrees) | `tan(45) = 1` |
| `log` | Log base 10 | `log(100) = 2` |
| `ln` | Natural log | `ln(1) = 0` |
| `abs` | Absolute value | `abs(-42) = 42` |
| `!` | Factorial | `!(5) = 120` |

> **Note:** Trigonometric functions accept input in degrees, not radians.

---

## Project Structure

```
terminal-calculator/
├── Program.cs            # Entry point, menu system, calculation orchestration
├── Calculator.cs         # Core arithmetic and scientific functions
├── InputHandler.cs       # User input reading, validation, exit/memory detection
├── ConsoleHelper.cs      # Colorized console output utilities
├── History.cs            # Calculation history (add/view/clear)
├── Memory.cs             # Memory storage (store/recall/clear)
├── ExitException.cs      # Custom exception for graceful exit from any prompt
├── terminal-calculator.csproj
└── README.md
```

---

## Architecture

The application follows a **separation of concerns** pattern:

- **`Program`** orchestrates the application flow — it owns the menu loop and delegates to other classes.
- **`CalculatorEngine`** is a pure static class with no side effects. All math lives here.
- **`InputHandler`** encapsulates all `Console.ReadLine()` calls with validation loops. It also detects exit commands and memory recall keywords.
- **`ConsoleHelper`** provides semantic color methods (`WriteSuccess`, `WriteError`, `WriteInfo`, etc.) so output styling is consistent and centralized.
- **`History`** and **`Memory`** are simple static classes that manage in-memory state for their respective features.
- **`ExitException`** enables graceful exit from deeply nested input loops without complex control flow.

---

## License

MIT
