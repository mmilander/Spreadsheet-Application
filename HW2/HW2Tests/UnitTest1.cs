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
            Assert.NotNull(TestClass.array);
        }

        /// <summary> test to make sure all random values are between [0,20000]
        /// <return></void>
        [Test]
        public void TestInBounds()
        {
            for(int i = 0; i < 10000; i++)
            {
                Assert.LessOrEqual(TestClass.array[i], 20001);
                Assert.GreaterOrEqual(TestClass.array[i], 0);
            }
        }

        /// <summary> Test that all three unique number calculations are equivalent
        /// <return></void>
        [Test]
        public void TestEquality()
        {

        }
    }
}