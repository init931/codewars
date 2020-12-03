using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWarsSharp.Component {
    public class LinqJoin {
        public LinqJoin() {
            List<Team> teams = new List<Team>() {
                new Team { Name = "Бавария", Country ="Германия" },
                new Team { Name = "Барселона", Country ="Испания" },
                new Team { Name = "Ювентус", Country ="Италия" }
            };
            List<Player> players = new List<Player>()
                        {
                new Player {Name="Месси", Team="Барселона"},
                new Player {Name="Неймар", Team="Барселона"},
                new Player {Name="Роббен", Team="Бавария"}
            };

            var join = from p in players
                       join t in teams on p.Team equals t.Name
                       select $"{p.Name} - ({t.Name})";

            var join2 = players
                .Join(
                    teams,
                    player => player.Team,
                    team => team.Name,
                    (player, team) => $"{player.Name} - {team.Name}"
                );

            var groupJoin = teams
                .GroupJoin(
                    players,
                    t => t.Name,
                    p => p.Team,
                    (t, p) => new { t = t, p = p, count = p.Count() }
                );

            var zip = players
                .Zip(teams,
                (p, t) => $"{p.Name} {t.Name}"
            );

            { }
        }

        class Player {
            public string Name { get; set; }
            public string Team { get; set; }
        }
        class Team {
            public string Name { get; set; }
            public string Country { get; set; }
        }
    }
}
