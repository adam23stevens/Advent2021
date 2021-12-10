using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2021.DayNine
{
    public static class FileReader
    {
        public static string[] GetLines()
        {
            const string filePath = @"D:\dev\Advent\2021\AdventOfCode2021\AdventOfCode2021\DayNine\Input09.txt";
            var Lines = new List<string>(System.IO.File.ReadAllLines(filePath));

            return Lines.ToArray();
        }
    }
}
