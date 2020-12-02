using System;
using System.Collections.Generic;

namespace CodeWarsSharp.Component {
    public class Generics {
        public Generics() {
            var t1 = new cl1<int>();
            t1.prop1 = 15;

            var t2 = new cl1<string>();
            t2.prop1 = "asds";

            var t3 = new cl2();
            t3.method1<int>();
            t3.method1<string>();
        }
    }

    class cl1<T> {
        public T prop1 { get; set; }
    }

    class cl2 {
        public void method1<T>() {
            Console.WriteLine(typeof(T));
        }
    }
}
