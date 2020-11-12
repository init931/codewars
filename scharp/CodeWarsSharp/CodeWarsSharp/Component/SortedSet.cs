using System;
using System.Collections.Generic;

namespace CodeWarsSharp.Component {
    public class SortedSet {
        private string[] arr1 = new string[] { "hi", "hello", "hi", "aaa" };
        private string[] arr2 = new string[] { "hi", "hello", "hi", "ggg" };

        public SortedSet() {
            var ss = new SortedSet<string>(arr1);
            ss.Add("aaa");
            ss.Add("ho");
            ss.Add("qq");
            ss.Add("aa");
            foreach (var item in ss) {
                Console.WriteLine(item);
            }
            { }
        }
    }
}
