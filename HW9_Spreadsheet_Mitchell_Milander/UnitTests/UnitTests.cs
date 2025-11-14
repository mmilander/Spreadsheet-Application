// <copyright file="UnitTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Linq.Expressions;
using System.Reflection;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using SpreadsheetEngine;

/// <summary>
/// This program provides the testing framework for SpreadSheet Cell Class.
/// </summary>
public class UnitTests
{
    // Suppressed this warning about having a [Teardown] method because
    // I am unsure how to handle it.
#pragma warning disable NUnit1032 // An IDisposable field/property should be Disposed in a TearDown method
    private Spreadsheet normalCaseSpreadsheet;
    private Spreadsheet edgeCaseSpreadsheet;
    private Spreadsheet? exceptionCaseSpreadsheet;
    private ExpressionTree objectUnderTest;
#pragma warning restore NUnit1032 // An IDisposable field/property should be Disposed in a TearDown method.
    /// <summary>
    /// This method provides the initial setup for the testing.
    /// </summary>
    [SetUp]
    public void Setup()
    {
        this.normalCaseSpreadsheet = new Spreadsheet(5, 5);
        this.edgeCaseSpreadsheet = new Spreadsheet(5, 5);
        this.objectUnderTest = new ExpressionTree("2 + 4 + 1");
    }

    /// <summary>
    /// Checks that a spreadsheet is saved and loaded correctly.
    /// </summary>
    [Test]
    public void TestNormalCaseXML()
    {
        MemoryStream test = new MemoryStream();
        this.normalCaseSpreadsheet.GetCell(0, 0).Text = "10";
        this.normalCaseSpreadsheet.GetCell(0, 1).Text = "=A1";
        this.normalCaseSpreadsheet.GetCell(1, 0).BGColor = 0xFF0000FF;
        this.normalCaseSpreadsheet.Save(test);
        test.Seek(0, SeekOrigin.Begin); // Set postition to beginning
        Spreadsheet sheetTwo = new Spreadsheet(5, 5);
        sheetTwo.Load(test);
        Assert.That(sheetTwo.GetCell(0, 0).Text, Is.EqualTo("10"));
        Assert.That(sheetTwo.GetCell(0, 1).Text, Is.EqualTo("=A1"));
        Assert.That(sheetTwo.GetCell(0, 1).BGColor, Is.EqualTo(0xFF0000FF));
    }

    /// <summary>
    /// Checks that saving and loading an empty cell works correctly.
    /// </summary>
    [Test]
    public void EdgeCaseXML()
    {
        MemoryStream test = new MemoryStream();
        Spreadsheet empty = new Spreadsheet(5, 5);
        empty.Save(test);
        test.Seek(0, SeekOrigin.Begin); // Set postition to beginning
        Spreadsheet sheetTwo = new Spreadsheet(5, 5);
        sheetTwo.Load(test);
        Assert.That(sheetTwo.GetCell(0, 0).Text, Is.EqualTo(string.Empty));
        Assert.That(sheetTwo.GetCell(0, 1).Text, Is.EqualTo(string.Empty));
        Assert.That(sheetTwo.GetCell(0, 1).BGColor, Is.EqualTo(0xFFFFFFFF));
    }

    /// <summary>
    /// This tests the load function with invalid input.
    /// </summary>
    [Test]
    public void ExceptionCaseXML()
    {
        Spreadsheet empty = new Spreadsheet(5, 5);
        Assert.Throws<ArgumentNullException>(() => empty.Load(null));
    }

    /// <summary>
    /// Checks that string retrieval method functions properly.
    /// </summary>
    [Test]
    public void TestNormalCaseCommandDP()
    {
        UndoRedoCollection newCollection = new UndoRedoCollection("text change");
        ChangeTextCommand changeText = new ChangeTextCommand(this.normalCaseSpreadsheet, 0, 1, "...", "newtext");
        newCollection.AddCmd(changeText);
        this.normalCaseSpreadsheet.AddUndo(newCollection);
        string check = this.normalCaseSpreadsheet.GetUndoInfo();
        Assert.That(check, Is.EqualTo("Undo text change"));
    }

    /// <summary>
    /// Checks that string retrieval method works if undoCollection is empty.
    /// </summary>
    [Test]
    public void EdgeCaseResultCommandDP()
    {
        string check = this.edgeCaseSpreadsheet.GetUndoInfo();
        Assert.That(check, Is.EqualTo(string.Empty));
    }

