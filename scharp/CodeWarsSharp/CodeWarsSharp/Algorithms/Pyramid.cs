using System;
namespace CodeWarsSharp.Algorithms {
    public class Pyramid {
        private static int parent(int i) {
            return ((i + 1) / 2) - 1;
        }

        private static int left(int i) {
            return ((i + 1) * 2) - 1;
        }

        private static int right(int i) {
            return (i + 1) * 2;
        }

        public static void MaxHeapify(int[] A, int aHeapSize, int i) {
            var l = left(i);
            var r = right(i);
            int largest;

            if (l < aHeapSize && A[l] > A[i]) {
                largest = l;
            }
            else {
                largest = i;
            }

            if (r < aHeapSize && A[r] > A[largest]) {
                largest = r;
            }

            if (largest != i) {
                var swap = A[i];
                A[i] = A[largest];
                A[largest] = swap;
                MaxHeapify(A, aHeapSize, largest);
            }
        }

        public static void BuildMaxHeap(int[] A) {
            var heapSizeA = A.Length;
            for (int i = A.Length / 2; i >= 0; i--) {
                MaxHeapify(A, heapSizeA, i);
            }
        }
    }
}
