using System;
using System.Linq;
using System.Collections.Generic;

namespace CodeWarsSharp.Kata {
    public partial class Kata {
        /// <summary>
        /// https://www.codewars.com/kata/5679aa472b8f57fb8c000047/train/csharp
        /// You are going to be given an array of integers. Your job is to take
        /// that array and find an index N where the sum of the integers to
        /// the left of N is equal to the sum of the integers to the right of N.
        /// If there is no index that would make this happen, return -1.
        /// </summary>
        public static int EqualSidesOfAnArray(int[] arr) {
            var sum = arr.Sum();
            var leftSide = 0;
            for (int i = 0; i < arr.Length; i++) {
                var rightSide = sum - arr[i] - leftSide;
                if (leftSide == rightSide) {
                    return i;
                }
                else {
                    leftSide += arr[i];
                }
            }
            return -1;
        }
    }
}
