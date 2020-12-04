using System;
using System.Linq;

namespace CodeWarsSharp.Kata {
    public partial class Kata {
        /// <summary>
        /// https://www.codewars.com/kata/5420fc9bb5b2c7fd57000004/train/csharp
        /// </summary>
        public static int HighestRank(int[] arr) {
            var group = arr.GroupBy(x => x).Select(x => new { ch = x.Key, cnt = x.Count() });
            var max = group.Where(x => x.cnt == group.Max(x => x.cnt));
            return max.Count() == 1 ? max.First().ch : max.Max(x => x.ch);
        }
    }
}
