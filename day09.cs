using System;
using System.IO;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    static class Day9
    {
        static void Main(string[] args)
        {
            Directory.SetCurrentDirectory(@"D:\projects\adventofcode\2020");

            var contents = System.IO.File.ReadAllLines("input/day09.data");

            int len = 25;

            ulong [] data = new ulong[contents.Length];
            int i = 0;

            foreach (var line in contents)
            {
                data[i] = ulong.Parse(line);
                i++;
            }

            ulong [] preamble = new ulong[len];

            for (var j = len; j < data.Length; j++)
            {
                Array.Copy(data, j - len, preamble, 0, len);
                if (!Valid(data[j], preamble))
                {
                    Console.WriteLine("Answer 1: " + data[j]);
                    break;
                }
            }

            ulong target = 1930745883L;

            ulong l = 0, h = 0;
            ulong sum;

            for (i = 0; i < data.Length; i++)
            {
                sum = 0;
                l = data[i]; h = 0;

                for (int j = i; sum < target && j < data.Length; j++)
                {
                    if (data[j] < l) l = data[j];
                    if (data[j] > h) h = data[j];
                    sum += data[j];
                }                
                if (sum == target)
                    break;
            }

            Console.WriteLine($"Answer 2: {l + h}, {l}, {h}");
        }

        static bool Valid(ulong v, ulong[] slice)
        {
            for (int i = 0; i < slice.Length; i++)
                for (int j = 0; j < slice.Length; j++)
                {
                    if (i == j) continue;

                    if (slice[i] + slice[j] == v)
                    {
                        return true;
                    }
                }

            return false;
        }
    }
}
