using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Box
    {
        private static string rowNames = "87654321";
        private static string colNames = "ABCDEFGH";

        private static int r;
        private static int c;
        private static ChessPiece p;

        private static ConsoleColor backColor;
        private static ConsoleColor pieceColor;
        private static ConsoleColor foreColor;

        public static bool isActive = false;

        private static bool IsOOver => Board.ORow == r && Board.OCol == c;

        private static bool IsOver => Board.Row == r && Board.Col == c;

        public static bool IsActive { get => IsOver && isActive; set => isActive = value; }

        private static bool IsUnderAttack => null != p && p.MoveSet.Contains($"{r}{c}");

        private static void SetBc(ConsoleColor color)
        {
            Console.BackgroundColor = color;
        }
        private static void SetFc(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }

        public static void Draw(string bgColor, int rowIndex, int colIndex, ChessPiece piece)
        {
            r = rowIndex;
            c = colIndex;
            p = piece;

            string color = null != p ? p.Color : "B";

            backColor = bgColor == "B" ? ConsoleColor.DarkGray : ConsoleColor.Gray;
            pieceColor = color == "B" ? ConsoleColor.Black : ConsoleColor.White;
            foreColor = color == "W" ? ConsoleColor.Black : ConsoleColor.White;

            SetFc(foreColor);
            SetBc(backColor);

            SetIndicators();

            if (colIndex == 0) 
                DrawTopRow(rowNames[r].ToString());
            else 
                DrawTopRow();

            NextRow();

            if (null != p)
                DrawRow(p);
            else
                DrawRow();

            NextRow();

            if (rowIndex == 7)
                DrawBottomRow(colNames[c].ToString());
            else
                DrawBottomRow();

            SetBc(ConsoleColor.Black);
            SetFc(ConsoleColor.White);
        }

        private static void SetIndicators() {
            if (IsOver) SetBc(ConsoleColor.DarkCyan);
            if (IsOOver) SetBc(ConsoleColor.Red);
            if (IsActive) SetBc(ConsoleColor.DarkRed);
            if (IsUnderAttack) SetBc(ConsoleColor.Cyan);
        }

        private static void DrawTopRow() {
            DrawRow();
        }
        private static void DrawTopRow(string val)
        {
            SetFc(ConsoleColor.Black);
            Console.Write($@"{val}    ");
            SetFc(foreColor);
        }

        private static void DrawBottomRow()
        {
            DrawRow();
        }
        private static void DrawBottomRow(string val)
        {
            SetFc(ConsoleColor.Black);
            Console.Write($@"{val}    ");
            SetFc(foreColor);
        }

        private static void DrawRow()
        {
            Console.Write("     ");
        }
        private static void DrawRow(ChessPiece piece)
        {
            Console.Write(" ");
            SetBc(pieceColor);
            Console.Write($@" {piece.Name} ");
            SetBc(backColor);

            SetIndicators();

            Console.Write(" ");
        }

        private static void DrawRow(string val)
        {
            SetFc(ConsoleColor.Black);
            Console.Write(val + "    ");
            SetFc(foreColor);
        }

        private static void NextRow()
        {
            Console.SetCursorPosition(Console.CursorLeft - 5, Console.CursorTop + 1);
        }
    }
}
