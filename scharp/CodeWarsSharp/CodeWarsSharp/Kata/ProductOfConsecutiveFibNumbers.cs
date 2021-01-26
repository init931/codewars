using System;

namespace CodeWarsSharp.Kata {
    public partial class Kata {
        /// <summary>
        /// https://www.codewars.com/kata/5541f58a944b85ce6d00006a/train/csharp
        /// Given a number, say prod(for product), we search two Fibonacci numbers F(n) and F(n+1) verifying
        /// F(n) * F(n+1) = prod.
        /// Your function productFib takes an integer(prod) and returns an array:
        /// [F(n), F(n + 1), true] or {F(n), F(n+1), 1} or (F(n), F(n+1), True)
        /// depending on the language if F(n) * F(n+1) = prod.
        /// If you don't find two consecutive F(m) verifying F(m) * F(m+1) = prodyou will return
        /// [F(m), F(m + 1), false] or {F(n), F(n+1), 0} or (F(n), F(n + 1), False)
        /// F(m) being the smallest one such as F(m) *F(m + 1) > prod.
        /// </summary>
        public static ulong[] ProductOfConsecutiveFibNumbers(ulong prod) {
            ulong n1 = 0;
            ulong n2 = 1;
            while (true) {
                var n3 = n1 + n2;

                if (n1 * n2 == prod) {
                    return new ulong[] { n1, n2, 1 };
                }
                else if (n1 * n2 > prod) {
                    return new ulong[] { n1, n2, 0 };
                }

                n1 = n2;
                n2 = n3;
            }
        }

        public static ulong[] ProductOfConsecutiveFibNumbers_GoldenRatio(ulong prod) {
            var phi = (1 + Math.Sqrt(5)) / 2;
            var fibM = Math.Sqrt(prod);

            var m = Math.Floor(Math.Log(fibM * Math.Sqrt(5)) / Math.Log(phi));

            var fibm = (ulong)Math.Round(Math.Pow(phi, m) / Math.Sqrt(5));
            var fibm2 = (ulong)Math.Round(Math.Pow(phi, m + 1) / Math.Sqrt(5));

            if (fibm * fibm2 == prod) {
                return new ulong[] { fibm, fibm2, (ulong)1 };
            }
            else if (fibm * fibm2 > prod) {
                return new ulong[] { fibm, fibm2, 0 };
            }
            else {
                return new ulong[] { fibm2, (ulong)Math.Round(Math.Pow(phi, m + 2) / Math.Sqrt(5)), 0 };
            }
        }
    }
}
