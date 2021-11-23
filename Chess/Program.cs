using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Program
    {
        static int OnUpArrow(Board board)
        {
            return board.HasSelectedCell ? board.OverRowIndex-- : board.ActiveRowIndex--;
        }

        static int OnDownArrow(Board board)
        {
            return board.HasSelectedCell ? board.OverRowIndex++ : board.ActiveRowIndex++;
        }

        static int OnLeftArrow(Board board)
        {
            return board.HasSelectedCell ? board.OverColIndex-- : board.ActiveColIndex--;
        }

        static int OnRightArrow(Board board)
        {
            return board.HasSelectedCell ? board.OverColIndex++ : board.ActiveColIndex++;
        }

        static Cell OnEnter(Board board)
        {
            if (!board.HasSelectedCell)
            {
                return board.SelectedCell = board.CellList.Find(
                    e => e.RowIndex == board.OverRowIndex && e.ColIndex == board.OverColIndex
                );
            }
            else
            {
                board.OverCell.Piece = board.SelectedCell.Piece;
                board.OverCell.Piece.Touched = true;
                board.SelectedCell.Piece = null;

                board.ActiveRowIndex = board.OverRowIndex;
                board.ActiveColIndex = board.OverColIndex;

                return board.SelectedCell = null;
            }
        }

        static void OnBackspace(Board board)
        {
            board.SelectedCell = null;
        }

        static void StartListeners(Board board)
        {
            ConsoleKey key;

            do
            {
                key = Console.ReadKey().Key;

                if (key == ConsoleKey.UpArrow) OnUpArrow(board);

                if (key == ConsoleKey.DownArrow) OnDownArrow(board);

                if (key == ConsoleKey.LeftArrow) OnLeftArrow(board);

                if (key == ConsoleKey.RightArrow) OnRightArrow(board);

                if (key == ConsoleKey.Enter) OnEnter(board);

                if (key == ConsoleKey.Backspace) OnBackspace(board);

                if (!board.HasSelectedCell)
                {
                    board.OverRowIndex = board.ActiveRowIndex;
                    board.OverColIndex = board.ActiveColIndex;
                }

                board.Draw();

            } while (key != ConsoleKey.Escape);
        }

        static void Main(string[] args)
        {
            Board.DrawRules();
            StartListeners(new Board());
        }
    }
}
