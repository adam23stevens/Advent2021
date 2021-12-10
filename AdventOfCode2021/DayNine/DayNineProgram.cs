using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2021.DayNine
{
    public static class DayNineProgram
    {
        public static string GetPart1Answer()
        {
            var answer = 0;
            var allLines = FileReader.GetLines();
            var lowestNumbers = new List<int>();

            for (int x = 0; x < allLines.Length; x++)
            {
                for (int y = 0; y < allLines[x].Length; y++)
                {
                    var thisNum = int.Parse(allLines[x][y].ToString());
                    var compareNums = GetCompareNums(x, y, allLines);

                    if (compareNums.All(c => c.num > thisNum))
                    {
                        lowestNumbers.Add(int.Parse(thisNum.ToString()));
                    }
                }
            }

            foreach (var num in lowestNumbers)
            {
                answer += num + 1;
            }

            return answer.ToString();
        }
        public static string GetPart2Answer()
        {
            var answer = 1;
            var allLines = FileReader.GetLines();
            var BasinList = new List<Basin>();
            for (var x = 0; x < allLines.Length; x++)
            {
                for (var y = 0; y < allLines[x].Length; y++)
                {
                    var thisNum = int.Parse(allLines[x][y].ToString());
                    if (thisNum == 9)
                    {
                        continue;
                    }
                    Basin thisBasin;
                    var compareNums = GetCompareNums(x, y, allLines);

                    if (BasinList.Any(b => b.IsInThisBasin(x, y)))
                    {                    
                        thisBasin = BasinList.First(b => b.Coordinates.Any(c => c.XVal == x && c.YVal == y));
                    }
                    else
                    {
                        thisBasin = new Basin(x, y);
                    }
                    
                    foreach (var compareNum in compareNums)
                    {
                        if (compareNum.num == 9)
                        {
                            continue;
                        }

                        if (!thisBasin.IsInThisBasin(compareNum.xCoord, compareNum.yCoord))
                        {                            
                            var otherBasin = BasinList.FirstOrDefault(b => b.IsInThisBasin(compareNum.xCoord, compareNum.yCoord) && b.Id != thisBasin.Id);
                            if (otherBasin != null)
                            {
                                foreach(var coord in otherBasin.Coordinates)
                                {
                                    if (!thisBasin.Coordinates.Contains(coord))
                                    {
                                        thisBasin.AddCoordinates(coord.XVal, coord.YVal);
                                    }
                                }
                                BasinList.Remove(otherBasin);
                            }
                            else
                            {
                                thisBasin.AddCoordinates(compareNum.xCoord, compareNum.yCoord);
                            }
                        }                        
                    }
                    
                    if (!BasinList.Any(B => B.Id == thisBasin.Id))
                    {
                        BasinList.Add(thisBasin);
                    }                    
                }
            }
            
            foreach (var val in BasinList.OrderByDescending(b => b.BasinValue).Take(3))
            {
                answer *= val.BasinValue;
            }

            return answer.ToString();
        }

        private enum Dir
        {
            UP, DOWN, LEFT, RIGHT
        }

        private static List<CompareNum> GetCompareNums(int x, int y, string[] allLines)
        {
            var retList = new List<CompareNum>();
            if (x > 0)
            {
                var upNum = allLines[x - 1][y];
                retList.Add(new CompareNum()
                {
                    num = int.Parse(upNum.ToString()),
                    xCoord = x - 1,
                    yCoord = y
                });
            }
            if (x < allLines.Length - 1)
            {
                var downNum = allLines[x + 1][y];
                retList.Add(new CompareNum()
                {
                    num = int.Parse(downNum.ToString()),
                    xCoord = x + 1,
                    yCoord = y
                });
            }
            if (y > 0)
            {
                var leftNum = allLines[x][y - 1];
                retList.Add(new CompareNum()
                {
                    num = int.Parse(leftNum.ToString()),
                    xCoord = x,
                    yCoord = y - 1
                });
            }
            if (y < allLines[x].Length - 1)
            {
                var rightNum = allLines[x][y + 1];
                retList.Add(new CompareNum()
                {
                    num = int.Parse(rightNum.ToString()),
                    xCoord = x,
                    yCoord = y + 1
                });
            }
            return retList;
        }
        private class CompareNum
        {
            public int num { get; set; }
            public int xCoord { get; set; }
            public int yCoord { get; set; }
        }
    }

    public class Basin
    {
        public Basin(int x, int y)
        {
            Coordinates = new List<Coordinate>() { new Coordinate() { XVal = x, YVal = y } };
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }

        public bool IsInThisBasin(int x, int y) => Coordinates.Any(c => c.XVal == x && c.YVal == y);
        public void AddCoordinates(int x, int y) => Coordinates.Add(new Coordinate { XVal = x, YVal = y });
        public List<Coordinate> Coordinates { get; set; }
        public int BasinValue => Coordinates.Count;
    }
    public class Coordinate
    {
        public int XVal { get; set; }
        public int YVal { get; set; }
    }
}
