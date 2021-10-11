using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    class ChessRook : ChessPiece
    {
		char name;
		char color;
		int[,] rookPositions = new int[28, 2];
		public ChessRook(char color) : base(color)
        {
			this.name = 'R';
			this.color = color;
        }
		public override string Name => this.name.ToString();
		public override string Color => this.color.ToString();
		public override bool MoveSet(int starti, int startj, int endi, int endj, Chessboard currentboard)
        {
			// vertical up positions:
			rookPositions[0, 0] = starti - 1; rookPositions[0, 1] = startj;
			rookPositions[1, 0] = starti - 2; rookPositions[1, 1] = startj;
			rookPositions[2, 0] = starti - 3; rookPositions[2, 1] = startj;
			rookPositions[3, 0] = starti - 4; rookPositions[3, 1] = startj;
			rookPositions[4, 0] = starti - 5; rookPositions[4, 1] = startj;
			rookPositions[5, 0] = starti - 6; rookPositions[5, 1] = startj;
			rookPositions[6, 0] = starti - 7; rookPositions[6, 1] = startj;
			// vertical down positions:
			rookPositions[7, 0] = starti + 1; rookPositions[7, 1] = startj;
			rookPositions[8, 0] = starti + 2; rookPositions[8, 1] = startj;
			rookPositions[9, 0] = starti + 3; rookPositions[9, 1] = startj;
			rookPositions[10, 0] = starti + 4; rookPositions[10, 1] = startj;
			rookPositions[11, 0] = starti + 5; rookPositions[11, 1] = startj;
			rookPositions[12, 0] = starti + 6; rookPositions[12, 1] = startj;
			rookPositions[13, 0] = starti + 7; rookPositions[13, 1] = startj;
			// horizontal right positions:
			rookPositions[14, 0] = starti; rookPositions[14, 1] = startj + 1;
			rookPositions[15, 0] = starti; rookPositions[15, 1] = startj + 2;
			rookPositions[16, 0] = starti; rookPositions[16, 1] = startj + 3;
			rookPositions[17, 0] = starti; rookPositions[17, 1] = startj + 4;
			rookPositions[18, 0] = starti; rookPositions[18, 1] = startj + 5;
			rookPositions[19, 0] = starti; rookPositions[19, 1] = startj + 6;
			rookPositions[20, 0] = starti; rookPositions[20, 1] = startj + 7;
			// horizontal left positions:
			rookPositions[21, 0] = starti; rookPositions[21, 1] = startj - 1;
			rookPositions[22, 0] = starti; rookPositions[22, 1] = startj - 2;
			rookPositions[23, 0] = starti; rookPositions[23, 1] = startj - 3;
			rookPositions[24, 0] = starti; rookPositions[24, 1] = startj - 4;
			rookPositions[25, 0] = starti; rookPositions[25, 1] = startj - 5;
			rookPositions[26, 0] = starti; rookPositions[26, 1] = startj - 6;
			rookPositions[27, 0] = starti; rookPositions[27, 1] = startj - 7;

			Chessboard board = currentboard;
			for (int i = 0; i < 28; i++)
			{
				if (this.Color == "W")
				{
					if (endi == rookPositions[i, 0] && endj == rookPositions[i, 1] && (board.boardFields[endi, endj].Color != "W"))
					{
						if(0 < i && i <= 6)
                        {
							for (int g = 0; g < i; g++)
							{
                                if ((board.boardFields[rookPositions[g, 0], rookPositions[g, 1]].Color != "w") && (board.boardFields[rookPositions[g, 0], rookPositions[g, 1]].Color != "b"))
                                {
                                    Console.WriteLine("The Rook can't jump over other Pieces.");
									return false;
                                }
							}
						}
						else if (7 < i && i <= 13)
                        {
							for (int g = 7; g < i; g++)
							{
								if ((board.boardFields[rookPositions[g, 0], rookPositions[g, 1]].Color != "w") && (board.boardFields[rookPositions[g, 0], rookPositions[g, 1]].Color != "b"))
								{
									Console.WriteLine("The Rook can't jump over other Pieces.");
									return false;
								}
							}
						}
						else if (14 < i && i <= 20)
						{
							for (int g = 14; g < i; g++)
							{
								if ((board.boardFields[rookPositions[g, 0], rookPositions[g, 1]].Color != "w") && (board.boardFields[rookPositions[g, 0], rookPositions[g, 1]].Color != "b"))
								{
									Console.WriteLine("The Rook can't jump over other Pieces.");
									return false;
								}
							}
						}
						else if (21 < i && i <= 27)
						{
							for (int g = 21; g < i; g++)
							{
								if ((board.boardFields[rookPositions[g, 0], rookPositions[g, 1]].Color != "w") && (board.boardFields[rookPositions[g, 0], rookPositions[g, 1]].Color != "b"))
								{
									Console.WriteLine("The Rook can't jump over other Pieces.");
									return false;
								}
							}
						}
						return true;
					}
				}
				else    //Black
				{
					if (endi == rookPositions[i, 0] && endj == rookPositions[i, 1] && (board.boardFields[endi, endj].Color != "B"))
					{
						if (0 <= i && i <= 6)
						{
							for (int g = 0; g < 7; g++)
							{
								if ((board.boardFields[rookPositions[g, 0], rookPositions[g, 1]].Color != "w") && (board.boardFields[rookPositions[g, 0], rookPositions[g, 1]].Color != "b"))
								{
									Console.WriteLine("The Rook can't jump over other Pieces.");
									return false;
								}
							}
						}
						else if (7 <= i && i <= 13)
						{
							for (int g = 7; g < 14; g++)
							{
								if ((board.boardFields[rookPositions[g, 0], rookPositions[g, 1]].Color != "w") && (board.boardFields[rookPositions[g, 0], rookPositions[g, 1]].Color != "b"))
								{
									Console.WriteLine("The Rook can't jump over other Pieces.");
									return false;
								}
							}
						}
						else if (14 <= i && i <= 20)
						{
							for (int g = 14; g < 21; g++)
							{
								if ((board.boardFields[rookPositions[g, 0], rookPositions[g, 1]].Color != "w") && (board.boardFields[rookPositions[g, 0], rookPositions[g, 1]].Color != "b"))
								{
									Console.WriteLine("The Rook can't jump over other Pieces.");
									return false;
								}
							}
						}
						else
						{
							for (int g = 21; g < 28; g++)
							{
								if ((board.boardFields[rookPositions[g, 0], rookPositions[g, 1]].Color != "w") && (board.boardFields[rookPositions[g, 0], rookPositions[g, 1]].Color != "b"))
								{
									Console.WriteLine("The Rook can't jump over other Pieces.");
									return false;
								}
							}
						}
						return true;
					}
				}
			}
			Console.WriteLine("The Rook can't step here.");
			return false;
		}





		}
}
