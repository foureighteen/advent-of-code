using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path ="indata.txt";

            var lines = File
                .ReadLines(path, Encoding.UTF8)
                .ToList();

            var withinBoundsCount = lines
                .Select(x => Parse(x))
                .Where(x => isWithinBounds(x.from, x.to, x.letter, x.code))
                .Count();

            var validPasswordCount = lines
                .Select(x => Parse(x))
                .Where(x => isValidPassword(x.from, x.to, x.letter, x.code))
                .Count();

            Console.WriteLine($"Within bounds: {withinBoundsCount}");
            Console.WriteLine($"Valid passwords: {validPasswordCount}");
        }

        static (int from, int to, char letter, string code) Parse(string input)
        {
            string pattern = @"(.*)-(.*) ([a-z]): (.*)";
            Match m = Regex.Match(input, pattern, RegexOptions.IgnoreCase);
            return (
                int.Parse(m.Groups.Values.ElementAt(1).Value)-1,
                int.Parse(m.Groups.Values.ElementAt(2).Value)-1,
                m.Groups.Values.ElementAt(3).Value.ToCharArray().First(),
                m.Groups.Values.ElementAt(4).Value
            );
        }

        static bool isWithinBounds(int from, int to, char letter, string code) {
            var count = code.ToCharArray().Count(x => x == letter);
            return count >= from && count <= to;
        }

        static bool isValidPassword(int from, int to, char letter, string code) {
            var letters = code.ToCharArray();
            var isFirstButNotLast = letters.ElementAt(from) == letter && letters.ElementAt(to) != letter;
            var isLastButNotFirst = letters.ElementAt(from) != letter && letters.ElementAt(to) == letter;
            return isFirstButNotLast || isLastButNotFirst;
        }
    }
}
