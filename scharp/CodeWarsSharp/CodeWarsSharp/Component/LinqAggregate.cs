using System;
using System.Linq;
using System.Collections.Generic;

namespace CodeWarsSharp.Component {
    public class LinqAggregate {
        public LinqAggregate() {
            int[] numbers = { 1, 2, 3, 4, 5 };
            List<User> users = new List<User> {
                new User {Name="Том", Age=23},
                new User {Name="Боб", Age=27},
                new User {Name="Джон", Age=29},
                new User {Name="Элис", Age=24}
            };


            var formula1 = numbers.Aggregate((x, y) => x + y);

            var str = numbers.Select(x => x.ToString()).Aggregate((x,y) => x + y );

            //начальное значение
            var t1 = users.Aggregate(0, (seed, x) => seed + x.Age);

            { }
        }

        class User {
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
}
