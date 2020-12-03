using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWarsSharp.Component {
    public class LinqTakeSkip {
        public LinqTakeSkip() {
            int[] numbers = { -3, -2, -1, 0, 1, 2, 3 };
            List<User> users = new List<User> {
                new User {Name="Том", Age=23, Languages = new List<string> {"английский", "немецкий" } },
                new User {Name="Боб", Age=27, Languages = new List<string> {"английский", "французский" }},
                new User {Name="Джон", Age=29, Languages = new List<string> {"английский", "испанский" }},
                new User {Name="Элис", Age=24, Languages = new List<string> {"испанский", "немецкий" }}
            };

            var take = users.Take(2);
            var skip = numbers.Skip(4);

            var takeWhile = users.TakeWhile(x => x.Age < 28);
            var skipWhile = numbers.SkipWhile(x => x < 0);

            { }
        }

        class User {
            public string Name { get; set; }
            public int Age { get; set; }
            public List<string> Languages { get; set; }
            public User() {
                Languages = new List<string>();
            }
        }
    }
}
