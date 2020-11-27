using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWarsSharp.Kata {
    public partial class Kata {
        /// <summary>
        /// https://www.codewars.com/kata/526156943dfe7ce06200063e/train/csharp
        /// </summary>
        public static string Brainfuck(string code, string input) {
            var cells = new byte[100];
            var pointer = 0;
            var output = "";
            var inputPoiter = 0;
            var bracketStack = new List<int>();

            for (int i = 0; i < code.Length; i++) {
                var codeChar = code[i];

                switch (codeChar) {
                    case '+':
                        cells[pointer]++;
                        break;
                    case '-':
                        cells[pointer]--;
                        break;
                    case '>':
                        pointer++;
                        break;
                    case '<':
                        pointer--;
                        break;
                    case '[':
                        if (cells[pointer] == 0) {
                            while (true) {
                                var nextClose = code.IndexOf(']', i);
                                var openBracketBeforeClose = code.IndexOf('[', i + 1);
                                i = nextClose;
                                if (openBracketBeforeClose < nextClose) {
                                    i++;
                                    continue;
                                }
                                else {
                                    break;
                                }
                            }
                        }
                        else {
                            bracketStack.Add(i);
                        }
                        break;
                    case ']':
                        if (cells[pointer] != 0) {
                            i = bracketStack.Last();
                        }
                        else {
                            bracketStack.RemoveAt(bracketStack.Count - 1);
                        }
                        break;
                    case '.':
                        output += Char.ConvertFromUtf32(cells[pointer]);
                        break;
                    case ',':
                        var val = Char.ConvertToUtf32(input, inputPoiter);
                        inputPoiter++;
                        cells[pointer] = (byte)val;
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }

            return output;
        }
    }
}
