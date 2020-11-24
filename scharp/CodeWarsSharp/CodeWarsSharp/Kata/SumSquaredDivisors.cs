using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWarsSharp.Kata {
    public partial class Kata {
        /// <summary>
        /// https://www.codewars.com/kata/55aa075506463dac6600010d/train/csharp
        /// Divisors of 42 are : 1, 2, 3, 6, 7, 14, 21, 42. These divisors
        /// squared are: 1, 4, 9, 36, 49, 196, 441, 1764. The sum of the squared
        /// divisors is 2500 which is 50 * 50, a square!
        /// Given two integers m, n (1 <= m <= n) we want to find all integers
        /// between m and n whose sum of squared divisors is itself a square.
        /// 42 is such a number.
        /// The result will be an array of arrays or of tuples(in C an array of Pair)
        /// or a string, each subarray having two elements, first the number whose
        /// squared divisors is a square and then the sum of the squared divisors.
        /// </summary>
        public static string SumSquaredDivisors(long m, long n) {
            var ret = new List<long[]>();
            for (long i = m; i <= n; i++) {
                var divisors = new List<long>();
                for (int j = 1; j <= i; j++) {
                    if (i % j == 0) {
                        divisors.Add(j * j);
                    }
                }

                var sum = divisors.Sum();
                var sqrt = Math.Sqrt(sum);
                if (sqrt == (long)sqrt) {
                    ret.Add(new long[] { i, sum });
                }
            }

            var str = "[";
            if (ret.Count > 0) {
                foreach (var item in ret) {
                    str += $"[{string.Join(", ", item)}], ";
                }
                str = str.Substring(0, str.Length - 2);
            }
            str += "]";
            return str;
        }
    }
}
