using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace CodeWarsSharp.Kata {
    public partial class Kata {
        public static List<string> SinglePermutations(string s) {
            //var res = new string[factorial(s.Length)];


            var ret2 = new HashSet<string>();
            for (int i = 0; i < s.Length; i++) {
                var ch = s[i].ToString();
                var str = s.Remove(i, 1);
                { }
                for (int j = 0; j < s.Length; j++) {
                    var prem = str.Insert(j, ch);
                    //if (!ret.Contains(prem)) {
                    ret2.Add(prem);
                    //}
                }

                { }
            }



            var ret = new List<string>();

            for (int i = 0; i < s.Length; i++) {
                for (int j = 0; j < s.Length; j++) {
                    if (i == j) continue;

                    if (i == 3) {

                    }

                    var str = s;
                    var iVal = str[i];
                    var jVal = str[j];
                    str = str.Remove(i, 1);
                    str = str.Insert(i, jVal.ToString());
                    str = str.Remove(j, 1);
                    str = str.Insert(j, iVal.ToString());
                    ret.Add(str);
                }
            }

            var un = ret.Distinct();


            var chTotal = 1;
            while (true) {
                var s2 = "";
                var chLocal = chTotal;
                for (int i = 0; i < s.Length; i++) {
                    if (chLocal == s.Length) {
                        chLocal = 0;
                    }
                    s2 = s2 + s[chLocal].ToString();
                    chLocal++;
                }

                chTotal++;

                { }
            }



            var elems = s.Select(x => x.ToString()).ToList();
            for (int i = 1; i <= s.Length - 1; i++) {
                var shifted = new List<string>();
                var ch = i;
                for (int j = 0; j < s.Length; j++) {
                    if (ch == s.Length) {
                        ch = 0;
                    }
                    shifted.Add(s[ch].ToString());
                    ch++;
                }
                elems = elems.Zip(shifted, (e, sh) => $"{e}{sh}").ToList();
            }
            return elems.ToList();
        }

        private static int factorial(int f) {
            if (f == 0) {
                return 1;
            }
            else {
                return f * factorial(f - 1);
            }
        }
    }
}
