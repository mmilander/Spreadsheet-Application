// <copyright file="ConsoleApp.cs" company="ConsoleApp">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using SpreadsheetEngine;

/// <summary>
/// This class run the console application demo.
/// </summary>
public class ConsoleApp
{
    /// <summary>
    /// Main Menu for running program.
    /// </summary>
    /// <param name="args">Default param.</param>
    public static void Main(string[] args)
    {
        ConsoleApp run = new ConsoleApp();
        run.MenuLogic();
    }

    private void PrintMenu(string expression)
    {
        Console.WriteLine($"Menu (current expression = \"{expression}\")");
        Console.WriteLine("\t 1 = Enter a new expression");
        Console.WriteLine("\t 2 = Set a variable value");
        Console.WriteLine("\t 3 = Evaluate tree");
        Console.WriteLine("\t 4 = Quit");
    }

    private void MenuLogic()
    {
        ExpressionTree solution = new ExpressionTree("2+5+1");
        string expression = string.Empty;
        string input = string.Empty;
        double variableValue = 0;
        this.PrintMenu(expression);
        bool flag = true;
        while (flag == true)
        {
            input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.Write("Enter your new expression: ");
                    input = Console.ReadLine();
                    solution = new ExpressionTree(input);
                    expression = input;
                    this.PrintMenu(expression);
                    break;
                case "2":
                    Console.Write("Enter a variable name: ");
                    input = Console.ReadLine();
                    Console.Write("Enter a variable value: ");
                    variableValue = double.Parse(Console.ReadLine());
                    solution.SetVariable(input, variableValue);
                    this.PrintMenu(expression);
                    break;
                case "3":
                    Console.WriteLine(solution.Evaluate());
                    this.PrintMenu(expression);
                    break;
                case "4":
                    Console.WriteLine("Done");
                    flag = false;
                    break;
                default:
                    break;
            }
        }
    }
}
