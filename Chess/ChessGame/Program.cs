using System;

namespace ChessGame
{
    class Program
    {
        static void Main(string[] args)
        {
            ChessMechanism chessgame = new ChessMechanism();
            chessgame.StartGame();
            Console.ReadLine();
        }
    }
}
