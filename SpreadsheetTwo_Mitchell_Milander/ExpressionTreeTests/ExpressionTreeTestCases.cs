// <copyright file="UnitTest1.cs" company="ExpressionTreeTests">
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
        /// Normal Case test.
        /// </summary>
        public void NormalTest()
        {
            ExpressionTree normalCase = new ExpressionTree("(2+4)/3");
            double testNum = normalCase.Evaluate();
            Assert.That(2.0, Is.EqualTo(testNum));
        }

        /// <summary>
        /// Edge case test.
        /// </summary>
        [Test]
        public void EdgeCase()
        {
            ExpressionTree edgeCase = new ExpressionTree("");
            Assert.That(edgeCase, Is.Null);
        }

        /// <summary>
        /// Exception case test.
        /// </summary>
        [Test]
        public void ExceptionCase()
        {
            Assert.Throws<Exception>(() => new ExpressionTree("%"));
        }
    }
}