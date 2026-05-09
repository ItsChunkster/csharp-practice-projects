# Terminal Calculator

A simple interactive console calculator that supports basic arithmetic operations.

## Features

- Addition, subtraction, multiplication, and division
- Input validation for numbers and operations
- Division by zero error handling
- Option to perform multiple calculations in a single session

## How to Run

```bash
dotnet run --project terminal-calculator
```

## Usage

```
===========================
   C# Console Calculator   
===========================

Enter the first number: 10
Enter an operation (+, -, *, /): +
Enter the second number: 5

  10 + 5 = 15

Perform another calculation? (y/n): n
Goodbye!
```

## Project Structure

- **Program.cs** — Entry point and main application loop
- **Calculator.cs** — Core arithmetic logic
- **InputHandler.cs** — User input reading and validation
