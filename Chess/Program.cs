using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            //  Chessboard Assembly:
            Chessboard chessboard = new Chessboard();
            chessboard.Fields();

            //  Importing ChessPieces from txt:
            List<ChessPiece> allChessPieces = new List<ChessPiece>();
            using (var chesspieces = new StreamReader("chesspieces.txt"))
            {
                chesspieces.ReadLine().Skip(1);
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        string[] temp = chesspieces.ReadLine().Split(';') ;
                        ChessPiece chesspiece = new ChessPiece(temp[0], temp[1], temp[2].Split());
                        allChessPieces.Add(chesspiece);
                    }
                }
            }
            for (int i = 0; i < 32; i++)
            {
                Console.WriteLine($"{allChessPieces[i].Name} {allChessPieces[i].Position} {allChessPieces[i].MoveSet}");
            }

                Console.ReadLine();
        }
    }
}
