using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Advent_of_code_2016
{
    public static class Day6_reddit
    {
        /*
            from user /u/keekmiks
        */
        public static void Run()
        {
            var s = Transpose(File.ReadLines(Environment.CurrentDirectory + "/inputs/inputDay6.txt")).Select(c => c.GroupBy(l => l).OrderBy(g => g.Count()).Select(g => g.Key));
            Console.WriteLine(string.Concat(s.Select(c => c.Last())));  //A
            Console.WriteLine(string.Concat(s.Select(c => c.First()))); //B
        }
        private static IEnumerable<IEnumerable<T>> Transpose<T>(IEnumerable<IEnumerable<T>> input) =>
            Enumerable.Range(0, input.First().Count()).Select(i => input.Select(l => l.ElementAt(i)));
    }
}
