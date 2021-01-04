using System;
using System.Linq;
using CodeWarsSharp.Component;
using CodeWarsSharp.Kata;
using System.Collections.Generic;

namespace CodeWarsSharp {
    class Program {
        static void Main(string[] args) {

            var t1 = new int[] { 2, 5, 3, 0, 2, 3, 0, 3 };
            t1 = Algorithms.CountingSort.SortAsc(t1, new int[t1.Length + 1], t1.Max());

            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}