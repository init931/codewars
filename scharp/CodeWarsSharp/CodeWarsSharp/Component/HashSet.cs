using System;
using System.Collections.Generic;

namespace CodeWarsSharp.Component {
    public class HashSet {
        public HashSet() {
            var arr1 = new string[] { "hi", "hello", "hi" };

            var hs = new HashSet<string>(arr1);
            Console.WriteLine($"HashSet items count = {hs.Count}");
            { }
        }
    }
}
