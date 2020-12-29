using System;
using CodeWarsSharp.DataStructures;

namespace CodeWarsSharp.Algorithms {
    public class HeapSort {
        public static void SortAsc(int[] A) {
            var heapSizeA = A.Length;

            BinaryHeap.BuildMaxHeap(A);
            for (int i = A.Length - 1; i >= 1; i--) {
                var swap = A[0];
                A[0] = A[i];
                A[i] = swap;
                heapSizeA = heapSizeA - 1;
                BinaryHeap.MaxHeapify(A, heapSizeA, 0);
            }
        }
    }
}
