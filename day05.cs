using System;
using System.IO;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    static class Day5
    {
        static void Main(string[] args)
        {
            Directory.SetCurrentDirectory(@"D:\projects\adventofcode\2020");

            Console.WriteLine(Row("FBFBBFFRLR") == 44);
            Console.WriteLine(Seat("FBFBBFFRLR") == 5);

            Console.WriteLine(Row("BFFFBBFRRR") == 70);
            Console.WriteLine(Seat("BFFFBBFRRR") == 7);

            Console.WriteLine(Row("FFFBBBFRRR") == 14);
            Console.WriteLine(Seat("FFFBBBFRRR") == 7);

            Console.WriteLine(Row("BBFFBBFRLL") == 102);
            Console.WriteLine(Seat("BBFFBBFRLL") == 4);

            var contents = System.IO.File.ReadAllLines("input/day05.data");
            int highest = 0, lowest = 1000;

            var data = new Boolean[1000];

            foreach (var pass in contents)
            {
                var h = SeatID(pass);
                data[h] = true;
                if (h > highest) highest = h;
                if (h < lowest) lowest = h;
            }

            for (int i = lowest + 1; i < highest; i++)
            {
                if (!data[i] && data[i-1] & data[i+1])
                {
                    Console.WriteLine("Seat: " + i);
                    break;
                }
            }

            Console.WriteLine(highest);

        }

        static int SeatID(string pass)
        {
            int row = Row(pass);
            int seat = Seat(pass);

            return (row*8)+seat;
        }

        static int Row(string pass)
        {
            int lower = 0, upper = 127;

            for (int i = 0; i < 7; i++)
            {
                var d = (upper - lower)/2;
                if (pass[i] == 'F')
                    upper = lower + d;
                else
                    lower = upper - d;
            }

            return upper;
        }

        static int Seat(string pass)
        {
            int lower = 0, upper = 7;

            for (int i = 7; i < 10; i++)
            {
                var d = (upper - lower)/2;
                if (pass[i] == 'L')
                    upper = lower + d;
                else
                    lower = upper - d;
            }

            return upper;
            // int lower = 0, upper = 7;
            // int slice = 4;

            // for (int i = 7; i < 10; i++)
            // {
            //     if (pass[i] == 'L')
            //         upper = lower + slice;
            //     else
            //     {
            //         lower = upper - slice;
            //     }

            //     slice /= 2;
            // }

            // return upper;
        }
    }
}
