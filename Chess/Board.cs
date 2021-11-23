using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Board
    {
        private int activeRowIndex = 7;
        private int activeColIndex = 0;

        private int overRowIndex = 7;
        private int overColIndex = 0;

        public Cell SelectedCell { get; set; }

        public bool HasSelectedCell => null != SelectedCell;

        public int ActiveRowIndex
        {
            get => activeRowIndex;
            set => activeRowIndex = 7 - ((7 - (value % 8)) % 8);
        }

        public int ActiveColIndex
        {
            get => activeColIndex;
            set => activeColIndex = 7 - ((7 - (value % 8)) % 8);
        }


        public int OverRowIndex
        {
            get => overRowIndex;
            set => overRowIndex = 7 - ((7 - (value % 8)) % 8);
        }

        public int OverColIndex
        {
            get => overColIndex;
            set => overColIndex = 7 - ((7 - (value % 8)) % 8);
        }

        public Cell ActiveCell => CellList.Find(cell => cell.IsActive);

        public Cell OverCell => CellList.Find(cell => cell.IsOver);

        public List<Cell> CellList
        {
            get {
                List<Cell> cells = new List<Cell>();

                foreach (Cell[] row in state)
                {
                    foreach (Cell cell in row)
                    {
                        cells.Add(cell);
                    }
                }

                return cells;
            }
        }

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

        public Cell[][] state = new Cell[][] {
            new Cell[] { null, null, null, null, null, null, null, null },
            new Cell[] { null, null, null, null, null, null, null, null },
            new Cell[] { null, null, null, null, null, null, null, null },
            new Cell[] { null, null, null, null, null, null, null, null },
            new Cell[] { null, null, null, null, null, null, null, null },
            new Cell[] { null, null, null, null, null, null, null, null },
            new Cell[] { null, null, null, null, null, null, null, null },
            new Cell[] { null, null, null, null, null, null, null, null }
        };

        public Board()
        {
            Draw();
        }

        public static void Sc(int left, int top)
        {
            Console.SetCursorPosition(left, top);
        }

        public static void DrawRules()
        {
            Sc(41, 0);  Console.Write("Controls");

            Sc(41, 2);  Console.Write("Esc.............................Quit");

            Sc(41, 4);  Console.Write("Up arrow..........................Up");
            Sc(41, 5);  Console.Write("Down arrow......................Down");
            Sc(41, 6);  Console.Write("Left arrow......................Left");
            Sc(41, 7);  Console.Write("Right arrow....................Right");

            Sc(41, 9);  Console.Write("Enter...................Select piece");
            Sc(41, 10); Console.Write("Backspace................Cancel move");
        }

        public void Draw()
        {
            for (int rowIndex = 0; rowIndex < start.Length; rowIndex++)
            {
                string[] row = start[rowIndex];
                for (int colIndex = 0; colIndex < row.Length; colIndex++)
                {
                    /// Piece.Name: (R | N | B | Q | K | P) + Piecve.Color: (B | W)
                    string nameAndColor = row[colIndex];

                    Cell cell = state[rowIndex][colIndex];

                    if (null == cell)
                    {
                        cell = new Cell(rowIndex, colIndex, this);

                        cell.Piece = nameAndColor == "" ? null : new ChessPiece(nameAndColor, cell);

                        state[rowIndex][colIndex] = cell;
                    }

                    cell.Draw();
                }
            }
        }

        public Cell GetAt(int rowIndex, int colIndex)
        {
            return Cell.DoesExist(rowIndex, colIndex) ? state[rowIndex][colIndex] : null;
        }
    }
}
