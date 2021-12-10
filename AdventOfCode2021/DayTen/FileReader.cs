using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2021.DayTen
{
    public static class FileReader
    {
        public static string[] GetLines()
        {
            const string filePath = @"D:\dev\Advent\2021\AdventOfCode2021\AdventOfCode2021\DayTen\Input10.txt";
            var Lines = new List<string>(System.IO.File.ReadAllLines(filePath));

            return Lines.ToArray();
        }
    }
}
