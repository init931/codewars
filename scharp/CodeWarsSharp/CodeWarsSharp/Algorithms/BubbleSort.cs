using System;
namespace CodeWarsSharp.Algorithms {
    public class BubbleSort {
        public static void SortAsc(int[] A) {
            for (int i = 1; i < A.Length; i++) {
                for (int j = A.Length - 1; j >= i; j--) {
                    if (A[j] < A[j - 1]) {
                        var key = A[j];
                        A[j] = A[j - 1];
                        A[j - 1] = key;
                    }
                }
            }
        }
    }
}
