using System;
using NUnit.Framework;

namespace CodeWarsSharpNUnitTests {
    [TestFixture]
    public class SetUp_TearDown_Test {
        [SetUp]
        public void SetUp() {
            TestContext.WriteLine("set up");
        }

        [TearDown]
        public void TearDown() {
            TestContext.WriteLine("tear down");
        }


        [OneTimeSetUp]
        public void OneTimeSetUp() {
            TestContext.WriteLine("one time set up");
        }

        [OneTimeTearDown]
        public void OneTimeTearDown() {
            TestContext.WriteLine("one time tear down");
        }

        [Test]
        public void Test1() {
            TestContext.WriteLine("test1");
            Assert.AreEqual(true, true);
        }

        [Test]
        public void Test2() {
            TestContext.WriteLine("test2");
            Assert.AreEqual(true, true);
        }
    }
}
