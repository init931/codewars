using System;
namespace CodeWarsSharp.Algorithms {
    public class MergeSort {
        public static void MergeSortAsc(int[] A) {
            MergeSortAsc(A, 0, A.Length - 1);
        }

        private static void MergeSortAsc(int[] A, int p, int r) {
            if (p < r) {
                var q = (p + r) / 2;
                MergeSortAsc(A, p, q);
                MergeSortAsc(A, q + 1, r);
                Merge(A, p, q, r);
            }
        }

        private static void Merge(int[] A, int p, int q, int r) {
            var n1 = q - p + 1;
            var n2 = r - q;
            var L = new int[n1 + 1];
            var R = new int[n2 + 1];
            var i = 0;
            var j = 0;
            for (i = 0; i < n1; i++) {
                L[i] = A[p + i];
            }
            for (j = 0; j < n2; j++) {
                R[j] = A[q + j + 1];
            }
            L[n1] = int.MaxValue;
            R[n2] = int.MaxValue;
            i = 0;
            j = 0;
            for (int k = p; k <= r; k++) {
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





        private static void merge(int[] array_of_integers, int p, int q, int r) {
            int n1 = q - p + 1;
            int n2 = r - q;
            int i, j, k;
            var left_array = new int[n1 + 1];
            var right_array = new int[n2 + 1];

            left_array[n1] = 123456798;
            right_array[n2] = 123456798;

            for (i = 0; i < n1; i++)
                left_array[i] = array_of_integers[p + i];
            for (j = 0; j < n2; j++)
                right_array[j] = array_of_integers[q + j + 1];

            i = 0;
            j = 0;

            for (k = p; k <= r; k++) {
                if (left_array[i] <= right_array[j]) {
                    array_of_integers[k] = left_array[i];
                    i++;
                }
                else {
                    array_of_integers[k] = right_array[j];
                    j++;
                }
            }
        }

        private static void merge_sort(int[] array_of_integers, int p, int r) {
            if (p < r) {
                int q = (p + r) / 2;
                merge_sort(array_of_integers, p, q);
                merge_sort(array_of_integers, q + 1, r);
                merge(array_of_integers, p, q, r);
            }
        }
    }
}
