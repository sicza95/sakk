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

            Console.WriteLine("Press ESC to stop");

            ConsoleKey key = Console.ReadKey().Key;

            do
            {
                while (!Console.KeyAvailable && key != ConsoleKey.Escape)
                {
                    key = Console.ReadKey().Key;
                    if (key == ConsoleKey.UpArrow)
                    {
                        Board.row--;
                        board.Draw();
                    }

                    if (key == ConsoleKey.DownArrow)
                    {
                        Board.row++;
                        board.Draw();
                    }

                    if (key == ConsoleKey.LeftArrow)
                    {
                        Board.col--;
                        board.Draw();
                    }

                    if (key == ConsoleKey.RightArrow)
                    {
                        Board.col++;
                        board.Draw();
                    }
                }
            } while (key != ConsoleKey.Escape);


            Console.ReadKey();
        }
    }
}
