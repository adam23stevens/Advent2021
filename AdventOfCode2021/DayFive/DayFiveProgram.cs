using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2021.DayFive
{
    public static class DayFiveProgram
    {
        public static string GetPart1Answer()
        {
            var coordinatePairs = FileReader.GetCoordinatePairs();
            var coordHits = CreateCoordinates(coordinatePairs, false);

            var answer = coordHits.Count(c => c.HitCount > 1);
            return answer.ToString();
        }

        public static string GetPart2Answer()
        {
            var coordinatePairs = FileReader.GetCoordinatePairs();
            var coordHits = CreateCoordinates(coordinatePairs, true);

            var answer = coordHits.Count(c => c.HitCount > 1);
            return answer.ToString();
        }

        private static List<CoordinateHit> CreateCoordinates(List<CoordinatePair> coordinatePairs, bool IsPart2)
        {
            var coordHits = new List<CoordinateHit>();

            foreach (var coordPair in coordinatePairs)
            {
                AddToCoordHits(coordHits, coordPair.FirstPointX, coordPair.FirstPointY);
                AddToCoordHits(coordHits, coordPair.SecondPointX, coordPair.SecondPointY);

                if (coordPair.FirstPointX == coordPair.SecondPointX || coordPair.FirstPointY == coordPair.SecondPointY)
                {
                    var xDiff = coordPair.SecondPointX - coordPair.FirstPointX;
                    var yDiff = coordPair.SecondPointY - coordPair.FirstPointY;

                    for (var x = coordPair.FirstPointX + 1; x < coordPair.FirstPointX + xDiff; x++)
                    {
                        AddToCoordHits(coordHits, x, coordPair.FirstPointY);
                    }
                    for (var y = coordPair.FirstPointY + 1; y < coordPair.FirstPointY + yDiff; y++)
                    {
                        AddToCoordHits(coordHits, coordPair.FirstPointX, y);
                    }
                }
                else if (IsPart2)
                {
                    //Part 2 
                    var XIsGoingUp = coordPair.FirstPointX < coordPair.SecondPointX;
                    var YIsGoingUp = coordPair.FirstPointY < coordPair.SecondPointY;

                    if (XIsGoingUp && YIsGoingUp)
                    {
                        int x = coordPair.FirstPointX + 1;
                        int y = coordPair.FirstPointY + 1;
                        for (; x < coordPair.SecondPointX || y < coordPair.SecondPointY; x++, y++)
                        {
                            AddToCoordHits(coordHits, x, y);
                        }
                    }
                    
                    if (XIsGoingUp && !YIsGoingUp)
                    {
                        int x = coordPair.FirstPointX + 1;
                        int y = coordPair.FirstPointY - 1;
                        for (; x < coordPair.SecondPointX || y > coordPair.SecondPointY; x++, y--)
                        {
                            AddToCoordHits(coordHits, x, y);
                        }
                    }

                    if (!XIsGoingUp && YIsGoingUp)
                    {
                        int x = coordPair.FirstPointX - 1;
                        int y = coordPair.FirstPointY + 1;
                        for (; x > coordPair.SecondPointX || y < coordPair.SecondPointY; x--, y++)
                        {
                            AddToCoordHits(coordHits, x, y);
                        }
                    }

                    if (!XIsGoingUp && !YIsGoingUp)
                    {
                        int x = coordPair.FirstPointX - 1;
                        int y = coordPair.FirstPointY - 1;
                        for (; x > coordPair.SecondPointX || y > coordPair.SecondPointY; x--, y--)
                        {
                            AddToCoordHits(coordHits, x, y);
                        }
                    }
                }
            }

            return coordHits;
        }

        private static void AddToCoordHits(List<CoordinateHit> hits, int x, int y)
        {
            var match = hits.FirstOrDefault(c => c.PosX == x && c.PosY == y);
            if (match != null)
            {
                hits.First(c => c.PosX == x && c.PosY == y).HitCount++;
            }
            else
            {
                hits.Add(new CoordinateHit()
                {
                    PosX = x,
                    PosY = y,
                    HitCount = 1
                });
            }
        }

        public class CoordinateHit
        {
            public int PosX { get; set; }
            public int PosY { get; set; }
            public int HitCount { get; set; }
        }
    }
}
