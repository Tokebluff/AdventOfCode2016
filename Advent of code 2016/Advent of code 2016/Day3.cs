using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Advent_of_code_2016
{
    public static class Day3
    {
        public static void Run()
        {
            Console.Write("Part 1: ");
            RunPart(false);
            Console.Write("Part 2: ");
            RunPart(true);
        }
        static void RunPart(bool part2)
        {
            var inputs = !part2 ? File.ReadAllLines(Environment.CurrentDirectory + "/inputs/inputDay3.txt") : GetInputListPart2().ToArray();
            var c = 0;
            RegexOptions options = RegexOptions.None;
            Regex regex = new Regex("[ ]{2,}", options);
            foreach (var line in inputs)
            {
                var sides = Array.ConvertAll(regex.Replace(line.Trim(), " ").Split(' '), s => int.Parse(s));
                c = ((sides[0] + sides[1] > sides[2]) && (sides[0] + sides[2] > sides[1]) && (sides[1] + sides[2] > sides[0])) ? c + 1 : c;
            }
            Console.WriteLine(c);
        }
        static List<string> GetInputListPart2()
        {
            var inputs = File.ReadAllLines(Environment.CurrentDirectory + "/inputs/inputDay3.txt");
            List<string> newInputs = new List<string>();
            RegexOptions options = RegexOptions.None;
            Regex regex = new Regex("[ ]{2,}", options);
            for (var i = 0; i < inputs.Length; i=i+3)
            {
                var line1 = regex.Replace(inputs[i+0].Trim(), " ").Split(' ');
                var line2 = regex.Replace(inputs[i+1].Trim(), " ").Split(' ');
                var line3 = regex.Replace(inputs[i+2].Trim(), " ").Split(' ');
                newInputs.Add(line1[0] + " " + line2[0] + " " + line3[0]);
                newInputs.Add(line1[1] + " " + line2[1] + " " + line3[1]);
                newInputs.Add(line1[2] + " " + line2[2] + " " + line3[2]);
            }
            return newInputs;
        }
    }
}
