using System;
using System.Linq;
using CodeWarsSharp.Component;
using CodeWarsSharp.Kata;
using System.Collections.Generic;

namespace CodeWarsSharp {
    class Program {
        static void Main(string[] args) {

            //var t1 = new int[] { 5, 2, 4, 7, 1, 3, 2, 6 };
            var t1 = new int[] { 8, 7, 6, 5, 4, 3, 2, 1 };
            Algorithms.BubbleSort.SortAsc(t1);

            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}