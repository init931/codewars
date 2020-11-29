using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWarsSharp.Kata {
    public partial class Kata {
        /// <summary>
        /// https://www.codewars.com/kata/5263c6999e0f40dee200059d/train/csharp
        /// </summary>
        public static List<string> GetPINs(string observed) {
            var ret = new List<string>();
            var bag = new int[observed.Length][];

            for (int i = 0; i < observed.Length; i++) {
                var num = int.Parse(observed[i].ToString());
                bag[i] = getAdjacent(num);
            }

            var round = new int[observed.Length];
            for (int i = 0; i < bag.Length; i++) {
                round[i] = bag[i][0]; //first init
            }
            var pointer = new int[bag.Length];
            for (int i = 0; i < bag.Length; i++) {
                pointer[i] = bag[i].Length; //init pointer
            }



            while(!pointer.All(x => x == 0)) {
                var pin = string.Join("", round);
                if (!ret.Contains(pin)) {
                    ret.Add(pin);
                }

                for (int i = pointer.Length - 1; i >= 0; i--) {
                    if (pointer[i] > 0) {
                        pointer[i]--;
                        round[i] = bag[i][pointer[i]];
                        break;
                    }
                    else {
                        if (i > 0) {
                            if (pointer[i - 1] == 0) {
                                continue;
                            }
                            else {
                                pointer[i - 1]--;
                                round[i - 1] = bag[i - 1][pointer[i - 1]];
                            }
                            for (int j = i; j < bag.Length; j++) {
                                pointer[j] = bag[j].Length;
                                round[j] = bag[j][0];
                            }
                            break;
                        }
                    }
                }
            }

            return ret.Select(x => x.ToString()).ToList();
        }

        public static int[] getAdjacent(int num) {
            return num switch {
                0 => new int[] { 0, 8 },
                1 => new int[] { 1, 2, 4 },
                2 => new int[] { 2, 1, 3, 5 },
                3 => new int[] { 3, 2, 6 },
                4 => new int[] { 4, 1, 5, 7 },
                5 => new int[] { 5, 2, 4, 6, 8 },
                6 => new int[] { 6, 3, 5, 9 },
                7 => new int[] { 7, 4, 8 },
                8 => new int[] { 8, 5, 7, 9, 0 },
                9 => new int[] { 9, 6, 8 },
                _ => new int[0]
            };
        }
    }
}
