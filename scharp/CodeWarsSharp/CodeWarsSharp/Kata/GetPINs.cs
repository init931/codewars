using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWarsSharp.Kata {
    public partial class Kata {
        /// <summary>
        /// https://www.codewars.com/kata/5263c6999e0f40dee200059d/train/csharp
        /// </summary>
        public static List<string> GetPINs(string observed) {
            var ret = new List<int>();

            for (int i = 0; i < observed.Length; i++) {
                var ch = observed[i];


            }

            return ret.Select(x => x.ToString()).ToList();
        }

        public static int[] getAdjacent(int num) {
            return num switch {
                0 => new int[] { 8 },
                1 => new int[] { 2, 4 },
                2 => new int[] { 1, 3, 5 },
                3 => new int[] { 2, 6 },
                4 => new int[] { 1, 5, 7 },
                5 => new int[] { 2, 4, 6, 8 },
                6 => new int[] { 3, 5, 9 },
                7 => new int[] { 4, 8 },
                8 => new int[] { 5, 7, 9 },
                9 => new int[] { 6, 8 },
                _ => new int[0]
            };
        }
    }
}
