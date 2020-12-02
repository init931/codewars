using System;
using System.Linq;
using System.Collections.Generic;

namespace CodeWarsSharp.Component {
    public class LinqAggregate {
        public LinqAggregate() {
            int[] numbers = { 1, 2, 3, 4, 5 };

            var formula1 = numbers.Aggregate((x, y) => x + y);

            var str = numbers.Select(x => x.ToString()).Aggregate((x,y) => x + y );

            { }
        }
    }
}
