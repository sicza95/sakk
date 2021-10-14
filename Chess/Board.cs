using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Board
    {
        public static int row = 7;
        public static int col = 0;

        public static string[][] template = new string[][] {
            new string[] { "W", "B", "W", "B", "W", "B", "W", "B" },
            new string[] { "B", "W", "B", "W", "B", "W", "B", "W" },
            new string[] { "W", "B", "W", "B", "W", "B", "W", "B" },
            new string[] { "B", "W", "B", "W", "B", "W", "B", "W" },
            new string[] { "W", "B", "W", "B", "W", "B", "W", "B" },
            new string[] { "B", "W", "B", "W", "B", "W", "B", "W" },
            new string[] { "W", "B", "W", "B", "W", "B", "W", "B" },
            new string[] { "B", "W", "B", "W", "B", "W", "B", "W" }
        };

        public static string[][] start = new string[][] {
            new string[] { "RB", "NB", "BB", "QB", "KB", "BB", "NB", "RB" },
            new string[] { "PB", "PB", "PB", "PB", "PB", "PB", "PB", "PB" },
            new string[] { "", "", "", "", "", "", "", "" },
            new string[] { "", "", "", "", "", "", "", "" },
            new string[] { "", "", "", "", "", "", "", "" },
            new string[] { "", "", "", "", "", "", "", "" },
            new string[] { "PW", "PW", "PW", "PW", "PW", "PW", "PW", "PW" },
            new string[] { "RW", "NW", "BW", "QW", "KW", "BW", "NW", "RW" },
        };

        public Board()
        {
            Draw();
        }

        public void Draw()
        {
            for (int rowIndex = 0; rowIndex < start.Length; rowIndex++)
            {
                string[] row = start[rowIndex];
                for (int colIndex = 0; colIndex < row.Length; colIndex++)
                {
                    string col = row[colIndex];

                    Cell cell;

                    if (col == "")
                    {
                        cell = new Cell(rowIndex, colIndex);
                    }
                    else
                    {
                        cell = new Cell(rowIndex, colIndex, new ChessPiece(col, rowIndex, colIndex, this));
                    }

                    cell.Draw(rowIndex, colIndex);
                }
            }
        }
    }
}
