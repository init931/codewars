using System;
namespace CodeWarsSharp.Algorithms {
    public class InsertionSort {
        public static void SortAsc(int[] A) {
            for (int j = 1; j < A.Length; j++) {
                var key = A[j];
                var i = j - 1;
                while (i >= 0 && A[i] > key) {
                    A[i + 1] = A[i];
                    i--;
                }
                A[i + 1] = key;
            }
        }

        public static void SortDesc(int[] A) {
            for (int j = 1; j < A.Length; j++) {
                var key = A[j];
                var i = j - 1;
                while (i >= 0 && A[i] < key) {
                    A[i + 1] = A[i];
                    i--;
                }
                A[i + 1] = key;
            }
        }
    }
}
