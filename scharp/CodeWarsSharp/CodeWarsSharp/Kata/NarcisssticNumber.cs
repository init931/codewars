using System;
using System.Linq;
using System.Collections.Generic;

namespace CodeWarsSharp.Kata {
    public partial class Kata {
        /// <summary>
        /// A Narcissistic Number is a positive number which is the sum of its own digits,
        /// each raised to the power of the number of digits in a given base.
        /// In this Kata, we will restrict ourselves to decimal (base 10).
        /// For example, take 153 (3 digits), which is narcisstic:
        ///     1^3 + 5^3 + 3^3 = 1 + 125 + 27 = 153
        /// and 1652 (4 digits), which isn't:
        ///     1^4 + 6^4 + 5^4 + 2^4 = 1 + 1296 + 625 + 16 = 1938
        /// Your code must return true or false depending upon whether the given number
        /// is a Narcissistic number in base 10.
        /// </summary>
        public static bool NarcisssticNumber(int value) {
            var str = value.ToString();
            int sum = 0;
            for (int i = 0; i < str.Length; i++) {
                sum += (int)Math.Pow(Double.Parse(str[i].ToString()), str.Length);
            }
            return sum == value;
        }

        public static bool NarcisssticNumber_Linq(int value) {
            var str = value.ToString();
            return str.Sum(c => Math.Pow(Convert.ToInt16(c.ToString()), str.Length)) == value;
        }
    }
}
