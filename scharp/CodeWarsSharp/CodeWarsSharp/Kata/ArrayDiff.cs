using System;
using System.Linq;
using System.Collections.Generic;

namespace CodeWarsSharp.Kata {
    public partial class Kata {
        /// <summary>
        /// https://www.codewars.com/kata/523f5d21c841566fde000009/train/csharp
        /// </summary>
        public static int[] ArrayDiff(int[] a, int[] b) {
            /*Your goal in this kata is to implement a difference function, 
            which subtracts one list from another and returns the result.
            It should remove all values from list a, which are present in list b.
            If a value is present in b, all of its occurrences must be removed from the other*/

            var ret = new List<int>();
            for (int i = 0; i < a.Length; i++) {
                var ia = a[i];
                if (!b.Contains(ia)) {
                    ret.Add(ia);
                }
            }
            return ret.ToArray();
        }

        public static int[] ArrayDiff_Linq(int[] a, int[] b) {
            return a.Where(n => !b.Contains(n)).ToArray();
        }

        public static int[] ArrayDiff_HashSet(int[] a, int[] b) {
            var result = new List<int>();
            var excludes = new HashSet<int>(b);
            foreach (var x in a) {
                if (!excludes.Contains(x))
                    result.Add(x);
            }

            return result.ToArray();
        }

        /// <summary>
        /// FindAll все тормозит
        /// </summary>
        public static int[] ArrayDiff_FindAll(int[] a, int[] b) {
            var sb = new HashSet<int>(b);
            return Array.FindAll(a, x => !sb.Contains(x));
        }
    }
}
