using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2021.DayEleven
{
    public static class DayElevenProgram
    {
        private static int TotalFlashCnt { get; set; }
        private static int ScanFlashCnt { get; set; }
        private static List<CoordinateRecord> flashedCnt { get; set; }
        public static string GetPart1Answer()
        {
            var allLines = FileReader.GetLines();
            var nextLines = new List<string>();

            for (int x = 0; x < 100; x++)
            {
                flashedCnt = new List<CoordinateRecord>();

                if (nextLines.Count <= 0)
                {
                    nextLines = allLines.ToList();
                }
                for (int r = 0; r < nextLines.Count; r++)
                {
                    for (int c = 0; c < nextLines[r].Length; c++)
                    {
                        nextLines = UpdateRetAt(nextLines, r, c);
                    }
                }
            }

            return TotalFlashCnt.ToString();
        }

        public static string GetPart2Answer()
        {
            var allLines = FileReader.GetLines();
            var nextLines = new List<string>();
            var answer = 0;
            int x = 0;
            for (; x < 1000000; x++)
            {
                if (answer > 0)
                {
                    break;
                }

                flashedCnt = new List<CoordinateRecord>();

                if (nextLines.Count <= 0)
                {
                    nextLines = allLines.ToList();
                }
                for (int r = 0; r < nextLines.Count; r++)
                {
                    for (int c = 0; c < nextLines[r].Length; c++)
                    {
                        
                        if (nextLines.All(n => n == "0000000000"))
                        {
                            answer = x + 1;
                        }

                        nextLines = UpdateRetAt(nextLines, r, c);
                    }
                }
            }

            return answer.ToString();
        }

        public class CoordinateRecord
        {
            public int colIndex { get; set; }
            public int rowIndex { get; set; }
        }

        private static List<string> UpdateNeighbours(List<string> currentList, int rowIndex, int colIndex)
        {
            //topleft
            if (rowIndex > 0 && colIndex > 0)
            {
                if (currentList[rowIndex - 1][colIndex - 1] != 0)
                {
                    currentList = UpdateRetAt(currentList, rowIndex - 1, colIndex - 1);
                }
            }

            //top
            if (rowIndex > 0)
            {
                if (currentList[rowIndex - 1][colIndex] != 0)
                {
                    currentList = UpdateRetAt(currentList, rowIndex - 1, colIndex);
                }
            }

            //topright
            if (rowIndex > 0 && colIndex < currentList[rowIndex].Length - 1)
            {
                if (currentList[rowIndex - 1][colIndex + 1] != 0)
                {
                    currentList = UpdateRetAt(currentList, rowIndex - 1, colIndex + 1);
                }
            }

            //left
            if (colIndex > 0)
            {
                if (currentList[rowIndex][colIndex - 1] != 0)
                {
                    currentList = UpdateRetAt(currentList, rowIndex, colIndex - 1);
                }
            }

            //right
            if (colIndex < currentList[rowIndex].Length - 1)
            {
                if (currentList[rowIndex][colIndex + 1] != 0)
                {
                    currentList = UpdateRetAt(currentList, rowIndex, colIndex + 1);
                }
            }

            //bottom left
            if (rowIndex < currentList.Count - 1 && colIndex > 0)
            {
                if (currentList[rowIndex + 1][colIndex - 1] != 0)
                {
                    currentList = UpdateRetAt(currentList, rowIndex + 1, colIndex - 1);
                }
            }

            //bottom
            if (rowIndex < currentList.Count - 1)
            {
                if (currentList[rowIndex + 1][colIndex] != 0)
                {
                    currentList = UpdateRetAt(currentList, rowIndex + 1, colIndex);
                }
            }

            //bottom right
            if (rowIndex < currentList.Count - 1 && colIndex < currentList[rowIndex].Length - 1)
            {
                if (currentList[rowIndex + 1][colIndex + 1] != 0)
                {
                    currentList = UpdateRetAt(currentList, rowIndex + 1, colIndex + 1);
                }
            }


            return currentList;
        }

        private static List<string> UpdateRetAt(List<string> currentList, int rowIndex, int colIndex)
        {
            var newNum = int.Parse(currentList[rowIndex][colIndex].ToString());
            if (newNum >= 9)
            {
                TotalFlashCnt++;

                newNum = 0;
                flashedCnt.Add(new CoordinateRecord { colIndex = colIndex, rowIndex = rowIndex });

                var thisRow = currentList[rowIndex];
                thisRow = thisRow.Remove(colIndex, 1);
                thisRow = thisRow.Insert(colIndex, newNum.ToString());
                currentList[rowIndex] = thisRow;

                currentList = UpdateNeighbours(currentList, rowIndex, colIndex);
            }
            else if (!flashedCnt.Any(f => f.colIndex == colIndex && f.rowIndex == rowIndex))
            {
                newNum++;

                var thisRow = currentList[rowIndex];
                thisRow = thisRow.Remove(colIndex, 1);
                thisRow = thisRow.Insert(colIndex, newNum.ToString());
                currentList[rowIndex] = thisRow;
            }

            return currentList;
        }
    }
}
