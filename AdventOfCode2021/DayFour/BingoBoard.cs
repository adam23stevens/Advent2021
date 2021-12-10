using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2021.DayFour
{
    public class BingoBoard
    {
        public BingoBoard()
        {
            var newCols = new List<BingoColumn>()
            {
                new BingoColumn() { ColumnNum = 0 },
                new BingoColumn() {ColumnNum = 1 },
                new BingoColumn() {ColumnNum = 2 },
                new BingoColumn() {ColumnNum = 3 },
                new BingoColumn() {ColumnNum = 4 }
            };

            BingoColumns = newCols;

            var newRows = new List<BingoRow>()
            {
                new BingoRow() {RowNum = 0 },
                new BingoRow() {RowNum = 1 },
                new BingoRow() {RowNum = 2 },
                new BingoRow() {RowNum = 3 },
                new BingoRow() {RowNum = 4 }
            };

            BingoRows = newRows;
        }
        public List<BingoColumn> BingoColumns { get; set; }
        public List<BingoRow> BingoRows { get; set; }

    }

    public class BingoColumn
    {
        public BingoColumn() => BingoSquares = new List<BingoSquare>();
        public int ColumnNum { get; set; }
        public List<BingoSquare> BingoSquares { get; set; }
        public bool IsComplete => BingoSquares.All(b => b.IsMarked);
    }

    public class BingoRow
    {
        public BingoRow() => BingoSquares = new List<BingoSquare>();
        public int RowNum { get; set; }
        public List<BingoSquare> BingoSquares { get; set; }
        public bool IsComplete => BingoSquares.All(b => b.IsMarked);
    }

    public class BingoSquare
    {
        public int SquareNumber { get; set; }
        public bool IsMarked { get; set; }
    }

}
