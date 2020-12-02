using System;
using System.Linq;
using System.Collections.Generic;

namespace CodeWarsSharp.Component {
    public class LinqQuery {
        public LinqQuery() {
            string[] teams = { "Бавария", "Боруссия", "Реал Мадрид", "Манчестер Сити", "ПСЖ", "Барселона" };

            List<User> users = new List<User> {
                new User {Name="Том", Age=23, Languages = new List<string> {"английский", "немецкий" } },
                new User {Name="Боб", Age=27, Languages = new List<string> {"английский", "французский" }},
                new User {Name="Джон", Age=29, Languages = new List<string> {"английский", "испанский" }},
                new User {Name="Элис", Age=24, Languages = new List<string> {"испанский", "немецкий" }}
            };

            var sel = from t in teams
                      where t.Length > 8
                      orderby t
                      select t;

            var selectByLang = from user in users
                               from lang in user.Languages
                               where lang == "немецкий"
                               select user.Name;



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
