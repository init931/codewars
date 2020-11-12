using NUnit.Framework;
using CodeWarsSharp.Kata;

namespace CodeWarsSharpNUnitTests {
    public class KataTests {
        [Test]
        public void TakeATenMinuteWalk() {
            Assert.AreEqual(true, Kata.TakeATenMinuteWalk(new string[] { "n", "s", "n", "s", "n", "s", "n", "s", "n", "s" }), "should return true 1");
            Assert.AreEqual(false, Kata.TakeATenMinuteWalk(new string[] { "w", "e", "w", "e", "w", "e", "w", "e", "w", "e", "w", "e" }), "should return false 2");
            Assert.AreEqual(false, Kata.TakeATenMinuteWalk(new string[] { "w" }), "should return false 3");
            Assert.AreEqual(false, Kata.TakeATenMinuteWalk(new string[] { "n", "n", "n", "s", "n", "s", "n", "s", "n", "s" }), "should return false 4");
        }

        [Test]
        public void ArrayDiff() {
            Assert.AreEqual(new int[] { 2 }, Kata.ArrayDiff(new int[] { 1, 2 }, new int[] { 1 }));
            Assert.AreEqual(new int[] { 2, 2 }, Kata.ArrayDiff(new int[] { 1, 2, 2 }, new int[] { 1 }));
            Assert.AreEqual(new int[] { 1 }, Kata.ArrayDiff(new int[] { 1, 2, 2 }, new int[] { 2 }));
            Assert.AreEqual(new int[] { 1, 2, 2 }, Kata.ArrayDiff(new int[] { 1, 2, 2 }, new int[] { }));
            Assert.AreEqual(new int[] { }, Kata.ArrayDiff(new int[] { }, new int[] { 1, 2 }));
        }

        [Test]
        public void ReversedStrings() {
            Assert.AreEqual("dlrow", Kata.ReversedStrings("world"));
        }

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
