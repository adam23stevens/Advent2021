using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2021.DayFour
{
    public static class FileReader
    {
        public static List<int> GetNumbers()
        {
            const string filePath = @"D:\dev\Advent\2021\AdventOfCode2021\AdventOfCode2021\DayFour\Input04_numbers.txt";
            var Lines = new List<string>(System.IO.File.ReadAllLines(filePath));
            var numberStrList = Lines[0].Split(',').ToList();

            var retList = new List<int>();

            foreach (var l in numberStrList)
            {
                retList.Add(int.Parse(l));
            }

            return retList;
        }

        public static List<BingoBoard> GetBingoBoards()
        {
            const string filePath = @"D:\dev\Advent\2021\AdventOfCode2021\AdventOfCode2021\DayFour\Input04_board.txt";
            var Lines = new List<string>(System.IO.File.ReadAllLines(filePath));
            var allBoardStr = new List<BoardStr>();

            var retBoards = new List<BingoBoard>();

            Lines.RemoveAll(l => l.Length <= 0);

            for (int x = 0; x < Lines.Count; x += 5)
            {
                var newBoardLine = new BoardStr();
                var readLines = Lines.Skip(x).Take(5).ToList();
                newBoardLine.BoardRowStr = readLines;
                allBoardStr.Add(newBoardLine);
            }                                 

            foreach (var boardStr in allBoardStr)
            {
                var board = new BingoBoard();
                int rowCnt = 0;

                foreach (var rowStr in boardStr.BoardRowStr)
                {
                    var rowArr = rowStr.Split(' ').ToList();
                    rowArr.RemoveAll(r => r.Length <= 0);
                     
                    foreach (var rowNumStr in rowArr)
                    {
                        int rowNum = int.Parse(rowNumStr);
                        board.BingoRows.First(r => r.RowNum == rowCnt).BingoSquares.Add(new BingoSquare { IsMarked = false, SquareNumber = rowNum });
                    }

                    for (var x = 0; x < boardStr.BoardRowStr.Count; x++)
                    {                        
                        string numStr = rowArr[x];
                        int num = int.Parse(numStr);                        
                        board.BingoColumns.First(r => r.ColumnNum == x).BingoSquares.Add(new BingoSquare { IsMarked = false, SquareNumber = num });
                    }

                    rowCnt++;
                }

                retBoards.Add(board);
            }

            return retBoards;
        }

        public class BoardStr
        {
            public List<string> BoardRowStr { get; set; }
            public List<string> BoardColStr { get; set; }
        }
            
    }
}
