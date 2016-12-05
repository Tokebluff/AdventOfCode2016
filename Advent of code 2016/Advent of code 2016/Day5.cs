using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Advent_of_code_2016
{
    public static class Day5
    {
        public static void Run()
        {
            //Console.Write("Part 1: ");
            var input = File.ReadAllLines(Environment.CurrentDirectory + "/inputs/inputDay5.txt")[0];

            char[] cPart1 = new char[8] { '_', '_', '_', '_', '_', '_', '_', '_' };
            char[] cPart2 = new char[8] { '_', '_', '_', '_', '_', '_', '_', '_' };
            int counterPart1 = 0;
            int counterPart2 = 0;
            bool search = true;
            var index = 0;

            Console.Write("Part1: " + new string(cPart1) + "     Part2: " + new string(cPart2));
            while (search)
            {
                var hs = CalculateMD5Hash(input + index);
                if(hs.Substring(0,5).Equals("00000"))
                {
                    //part1
                    if(counterPart1 < 8)
                    {
                        cPart1[counterPart1] =  hs[5];
                        counterPart1++;
                    }
                    
                    //part 2
                    int position;
                    bool validPosition = int.TryParse(hs.Substring(5, 1), out position);
                    if(validPosition && position < 8 && cPart2[position].Equals('_'))
                    {
                        cPart2[position] = hs[6];
                        counterPart2++;
                    }
                    //display
                    Console.SetCursorPosition(0, Console.CursorTop);
                    Console.Write("Part1: " + new string(cPart1) + "     Part2: " + new string(cPart2));
                }
                if (counterPart1 == 8 && counterPart2 == 8)
                {
                    search = false;
                }
                index++;
            }
            Console.WriteLine();
            Console.WriteLine("Finished!");

        }
        public static string CalculateMD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);
            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
