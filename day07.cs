using System;
using System.IO;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    static class Day7
    {
        static Dictionary<string, bag> data = new Dictionary<string, bag>();
        static List<string> seen = new List<string>();
        static string myBag = "shiny gold";

        static void Main(string[] args)
        {
            Directory.SetCurrentDirectory(@"D:\projects\adventofcode\2020");

            var contents = System.IO.File.ReadAllLines("input/day07.data");

            foreach (var line in contents)
            {
                var s = line.Split(new string[] { " bags contain "}, StringSplitOptions.RemoveEmptyEntries);

                var b = new bag(s[0]);
                foreach(var d in s[1].Split(new string[] { " bags, ", " bags.", " bag, ", " bag." }, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (d != "no other")
                        b.contains(
                            int.Parse(d.Substring(0, d.IndexOf(' '))),
                            d.Substring(d.IndexOf(' ') + 1)
                        );
                }

                data.Add(b.name, b);
            }

            foreach (var bag in data.Values)
            {
                if (bag.name != myBag)
                    bag.gold = process(bag);
            }

            Console.WriteLine("Answer: " 
                + data.Values.Where(d => d.gold).Count());

            int count = 0;

            foreach (var bag in data[myBag].bags)
            {
                count += Count(bag);
            }

            Console.WriteLine("Answer: " + count);
        }

        static int Count(contained p)
        {
            int c = 0;
            foreach (var b in data[p.name].bags)
                c += Count(b);
            return p.count + (p.count * c);
        }

        static Boolean process(bag p)
        {
            if (p.name == myBag)
            {
                return true;
            }

            if (seen.Contains(p.name))
            {
                return p.gold;
            }

            seen.Add(p.name);

            foreach (var b in p.bags)
            {
                if (process(data[b.name]))
                {
                    p.gold = true;
                }
            }

            return p.gold;
        }
    }

    public class bag
    {
        public string name;
        public List<contained> bags;
        public Boolean gold;

        public bag(string n)
        {
            name = n;                         
            bags = new List<contained>();
        }

        public void contains(int count, string name)
        {
            bags.Add(new contained(count, name));
        }
    }

    public class contained
    {
        public int count;
        public string name;

        public contained(int c, string n)
        {
            count = c;
            name = n;
        }
    }
}
