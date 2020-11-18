using NUnit.Framework;
using CodeWarsSharp.Kata;
using System.Collections.Generic;

namespace CodeWarsSharpNUnitTests {
    [TestFixture]
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

        [Test]
        public void ReversedStrings() {
            Assert.AreEqual("dlrow", Kata.ReversedStrings("world"));
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
        public void TakeATenMinuteWalk() {
            Assert.AreEqual(true, Kata.TakeATenMinuteWalk(new string[] { "n", "s", "n", "s", "n", "s", "n", "s", "n", "s" }), "should return true 1");
            Assert.AreEqual(false, Kata.TakeATenMinuteWalk(new string[] { "w", "e", "w", "e", "w", "e", "w", "e", "w", "e", "w", "e" }), "should return false 2");
            Assert.AreEqual(false, Kata.TakeATenMinuteWalk(new string[] { "w" }), "should return false 3");
            Assert.AreEqual(false, Kata.TakeATenMinuteWalk(new string[] { "n", "n", "n", "s", "n", "s", "n", "s", "n", "s" }), "should return false 4");
        }

        [Test]
        public void WhoLikesIt() {
            Assert.AreEqual("no one likes this", Kata.WhoLikesIt(new string[0]));
            Assert.AreEqual("Peter likes this", Kata.WhoLikesIt(new string[] { "Peter" }));
            Assert.AreEqual("Jacob and Alex like this", Kata.WhoLikesIt(new string[] { "Jacob", "Alex" }));
            Assert.AreEqual("Max, John and Mark like this", Kata.WhoLikesIt(new string[] { "Max", "John", "Mark" }));
            Assert.AreEqual("Alex, Jacob and 2 others like this", Kata.WhoLikesIt(new string[] { "Alex", "Jacob", "Mark", "Max" }));
            Assert.AreEqual("Alex, Jacob and 3 others like this", Kata.WhoLikesIt(new string[] { "Alex", "Jacob", "Mark", "Max", "Griffin" }));
        }

        [Test]
        public void NarcisssticNumber() {
            Assert.AreEqual(true, Kata.NarcisssticNumber(1), "1 is narcissitic");
            Assert.AreEqual(true, Kata.NarcisssticNumber(371), "371 is narcissitic");
        }

        [Test]
        public void ProductOfConsecutiveFibNumbers() {
            Assert.AreEqual(new ulong[] { 5, 8, 1 }, Kata.ProductOfConsecutiveFibNumbers(40));
            Assert.AreEqual(new ulong[] { 55, 89, 1 }, Kata.ProductOfConsecutiveFibNumbers(4895));
            Assert.AreEqual(new ulong[] { 21, 34, 1 }, Kata.ProductOfConsecutiveFibNumbers(714));
            Assert.AreEqual(new ulong[] { 34, 55, 0 }, Kata.ProductOfConsecutiveFibNumbers(800));
            Assert.AreEqual(new ulong[] { 0, 1, 1 }, Kata.ProductOfConsecutiveFibNumbers(0));
        }

        [Test]
        public void IsANumberPrime() {
            Assert.AreEqual(false, Kata.IsANumberPrimeMy_TrialDivisionMethod(0), "0");
            Assert.AreEqual(false, Kata.IsANumberPrimeMy_TrialDivisionMethod(1), "1");
            Assert.AreEqual(true, Kata.IsANumberPrimeMy_TrialDivisionMethod(2), "2");
            Assert.AreEqual(true, Kata.IsANumberPrimeMy_TrialDivisionMethod(3), "3");
            Assert.AreEqual(false, Kata.IsANumberPrimeMy_TrialDivisionMethod(4), "4");
            Assert.AreEqual(true, Kata.IsANumberPrimeMy_TrialDivisionMethod(5), "5");
            Assert.AreEqual(false, Kata.IsANumberPrimeMy_TrialDivisionMethod(6), "6");
            Assert.AreEqual(true, Kata.IsANumberPrimeMy_TrialDivisionMethod(7), "7");
            Assert.AreEqual(false, Kata.IsANumberPrimeMy_TrialDivisionMethod(8), "8");
            Assert.AreEqual(true, Kata.IsANumberPrimeMy_TrialDivisionMethod(13), "13");
            Assert.AreEqual(false, Kata.IsANumberPrimeMy_TrialDivisionMethod(60), "60");
            Assert.AreEqual(true, Kata.IsANumberPrimeMy_TrialDivisionMethod(2147483647), "2147483647");
        }
    }

    public class Sample_Test {
        private static IEnumerable<TestCaseData> testCases {
            get {
                yield return new TestCaseData(1)
                                .Returns(true)
                                .SetDescription("1 is narcissitic");
                yield return new TestCaseData(371)
                                .Returns(true)
                                .SetDescription("371 is narcissitic");

            }
        }

        [Test, TestCaseSource("testCases")]
        public bool Test(int n) {
            return Kata.NarcisssticNumber(n);
        }
    }
}
