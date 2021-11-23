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

        private static int rowIndex;
        private static int colIndex;
        private static ChessPiece piece;
        private static Board board;

        private static ConsoleColor backColor;
        private static ConsoleColor pieceColor;
        private static ConsoleColor foreColor;

        private static bool IsOver => board.OverRowIndex == rowIndex && board.OverColIndex == colIndex;

        private static bool IsActive => board.ActiveRowIndex == rowIndex && board.ActiveColIndex == colIndex;

        private static bool IsUnderAttack => board.HasSelectedCell && board.SelectedCell.Piece.MoveSet.Contains($"{rowIndex}{colIndex}");

        private static void SetBc(ConsoleColor color)
        {
            Console.BackgroundColor = color;
        }
        private static void SetFc(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }

        public static void Draw(Cell cell)
        {
            rowIndex = cell.RowIndex;
            colIndex = cell.ColIndex;
            piece = cell.Piece;
            board = cell.Board;

            string color = null != piece ? piece.Color : "B";

            backColor = cell.Color == "B" ? ConsoleColor.DarkGray : ConsoleColor.Gray;
            pieceColor = color == "B" ? ConsoleColor.Black : ConsoleColor.White;
            foreColor = color == "W" ? ConsoleColor.Black : ConsoleColor.White;

            SetFc(foreColor);
            SetBc(backColor);

            SetIndicators();

            if (colIndex == 0)
                DrawTopRow(rowNames[rowIndex].ToString());
            else
                DrawTopRow();

            NextRow();

            if (null != piece)
                DrawRow(piece);
            else
                DrawRow();

            NextRow();

            if (rowIndex == 7)
                DrawBottomRow(colNames[colIndex].ToString());
            else
                DrawBottomRow();

            SetBc(ConsoleColor.Black);
            SetFc(ConsoleColor.White);
        }

        private static void SetIndicators()
        {
            if (IsActive) SetBc(ConsoleColor.DarkRed);
            if (IsUnderAttack) SetBc(ConsoleColor.Cyan);
            if (IsOver) SetBc(ConsoleColor.Red);
        }

        private static void DrawTopRow()
        {
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

        private static void NextRow()
        {
            Console.SetCursorPosition(Console.CursorLeft - 5, Console.CursorTop + 1);
        }
    }
}
