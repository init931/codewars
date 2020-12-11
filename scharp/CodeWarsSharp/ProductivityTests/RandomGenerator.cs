using System;
using System.Collections.Generic;

namespace ProductivityTests {
    public static class RandomGenerator {
        public static int[] GetInt(int count, int min, int max) {
            var rand = new Random();
            var rtnlist = new int[count];
            for (int i = 0; i < count; i++) {
                rtnlist[i] = rand.Next(min, max);
            }
            return rtnlist;
        }
    }
}
