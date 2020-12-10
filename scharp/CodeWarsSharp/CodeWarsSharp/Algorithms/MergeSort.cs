using System;
namespace CodeWarsSharp.Algorithms {
    public class MergeSort {
        public static void MergeSortAsc(int[] A, int p, int r) {
            if (p < r) {
                var q = (p + r) / 2;
                MergeSortAsc(A, p, q);
                MergeSortAsc(A, q + 1, r);
                Merge(A, p, q, r);
            }
        }

        public static void Merge(int[] A, int p, int q, int r) {
            var n1 = q - p;
            var n2 = r - q + 1;
            var L = new int[n1 + 1];
            var R = new int[n2 + 1];
            var i = 0;
            var j = 0;
            for (i = 0; i < n1; i++) {
                L[i] = A[p + i];
            }
            for (j = 0; j < n2; j++) {
                R[j] = A[q + j];
            }
            L[n1] = int.MaxValue;
            R[n2] = int.MaxValue;
            i = 0;
            j = 0;
            for (int k = p; k < r + 1; k++) {
                if (L[i] <= R[j]) {
                    A[k] = L[i];
                    i++;
                }
                else {
                    A[k] = R[j];
                    j++;
                }
            }
        }
    }
}
