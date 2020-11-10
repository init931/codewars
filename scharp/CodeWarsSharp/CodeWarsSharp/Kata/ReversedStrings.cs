using System;
using System.Text;
using System.Linq;

namespace CodeWarsSharp.Kata {
    public partial class Kata {
        /// <summary>
        /// https://www.codewars.com/kata/5168bb5dfe9a00b126000018/train/csharp
        /// </summary>
        public static string ReversedStrings(string str) {
            //Complete the solution so that it reverses the string passed into it.

            var ret = new StringBuilder();
            for (int i = str.Length - 1; i >= 0; i--) {
                ret.Append(str[i]);
            }
            return ret.ToString();
        }

        public static string ReversedStrings_MyReverse(string str) {
            return new string(str.Reverse().ToArray());
        }

        public static string ReversedStrings_Reverse(string str) {
            return new string(str.ToArray().Reverse().ToArray());
        }
    }
}
