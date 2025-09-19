using NUnit.Framework;
namespace FibonacciTextReaderTests
{
    public class FibonacciTextReaderTests
    {
#pragma warning disable NUnit1032 // An IDisposable field/property should be Disposed in a TearDown method
        private FibonacciTextReader normalCase;
        private FibonacciTextReader edgeCase;
        private FibonacciTextReader exceptionCase;
#pragma warning restore NUnit1032 // An IDisposable field/property should be Disposed in a TearDown method

        [SetUp]
        public void Setup()
        {
            normalCase = new FibonacciTextReader(5);
            edgeCase = new FibonacciTextReader(1);
        }

        /// <summary>
        /// This tests the first five numbers of the Fibonacci Sequence
        /// </summary>
        [Test]
        public void TestNormalCase()
        {

            string comp = "1: 0\r\n2: 1\r\n3: 1\r\n4: 2\r\n5: 3\r\n";
            string result = normalCase.ReadToEnd();
            Console.WriteLine(result);
            Assert.AreEqual(comp, result);
        }

        /// <summary>
        /// This tests that the fib sequence outputs the correct first number
        /// </summary>
        [Test]
        public void EdgeCase()
        {
            string comp = "1: 0\r\n";
            string result = edgeCase.ReadToEnd();
            Assert.AreEqual(comp, result);
        }

        /// <summary>
        /// This tests that when the FibonacciTextReader is initialized with
        /// a number outside of the input-range that an out-of-range exception
        /// is thrown.
        /// </summary>
        [Test]
        public void ExceptionCase()
        {
            Assert.Throws<ArgumentOutOfRangeException>(()=> exceptionCase = new FibonacciTextReader(-1));
        }
    }
}