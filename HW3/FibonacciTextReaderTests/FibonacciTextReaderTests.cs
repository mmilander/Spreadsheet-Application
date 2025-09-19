// <copyright file="FibonacciTextReaderTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using NUnit.Framework;

    /// <summary>
    /// This program provides the testing framework for the Fibonacci Text Reader.
    /// </summary>
public class FibonacciTextReaderTests
    {
 // Suppressed this warning about having a [Teardown] method because
 // we haven't learned about this in class yet.
#pragma warning disable NUnit1032 // An IDisposable field/property should be Disposed in a TearDown method
        private FibonacciTextReader normalCase;
        private FibonacciTextReader edgeCase;
        private FibonacciTextReader? exceptionCase;
#pragma warning restore NUnit1032 // An IDisposable field/property should be Disposed in a TearDown method.
       /// <summary>
       /// This method provides the initial setup for the testing.
       /// </summary>
        [SetUp]
        public void Setup()
        {
            this.normalCase = new FibonacciTextReader(5);
            this.edgeCase = new FibonacciTextReader(1);
        }

        /// <summary>
        /// This tests the first five numbers of the Fibonacci Sequence
        /// </summary>
        [Test]
        public void TestNormalCase()
        {
            string comp = "1: 0\r\n2: 1\r\n3: 1\r\n4: 2\r\n5: 3\r\n";
            string result = this.normalCase.ReadToEnd();
            Console.WriteLine(result);
            Assert.That(result, Is.EqualTo(comp));
        }

        /// <summary>
        /// This tests that the fib sequence outputs the correct first number
        /// </summary>
        [Test]
        public void EdgeCase()
        {
            string comp = "1: 0\r\n";
            string result = this.edgeCase.ReadToEnd();
            Assert.That(result, Is.EqualTo(comp));
        }

        /// <summary>
        /// This tests that when the FibonacciTextReader is initialized with
        /// a number outside of the input-range that an out-of-range exception
        /// is thrown.
        /// </summary>
        [Test]
        public void ExceptionCase()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => this.exceptionCase = new FibonacciTextReader(-1));
        }
    }