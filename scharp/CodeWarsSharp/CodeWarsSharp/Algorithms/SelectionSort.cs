using System;
namespace CodeWarsSharp.Algorithms {
    public class SelectionSort {
        public static void SortAsc(int[] A) {
            for (int i = 0; i < A.Length; i++) {
                var minVal_j = i;
                for (int j = i + 1; j < A.Length; j++) {
                    if (A[minVal_j] > A[j]) {
                        minVal_j = j;
                    }
                }

                var key = A[i];
                A[i] = A[minVal_j];
                A[minVal_j] = key;
            }
        }
    }
}
