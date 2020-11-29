using System;
using System.Text;

namespace CodeWarsSharp.Component {
    public class StringBuilder {
        public StringBuilder() {
            var sb = new System.Text.StringBuilder(10, 350);
            //sb.Capacity = 10;
            sb.Append("qqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqq");
            Console.WriteLine($"{sb.ToString()} Capasity={sb.Capacity} Length={sb.Length}");
            Console.WriteLine($"{sb[0]}");
            { }
        }
    }
}
