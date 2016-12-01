﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    class Program
    {
        public const int NORTH = 0;
        public const int EAST = 1;
        public const int SOUTH = 2;
        public const int WEST = 3;
        static void Main(string[] args)
        {
            var inputFile = File.ReadAllLines(Environment.CurrentDirectory + "/input.txt")[0];
            var direction = NORTH;

            int[,] matrix = new int[1000, 1000];
            var part1i = 500;
            var part1j = 500;

            int part2i = 0;
            int part2j = 0;
            
            var foundPart2 = false;

            var inputArray = inputFile.Split(new string[] { ", " }, StringSplitOptions.None);
            foreach (var input in inputArray)
            {
                var dir = input[0];
                var blocks = Convert.ToInt32(input.Substring(1, input.Length - 1));
                direction = dir == 'R' ? (direction + 1) % 4 : ((direction - 1) < 0 ? WEST : (direction - 1));

                var oldi = part1i;
                var oldj = part1j;
                switch (direction)
                {
                    case EAST:
                        part1j += blocks;
                        for (var index = oldj + 1; index <= part1j; index++)
                        {
                            matrix[part1i, index]++;
                            if (matrix[part1i, index] == 2 && !foundPart2)
                            {
                                foundPart2 = true;
                                part2i = part1i;
                                part2j = index;
                            }
                        }
                        break;
                    case SOUTH:
                        part1i += blocks;
                        for (var index = oldi + 1; index <= part1i; index++)
                        {
                            matrix[index, part1j]++;
                            if (matrix[index, part1j] == 2 && !foundPart2)
                            {
                                foundPart2 = true;
                                part2i = index;
                                part2j = part1j;
                            }
                        }
                        break;
                    case WEST:
                        part1j -= blocks;
                        for (var index = oldj - 1; index >= part1j; index--)
                        {
                            matrix[part1i, index]++;
                            if (matrix[part1i, index] == 2 && !foundPart2)
                            {
                                foundPart2 = true;
                                part2i = part1i;
                                part2j = index;
                            }
                        }
                        break;
                    case NORTH:
                        part1i -= blocks;
                        for (var index = oldi - 1; index >= part1i; index--)
                        {
                            matrix[index, part1j]++;
                            if (matrix[index, part1j] == 2 && !foundPart2)
                            {
                                foundPart2 = true;
                                part2i = index;
                                part2j = part1j;
                            }
                        }
                        break;
                }
            }
            if(!foundPart2)
            {
                part2i = part1i;
                part2j = part1j;
            }
            Console.WriteLine("Part 1: " + (Math.Abs(part1i - 500) + Math.Abs(part1j - 500)));
            Console.WriteLine("Part 2: " + (Math.Abs(part2i - 500) + Math.Abs(part2j - 500)));
            Console.ReadLine();
        }
    }
}
