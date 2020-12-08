using System;
using System.IO;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    static class Day8
    {
        static void Main(string[] args)
        {
            Directory.SetCurrentDirectory(@"D:\projects\adventofcode\2020");

            var contents = System.IO.File.ReadAllLines("input/day08.data");
            instruction [] data = new instruction[contents.Length];
            int i = 0;
            foreach (var line in contents)
            {
                data[i] = new instruction(line);
                i++;
            }

            int run = 0;
            int ix = 0;
            bool loop;
            int acc;

            do
            {
                acc = 0;
                loop = false;
                i = 0;
                ix++;

                while (data[ix].op == "acc" && ix < data.Length
                    || (data[ix].op == "nop" && data[ix].arg == 0))
                    ix++;

                if (data[ix].op != "nop")
                    data[ix].op = "nop";
                else
                    data[ix].op = "jmp";

                Console.WriteLine("Run: " + run + " ix: " + ix);
                do
                {
                    var ins = data[i];
                    if (ins.run > run)
                    {
                        loop = true;
                        break;
                    }

                    ins.run++;

                    switch(ins.op)
                    {
                        case "acc":
                            acc += ins.arg;
                            i++;
                            break;
                        case "jmp":
                            i += ins.arg;
                            break;
                        case "nop":                    
                            i++;
                            break;
                    }
                }
                while (i < contents.Length);

                if (data[ix].op != "nop")
                    data[ix].op = "nop";
                else
                    data[ix].op = "jmp";

                run++;
            }
            while (loop);

            Console.WriteLine("Answer: " + acc);
        }

        public class instruction
        {
            public string op;
            public int arg;
            public int run;

            public instruction(string line)
            {
                op = line.Substring(0, 3);
                arg = int.Parse(line.Substring(4));
            }
        }
    }
}
