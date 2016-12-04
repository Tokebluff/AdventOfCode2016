using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Advent_of_code_2016
{
    public static class Day4
    {
        public static void Run()
        {
            Console.Write("Part 1: ");
            var inputs = File.ReadAllLines(Environment.CurrentDirectory + "/inputs/inputDay4.txt");
            int idSum = 0;
            var rotatedNameList = new List<string>();

            foreach (var line in inputs)
            {
                //split string into useful information
                int[] buffer = new int[256];
                var checkSum = line.Substring(line.Length - 6).Substring(0,5);
                var id = Convert.ToInt32(line.Substring(line.Length - 10).Substring(0, 3));
                var name = line.Substring(0, line.Length - 11).Replace("-",string.Empty).ToCharArray();

                //part 1
                idSum += new string(name.GroupBy(c => c).Select(g => new { g.Key, Count = g.Count() }).OrderByDescending(x => x.Count).ThenBy(x => x.Key).Take(5).Select(x => x.Key).ToArray()).Equals(checkSum) ? id : 0;

                //part2
                for(var k = 0; k < name.Length; k++)
                {
                    for(var lol = 0; lol < id%26; lol++)
                    {
                        name[k] = name[k] == 'z' ? 'a' : (char)(name[k] + 1);  
                    }
                }
                rotatedNameList.Add(new string(name) + "====>" + id);
            }
            Console.WriteLine(idSum);
            Console.Write("Part 2: ");
            foreach (var mm in rotatedNameList.Where(x => x.Contains("northpole")))
            {
                Console.WriteLine(mm.Substring(mm.Length - 3));
            }
        }
    }
}
