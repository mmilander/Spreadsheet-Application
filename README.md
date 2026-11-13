# Spreadsheet Application

A desktop spreadsheet application built in **C# with .NET 8 and Windows Forms** for a semester-long software engineering course at Washington State University. The project explores object-oriented design, expression parsing, event-driven updates, and reusable design patterns through a spreadsheet engine separated from its graphical interface.

## Application screenshot

![Spreadsheet application running in Visual Studio during HW7](assets/spreadsheet-hw7-demo.png)

*An earlier HW7-stage build running in Visual Studio. The screenshot shows the spreadsheet grid with a formula being edited; the repository also includes later iterations.*

## Project highlights

- **Windows Forms spreadsheet UI:** Created a `DataGridView` with 26 columns (A–Z) and 50 rows, displaying cell text while editing and calculated values otherwise.
- **Arithmetic expression evaluator:** Built an expression-tree representation with constant, variable, and operator nodes, using tokenization and the **shunting-yard algorithm** to handle operator precedence and parentheses.
- **Reflection-based factory:** Created an `OperatorNodeFactory` that uses C# reflection and `Activator.CreateInstance` to discover and instantiate arithmetic operator nodes.
- **Event-driven updates:** Used `INotifyPropertyChanged` and cell-change events to propagate changes from the spreadsheet engine to the UI.
- **Command-based undo/redo:** Defined an `ICommand` interface and concrete commands for text and background-color changes, with stack-based undo/redo operations.
- **XML persistence:** Added `Save(Stream)` and `Load(Stream)` methods using .NET XML APIs to store and restore cell data.
- **Formula reference checks:** Added logic to recognize invalid references, self-references, and circular-reference cases as the spreadsheet developed.
- **Automated tests:** Wrote NUnit test cases for expression evaluation, cell behavior, editing commands, persistence, and reference handling.

## Design patterns and C# concepts

| Concept | Where it appears |
| --- | --- |
| **Factory-style object creation** | `OperatorNodeFactory` discovers operator types using reflection and creates operator-node instances. |
| **Command pattern** | `ICommand`, `ChangeTextCommand`, `ChangeBackgroundCommand`, and `UndoRedoCollection` represent reversible edits. |
| **Observer-style notifications** | `INotifyPropertyChanged` and spreadsheet events notify the UI when cell state changes. |
| **Object-oriented programming** | Abstract `Cell` and `Node` classes, specialized node subclasses, encapsulation, inheritance, and polymorphism. |
| **Algorithms and data structures** | Expression trees, shunting-yard parsing, dictionaries, stacks, and cell-dependency traversal. |

**Technologies:** C#, .NET 8, Windows Forms, NUnit, XML, Visual Studio, Git.

## Repository structure

The most recent spreadsheet iteration is in [`HW10_Spreadsheet_Mitchell_Milander`](HW10_Spreadsheet_Mitchell_Milander/):

```text
HW10_Spreadsheet_Mitchell_Milander/
├── SpreadsheetEngine/                 # Cell model, expression evaluator, commands, persistence
├── Spreadsheet_Mitchell_Milander/     # Windows Forms user interface
├── UnitTests/                         # NUnit test project
└── Spreadsheet_Mitchell_Milander.sln  # Visual Studio solution
```

The repository also retains earlier assignment folders, showing how the application evolved across the semester, along with smaller supporting C# exercises.

## Running the application in Visual Studio

**Requirements:** Windows, Visual Studio with the **.NET desktop development** workload, and the **.NET 8 SDK**.

1. Clone or download this repository.
2. Open `HW10_Spreadsheet_Mitchell_Milander/Spreadsheet_Mitchell_Milander.sln` in **Visual Studio**.
3. In **Solution Explorer**, right-click the `Spreadsheet_Mitchell_Milander` application project and select **Set as Startup Project**.
4. Click the green **Start** button or press **F5** to build and launch the application.

### Unit tests

The `UnitTests` project uses **NUnit**. To explore or run its tests, open **Test → Test Explorer** in Visual Studio and run the available tests.

## Background

Developed incrementally as part of CptS 321 software engineering coursework. This repository documents hands-on experience with C# application development, separating UI and business logic, implementing extensible components, and applying software engineering concepts in code.
