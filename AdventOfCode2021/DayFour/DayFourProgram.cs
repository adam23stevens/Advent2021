using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2021.DayFour
{
    public static class DayFourProgram
    {
        public static string GetPart1Answer()
        {
            string retAnswer = string.Empty;

            var numbers = FileReader.GetNumbers();

            var boards = FileReader.GetBingoBoards();

            foreach (var number in numbers)
            {
                foreach (var board in boards)
                {
                    StampNumbers(board, number);

                    if (board.BingoColumns.FirstOrDefault(c => c.IsComplete) != null || board.BingoRows.FirstOrDefault(r => r.IsComplete) != null)
                    {
                        int boardScore = 0;
                        board.BingoColumns.ForEach(col =>
                        {
                            boardScore += col.BingoSquares.Where(s => !s.IsMarked).Sum(s => s.SquareNumber);
                        });

                        var answer = boardScore * number;

                        retAnswer = answer.ToString();
                        return retAnswer;
                    }
                }
            }


            return retAnswer;
        }

        public static string GetPart2Answer()
        {
            string retAnswer = string.Empty;

            var numbers = FileReader.GetNumbers();

            var boards = FileReader.GetBingoBoards();

            foreach (var number in numbers)
            {
                foreach (var board in boards.Where(b => !b.BingoColumns.Any(b => b.IsComplete) && !b.BingoRows.Any(b => b.IsComplete)))
                {
                    StampNumbers(board, number);

                    int boardScore = 0;
                    board.BingoColumns.ForEach(col =>
                    {
                        boardScore += col.BingoSquares.Where(s => !s.IsMarked).Sum(s => s.SquareNumber);
                    });

                    var answer = boardScore * number;

                    retAnswer = answer.ToString();
                }
            }

            return retAnswer;
        }

        private static void StampNumbers(BingoBoard board, int number)
        {
            foreach (var boardRow in board.BingoRows)
            {
                boardRow.BingoSquares.ForEach(s =>
                {
                    if (s.SquareNumber == number)
                    {
                        s.IsMarked = true;
                    }
                });
            }
            foreach (var boardCol in board.BingoColumns)
            {
                boardCol.BingoSquares.ForEach(s =>
                {
                    if (s.SquareNumber == number)
                    {
                        s.IsMarked = true;
                    }
                });
            }
        }
    }
}
