using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CodeWarsSharp.Kata;
using static System.Net.Mime.MediaTypeNames;

namespace ProductivityTests {
    class Program {
        static void Main(string[] args) {
            //замеры скорости выполнения разных кусков кода
            //замеры по использовании памяти и процессора

            //Benchmark.SeparateCpu на маке не работает. Можно попробовать запутить тест в докер контейнере под виндой

            Sort();
        }

        #region Kata
        static void DuplicateEncode() {
            var ms = Benchmark.Stopwatch(() => {
                var checkMessage = "qwewqeteFFDDF11(99)))dfgdfg";
                //Kata.DuplicateEncode(checkMessage); //38ms
                //Kata.DuplicateEncode_1Line(checkMessage); //90ms
                //Kata.DuplicateEncode_UpperDistinct(checkMessage); //15ms
                //Kata.DuplicateEncodeMy_ToUpper(checkMessage); //39ms
                //Kata.DuplicateEncodeMy_StringBuilderWithRemoveAndInsert(checkMessage); //55ms
                //Kata.DuplicateEncodeMy_WithoutStringContainChar(checkMessage); //24ms
                //Kata.DuplicateEncodeMy_WithoutStringContainChar_WithoutCounter(checkMessage); //22ms
                //Kata.DuplicateEncodeMy_WithoutStringContainChar_WithoutCounter_AndWithStringBuilder(checkMessage); //13ms
                //Kata.DuplicateEncode_PitMaster(checkMessage); //393ms
                //Kata.DuplicateEncode_Split(checkMessage); //44ms
                Kata.DuplicateEncode_Concat(checkMessage); //77ms
            }, 10000, 1000);
        }

        static void ReversedStrings() {
            var ms = Benchmark.Stopwatch(() => {
                var checkMessage = "qwewqeteFFDDF11(99)))dfgdfg";
                //Kata.ReversedStrings(checkMessage); //22ms
                //Kata.ReversedStrings_Reverse(checkMessage); //64ms
                Kata.ReversedStrings_MyReverse(checkMessage); //55ms
            }, 100000, 1000);
        }

        static void ArrayDiff() {
            var ms = Benchmark.Stopwatch(() => {
                int[] a = new int[] { 1, 2, 2,3,4,5,2,3,4,1 }, b = new int[] { 1,4,8 };
                //Kata.ArrayDiff(a, b); //72ms
                //Kata.ArrayDiff_Linq(a, b); //85ms
                //Kata.ArrayDiff_HashSet(a, b); //66ms
                Kata.ArrayDiff_FindAll(a, b); //72ms
            }, 100000, 1000);
        }

        static void GetPINs() {
            var ms = Benchmark.Stopwatch(() => {
                var a = "369";
                //Kata.GetPINs(a); //14ms
                //Kata.GetPINs_Linq(a); //6ms
                //Kata.GetPINs_Recursion(a); //2.5ms
                Kata.GetPINs_Cartesian(a); //8ms
            }, 1000, 100);
        }
        #endregion

        #region Algorithms
        [STAThread]
        static void Sort() {
            
            Benchmark.CsvGraph<int>(
                new List<Action<int[]>> {
                    CodeWarsSharp.Algorithms.InsertionSort.SortAsc,
                    CodeWarsSharp.Algorithms.SelectionSort.SortAsc,
                    CodeWarsSharp.Algorithms.MergeSort.MergeSortAsc
                },
                new List<int[]> {
                    RandomGenerator.GetInt(1000, 1, 1000000),
                    RandomGenerator.GetInt(10000, 1, 1000000),
                    RandomGenerator.GetInt(100000, 1, 1000000),
                    RandomGenerator.GetInt(1000000, 1, 1000000),
                    RandomGenerator.GetInt(10000000, 1, 1000000),
                    RandomGenerator.GetInt(100000000, 1, 1000000)
                },
                1, 0
            );
        }
        #endregion
    }
}