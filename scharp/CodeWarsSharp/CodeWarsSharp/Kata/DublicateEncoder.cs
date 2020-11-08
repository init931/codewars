using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeWarsSharp.Kata {
    public partial class Kata {
        //https://www.codewars.com/kata/54b42f9314d9229fd6000d9c/train/csharp
        /*The goal of this exercise is to convert a string to a new string 
         * where each character in the new string is "(" if that character 
         * appears only once in the original string, or ")" if that character 
         * appears more than once in the original string. Ignore capitalization 
         * when determining if a character is a duplicate.*/

        public static string DuplicateEncode(string word) {
            var lower = word.ToLower();
            var dict = new Dictionary<char, int>();
            for (int i = 0; i < lower.Length; i++) {
                var ch = lower[i];
                if (dict.ContainsKey(ch)) {
                    continue;
                }
                dict.Add(ch, StringContainChar(lower, ch));
            }

            for (int i = 0; i < lower.Length; i++) {
                var ch = lower[i];
                if (dict[ch] > 1) {
                    lower = lower.Remove(i, 1);
                    lower = lower.Insert(i, ")");
                }
                else {
                    lower = lower.Remove(i, 1);
                    lower = lower.Insert(i, "(");
                }
            }
            return lower;
        }

        #region variations of my solutions

        /// <summary>
        /// Производительности не добавило. Даже слегка увеличила
        /// </summary>
        public static string DuplicateEncodeMy_ToUpper(string word) {
            var lower = word.ToUpper(); ////
            var dict = new Dictionary<char, int>();
            for (int i = 0; i < lower.Length; i++) {
                var ch = lower[i];
                if (dict.ContainsKey(ch)) {
                    continue;
                }
                dict.Add(ch, StringContainChar(lower, ch));
            }

            for (int i = 0; i < lower.Length; i++) {
                var ch = lower[i];
                if (dict[ch] > 1) {
                    lower = lower.Remove(i, 1);
                    lower = lower.Insert(i, ")");
                }
                else {
                    lower = lower.Remove(i, 1);
                    lower = lower.Insert(i, "(");
                }
            }
            return lower;
        }

        /// <summary>
        /// Результат хуже чем если напрямую работать со string. StringBuilder походу плохо переносить замены и инсерты(надо проверить) //!!!
        /// </summary>
        public static string DuplicateEncodeMy_StringBuilderWithRemoveAndInsert(string word) {
            var lower = word.ToLower();
            var dict = new Dictionary<char, int>();
            for (int i = 0; i < lower.Length; i++) {
                var ch = lower[i];
                if (dict.ContainsKey(ch)) {
                    continue;
                }
                dict.Add(ch, StringContainChar(lower, ch));
            }

            var sb = new StringBuilder(lower); ////
            for (int i = 0; i < sb.Length; i++) {
                var ch = sb[i];
                if (dict[ch] > 1) {
                    sb.Remove(i, 1);
                    sb.Insert(i, ")");
                }
                else {
                    sb.Remove(i, 1);
                    sb.Insert(i, "(");
                }
            }
            return sb.ToString();
        }

        #endregion

        public static int StringContainChar(string input, char search) {
            int count = 0;
            foreach (char ch in input) {
                if (ch == search) {
                    count++;
                }
            }
            return count;
        }

        public static string DuplicateEncode1Line(string word) {
            return new string(word.ToLower().Select(ch => word.ToLower().Count(innerCh => ch == innerCh) == 1 ? '(' : ')').ToArray());
        }

        public static string DuplicateEncodeUpperDistinct(string word) {
            //var disct = word.ToUpper().Distinct();
            Dictionary<char, int> counts = new Dictionary<char, int>();

            foreach (var c in word.ToUpper()) {
                if (counts.ContainsKey(c))
                    counts[c]++;
                else
                    counts.Add(c, 1);
            }

            StringBuilder builder = new StringBuilder();
            foreach (var c in word.ToUpper()) {
                if (counts[c] == 1)
                    builder.Append('(');
                else
                    builder.Append(')');
            }

            return builder.ToString();
        }
    }
}