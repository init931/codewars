using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace CodeWarsSharp.Kata {
    public partial class Kata {
        /// <summary>
        /// https://www.codewars.com/kata/5254ca2719453dcc0b00027d/csharp
        /// </summary>
        public static List<string> SinglePermutations(string s) {
            var ans = new List<string>();
            if (s.Length == 1) {
                ans.Add(s);
                return ans;
            }
            for (int i = 0; i < s.Length; i++) {
                var ch = s[i].ToString();
                var str = s.Remove(i, 1);
                var premStrs = SinglePermutations(str);
                for (int k = 0; k < premStrs.Count; k++) {

                    for (int j = 0; j < s.Length; j++) {
                        var prem = premStrs[k].Insert(j, ch);
                        ans.Add(prem);
                    }

                }
            }
            return ans.Distinct().ToList();
        }
    }
}
