using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2021.DayOne
{
    public static class FileReader
    {
        public static List<int> GetNumbers()
        {
            const string filePath = @"D:\dev\Advent\2021\AdventOfCode2021\AdventOfCode2021\DayOne\Input01.txt";
            var Lines = new List<string>(System.IO.File.ReadAllLines(filePath));

            var retList = new List<int>();

            foreach (var l in Lines)
            {
                retList.Add(int.Parse(l));
            }

            return retList;
        }

        public static List<int> GetNumberGroups()
        {
            var retList = new List<int>();
            var numbers = GetNumbers().ToArray();

            for(int x = 0; x < numbers.Length - 2; x++)
            {
                var newNum = numbers[x] + numbers[x + 1] + numbers[x + 2];

                retList.Add(newNum);
            }

            return retList;
        }
    }
}
