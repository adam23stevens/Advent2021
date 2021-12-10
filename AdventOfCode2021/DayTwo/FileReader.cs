using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2021.DayTwo
{
    public static class FileReader
    {
        public static List<string> ReadLines()
        {
            const string filePath = @"D:\dev\Advent\2021\AdventOfCode2021\AdventOfCode2021\DayTwo\Input02.txt";
            var Lines = new List<string>(System.IO.File.ReadAllLines(filePath));

            return Lines;
        }
    }    
}
