using System;
using System.IO;

namespace Advent_of_code_2016
{
    public static class Day2
    {
        public static void Run()
        {
            RunPart1();
            RunPart2();
        }
        static void RunPart1()
        {
            Console.Write("Part 1: ");
            var keyPad = new char[,]
                {
                        { '1', '2', '3'},
                        { '4', '5', '6'},
                        { '7', '8', '9'},
                };
            var i = 1;
            var j = 1;
            var inputs = File.ReadAllLines(Environment.CurrentDirectory + "/inputs/inputDay2.txt");
            foreach(var input in inputs)
            {
                for (var k = 0; k < input.Length ; k++)
                {
                    switch (input[k])
                    {
                        case 'U':
                            i = i == 0 ? i : i - 1;
                            break;
                        case 'D':
                            i = i == 2 ? i : i + 1;
                            break;
                        case 'L':
                            j = j == 0 ? j : j - 1;
                            break;
                        case 'R':
                            j = j == 2 ? j : j + 1;
                            break;
                    }
                }
                Console.Write(keyPad[i, j]);
            }
            Console.WriteLine();
        }
        static void RunPart2()
        {
            Console.Write("Part 2: ");
            var keyPad = new char[,]
                {
                        { '\0' , '\0' , '1' , '\0', '\0'},
                        { '\0' ,  '2' , '3' ,  '4', '\0'},
                        {  '5' ,  '6' , '7' ,  '8',  '9'},
                        { '\0' ,  'A' , 'B' ,  'C', '\0'},
                        { '\0' , '\0' , 'D' , '\0', '\0'},
                };
            var i = 2;
            var j = 0;
            var inputs = File.ReadAllLines(Environment.CurrentDirectory + "/inputs/inputDay2.txt");
            foreach (var input in inputs)
            {
                for (var k = 0; k < input.Length; k++)
                {
                    switch (input[k])
                    {
                        case 'U':
                            i = (i == 0 || keyPad[i - 1,j] == '\0') ? i : i - 1;
                            break;
                        case 'D':
                            i = (i == 4 || keyPad[i + 1, j] == '\0') ? i : i + 1;
                            break;
                        case 'L':
                            j = (j == 0 || keyPad[i, j - 1] == '\0') ? j : j - 1;
                            break;
                        case 'R':
                            j = (j == 4 || keyPad[i, j + 1] == '\0') ? j : j + 1;
                            break;
                    }
                }

                Console.Write(keyPad[i, j]);
            }
            Console.WriteLine();
        }
    }
}
