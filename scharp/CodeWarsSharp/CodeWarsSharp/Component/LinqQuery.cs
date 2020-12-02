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

            List<Phone> phones = new List<Phone>() {
                new Phone {Name="Lumia 630", Company="Microsoft" },
                new Phone {Name="iPhone 6", Company="Apple"},
            };

            var sel = from t in teams
                      where t.Length > 8
                      orderby t
                      select t;

            var selectByLang = from user in users
                               from lang in user.Languages
                               where lang == "немецкий"
                               select user.Name;

            var let = from t in users
                      let name = $"Mr. {t.Name}"
                      where t.Age > 25
                      orderby t.Age
                      select name;

            var twoSources = from user in users
                             from phone in phones
                             select new { User = user.Name, Phone = phone.Name };

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

        class Phone {
            public string Name { get; set; }
            public string Company { get; set; }
        }
    }
}
