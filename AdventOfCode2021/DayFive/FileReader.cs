using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2021.DayFive
{
    public static class FileReader
    {
        public static List<CoordinatePair> GetCoordinatePairs()
        {
            const string filePath = @"D:\dev\Advent\2021\AdventOfCode2021\AdventOfCode2021\DayFive\Input05.txt";
            var Lines = new List<string>(System.IO.File.ReadAllLines(filePath));

            var retList = new List<CoordinatePair>();

            foreach(var line in Lines)
            {
                var newPair = new CoordinatePair();

                var pairsStr = line.Split(" -> ");
                newPair.FirstPointX = int.Parse(pairsStr[0].Split(",")[0]);
                newPair.FirstPointY = int.Parse(pairsStr[0].Split(",")[1]);
                newPair.SecondPointX = int.Parse(pairsStr[1].Split(",")[0]);
                newPair.SecondPointY = int.Parse(pairsStr[1].Split(",")[1]);

                if (newPair.FirstPointX > newPair.SecondPointX || newPair.FirstPointY > newPair.SecondPointY)
                {
                    var swapVar = newPair.FirstPointX;
                    newPair.FirstPointX = newPair.SecondPointX;
                    newPair.SecondPointX = swapVar;

                    var swapVarY = newPair.FirstPointY;
                    newPair.FirstPointY = newPair.SecondPointY;
                    newPair.SecondPointY = swapVarY;

                }

                retList.Add(newPair);
            }

            return retList;
        }
    }

    public class CoordinatePair
    {
        public int FirstPointX { get; set; }
        public int FirstPointY { get; set; }
        public int SecondPointX { get; set; }
        public int SecondPointY { get; set; }
    }
}
