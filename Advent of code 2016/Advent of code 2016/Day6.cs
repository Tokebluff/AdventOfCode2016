using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Advent_of_code_2016
{
    public static class Day6
    {
        public static void Run()
        {
            var inputs = File.ReadAllLines(Environment.CurrentDirectory + "/inputs/inputDay6.txt");
            char[] cPart1 = new char[8];
            char[] cPart2 = new char[8];

            for (var i = 0; i < 8; i++)
            {
                var list = new List<char>();
                for(var j = 0; j < inputs.Length; j++)
                {
                    list.Add(inputs[j][i]);
                }
                var k = list.GroupBy(x => x).Select(g => new { Text = g.Key, Count = g.Count() });

                cPart1[i] = k.OrderByDescending(x => x.Count).First().Text;
                cPart2[i] = k.OrderBy(x => x.Count).First().Text;
            }
            Console.WriteLine("Part 1: " + new string(cPart1));
            Console.WriteLine("Part 2: " + new string(cPart2));
        }
    }
}
