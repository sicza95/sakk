using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    class ChessQueen : ChessPiece
    {
		char name;
		char color;
		int[,] queenPositions = new int[56, 2];
		public ChessQueen(char color) : base(color)
		{
			this.name = 'Q';
			this.color = color;
		}
		public override string Name => this.name.ToString();
		public override string Color => this.color.ToString();
		public override bool MoveSet(int starti, int startj, int endi, int endj, Chessboard currentboard)
		{
			// horizontal left positions:
			queenPositions[0, 0] = starti; queenPositions[0, 1] = startj - 1;
			queenPositions[1, 0] = starti; queenPositions[1, 1] = startj - 2;
			queenPositions[2, 0] = starti; queenPositions[2, 1] = startj - 3;
			queenPositions[3, 0] = starti; queenPositions[3, 1] = startj - 4;
			queenPositions[4, 0] = starti; queenPositions[4, 1] = startj - 5;
			queenPositions[5, 0] = starti; queenPositions[5, 1] = startj - 6;
			queenPositions[6, 0] = starti; queenPositions[6, 1] = startj - 7;
			// diagonal left up:
			queenPositions[7, 0] = starti - 1; queenPositions[7, 1] = startj - 1;
			queenPositions[8, 0] = starti - 2; queenPositions[8, 1] = startj - 2;
			queenPositions[9, 0] = starti - 3; queenPositions[9, 1] = startj - 3;
			queenPositions[10, 0] = starti - 4; queenPositions[10, 1] = startj - 4;
			queenPositions[11, 0] = starti - 5; queenPositions[11, 1] = startj - 5;
			queenPositions[12, 0] = starti - 6; queenPositions[12, 1] = startj - 6;
			queenPositions[13, 0] = starti - 7; queenPositions[13, 1] = startj - 7;
			// vertical up positions:
			queenPositions[14, 0] = starti - 1; queenPositions[14, 1] = startj;
			queenPositions[15, 0] = starti - 2; queenPositions[15, 1] = startj;
			queenPositions[16, 0] = starti - 3; queenPositions[16, 1] = startj;
			queenPositions[17, 0] = starti - 4; queenPositions[17, 1] = startj;
			queenPositions[18, 0] = starti - 5; queenPositions[18, 1] = startj;
			queenPositions[19, 0] = starti - 6; queenPositions[19, 1] = startj;
			queenPositions[20, 0] = starti - 7; queenPositions[20, 1] = startj;
			// diagonal right up:
			queenPositions[21, 0] = starti - 1; queenPositions[21, 1] = startj + 1;
			queenPositions[22, 0] = starti - 2; queenPositions[22, 1] = startj + 2;
			queenPositions[23, 0] = starti - 3; queenPositions[23, 1] = startj + 3;
			queenPositions[24, 0] = starti - 4; queenPositions[24, 1] = startj + 4;
			queenPositions[25, 0] = starti - 5; queenPositions[25, 1] = startj + 5;
			queenPositions[26, 0] = starti - 6; queenPositions[26, 1] = startj + 6;
			queenPositions[27, 0] = starti - 7; queenPositions[27, 1] = startj + 7;
			// horizontal right positions:
			queenPositions[28, 0] = starti; queenPositions[28, 1] = startj + 1;
			queenPositions[29, 0] = starti; queenPositions[29, 1] = startj + 2;
			queenPositions[30, 0] = starti; queenPositions[30, 1] = startj + 3;
			queenPositions[31, 0] = starti; queenPositions[31, 1] = startj + 4;
			queenPositions[32, 0] = starti; queenPositions[32, 1] = startj + 5;
			queenPositions[33, 0] = starti; queenPositions[33, 1] = startj + 6;
			queenPositions[34, 0] = starti; queenPositions[34, 1] = startj + 7;
			// diagonal right down:
			queenPositions[35, 0] = starti + 1; queenPositions[35, 1] = startj + 1;
			queenPositions[36, 0] = starti + 2; queenPositions[36, 1] = startj + 2;
			queenPositions[37, 0] = starti + 3; queenPositions[37, 1] = startj + 3;
			queenPositions[38, 0] = starti + 4; queenPositions[38, 1] = startj + 4;
			queenPositions[39, 0] = starti + 5; queenPositions[39, 1] = startj + 5;
			queenPositions[40, 0] = starti + 6; queenPositions[40, 1] = startj + 6;
			queenPositions[41, 0] = starti + 7; queenPositions[41, 1] = startj + 7;
			// vertical down positions:
			queenPositions[42, 0] = starti + 1; queenPositions[42, 1] = startj;
			queenPositions[43, 0] = starti + 2; queenPositions[43, 1] = startj;
			queenPositions[44, 0] = starti + 3; queenPositions[44, 1] = startj;
			queenPositions[45, 0] = starti + 4; queenPositions[45, 1] = startj;
			queenPositions[46, 0] = starti + 5; queenPositions[46, 1] = startj;
			queenPositions[47, 0] = starti + 6; queenPositions[47, 1] = startj;
			queenPositions[48, 0] = starti + 7; queenPositions[48, 1] = startj;
			// diagonal left down:
			queenPositions[49, 0] = starti + 1; queenPositions[49, 1] = startj - 1;
			queenPositions[50, 0] = starti + 2; queenPositions[50, 1] = startj - 2;
			queenPositions[51, 0] = starti + 3; queenPositions[51, 1] = startj - 3;
			queenPositions[52, 0] = starti + 4; queenPositions[52, 1] = startj - 4;
			queenPositions[53, 0] = starti + 5; queenPositions[53, 1] = startj - 5;
			queenPositions[54, 0] = starti + 6; queenPositions[54, 1] = startj - 6;
			queenPositions[55, 0] = starti + 7; queenPositions[55, 1] = startj - 7;

			Chessboard board = currentboard;
			for (int i = 0; i < 56; i++)
			{
                if (this.Color == "W")
                {
					if (endi == queenPositions[i, 0] && endj == queenPositions[i, 1] && (board.boardFields[endi, endj].Color != "W"))
					{
						if (0 < i && i <= 6)
						{
							for (int g = 0; g < i; g++)
							{
								if ((board.boardFields[queenPositions[g, 0], queenPositions[g, 1]].Color != "w") && (board.boardFields[queenPositions[g, 0], queenPositions[g, 1]].Color != "b"))
								{
									Console.WriteLine("The Queen can't jump over other Pieces.");
									return false;
								}
							}
						}
						else if (7 < i && i <= 13)
						{
							for (int g = 7; g < i; g++)
							{
								if ((board.boardFields[queenPositions[g, 0], queenPositions[g, 1]].Color != "w") && (board.boardFields[queenPositions[g, 0], queenPositions[g, 1]].Color != "b"))
								{
									Console.WriteLine("The Queen can't jump over other Pieces.");
									return false;
								}
							}
						}
						else if (14 < i && i <= 20)
						{
							for (int g = 14; g < i; g++)
							{
								if ((board.boardFields[queenPositions[g, 0], queenPositions[g, 1]].Color != "w") && (board.boardFields[queenPositions[g, 0], queenPositions[g, 1]].Color != "b"))
								{
									Console.WriteLine("The Queen can't jump over other Pieces.");
									return false;
								}
							}
						}
						else if (21 < i && i <= 27)
						{
							for (int g = 21; g < i; g++)
							{
								if ((board.boardFields[queenPositions[g, 0], queenPositions[g, 1]].Color != "w") && (board.boardFields[queenPositions[g, 0], queenPositions[g, 1]].Color != "b"))
								{
									Console.WriteLine("The Queen can't jump over other Pieces.");
									return false;
								}
							}
						}
						else if (28 < i && i <= 34)
						{
							for (int g = 28; g < i; g++)
							{
								if ((board.boardFields[queenPositions[g, 0], queenPositions[g, 1]].Color != "w") && (board.boardFields[queenPositions[g, 0], queenPositions[g, 1]].Color != "b"))
								{
									Console.WriteLine("The Queen can't jump over other Pieces.");
									return false;
								}
							}
						}
						else if (35 < i && i <= 41)
						{
							for (int g = 35; g < i; g++)
							{
								if ((board.boardFields[queenPositions[g, 0], queenPositions[g, 1]].Color != "w") && (board.boardFields[queenPositions[g, 0], queenPositions[g, 1]].Color != "b"))
								{
									Console.WriteLine("The Queen can't jump over other Pieces.");
									return false;
								}
							}
						}
						else if (42 < i && i <= 48)
						{
							for (int g = 42; g < i; g++)
							{
								if ((board.boardFields[queenPositions[g, 0], queenPositions[g, 1]].Color != "w") && (board.boardFields[queenPositions[g, 0], queenPositions[g, 1]].Color != "b"))
								{
									Console.WriteLine("The Queen can't jump over other Pieces.");
									return false;
								}
							}
						}
						else if (49 < i && i <= 55)
						{
							for (int g = 49; g < i; g++)
							{
								if ((board.boardFields[queenPositions[g, 0], queenPositions[g, 1]].Color != "w") && (board.boardFields[queenPositions[g, 0], queenPositions[g, 1]].Color != "b"))
								{
									Console.WriteLine("The Queen can't jump over other Pieces.");
									return false;
								}
							}
						}
						return true;
					}
				}
                else
                {
					if (endi == queenPositions[i, 0] && endj == queenPositions[i, 1] && (board.boardFields[endi, endj].Color != "B"))
					{
						if (0 < i && i <= 6)
						{
							for (int g = 0; g < i; g++)
							{
								if ((board.boardFields[queenPositions[g, 0], queenPositions[g, 1]].Color != "w") && (board.boardFields[queenPositions[g, 0], queenPositions[g, 1]].Color != "b"))
								{
									Console.WriteLine("The Queen can't jump over other Pieces.");
									return false;
								}
							}
						}
						else if (7 < i && i <= 13)
						{
							for (int g = 7; g < i; g++)
							{
								if ((board.boardFields[queenPositions[g, 0], queenPositions[g, 1]].Color != "w") && (board.boardFields[queenPositions[g, 0], queenPositions[g, 1]].Color != "b"))
								{
									Console.WriteLine("The Queen can't jump over other Pieces.");
									return false;
								}
							}
						}
						else if (14 < i && i <= 20)
						{
							for (int g = 14; g < i; g++)
							{
								if ((board.boardFields[queenPositions[g, 0], queenPositions[g, 1]].Color != "w") && (board.boardFields[queenPositions[g, 0], queenPositions[g, 1]].Color != "b"))
								{
									Console.WriteLine("The Queen can't jump over other Pieces.");
									return false;
								}
							}
						}
						else if (21 < i && i <= 27)
						{
							for (int g = 21; g < i; g++)
							{
								if ((board.boardFields[queenPositions[g, 0], queenPositions[g, 1]].Color != "w") && (board.boardFields[queenPositions[g, 0], queenPositions[g, 1]].Color != "b"))
								{
									Console.WriteLine("The Queen can't jump over other Pieces.");
									return false;
								}
							}
						}
						else if (28 < i && i <= 34)
						{
							for (int g = 28; g < i; g++)
							{
								if ((board.boardFields[queenPositions[g, 0], queenPositions[g, 1]].Color != "w") && (board.boardFields[queenPositions[g, 0], queenPositions[g, 1]].Color != "b"))
								{
									Console.WriteLine("The Queen can't jump over other Pieces.");
									return false;
								}
							}
						}
						else if (35 < i && i <= 41)
						{
							for (int g = 35; g < i; g++)
							{
								if ((board.boardFields[queenPositions[g, 0], queenPositions[g, 1]].Color != "w") && (board.boardFields[queenPositions[g, 0], queenPositions[g, 1]].Color != "b"))
								{
									Console.WriteLine("The Queen can't jump over other Pieces.");
									return false;
								}
							}
						}
						else if (42 < i && i <= 48)
						{
							for (int g = 42; g < i; g++)
							{
								if ((board.boardFields[queenPositions[g, 0], queenPositions[g, 1]].Color != "w") && (board.boardFields[queenPositions[g, 0], queenPositions[g, 1]].Color != "b"))
								{
									Console.WriteLine("The Queen can't jump over other Pieces.");
									return false;
								}
							}
						}
						else if (49 < i && i <= 55)
						{
							for (int g = 49; g < i; g++)
							{
								if ((board.boardFields[queenPositions[g, 0], queenPositions[g, 1]].Color != "w") && (board.boardFields[queenPositions[g, 0], queenPositions[g, 1]].Color != "b"))
								{
									Console.WriteLine("The Queen can't jump over other Pieces.");
									return false;
								}
							}
						}
						return true;
					}
				}
			}
			Console.WriteLine("The Queen can't step here.");
			return false;
		}






		}
}
