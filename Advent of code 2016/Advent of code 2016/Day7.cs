using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Advent_of_code_2016
{
    public static class Day7
    {
        public static void Run()
        {
            var inputs = File.ReadAllLines(Environment.CurrentDirectory + "/inputs/inputDay7.txt");
            var cPart1 = 0;
            var cPart2 = 0;
            foreach (var line in inputs)
            {
                var ot = RemoveBetween(line, '[', ']');
                var it = RemoveOutside(line, '[', ']');

                var patternPart2 = @"(.)(.)(?!\1)\2\1";
                var matchO = Regex.Match(ot, patternPart2, RegexOptions.Singleline | RegexOptions.IgnoreCase).Success;
                var matchI = !Regex.Match(it, patternPart2, RegexOptions.Singleline | RegexOptions.IgnoreCase).Success;
                if (matchO && matchI)
                {
                    cPart1++;
                }
                string patternPart1 = @"(?=((.)(?!\2).\2))";
                var matches = Regex.Matches(ot, patternPart1, RegexOptions.Singleline | RegexOptions.IgnoreCase);
                var abaGroupsOutside = Enumerable.Range(0, matches.Count).Select(x => new { Key = matches[x].Groups[1].Value, KeyM = new string(new char[] { matches[x].Groups[1].Value[1], matches[x].Groups[1].Value[0], matches[x].Groups[1].Value[1] }) });
                var exists = Enumerable.Range(0, abaGroupsOutside.Count()).Select(x => it.Contains(abaGroupsOutside.ElementAt(x).KeyM)).Contains(true);
                if (exists)
                {
                    cPart2++;
                }
            }
            Console.WriteLine(cPart1);
            Console.WriteLine(cPart2);
        }
      
        static string RemoveBetween(string s, char begin, char end)
        {
            Regex regex = new Regex(string.Format("\\{0}.*?\\{1}", begin, end));
            return regex.Replace(s, "#*");
        }
        static string RemoveOutside(string s, char begin, char end)
        {
            string pattern = @"(?<=\[)(.*?)(?=\])";
            var matches = Regex.Matches(s, pattern, RegexOptions.Singleline | RegexOptions.IgnoreCase);
            var output = "";
            foreach (Match match in matches)
            {
                output += match.Value + "#*";
            }
            return output.Substring(0, output.Length - 1);
        }
    }
}
