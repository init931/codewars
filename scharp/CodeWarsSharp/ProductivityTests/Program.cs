using System;
using System.Threading;

namespace ProductivityTests {
    class Program {
        static void Main(string[] args) {
            //замеры скорости выполнения разных кусков кода
            //замеры по использовании памяти и процессора
            
            var ms = Benchmark.Stopwatch(() => { Thread.Sleep(10); }, 100);
            
        }
    }
}