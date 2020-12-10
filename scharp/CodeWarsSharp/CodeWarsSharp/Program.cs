using System;
using System.Linq;
using CodeWarsSharp.Component;
using CodeWarsSharp.Kata;
using System.Collections.Generic;

namespace CodeWarsSharp {
    class Program {
        static void Main(string[] args) {

            var t1 = new int[] { 2, 3, 6, 5, 1, 4 };
            Algorithms.SelectionSort.SortAsc(t1);

            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}