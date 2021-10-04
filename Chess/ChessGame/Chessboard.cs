using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    class Chessboard
    {
		ChessPiece[,] boardFields = new ChessPiece[8,8];
		
		//	Drawing the Board.
		public void DrawBoard()
		{
            Console.WriteLine();
			int g = 2;				//indexelés segéd.
			for (int i = 0; i < 19; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine("      0    1    2    3    4    5    6    7  ");
                }
				else if (i == 18)
				{
					Console.WriteLine("      0    1    2    3    4    5    6    7  ");
				}
				else if (!(i%2==0))
                {
					for (int j = 0; j < 6; j++)
					{
						if (j == 0)
						{
							Console.Write("   ");
						}
						if (j == 5)
						{
							Console.Write("------"+"\n");
						}
						else
						{
							Console.Write("-------");
						}
					}
				}
                else
                {
					for (int j = 0; j < 8; j++)
					{
						if (j == 0)
						{
							Console.Write($" {(i - g)} ");
						}
						if (j == 7)
						{
							Console.Write($"| {boardFields[(i - g), j].Name}{boardFields[(i - g), j].Color} | {(i-g)}" + "\n");
						}
						else
						{           
							Console.Write($"| {boardFields[(i - g), j].Name}{boardFields[(i - g), j].Color} ");
						}
					}
					g += 1;
				}        
            }
        }

		// Initialization of the board
		public Chessboard()
        {
            for (int i = 0; i < 8; i++)
            {
                if (i%2==0)
                {
					for (int j = 0; j < 8; j++)
					{
						if (j%2==0)
						{
							boardFields[i, j] = new ChessPiece('w');	//White field
						}
                        else
                        {
							boardFields[i, j] = new ChessPiece('b');	//Black Field
						}				
					}
				}
                else
                {
					for (int j = 0; j < 8; j++)
					{
						if (j % 2 == 0)
						{
							boardFields[i, j] = new ChessPiece('b');    //White field
						}
						else
						{
							boardFields[i, j] = new ChessPiece('w');    //Black Field
						}
					}
				}
            }

			boardFields[0, 0] = new ChessRook('B');
			boardFields[0, 1] = new ChessKnight('B');
			boardFields[0, 2] = new ChessBishop('B');
			boardFields[0, 3] = new ChessQueen('B');
			boardFields[0, 4] = new ChessKing('B');
			boardFields[0, 5] = new ChessBishop('B');
			boardFields[0, 6] = new ChessKnight('B');
			boardFields[0, 7] = new ChessRook('B');

            for (int j = 0; j < 8; j++)
            {
				boardFields[1, j] = new ChessPawn('B');
			}

			boardFields[7, 0] = new ChessRook('W');
			boardFields[7, 1] = new ChessKnight('W');
			boardFields[7, 2] = new ChessBishop('W');
			boardFields[7, 3] = new ChessQueen('W');
			boardFields[7, 4] = new ChessKing('W');
			boardFields[7, 5] = new ChessBishop('W');
			boardFields[7, 6] = new ChessKnight('W');
			boardFields[7, 7] = new ChessRook('W');

			for (int j = 0; j < 8; j++)
			{
				boardFields[6, j] = new ChessPawn('W');
			}
		}



	}
}
