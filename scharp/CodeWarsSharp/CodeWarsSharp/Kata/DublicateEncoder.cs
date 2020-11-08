using System;
using System.Collections.Generic;

namespace CodeWarsSharp.Kata {
    public partial class Kata {
        //https://www.codewars.com/kata/54b42f9314d9229fd6000d9c/train/csharp
        /*The goal of this exercise is to convert a string to a new string 
         * where each character in the new string is "(" if that character 
         * appears only once in the original string, or ")" if that character 
         * appears more than once in the original string. Ignore capitalization 
         * when determining if a character is a duplicate.*/

        public static string DuplicateEncode(string word) {
            var res = word.ToLower();
            var dict = new Dictionary<char, int>();
            for (int i = 0; i < res.Length; i++) {
                var ch = res[i];
                if (dict.ContainsKey(ch)) {
                    continue;
                }
                dict.Add(ch, StringContainChar(res, ch));
            }

            for (int i = 0; i < res.Length; i++) {
                var ch = res[i];
                if (dict[ch] > 1) {
                    res = res.Remove(i, 1);
                    res = res.Insert(i, ")");
                }
                else {
                    res = res.Remove(i, 1);
                    res = res.Insert(i, "(");
                }
            }
            return res;
        }

        public static int StringContainChar(string input, char search) {
            int count = 0;
            foreach (char ch in input) {
                if (ch == search) {
                    count++;
                }
            }
            return count;
        }
    }
}