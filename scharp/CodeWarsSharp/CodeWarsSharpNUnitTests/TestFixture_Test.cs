using System;
using NUnit.Framework;

namespace CodeWarsSharpNUnitTests {
    [TestFixture("zip", "zip")]
    [TestFixture("param", "param")]
    public class TestFixture_Test {
        private readonly string _param1;
        private readonly string _param2;

        public TestFixture_Test(string param1, string param2) {
            _param1 = param1;
            _param2 = param2;
        }

        [Test]
        public void TestEquality() {
            Assert.AreEqual(_param1, _param2);
        }
    }
}
