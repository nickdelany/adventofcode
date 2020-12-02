using System;
using System.IO;
using System.Diagnostics;
using System.Linq;

namespace AdventOfCode2020
{
    static class Day2
    {
        static void Main(string[] args)
        {
            Directory.SetCurrentDirectory(@"D:\projects\adventofcode\2020");
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            ShowElapsed("starting", stopWatch);

            var contents = System.IO.File.ReadAllLines("input/day2.data");
            var len = contents.Length;
            var data = new Policy[len];
            var i = 0;
            var ix = 0;
            var iy = 0;
            
            foreach (var line in contents)
            {
                var fields = line.Split(' ');
                var range = fields[0].Split('-');
                data[i] = new Policy {
                    Password = fields[2],
                    Letter = fields[1][0],
                    Lowest = int.Parse(range[0]),
                    Highest = int.Parse(range[1])
                };
                i++;
            }

            ShowElapsed("read", stopWatch);

            for (i = 0; i < len; i++)
            { 
                var policy = data[i];
                var cnt = policy.Password.Count(x => x == policy.Letter);

                if (policy.Lowest <= cnt &&  policy.Highest >= cnt)
                    ix ++;

                if (Check(policy.Password, policy.Lowest, policy.Letter)
                    ^ Check(policy.Password, policy.Highest, policy.Letter))
                    iy++;
            }

            Console.WriteLine($"{ix} valid passwords (policy one)");
            Console.WriteLine($"{iy} valid passwords (policy two)");

            ShowElapsed("finish", stopWatch);            

            Boolean Check(string pwd, int idex, char letter)
            {
                idex--;
                return idex >= 0 && idex < pwd.Length && pwd[idex] == letter;
            }

            void ShowElapsed(string what, Stopwatch sw)
            {
                Console.WriteLine($"{what}:\t{sw.ElapsedTicks}");
                sw.Restart();
            }
        }
    }

    class Policy
    {
        public int Lowest { get; set; }
        public int Highest { get; set; }
        public char Letter { get; set; }
        public string Password { get; set; }

    }
}