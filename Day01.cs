using System;
using System.IO;
using System.Diagnostics;

namespace AdventOfCode2020
{
    static class Day1
    {
        static void Main(string[] args)
        {
            Directory.SetCurrentDirectory(@"D:\projects\adventofcode\2020");
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            ShowElapsed("startup", stopWatch);

            var contents = System.IO.File.ReadAllLines("input/day1.data");
            var len = contents.Length;
            var data = new int[len];
            var i = 0;
            var ix = 0;
            
            foreach (var line in contents)
            {
                data[i] = int.Parse(line);
                i++;
            }

            ShowElapsed("read", stopWatch);

            for (i = 0; i < len && ix < 2; i++)
                for (var j = i + 1; j < len; j++)
                {
                    if (data[i] + data[j] == 2020)
                    {
                        Console.WriteLine($"Two numbers: {data[i] * data[j]}");
                        ix++;
                        ShowElapsed("two", stopWatch);            
                        break;
                    }
                    
                    for (var k = j; k < len; k++)
                        if (data[i] + data[j] + data[k] == 2020)
                        {
                            Console.WriteLine($"Three numbers: {data[i] * data[j] * data[k]}");
                            ix++;
                            ShowElapsed("three", stopWatch);            
                            break;
                        }
                }
                 ShowElapsed("finish", stopWatch);            
        }

        static void ShowElapsed(string what, Stopwatch sw)
        {
            Console.WriteLine($"{what}:\t{sw.ElapsedTicks}");
            sw.Restart();
        }
    }
}