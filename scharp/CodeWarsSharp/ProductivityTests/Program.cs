﻿using System;
using System.Threading;
using CodeWarsSharp.Kata;

namespace ProductivityTests {
    class Program {
        static void Main(string[] args) {
            //замеры скорости выполнения разных кусков кода
            //замеры по использовании памяти и процессора

            //Benchmark.SeparateCpu на маке не работает. Можно попробовать запутить тест в докер контейнере под виндой

            var ms = Benchmark.Stopwatch(() => {
                var checkMessage = "qwewqeteFFDDF11(99)))dfgdfg";
                //Kata.DuplicateEncode(checkMessage); //38ms
                //Kata.DuplicateEncode1Line(checkMessage); //90ms
                //Kata.DuplicateEncodeUpperDistinct(checkMessage); //15ms
                //Kata.DuplicateEncodeMy_ToUpper(checkMessage); //39ms
                Kata.DuplicateEncodeMy_StringBuilderWithRemoveAndInsert(checkMessage); //55ms
            }, 10000);
        }
    }
}