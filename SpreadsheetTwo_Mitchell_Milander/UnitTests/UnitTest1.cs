// <copyright file="UnitTest1.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using NUnit.Framework;
using SpreadsheetEngine;

/// <summary>
/// This program provides the testing framework for SpreadSheet Cell Class.
/// </summary>
public class UnitTest1
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
    public void TestNormalCase()
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
    public void EdgeCase()
    {
        Cell cellTemp = this.edgeCase.GetCell(0, 0);
        Assert.IsNotNull(cellTemp);
    }

    /// <summary>
    /// This tests the spreadsheet with negative dimensions.
    /// </summary>
    [Test]
    public void ExceptionCase()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => this.exceptionCase = new Spreadsheet(-1, 3));
    }
}