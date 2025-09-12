using HW2;
using NUnit.Framework;
namespace HW2Tests
{
    public class Tests
    {
        private Form1 TestClass;

        [SetUp]
        public void Setup()
        {
            TestClass = new Form1();
        }

        /// <summary> test to make sure array is initialized with values
        /// <return></void>
        [Test]
        public void TestNullCase()
        {
            Assert.IsNotEmpty(TestClass.list);
        }

        /// <summary> test to make sure all random values are between [0,20000]
        /// <return></void>
        [Test]
        public void TestInBounds()
        {
            foreach(var num in TestClass.list)
            {
                Assert.LessOrEqual(num, 20001);
                Assert.GreaterOrEqual(num, 0);
            }
        }

        /// <summary> Test that all three unique number calculations are equivalent
        /// <return></void>
        [Test]
        public void TestEquality()
        {
            Assert.AreEqual(TestClass.methodOneResult, TestClass.methodTwoResult, TestClass.methodThreeResult);

        }
    }
}