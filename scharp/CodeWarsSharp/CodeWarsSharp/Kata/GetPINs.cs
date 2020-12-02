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

        #region Linq
        public static List<string> GetPINs_Linq(string observed) {
            var result = new List<string> { "" };

            var adjacentKeys = new Dictionary<char, IEnumerable<string>>() {
                { '1', new[] { "1", "2", "4" } },
                { '2', new[] { "1", "2", "3", "5" } },
                { '3', new[] { "2", "3", "6" } },
                { '4', new[] { "1", "4", "5", "7" } },
                { '5', new[] { "2", "4", "5", "6", "8" } },
                { '6', new[] { "3", "5", "6", "9" } },
                { '7', new[] { "4", "7", "8" } },
                { '8', new[] { "5", "7", "8", "9", "0" } },
                { '9', new[] { "6", "8", "9" } },
                { '0', new[] { "8", "0" } }
            };

            foreach (var c in observed) {
                result =
                  (from r in result
                   from a in adjacentKeys[c]
                   select $"{r}{a}").ToList();
            }

            return result;
        }
        #endregion

        #region Recursion
        public static List<string> GetPINs_Recursion(string observed) {
            List<string> ans = new List<string>();
            if (observed.Length > 0) {
                List<string> remainder = GetPINs_Recursion(observed.Substring(1));
                String neighbors = GetPINs_GetNeighbors_Recursion(observed[0]);
                for (int i = 0; i < neighbors.Length; i++) {
                    String s = neighbors[i].ToString();
                    if (remainder.Count == 0) ans.Add(s);
                    else {
                        for (int j = 0; j < remainder.Count; j++) {
                            ans.Add(s + remainder[j]);
                        }
                    }
                }
            }
            return ans;
        }

        public static string GetPINs_GetNeighbors_Recursion(char n) {
            switch (n) {
                case '0': return "08";
                case '1': return "124";
                case '2': return "1235";
                case '3': return "236";
                case '4': return "1457";
                case '5': return "24568";
                case '6': return "3569";
                case '7': return "478";
                case '8': return "57890";
                case '9': return "689";
                default: return "";
            }
        }
        #endregion

        #region Cartesian grid
        public static List<string> GetPINs_Cartesian(string observed) {
            var adjacent = new Dictionary<char, List<string>>{
                {'0', new List<string> {"0", "8"}},
                {'1', new List<string> {"1", "2", "4"}},
                {'2', new List<string> {"1", "2", "3", "5"}},
                {'3', new List<string> {"2", "3", "6"}},
                {'4', new List<string> {"1", "4", "5", "7"}},
                {'5', new List<string> {"2", "4", "5", "6", "8"}},
                {'6', new List<string> {"3", "5", "6", "9"}},
                {'7', new List<string> {"4", "7", "8"}},
                {'8', new List<string> {"0" ,"5", "7", "8", "9"}},
                {'9', new List<string> {"6", "8", "9"}}
            };

            return GetPINs_CartesianN(observed.Select(c => adjacent[c]));
        }

        public static List<string> GetPINs_CartesianN(IEnumerable<List<string>> xss)
          => xss.Aggregate(new List<string>(), (acc, cur) => !acc.Any() ? cur : GetPINs_Cartesian(acc, cur));

        public static List<string> GetPINs_Cartesian(List<string> xs, List<string> ys)
          => xs.SelectMany(x => ys, (x, y) => $"{x}{y}").ToList();
        #endregion
    }
}
