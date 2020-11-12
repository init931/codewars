using System;

namespace CodeWarsSharp.Kata {
    public partial class Kata {
        /// <summary>
        /// Implement a function, which must take in input array, containing
        /// the names of people who like an item.
        /// It must return the display text as shown in the examples:
        /// Kata.Likes(new string[0]) => "no one likes this"
        /// Kata.Likes(new string[] {"Peter"}) => "Peter likes this"
        /// Kata.Likes(new string[] {"Jacob", "Alex"}) => "Jacob and Alex like this"
        /// Kata.Likes(new string[] { "Max", "John", "Mark" }) => "Max, John and Mark like this"
        /// Kata.Likes(new string[] { "Alex", "Jacob", "Mark", "Max" }) => "Alex, Jacob and 2 others like this"
        /// For 4 or more names, the number in and 2 others simply increases.
        /// </summary>
        public static string WhoLikesIt(string[] name) {
            switch (name.Length) {
                case 0:
                    return "no one likes this";
                case 1:
                    return $"{name[0]} likes this";
                case 2:
                    return $"{name[0]} and {name[1]} like this";
                case 3:
                    return $"{name[0]}, {name[1]} and {name[2]} like this";
                default:
                    return $"{name[0]}, {name[1]} and {name.Length - 2} others like this";
            }
        }
    }
}
