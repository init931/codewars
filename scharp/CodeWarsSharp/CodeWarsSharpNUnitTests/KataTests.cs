using NUnit.Framework;
using CodeWarsSharp.Kata;

namespace CodeWarsSharpNUnitTests {
    public class KataTests {
        [Test]
        public void DuplicateEncoder() {
            Assert.AreEqual(")))))(", Kata.DuplicateEncode(" ( ( )"));
            Assert.AreEqual("(((", Kata.DuplicateEncode("din"));
            Assert.AreEqual("()()()", Kata.DuplicateEncode("recede"));
            Assert.AreEqual(")())())", Kata.DuplicateEncode("Success"), "should ignore case");
            Assert.AreEqual("))((", Kata.DuplicateEncode("(( @"));
            Assert.Pass();
        }
    }
}
