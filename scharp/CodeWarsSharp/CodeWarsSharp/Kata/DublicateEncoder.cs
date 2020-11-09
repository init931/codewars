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
        /// Результат хуже чем если напрямую работать со string. StringBuilder походу плохо переносить замены и инсерты(надо проверить)
        /// проверил, скорость неплохо проседает
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

        /// <summary>
        /// Избавление от StringContainChar ускорило код еще больше. реально, зачем мне нужен был отдельный метод?
        /// </summary>
        public static string DuplicateEncodeMy_WithoutStringContainChar(string word) {
            var lower = word.ToLower();
            var counts = new Dictionary<char, int>();
            foreach (var ch in lower) {         ////
                if (counts.ContainsKey(ch)) {
                    counts[ch]++;
                }
                else {
                    counts.Add(ch, 1);
                }
            }

            for (int i = 0; i < lower.Length; i++) {
                var ch = lower[i];
                if (counts[ch] > 1) {
                    lower = lower.Remove(i, 1);
                    lower = lower.Insert(i, ")");
                } else {
                    lower = lower.Remove(i, 1);
                    lower = lower.Insert(i, "(");
                }
            }
            return lower;
        }

        /// <summary>
        /// Быстрее за счет избавления от счетчика
        /// </summary>
        public static string DuplicateEncodeMy_WithoutStringContainChar_WithoutCounter(string word) {
            var lower = word.ToLower();
            var counts = new Dictionary<char, char>();
            foreach (var ch in lower) {
                if (!counts.ContainsKey(ch)) {   ////
                    counts.Add(ch, '(');
                }
                else {
                    counts[ch] = ')';
                }
            }

            for (int i = 0; i < lower.Length; i++) {
                var ch = lower[i];
                if (counts[ch] == ')') {
                    lower = lower.Remove(i, 1);
                    lower = lower.Insert(i, ")");
                } else {
                    lower = lower.Remove(i, 1);
                    lower = lower.Insert(i, "(");
                }
            }
            return lower;
        }

        /// <summary>
        /// Значительно быстрее чем предыдущий. Походу StringBuilder очень быстрая вещь если писать последовательно
        /// </summary>
        public static string DuplicateEncodeMy_WithoutStringContainChar_WithoutCounter_AndWithStringBuilder(string word) {
            var lower = word.ToLower();
            var map = new Dictionary<char, char>();
            foreach (var ch in lower) {
                if (!map.ContainsKey(ch)) {
                    map.Add(ch, '(');
                } else {
                    map[ch] = ')';
                }
            }

            var sp = new StringBuilder();               ////
            for (int i = 0; i < lower.Length; i++) {
                var ch = lower[i];
                sp.Append(map[ch]);
            }
            return sp.ToString();
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

        /// <summary>
        /// Не производительно, но в одну строку
        /// </summary>
        public static string DuplicateEncode_1Line(string word) {
            return new string(word.ToLower().Select(ch => word.ToLower().Count(innerCh => ch == innerCh) == 1 ? '(' : ')').ToArray());
        }

        /// <summary>
        /// Рещение хорошо тем, что использует StringBuilder
        /// </summary>
        public static string DuplicateEncode_UpperDistinct(string word) {
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

        /// <summary>
        /// Крайне тяжелое решение по производительности
        /// </summary>
        public static string DuplicateEncode_PitMaster(string word) {
            return GetEncodedString(word, GetDuplicateCharacters(word));
        }


        private static string GetEncodedString(string word, IEnumerable<char> duplicateCharacters) {
            var newString = new StringBuilder();
            word.ToLower().ToList().ForEach(c => newString.Append(duplicateCharacters.Contains(c) ? ")" : "("));
            return newString.ToString();
        }

        private static IEnumerable<char> GetDuplicateCharacters(string word) {
            return word.ToLower().GroupBy(c => c).Where(c => c.Count() > 1).Select(c => c.Key);
        }

        public static string DuplicateEncode_Split(string word) {
            string retval = "";
            word = word.ToLower();
            for (int i = 0; i < word.Length; i++)
                retval += (word.Split(word[i]).Length - 1 > 1 ? ')' : '(');
            return retval;
        }

        public static string DuplicateEncode_Concat(string word) {
            word = word.ToLower();
            return string.Concat(word.Select(x => word.Count(w => w == x) > 1 ? ')' : '('));
        }
    }
}