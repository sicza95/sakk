﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Chessboard board = new Chessboard();
            board.DrawBoard();

            Console.ReadLine();


        }
    }
}
