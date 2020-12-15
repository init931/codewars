using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CodeWarsSharpNUnitTests {
    [TestFixture]
    public class AlgorithmTests {
        [Test]
        public void BinarySearch() {
            var A = new List<int>();
            Assert.AreEqual(-1, CodeWarsSharp.Algorithms.BinarySearch.SearchIndex(A.ToArray(), 5));

            A.Add(1);
            Assert.AreEqual(0, CodeWarsSharp.Algorithms.BinarySearch.SearchIndex(A.ToArray(), 1));
            Assert.AreEqual(-1, CodeWarsSharp.Algorithms.BinarySearch.SearchIndex(A.ToArray(), 5));

            A.Add(2);
            Assert.AreEqual(0, CodeWarsSharp.Algorithms.BinarySearch.SearchIndex(A.ToArray(), 1));
            Assert.AreEqual(1, CodeWarsSharp.Algorithms.BinarySearch.SearchIndex(A.ToArray(), 2));
            Assert.AreEqual(-1, CodeWarsSharp.Algorithms.BinarySearch.SearchIndex(A.ToArray(), 5));
        }
    }
}
