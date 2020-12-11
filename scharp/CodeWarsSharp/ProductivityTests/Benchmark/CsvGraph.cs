using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace ProductivityTests {
    public static partial class Benchmark {
        /// <summary>
        /// Запуск бенчмарка с разной нагрузкой и вывод ее в csv
        /// </summary>
        public static string CsvGraph<T>(List<Action<T[]>> actions, List<T[]> data,
            int iterations, int warmups = 1) {

            var filePath = Path.GetTempFileName();
            var content = new List<string>();
            var header = "dataCount";
            for (int i = 0; i < actions.Count; i++) {
                header += $",action{i}";
            }
            content.Add(header);
            Console.WriteLine(header.Replace(',', '\t'));

            for (int i = 0; i < data.Count; i++) {
                var line = data[i].Count().ToString();
                for (int j = 0; j < actions.Count; j++) {
                    var ms = Stopwatch(() => {
                        actions[j](data[i]);
                    }, iterations, warmups, false);
                    line += $",{ms}";
                }
                Console.WriteLine(line.Replace(',', '\t'));
                content.Add(line);
            }

            File.WriteAllLines(filePath, content);
            Console.WriteLine($"Csv result saved = '{filePath}'");
            return filePath;
        }
    }
}
