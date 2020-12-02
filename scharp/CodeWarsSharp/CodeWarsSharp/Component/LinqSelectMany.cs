using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWarsSharp.Component {
    public class LinqSelectMany {
        public LinqSelectMany() {
            List<User> users = new List<User> {
                new User {Name="Том", Age=23, Languages = new List<string> {"английский", "немецкий" } },
                new User {Name="Боб", Age=27, Languages = new List<string> {"английский", "французский" }},
                new User {Name="Джон", Age=29, Languages = new List<string> {"английский", "испанский" }},
                new User {Name="Элис", Age=24, Languages = new List<string> {"испанский", "немецкий" }}
            };

            var selLang = users
                .SelectMany(
                    user => user.Languages,
                    (user, lang) => new { UserParam = user, LangParam = lang }
                )
                .Where(x => x.LangParam == "немецкий")
                .Select(x => x.UserParam.Name);

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
