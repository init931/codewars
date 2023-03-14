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

//Console.WriteLine("start");
            ArrayDiff();
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
            var func = (int[] a, int[] b) => {
                Console.WriteLine();
                Console.WriteLine($"a.count={a.Length} b.count={b.Length}");
                var ms = Benchmark.Stopwatch(() => {
                    Kata.ArrayDiff(a, b); //39ms
                }, 100000, 1000, false);
                Console.WriteLine($"ArrayDiff: {ms:N4} ms");
                var ms2 = Benchmark.Stopwatch(() => {
                    Kata.ArrayDiff_Linq(a, b); //85ms
                }, 100000, 1000, false);
                Console.WriteLine($"ArrayDiff_Linq: {ms2:N4} ms");
                var ms3 = Benchmark.Stopwatch(() => {
                    Kata.ArrayDiff_HashSet(a, b); //66ms
                }, 100000, 1000, false);
                Console.WriteLine($"ArrayDiff_HashSet: {ms3:N4} ms");
                var ms4 = Benchmark.Stopwatch(() => {
                    Kata.ArrayDiff_FindAll(a, b); //72ms
                }, 100000, 1000, false);
                Console.WriteLine($"ArrayDiff_FindAll: {ms4:N4} ms");
            };

            int[] a = new int[] { 1, 2, 2,3,4,5,2,3,4,1 }, b = new int[] { 1,4,8 };
            func(a, b);

            Random rand = new Random();
            var func_rand = (int[] a) => {
                for (int i = 0; i < a.Length; i++) {
                    a[i] = rand.Next(1, 1000);
                }
            };
            a = new int[50]; func_rand(a);
            b = new int[10]; func_rand(b);
            func(a, b);

            a = new int[50]; func_rand(a);
            b = new int[20]; func_rand(b);
            func(a, b);

            a = new int[1000]; func_rand(a);
            b = new int[50]; func_rand(b);
            func(a, b);


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