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

        private static string FocusIndicator
        {
            get
            {
                return Board.row == r && Board.col == c ? "ooo" : "   ";
            }
        }
        private static string HoverIndicator
        {
            get
            {
                return null != p && p.MoveSet.Contains($"{r}{c}") ? "xxx" : "   ";
            }
        }

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

        private static void DrawTopRow() {
            Console.Write(" ");
            SetFc(ConsoleColor.Red);
            Console.Write(FocusIndicator);
            SetFc(foreColor);
            Console.Write(" ");
        }
        private static void DrawTopRow(string val)
        {
            SetFc(ConsoleColor.Black);
            Console.Write(val);
            SetFc(ConsoleColor.Red);
            Console.Write(FocusIndicator);
            SetFc(foreColor);
            Console.Write(" ");
        }

        private static void DrawBottomRow()
        {
            Console.Write(" ");
            SetFc(ConsoleColor.Red);
            Console.Write(HoverIndicator);
            SetFc(foreColor);
            Console.Write(" ");
        }
        private static void DrawBottomRow(string val)
        {
            SetFc(ConsoleColor.Black);
            Console.Write(val);
            SetFc(ConsoleColor.Red);
            Console.Write(HoverIndicator);
            SetFc(foreColor);
            Console.Write(" ");
        }

        private static void DrawRow()
        {
            Console.Write("     ");
        }
        private static void DrawRow(ChessPiece piece)
        {
            Console.Write(" ");
            Console.BackgroundColor = pieceColor;
            Console.Write(" " + piece.Name + " ");
            Console.BackgroundColor = backColor;
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
