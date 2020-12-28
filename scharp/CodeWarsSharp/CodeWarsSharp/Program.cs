using System;
using System.Linq;
using CodeWarsSharp.Component;
using CodeWarsSharp.Kata;
using System.Collections.Generic;

namespace CodeWarsSharp {
    class Program {
        static void Main(string[] args) {

            var t1 = new int[] { 16, 4, 10, 14, 7, 9, 3, 2, 8, 1 };
            Algorithms.HeapSort.SortAsc(t1);

            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}