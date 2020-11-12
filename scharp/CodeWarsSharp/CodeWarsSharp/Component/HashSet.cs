using System;
using System.Collections.Generic;

namespace CodeWarsSharp.Component {
    public class HashSet {
        private string[] arr1 = new string[] { "hi", "hello", "hi", "aaa" };
        private string[] arr2 = new string[] { "hi", "hello", "hi", "ggg" };

        public HashSet() {

        }

        private void add() {
            var hs = new HashSet<string>(arr1);
        }

        private void union() {
            var hs = new HashSet<string>(arr1);
            var hs2 = new HashSet<string>(arr2);
            hs.UnionWith(hs2);
            foreach (var item in hs) {
                Console.WriteLine(item);
            }
            Console.WriteLine(hs.Count);
        }

        /// <summary>
        /// This method is used to modify the HashSet by removing all elements which match with elements in another collection.
        /// </summary>
        private void exceptWith() {
            var hs = new HashSet<string>(arr1);
            var hs2 = new HashSet<string>(arr2);
            hs.ExceptWith(hs2);
            foreach (var item in hs) {
                Console.WriteLine(item);
            }
            Console.WriteLine(hs.Count);
        }


        /// <summary>
        /// This method modifies the HashSet object to contain those elements
        /// which are only present in one of the two collections, but not both.
        /// </summary>
        private void symmetricExceptWith() {
            var hs = new HashSet<string>(arr1);
            var hs2 = new HashSet<string>(arr2);
            hs.SymmetricExceptWith(hs2);
            foreach (var item in hs) {
                Console.WriteLine(item);
            }
            Console.WriteLine(hs.Count);
        }
    }
}
