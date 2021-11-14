using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Board board = new Board();

            Board.DrawRules();

            ConsoleKey key;

            do
            {
                key = Console.ReadKey().Key;

                if (key == ConsoleKey.UpArrow)
                {
                    if (Box.isActive) Board.ORow--;
                    else Board.Row--;
                }

                if (key == ConsoleKey.DownArrow)
                {
                    if (Box.isActive) Board.ORow++;
                    else Board.Row++;
                }

                if (key == ConsoleKey.LeftArrow)
                {
                    if (Box.isActive) Board.OCol--;
                    else Board.Col--;
                }

                if (key == ConsoleKey.RightArrow)
                {
                    if (Box.isActive) Board.OCol++;
                    else Board.Col++;
                }

                if (key == ConsoleKey.Enter)
                {
                    if (false == Box.isActive) Box.IsActive = true;
                    else 
                    {
                        board.OverCell.Piece = board.ActiveCell.Piece;

                        board.ActiveCell.Piece = null;

                        Box.IsActive = false;
                        Board.Row = Board.ORow;
                        Board.Col = Board.OCol;
                    }
                }

                if (key == ConsoleKey.Backspace)
                {
                    Box.IsActive = false;
                }

                if (!Box.isActive)
                {
                    Board.ORow = Board.Row;
                    Board.OCol = Board.Col;
                }

                board.Draw();

            } while (key != ConsoleKey.Escape);
        }
    }
}
