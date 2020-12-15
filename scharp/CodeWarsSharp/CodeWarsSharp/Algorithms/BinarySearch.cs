using System;
namespace CodeWarsSharp.Algorithms {
    public class BinarySearch {
        public static int SearchIndex(int[] sorted, int search) {
            if (sorted.Length == 0) {
                return -1;
            }
            if (sorted.Length == 1 && sorted[0] == search) {
                return 0;
            }
            var i = sorted.Length / 2;
            while (i >= 0) {
                if (sorted[i] == search) {
                    break;
                }
                else {
                    if (i == 0) {
                        i = -1;
                    }
                    else if ((sorted.Length - i) / 2 == 0) {
                        i = 0;
                    }
                    else if (sorted[i] < search) {
                        i = i + (sorted.Length - i) / 2;
                    }
                    else {
                        i = i - (sorted.Length - i) / 2;
                    }
                }
            }
            return i;
        }
    }
}
