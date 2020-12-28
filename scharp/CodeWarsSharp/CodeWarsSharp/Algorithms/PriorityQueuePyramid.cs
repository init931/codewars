using System;
namespace CodeWarsSharp.Algorithms {
    public class PriorityQueuePyramid {
        public static int HeapMaximum(int[] A) {
            return A[0];
        }

        public static int HeapExtractMax(int[] A, int heapSize) {
            if (heapSize < 0) {
                throw new Exception("Очередь пуста");
            }
            var max = A[0];
            A[0] = A[heapSize - 1];
            heapSize = heapSize - 1;
            Pyramid.MaxHeapify(A, heapSize, 0);
            return max;
        }

        public static void HeapIncreaseKey(int[] A, int i, int key) {
            if (key < A[i]) {
                throw new Exception("Новый ключ меньше текущего");
            }
            A[i] = key;
            while (i > 0 && A[Pyramid.Parent(i)] < A[i]) {
                var swap = A[i];
                A[i] = A[Pyramid.Parent(i)];
                A[Pyramid.Parent(i)] = swap;
                i = Pyramid.Parent(i);
            }
        }

        public static void MaxHeapInsert(int[] A, int key, int heapSize) {
            heapSize = heapSize + 1;
            Array.Resize(ref A, heapSize);
            A[heapSize - 1] = Int32.MinValue;
            HeapIncreaseKey(A, heapSize - 1, key);
        }
    }
}
