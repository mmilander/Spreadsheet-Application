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

        /// <summary> test to make sure random value is 20000 or below
        /// <return></void>
        [Test]
        public void TestInBounds()
        { 
            
        }

        /// <summary> Test that all three unique number calculations are equivalent
        /// <return></void>
        [Test]
        public void TestEquality()
        {

        }
    }
}