    /// <summary>
    /// Pass in empty UndoRedoCollection.
    /// </summary>
    [Test]
    public void ExceptionCaseResultCommandDP()
    {
        UndoRedoCollection newCollection = new UndoRedoCollection("text change");
        Assert.Throws<InvalidOperationException>(() => this.edgeCaseSpreadsheet.AddUndo(newCollection));
    }

    /// <summary>
    /// This tests that when changing one cell, the event is triggered
    /// and the value is updated.
    /// </summary>
    [Test]
    public void TestNormalCaseResult()
    {
        this.normalCaseSpreadsheet.GetCell(0, 0).Text = "10";
        this.normalCaseSpreadsheet.GetCell(0, 1).Text = "=A1";
        string tempName = this.normalCaseSpreadsheet.GetCell(0, 1).Value;
        Assert.That(tempName, Is.EqualTo("10")); // Since cell (0,1) value should update to A1
    }

    /// <summary>
    /// This tests retrieving the cell from coordinates (0,0) is not null.
    /// </summary>
    [Test]
    public void EdgeCaseResult()
    {
        Cell cellTemp = this.edgeCaseSpreadsheet.GetCell(0, 0);
        Assert.IsNotNull(cellTemp);
    }

    /// <summary>
    /// This tests the spreadsheet with negative dimensions.
    /// </summary>
    [Test]
    public void ExceptionCaseResult()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => this.exceptionCaseSpreadsheet = new Spreadsheet(-1, 3));
    }

    /// <summary>
    /// Normal case test of ExpressionTree.
    /// </summary>
    /// <param name="input">input string.</param>
    /// <param name="expected">expected string.</param>
    [TestCase("2+4+6", 12.0)]
    [TestCase("3-1-2", 0.0)]
    [TestCase("4-3", 1.0)]
    [TestCase("(5*9)-6", 39.0)]
    [TestCase("1*2*(10/5)", 4.0)]
    [TestCase("12/2", 6.0)]
    [TestCase("(12/2)*3", 18.0)]

    public void NormalTestExpressionTree(string input, double expected)
    {
        ExpressionTree normalCaseExpressionTree = new ExpressionTree(input);
        double testNum = normalCaseExpressionTree.Evaluate();
        Assert.That(expected, Is.EqualTo(testNum));
    }

    /// <summary>
    /// Edge case test using empty string as input.
    /// </summary>
    [Test]
    public void EdgeCaseExpressionTree()
    {
        Assert.Throws<ArgumentException>(() => new ExpressionTree(string.Empty));
    }

    /// <summary>
    /// Exception case test using invalid operator as input.
    /// </summary>
    [Test]
    public void ExceptionCaseExpressionTree()
    {
        Assert.Throws<ArgumentException>(() => new ExpressionTree("%"));
    }

    /// <summary>
    /// Normal case test for private Shunting Yard Algorithm .
    /// </summary>
    /// <param name="input">input string.</param>
    /// <param name="expected">expected string.</param>
    public void NormalTestShuntingYard()
    {
        List<string> input = new List<string> { "1", "+", "(", "6", "/", "2", "*", "3", ")" };
        List<string> comp = new List<string> { "1", "6", "2", "/", "3", "*", "+" };
        MethodInfo methodInfo = this.GetMethod("Shunt", new Type[] { typeof(List<string>) });
        CollectionAssert.AreEqual(comp, (List<string>)methodInfo.Invoke(this.objectUnderTest, new object[] { input }));
    }

    /// <summary>
    /// Edge case [empty list] test for private Shunting Yard Algorithm.
    /// </summary>
    [Test]
    public void EdgeCaseShuntingYard()
    {
        MethodInfo methodInfo = this.GetMethod("Shunt", new Type[] { typeof(List<string>) });
        List<string> comp = new List<string>();
        CollectionAssert.AreEqual(comp, (List<string>)methodInfo.Invoke(this.objectUnderTest, new object[] { comp }));
    }

    /// <summary>
    /// Exception case test for private Shunting Yard Algorithm.
    /// </summary>
    [Test]
    public void ExceptionCaseShuntingYard()
    {
        MethodInfo methodInfo = this.GetMethod("Shunt", new Type[] { typeof(List<string>) });
        Assert.Throws<TargetInvocationException>(() => methodInfo.Invoke(this.objectUnderTest, new object[] { null }));
    }

    private MethodInfo GetMethod(string methodName, Type[] parameterTypes)
    {
        if (string.IsNullOrWhiteSpace(methodName))
        {
            Assert.Fail("methodName cannot be null or whitespace");
        }

        var method = this.objectUnderTest.GetType().GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance, parameterTypes);
        if (method == null)
        {
            Assert.Fail(string.Format("{0} method not found", methodName));
        }

        return method;
    }
}