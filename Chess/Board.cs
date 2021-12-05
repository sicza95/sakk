using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Chess
{
    class Board
    {
        public List<string> history = new List<string>();

        public string Player {
            get 
            {
                if (history.Count() < 2)
                {
                    return "W";
                }

                if (history.Count() < 4)
                {
                    return "B";
                }

                return history.Last()[0].ToString() == "W" ? "B" : "W";
            }
        }

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
            new string[] { "RW", "NW", "BW", "QW", "KW", "BW", "NW", "RW" }
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
        private static void SetBc(ConsoleColor color)
        {
            Console.BackgroundColor = color;
        }
        private static void SetFc(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }

        public static void DrawRules()
        {
            Sc(41, 0);  Console.Write("Controls");

            Sc(41, 2);  Console.Write("Esc.............................Quit");
            Sc(41, 3);  Console.Write("F2..........................New game");
            Sc(41, 4);  Console.Write("F5..............................Save");
            Sc(41, 5);  Console.Write("F6..............................Load");

            Sc(41, 7);  Console.Write("Up arrow..........................Up");
            Sc(41, 8);  Console.Write("Down arrow......................Down");
            Sc(41, 9);  Console.Write("Left arrow......................Left");
            Sc(41, 10); Console.Write("Right arrow....................Right");

            Sc(41, 12); Console.Write("Enter...................Select piece");
            Sc(41, 13); Console.Write("Backspace................Cancel move");
        }

        public void DrawPlayer()
        {
            Sc(41, 15);

            if (Player == "W")
            {
                SetBc(ConsoleColor.Gray);
                Console.Write(" ");
                SetBc(ConsoleColor.Black);
                Console.Write(" ");

                Console.Write("White");
            }
            else
            {
                SetBc(ConsoleColor.DarkGray);
                Console.Write(" ");
                SetBc(ConsoleColor.Black);
                Console.Write(" ");

                Console.Write("Black");
            }

            Console.Write("'s move");
        }

        public void DrawLastMove()
        {
            Sc(41, 17);
            Console.Write(history.Last() + "          ");
        }

        public void Save()
        {
            File.WriteAllLines("./start.txt", state.Select(row => string.Join(";", row.Select(col => col.HasPiece ? $"{col.Piece.Name}{col.Piece.Color}" : ""))));
            File.WriteAllLines("./history.txt", history);
        }

        public void Load()
        {
            if (!File.Exists("./start.txt") || !File.Exists("./history.txt"))
            {
                Console.Write("No save file");

                return;
            }

            string[] saveHistory = File.ReadAllLines("./history.txt");
            history.Clear();
            history = saveHistory.ToList();

            DrawPlayer();

            string[][] saveStart = File.ReadAllLines("./start.txt").Select(row => row.Split(';')).ToArray();

            for (int rowIndex = 0; rowIndex < saveStart.Length; rowIndex++)
            {
                string[] row = saveStart[rowIndex];
                for (int colIndex = 0; colIndex < row.Length; colIndex++)
                {
                    /// Piece.Name: (R | N | B | Q | K | P) + Piece.Color: (B | W)
                    string nameAndColor = row[colIndex];

                    Cell cell = new Cell(rowIndex, colIndex, this);

                    cell.Piece = nameAndColor == "" ? null : new ChessPiece(nameAndColor, cell);

                    ChessPiece piece = cell.Piece;
                    if (null != piece) 
                    {
                        if (piece.Name == "P")
                        {
                            if (piece.Color == "W" && piece.RowIndex != 6 || piece.Color == "B" && piece.RowIndex != 1)
                            {
                                piece.Touched = true;
                            }
                        }
                        if (piece.Name == "K")
                        {
                            if (piece.Color == "W" && piece.Cell.Name != "E1" || piece.Color == "B" && piece.Cell.Name != "E8")
                            {
                                piece.Touched = true;
                            }
                        }
                    }
                    

                    state[rowIndex][colIndex] = cell;

                    cell.Draw();
                }
            }
        }

        public void New()
        {
            history.Clear();

            DrawPlayer();

            for (int rowIndex = 0; rowIndex < start.Length; rowIndex++)
            {
                string[] row = start[rowIndex];
                for (int colIndex = 0; colIndex < row.Length; colIndex++)
                {
                    /// Piece.Name: (R | N | B | Q | K | P) + Piece.Color: (B | W)
                    string nameAndColor = row[colIndex];

                    Cell cell = new Cell(rowIndex, colIndex, this);

                    cell.Piece = nameAndColor == "" ? null : new ChessPiece(nameAndColor, cell);

                    state[rowIndex][colIndex] = cell;

                    cell.Draw();
                }
            }
        }

        public void Draw()
        {
            DrawPlayer();

            for (int rowIndex = 0; rowIndex < start.Length; rowIndex++)
            {
                string[] row = start[rowIndex];
                for (int colIndex = 0; colIndex < row.Length; colIndex++)
                {
                    /// Piece.Name: (R | N | B | Q | K | P) + Piece.Color: (B | W)
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
