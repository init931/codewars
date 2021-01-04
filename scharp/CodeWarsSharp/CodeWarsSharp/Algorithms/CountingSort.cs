using System;
namespace CodeWarsSharp.Algorithms {
    public class CountingSort {
        public static int[] SortAsc(int[] A, int[] B, int k) {
            var C = new int[k + 1];
            for (int i = 0; i < C.Length; i++) {
                C[i] = 0;
            }
            for (int j = 0; j < A.Length; j++) {
                C[A[j]] = C[A[j]] + 1;
            }

            for (int i = 1; i < k + 1; i++) {
                C[i] = C[i] + C[i - 1];
            }

            for (int j = A.Length - 1; j >= 0; j--) {
                B[C[A[j]]] = A[j];
                C[A[j]] = C[A[j]] - 1;
            }

            int[] ret = new int[B.Length - 1];
            Array.ConstrainedCopy(B, 1, ret, 0, B.Length - 1);

            return ret;
        }
    }
}
