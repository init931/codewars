using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ProductivityTests {
    public static partial class Benchmark {
        public static double Stopwatch(Action action, int iterations, int warmups = 1) {
            //clean Garbage
            GC.Collect();

            //wait for the finalizer queue to empty
            GC.WaitForPendingFinalizers();

            //clean Garbage
            GC.Collect();

            //warm up
            for (int i = 0; i < warmups; i++) {
                action();
            }

            var stopwatch = new Stopwatch();
            var timings = new double[5];
            for (int i = 0; i < timings.Length; i++) {
                stopwatch.Reset();
                stopwatch.Start();
                for (int j = 0; j < iterations; j++) {
                    action();
                }
                stopwatch.Stop();
                timings[i] = stopwatch.Elapsed.TotalMilliseconds;
                Console.WriteLine($"ti {i}. {timings[i]:N4} ms");
            }
            var nmean = timings.normalizedMean();
            Console.WriteLine($"total nmean: {nmean:N4} ms");
            return nmean;
        }

        private static double normalizedMean(this ICollection<double> values) {
            if (values.Count == 0)
                return double.NaN;

            var deviations = values.deviations().ToArray();
            var meanDeviation = deviations.Sum(t => Math.Abs(t.Item2)) / values.Count;
            return deviations.Where(t => t.Item2 > 0 || Math.Abs(t.Item2) <= meanDeviation).Average(t => t.Item1);
        }

        private static IEnumerable<Tuple<double, double>> deviations(this ICollection<double> values) {
            if (values.Count == 0) {
                yield break;
            }

            var avg = values.Average();
            foreach (var d in values) {
                yield return Tuple.Create(d, avg - d);
            }
        }
    }
}
