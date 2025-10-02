// <copyright file="SpreadSheetEngineTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using NUnit.Framework;
using SpreadsheetEngine;

/// <summary>
/// This program provides the testing framework for SpreadSheet Cell Class.
/// </summary>
public class SpreadsheetEngineCellTests
{
   
    // Suppressed this warning about having a [Teardown] method because
    // I am unsure how to handle it.
#pragma warning disable NUnit1032 // An IDisposable field/property should be Disposed in a TearDown method
    private Cell normalCase;
    private Cell edgeCase;
    private Cell? exceptionCase;
#pragma warning restore NUnit1032 // An IDisposable field/property should be Disposed in a TearDown method.
    /// <summary>
    /// This method provides the initial setup for the testing.
    /// </summary>
    [SetUp]
    public void Setup()
    {
       
    }

    /// <summary>
    /// This tests...
    /// </summary>
    [Test]
    public void TestNormalCase()
    {
       
    }

    /// <summary>
    /// This tests...
    /// </summary>
    [Test]
    public void EdgeCase()
    {
        
    }

    /// <summary>
    /// This tests...
    /// </summary>
    [Test]
    public void ExceptionCase()
    {
        
    }
}