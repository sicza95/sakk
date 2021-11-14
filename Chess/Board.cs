using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Board
    {
        private static int row = 7;
        private static int col = 0;

        private static int o_row = 7;
        private static int o_col = 0;

        public static int Row
        {
            get => row;
            set
            {
                row = value;
                if (value == -1) row = 7;
                if (value == 8) row = 0;
            }
        }

        public static int Col
        {
            get => col;
            set
            {
                col = value;
                if (value == -1) col = 7;
                if (value == 8) col = 0;
            }
        }


        public static int ORow
        {
            get => o_row;
            set
            {
                o_row = value;
                if (value == -1) o_row = 7;
                if (value == 8) o_row = 0;
            }
        }

        public static int OCol
        {
            get => o_col;
            set
            {
                o_col = value;
                if (value == -1) o_col = 7;
                if (value == 8) o_col = 0;
            }
        }

        public Cell ActiveCell
        {
            get
            {
                List<Cell> cells = GetCellList();

                return cells.Find(cell => cell.IsActive);
            }
        }

        public Cell OverCell
        {
            get
            {
                List<Cell> cells = GetCellList();

                return cells.Find(cell => cell.IsOver);
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

        private List<Cell> GetCellList()
        {
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
                    string value = row[colIndex];

                    Cell cell = state[rowIndex][colIndex];

                    if (null == cell)
                    {
                        if (value == "")
                        {
                            cell = new Cell(rowIndex, colIndex);
                        }
                        else
                        {
                            cell = new Cell(rowIndex, colIndex, new ChessPiece(value, rowIndex, colIndex, this));
                        }

                        state[rowIndex][colIndex] = cell;
                    }

                    cell.Draw(rowIndex, colIndex);
                }
            }
        }
    }
}
