using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWarsSharp.Component {
    public class LinqAllAny {
        public LinqAllAny() {
            var list = new List<int> { 1,2,3,4,5,6,7,8,9,0,123,44,2,5,7,8,9,10 };

            var isListHaveElements = list.Any();
            var any = list.Any(x => x > 5);

            var all = list.All(x => x < 1000);

            { }
        }
    }
}
