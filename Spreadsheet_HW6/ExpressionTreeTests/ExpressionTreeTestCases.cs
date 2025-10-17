// <copyright file="ExpressionTreeTestCases.cs" company="ExpressionTreeTests">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ExpressionTreeTests
{
    using NUnit.Framework;
    using SpreadsheetEngine;

    /// <summary>
    /// Test cases for expression tree.
    /// </summary>
    public class ExpressionTreeTestCases
    {
        /// <summary>
        /// Setup method for testing.
        /// </summary>
        [SetUp]
        public void Setup()
        {
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
        [TestCase("1*2*3*4", 24.0)]
        [TestCase("12/2", 6.0)]
        [TestCase("(12/2)*3", 18.0)]

        public void NormalTest(string input, double expected)
        {
            ExpressionTree normalCase = new ExpressionTree(input);
            double testNum = normalCase.Evaluate();
            Assert.That(expected, Is.EqualTo(testNum));
        }

        /// <summary>
        /// Edge case test using empty string as input.
        /// </summary>
        [Test]
        public void EdgeCase()
        {
            Assert.Throws<ArgumentException>(() => new ExpressionTree(string.Empty));
        }

        /// <summary>
        /// Exception case test using invalid operator as input.
        /// </summary>
        [Test]
        public void ExceptionCase()
        {
            Assert.Throws<ArgumentException>(() => new ExpressionTree("%"));
        }
    }
}