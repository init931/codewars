using System;
namespace CodeWarsSharp.Kata {
    public partial class Kata {
        public static long BuildAPileOfCubes(long m) {
            long n = 1;
            long sum = 0;
            for (; m > sum; n++) {
                sum += (long)Math.Pow(n, 3);
            }
            return m == sum ? n - 1 : -1;
        }
    }
}
