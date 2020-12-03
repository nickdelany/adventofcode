using System;
using System.IO;
using System.Diagnostics;
using System.Linq;

namespace AdventOfCode2020
{
    static class Day3
    {
        static void Main(string[] args)
        {
            Directory.SetCurrentDirectory(@"D:\projects\adventofcode\2020");
            var stopWatch = new Stopwatch();

            stopWatch.Start();
            ShowElapsed("start", stopWatch);

            var contents = System.IO.File.ReadAllLines("input/day03.data");
            var len = contents.Length;
            
            int [] trees = new []{ 0,0,0,0,0};
            int [] nope  = new []{ 0,0,0,0,0};
            int [] right = new []{ 1,3,5,7,1};
            int [] down  = new []{ 1,1,1,1,2};

            ShowElapsed("read", stopWatch);

            for (var i = 0; i < 5; i++)
            {
                int x = 0, y = 0;

                while (y < len - down[i])
                {
                    y += down[i];
                    x += right[i];
                    x = x % 31;

                    if (contents[y][x] == '#')
                        trees[i]++;
                    else
                        nope[i]++;
                }
            }

            for (var i = 0; i < 5; i++)
            {
                Console.WriteLine(trees[i]);                
            }

            Console.WriteLine((long)trees[0]*trees[1]*trees[2]*trees[3]*trees[4]);

            ShowElapsed("finish", stopWatch);            
        }
        
        static void ShowElapsed(string what, Stopwatch sw)
        {
            Console.WriteLine($"{what}:\t{sw.ElapsedMilliseconds}");
            sw.Restart();
        }
    }
}