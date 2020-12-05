using System;
using System.IO;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;

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
                            id.byr = int.Parse(data[1].Trim());
                            break;
                        case "iyr":
                            id.iyr = int.Parse(data[1].Trim());
                            break;
                        case "eyr":
                            id.eyr = int.Parse(data[1].Trim());
                            break;
                        case "hgt":
                            id.hgt = new height(data[1].Trim());
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

            Console.WriteLine("Answer: " + valid);

            ShowElapsed("finish", stopWatch);            
        }
        
        static void ShowElapsed(string what, Stopwatch sw)
        {
            Console.WriteLine($"{what}:\t{sw.ElapsedMilliseconds}");
            sw.Restart();
        }
    }

    public class height
    {
        public Boolean v;

        Regex rxHgt = new Regex(@"(\d+)(cm|in)",
          RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public height(string d)
        {
            var mg = rxHgt.Matches(d);

            if (mg.Count != 1)
            {
                v = false;
                return;
            }

            var m = mg[0].Groups;
            var h = int.Parse(m[1].Value);
            if (m[2].Value == "cm")
            {
                v = (h <= 193 && h >= 150);
            }
            else
                v = (h <= 76 && h >= 59);
        }
    }

    public class id 
    {
        public int? byr;
        public int? iyr;
        public int? eyr;
        public height hgt;
        public string hcl;
        public string ecl;
        public string pid;
        public string cid;

        Regex rxHcl = new Regex(@"#[0-9a-f]{6}",
          RegexOptions.Compiled | RegexOptions.IgnoreCase);

        Regex rxPid = new Regex(@"\d{9}",
          RegexOptions.Compiled | RegexOptions.IgnoreCase);

        List<string> rxEcl = new List<string>{ "amb", "blu","brn","gry","grn","hzl","oth" };

        public Boolean isValid()
        {
            return 
                (byr != null && byr <= 2002 && byr >= 1920)
                && (iyr != null && iyr <= 2020 && iyr >= 2010) 
                && (eyr != null && eyr <= 2030 && eyr >= 2020) 
                && (hgt != null && hgt.v) 
                && (hcl != null && hcl.Length == 7 && rxHcl.IsMatch(hcl)) 
                && (ecl != null && rxEcl.Contains(ecl)) 
                && (pid != null && pid.Length == 9 && rxPid.IsMatch(pid))
                ;
        }
    }
}
