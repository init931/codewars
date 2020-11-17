using System;
using System.Collections.Generic;

namespace CodeWarsSharp.Kata {
    public partial class Kata {
        /// <summary>
        /// https://www.codewars.com/kata/5262119038c0985a5b00029f/train/csharp
        /// Define a function that takes one integer argument and returns
        /// logical value true or false depending on if the integer is a prime.
        /// Per Wikipedia, a prime number(or a prime) is a natural number
        /// greater than 1 that has no positive divisors other than 1 and itself.
        /// </summary>
        public static bool IsANumberPrime(int n) {
            if (n <= 1) {
                return false;
            }
            if (n == 2) {
                return true;
            }
            if (n % 2 == 0 ) {
                return false;
            }

            for (int i = 3; i < (n + 1 / 2); i+=2) {
                if (n % i == 0) {
                    return false;
                }
            }

            return true;
        }

        public static bool IsANumberPrime_TrialDivisionMethod(int n) {
            var a = new List<double>();
            var f = 3;
            while (f * f <= n) {
                if (n % f == 0) {
                    return false;
                    a.Add(f);
                    n /= f;
                }
                else {
                    f += 2;
                }
            }
            if (n != 1) {
                a.Add(n);
            }

            return true;
        }
    }
}
