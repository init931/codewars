using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWarsSharp.Kata {
    public partial class Kata {
        /// <summary>
        /// https://www.codewars.com/kata/5263c6999e0f40dee200059d/train/csharp
        /// </summary>
        public static List<string> GetPINs(string observed) {
            var ret = new HashSet<int>();
            var bag = new int[observed.Length][];

            for (int i = 0; i < observed.Length; i++) {
                var num = int.Parse(observed[i].ToString());
                bag[i] = getAdjacent(num);
            }

            var pointer = new int[bag.Length];
            for (int i = 0; i < bag.Length; i++) {
                pointer[i] = bag[i].Length; //init pointer
            }

            while(!pointer.All(x => x == 0)) {
                var pin = 0.0;
                for (int i = 0; i < bag.Length; i++) {
                    pin += bag[i][pointer[i] - 1] * Math.Pow(10, bag.Length - 1 - i);
                }
                
                if (!ret.Contains((int)pin)) {
                    ret.Add((int)pin);
                }

                var offset = pointer.Length - 1;
                pointer[offset]--;

                if (pointer.All(x => x == 0)) {
                    break;
                }

                while (pointer[offset] == 0) {
                    if (offset > 0) {
                        offset = offset - 1;
                        while (pointer[offset] == 0) {
                            offset--;
                        }
                        pointer[offset]--;
                        if (pointer[offset] == 0) {
                            continue;
                        }
                        for (int j = offset + 1; j < bag.Length; j++) {
                            pointer[j] = bag[j].Length;
                        }
                    }
                    break;
                }
            }
            
            return ret.Select(x => x.ToString($"D{observed.Length}")).ToList();
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
