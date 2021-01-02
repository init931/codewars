using System;
namespace CodeWarsSharp.Algorithms {
    public class QuickSort {
        public static void SortAsc(int[] A, int p, int r) {
            if (p < r) {
                var q = partition(A, p, r);
                SortAsc(A, p, q - 1);
                SortAsc(A, q + 1, r);
            }
        }

        private static int partition(int[] A, int p, int r) {
            int x = A[r];
            int i = p - 1;
            for (int j = p; j < r; j++) {
                if (A[j] < x) {
                    i = i + 1;
                    var swap = A[i];
                    A[i] = A[j];
                    A[j] = swap;
                }
            }
            var swap2 = A[i + 1];
            A[i + 1] = A[r];
            A[r] = swap2;
            return i + 1;
        }
    }
}
