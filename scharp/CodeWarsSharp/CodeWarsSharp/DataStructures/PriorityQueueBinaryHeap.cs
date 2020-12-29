using System;

namespace CodeWarsSharp.DataStructures {
    public class PriorityQueueBinaryHeap {
        public static int HeapMaximum(int[] A) {
            return A[0];
        }

        public static int HeapExtractMax(ref int[] A) {
            var heapSize = A.Length;
            if (heapSize < 0) {
                throw new Exception("Очередь пуста");
            }
            var max = A[0];
            A[0] = A[heapSize - 1];
            heapSize = heapSize - 1;
            Array.Resize(ref A, heapSize);
            BinaryHeap.MaxHeapify(A, heapSize, 0);
            return max;
        }

        public static void HeapIncreaseKey(int[] A, int i, int key) {
            if (key < A[i]) {
                throw new Exception("Новый ключ меньше текущего");
            }
            A[i] = key;
            while (i > 0 && A[BinaryHeap.Parent(i)] < A[i]) {
                var swap = A[i];
                A[i] = A[BinaryHeap.Parent(i)];
                A[BinaryHeap.Parent(i)] = swap;
                i = BinaryHeap.Parent(i);
            }
        }

        public static void MaxHeapInsert(ref int[] A, int key) {
            var heapSize = A.Length + 1;
            Array.Resize(ref A, heapSize);
            A[heapSize - 1] = Int32.MinValue;
            HeapIncreaseKey(A, heapSize - 1, key);
        }
    }
}
