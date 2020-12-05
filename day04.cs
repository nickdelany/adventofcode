using System;
using System.IO;
using System.Diagnostics;
using System.Linq;

namespace AdventOfCode2020
{
    static class Day4
    {
        static void Main(string[] args)
        {
            Directory.SetCurrentDirectory(@"D:\projects\adventofcode\2020");
            var stopWatch = new Stopwatch();

            stopWatch.Start();
            ShowElapsed("start", stopWatch);

            var contents = System.IO.File.ReadAllLines("input/day04.data");
            id id = new id();
            int valid = 0;

            foreach (var line in contents)
            {
                if (string.IsNullOrEmpty(line))
                {
                    if (id != null && id.isValid()) valid++;

                    id = new id();
                    continue;
                }

                foreach (var field in line.Split(' '))
                {
                    var data = field.Split(':');

                    switch (data[0])
                    {
                        case "byr":
                            id.byr = data[1].Trim();
                            break;
                        case "iyr":
                            id.iyr = data[1].Trim();
                            break;
                        case "eyr":
                            id.eyr = data[1].Trim();
                            break;
                        case "hgt":
                            id.hgt = data[1].Trim();
                            break;
                        case "hcl":
                            id.hcl = data[1].Trim();
                            break;
                        case "ecl":
                            id.ecl = data[1].Trim();
                            break;
                        case "pid":
                            id.pid = data[1].Trim();
                            break;
                        case "cid":
                            id.cid = data[1].Trim();
                            break;
                        default:
                            throw new Exception("unexpected");
                    }
                }
            }

            if (id.isValid()) valid++;

            Console.WriteLine(valid);

            ShowElapsed("finish", stopWatch);            
        }
        
        static void ShowElapsed(string what, Stopwatch sw)
        {
            Console.WriteLine($"{what}:\t{sw.ElapsedMilliseconds}");
            sw.Restart();
        }
    }

    public class id 
    {
        public string byr;
        public string iyr;
        public string eyr;
        public string hgt;
        public string hcl;
        public string ecl;
        public string pid;
        public string cid;

        public Boolean isValid()
        {
            return byr != null &&
            iyr != null && eyr != null && hgt != null && hcl != null && ecl != null && pid != null;
        }
    }
}
