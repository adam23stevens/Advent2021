using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2021.DayThree
{
    public static class FileReader
    {
        public static List<string> GetNumbers()
        {
            const string filePath = @"D:\dev\Advent\2021\AdventOfCode2021\AdventOfCode2021\DayThree\Input03.txt";
            var Lines = new List<string>(System.IO.File.ReadAllLines(filePath));

            var retList = new List<string>();

            foreach (var l in Lines)
            {
                retList.Add(l);
            }

            return retList;
        }
    }
}
