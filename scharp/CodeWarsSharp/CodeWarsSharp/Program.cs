using System;
using System.Linq;
using CodeWarsSharp.Component;
using CodeWarsSharp.Kata;
using System.Collections.Generic;

namespace CodeWarsSharp {
    class Program {
        static void Main(string[] args) {

            var t1 = new int[] { 0,0,0,0,0,0,0,-1, 2, 4, 5, 7, 1, 2, 3, 6, -1 };
            Algorithms.MergeSort.MergeSortAsc(t1, 0, t1.Length);

            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}