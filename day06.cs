using System;
using System.IO;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    static class Day6
    {
        static void Main(string[] args)
        {
            Directory.SetCurrentDirectory(@"D:\projects\adventofcode\2020");

            var contents = System.IO.File.ReadAllLines("input/day06.data");

            int[] data = new int[contents.Length];
            int ix = 0;
            Boolean [] chk = new Boolean[26];

            foreach (var line in contents)
            {
                if (String.IsNullOrEmpty(line))
                {
                    data[ix] = chk.Count(x => x);
                    ix++;
                    for (var i = 0; i < 26; i++) chk[i] = false;
                }

                foreach (var c in line)
                    chk[c - 97] = true;

            }

            data[ix] = chk.Count(x => x);
            ix++;

            Console.WriteLine("Answer: " + data.Sum());

        }

    }
}
