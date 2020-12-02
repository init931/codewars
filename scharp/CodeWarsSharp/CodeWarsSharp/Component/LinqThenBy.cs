using System;
using System.Linq;
using System.Collections.Generic;

namespace CodeWarsSharp.Component {
    public class LinqThenBy {
        public LinqThenBy() {
            List<User> users = new List<User> {
                new User {Name="Том", Age=23, Languages = new List<string> {"английский", "немецкий" } },
                new User {Name="Том", Age=24, Languages = new List<string> {"английский", "немецкий" } },
                new User {Name="Том", Age=25, Languages = new List<string> {"английский", "немецкий" } },
                new User {Name="Боб", Age=27, Languages = new List<string> {"английский", "французский" }},
                new User {Name="Джон", Age=29, Languages = new List<string> {"английский", "испанский" }},
                new User {Name="Элис", Age=24, Languages = new List<string> {"испанский", "немецкий" }}
            };

            var ordered = users
                .OrderByDescending(x => x.Age)
                .ThenBy(x => x.Name);

            { }
        }

        class User {
            public string Name { get; set; }
            public int Age { get; set; }
            public List<string> Languages { get; set; }
            public User() {
                Languages = new List<string>();
            }
            public override string ToString() {
                return $"{Name} {Age}";
            }
        }
    }
}
