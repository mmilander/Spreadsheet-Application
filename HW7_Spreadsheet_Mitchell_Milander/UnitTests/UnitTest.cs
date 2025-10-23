// <copyright file="UnitTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using NUnit.Framework;
using SpreadsheetEngine;
using System.Linq.Expressions;

/// <summary>
/// This program provides the testing framework for SpreadSheet Cell Class.
/// </summary>
public class UnitTest
{
    // Suppressed this warning about having a [Teardown] method because
    // I am unsure how to handle it.
#pragma warning disable NUnit1032 // An IDisposable field/property should be Disposed in a TearDown method
    private Spreadsheet normalCase;
    private Spreadsheet edgeCase;
    private Spreadsheet? exceptionCase;
#pragma warning restore NUnit1032 // An IDisposable field/property should be Disposed in a TearDown method.
    /// <summary>
    /// This method provides the initial setup for the testing.
    /// </summary>
    [SetUp]
    public void Setup()
    {
        this.normalCase = new Spreadsheet(5, 5);
        this.edgeCase = new Spreadsheet(5, 5);
    }


    /// <summary>
    /// This tests that when changing one cell, the event is triggered
    /// and the value is updated.
    /// </summary>
    [Test]
    public void TestNormalCaseResult()
    {
        this.normalCase.GetCell(0, 0).Text = "A1";
        this.normalCase.GetCell(0, 1).Text = "=A1";
        string tempName = this.normalCase.GetCell(0, 1).Value;
        Assert.That(tempName, Is.EqualTo("A1")); // Since cell (0,1) value should update to A1
    }

    /// <summary>
    /// This tests retrieving the cell from coordinates (0,0) is not null.
    /// </summary>
    [Test]
    public void EdgeCaseResult()
    {
        Cell cellTemp = this.edgeCase.GetCell(0, 0);
        Assert.IsNotNull(cellTemp);
    }

    /// <summary>
    /// This tests the spreadsheet with negative dimensions.
    /// </summary>
    [Test]
    public void ExceptionCaseResult()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => this.exceptionCase = new Spreadsheet(-1, 3));
    }

    /// <summary>
    /// Normal case test.
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
        double testNum = this.normalCase.Evaluate(input);
        Assert.That(expected, Is.EqualTo(testNum));
    }

    /// <summary>
    /// Edge case test using empty string as input.
    /// </summary>
    [Test]
    public void EdgeCaseExpressionTree()
    {
        Assert.Throws<ArgumentException>(() => this.edgeCase.Evaluate((string.Empty)));
    }

    /// <summary>
    /// Exception case test using invalid operator as input.
    /// </summary>
    [Test]
    public void ExceptionCaseExpressionTree()
    {
        this.exceptionCase = new Spreadsheet(5, 5);
        Assert.Throws<ArgumentException>(() => this.exceptionCase.Evaluate("%"));
    }

    /// <summary>
    /// Normal case test for private Shunting Yard Algorithm .
    /// </summary>
    /// <param name="input">input string.</param>
    /// <param name="expected">expected string.</param>

    public void NormalTestShuntingYard()
    {
       // List<string> input = {}
      //  double testNum = this.normalCase.Evaluate(input);
       // Assert.That(expected, Is.EqualTo(testNum));
    }

    /// <summary>
    /// Edge case test for private Shunting Yard Algorithm.
    /// </summary>
    [Test]
    public void EdgeCaseShuntingYard()
    {
        //Assert.Throws<ArgumentException>(() => this.edgeCase.Evaluate((string.Empty)));
    }

    /// <summary>
    /// Exception case test for private Shunting Yard Algorithm.
    /// </summary>
    [Test]
    public void ExceptionCaseShuntingYard()
    {
        //this.exceptionCase = new Spreadsheet(5, 5);
        //Assert.Throws<ArgumentException>(() => this.exceptionCase.Evaluate("%"));
    }
}