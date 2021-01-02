using System;
using System.Linq;
using CodeWarsSharp.Component;
using CodeWarsSharp.Kata;
using System.Collections.Generic;

namespace CodeWarsSharp {
    class Program {
        static void Main(string[] args) {

            var t1 = new int[] { 2, 8, 7, 1, 3, 5, 6, 4 };
            Algorithms.QuickSort.SortAsc(t1, 0, t1.Length - 1);

            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}