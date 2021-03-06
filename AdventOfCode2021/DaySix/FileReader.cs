using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2021.DaySix
{
    public static class FileReader
    {
        public static List<int> GetFishNumbers()
        {
            const string filePath = @"D:\dev\Advent\2021\AdventOfCode2021\AdventOfCode2021\DaySix\Input06.txt";
            var Lines = new List<string>(System.IO.File.ReadAllLines(filePath));

            var numbLines = Lines[0].Split(",");
            var retList = new List<int>();
            foreach(var numLine in numbLines)
            {
                var num = int.Parse(numLine);
                retList.Add(num);
            }

            return retList;
        }
    }
}
