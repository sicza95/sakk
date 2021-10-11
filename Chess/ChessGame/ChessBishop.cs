using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    class ChessBishop : ChessPiece
    {
		char name;
		char color;
		int[,] bishopPositions = new int[28, 2];
		public ChessBishop(char color) : base(color)
		{
			this.name = 'B';
			this.color = color;
		}
		public override string Name => this.name.ToString();
		public override string Color => this.color.ToString();
		public override bool MoveSet(int starti, int startj, int endi, int endj, Chessboard currentboard)
		{
			// diagonal left up:
			bishopPositions[0, 0] = starti - 1; bishopPositions[0, 1] = startj - 1;
			bishopPositions[1, 0] = starti - 2; bishopPositions[1, 1] = startj - 2;
			bishopPositions[2, 0] = starti - 3; bishopPositions[2, 1] = startj - 3;
			bishopPositions[3, 0] = starti - 4; bishopPositions[3, 1] = startj - 4;
			bishopPositions[4, 0] = starti - 5; bishopPositions[4, 1] = startj - 5;
			bishopPositions[5, 0] = starti - 6; bishopPositions[5, 1] = startj - 6;
			bishopPositions[6, 0] = starti - 7; bishopPositions[6, 1] = startj - 7;
			// diagonal left down:
			bishopPositions[7, 0] = starti + 1; bishopPositions[7, 1] = startj - 1;
			bishopPositions[8, 0] = starti + 2; bishopPositions[8, 1] = startj - 2;
			bishopPositions[9, 0] = starti + 3; bishopPositions[9, 1] = startj - 3;
			bishopPositions[10, 0] = starti + 4; bishopPositions[10, 1] = startj - 4;
			bishopPositions[11, 0] = starti + 5; bishopPositions[11, 1] = startj - 5;
			bishopPositions[12, 0] = starti + 6; bishopPositions[12, 1] = startj - 6;
			bishopPositions[13, 0] = starti + 7; bishopPositions[13, 1] = startj - 7;
			// diagonal right up:
			bishopPositions[14, 0] = starti - 1; bishopPositions[14, 1] = startj + 1;
			bishopPositions[15, 0] = starti - 2; bishopPositions[15, 1] = startj + 2;
			bishopPositions[16, 0] = starti - 3; bishopPositions[16, 1] = startj + 3;
			bishopPositions[17, 0] = starti - 4; bishopPositions[17, 1] = startj + 4;
			bishopPositions[18, 0] = starti - 5; bishopPositions[18, 1] = startj + 5;
			bishopPositions[19, 0] = starti - 6; bishopPositions[19, 1] = startj + 6;
			bishopPositions[20, 0] = starti - 7; bishopPositions[20, 1] = startj + 7;
			// diagonal right down:
			bishopPositions[21, 0] = starti + 1; bishopPositions[21, 1] = startj + 1;
			bishopPositions[22, 0] = starti + 2; bishopPositions[22, 1] = startj + 2;
			bishopPositions[23, 0] = starti + 3; bishopPositions[23, 1] = startj + 3;
			bishopPositions[24, 0] = starti + 4; bishopPositions[24, 1] = startj + 4;
			bishopPositions[25, 0] = starti + 5; bishopPositions[25, 1] = startj + 5;
			bishopPositions[26, 0] = starti + 6; bishopPositions[26, 1] = startj + 6;
			bishopPositions[27, 0] = starti + 7; bishopPositions[27, 1] = startj + 7;

			Chessboard board = currentboard;
			for (int i = 0; i < 28; i++)
            {
				if(this.Color == "W")
                {
					if (endi == bishopPositions[i, 0] && endj == bishopPositions[i, 1] && (board.boardFields[endi, endj].Color != "W"))
                    {
						if (0 < i && i <= 6)
						{
                            for (int g = 0; g < i; g++)
                            {
								if ((board.boardFields[bishopPositions[g, 0], bishopPositions[g, 1]].Color != "w") && (board.boardFields[bishopPositions[g, 0], bishopPositions[g, 1]].Color != "b"))
								{
									Console.WriteLine("The Bishop can't jump over other Pieces.");
									return false;
								}
							}
						}
						else if (7 < i && i <= 13)
						{
							for (int g = 7; g < i; g++)
							{
								if ((board.boardFields[bishopPositions[g, 0], bishopPositions[g, 1]].Color != "w") && (board.boardFields[bishopPositions[g, 0], bishopPositions[g, 1]].Color != "b"))
								{
									Console.WriteLine("The Bishop can't jump over other Pieces.");
									return false;
								}
							}
						}
						else if (14 < i && i <= 20)
						{
							for (int g = 14; g < i; g++)
							{
								if ((board.boardFields[bishopPositions[g, 0], bishopPositions[g, 1]].Color != "w") && (board.boardFields[bishopPositions[g, 0], bishopPositions[g, 1]].Color != "b"))
								{
									Console.WriteLine("The Bishop can't jump over other Pieces.");
									return false;
								}
							}
						}
						else if (21 < i && i <= 27)
						{
							for (int g = 21; g < i; g++)
							{
								if ((board.boardFields[bishopPositions[g, 0], bishopPositions[g, 1]].Color != "w") && (board.boardFields[bishopPositions[g, 0], bishopPositions[g, 1]].Color != "b"))
								{
									Console.WriteLine("The Bishop can't jump over other Pieces.");
									return false;
								}
							}
						}
						return true;
                    }
                }
                else
                {
					if (endi == bishopPositions[i, 0] && endj == bishopPositions[i, 1] && (board.boardFields[endi, endj].Color != "B"))
					{
						if (0 < i && i <= 6)
						{
							for (int g = 0; g < i; g++)
							{
								if ((board.boardFields[bishopPositions[g, 0], bishopPositions[g, 1]].Color != "w") && (board.boardFields[bishopPositions[g, 0], bishopPositions[g, 1]].Color != "b"))
								{
									Console.WriteLine("The Bishop can't jump over other Pieces.");
									return false;
								}
							}
						}
						else if (7 < i && i <= 13)
						{
							for (int g = 7; g < i; g++)
							{
								if ((board.boardFields[bishopPositions[g, 0], bishopPositions[g, 1]].Color != "w") && (board.boardFields[bishopPositions[g, 0], bishopPositions[g, 1]].Color != "b"))
								{
									Console.WriteLine("The Bishop can't jump over other Pieces.");
									return false;
								}
							}
						}
						else if (14 < i && i <= 20)
						{
							for (int g = 14; g < i; g++)
							{
								if ((board.boardFields[bishopPositions[g, 0], bishopPositions[g, 1]].Color != "w") && (board.boardFields[bishopPositions[g, 0], bishopPositions[g, 1]].Color != "b"))
								{
									Console.WriteLine("The Bishop can't jump over other Pieces.");
									return false;
								}
							}
						}
						else if (21 < i && i <= 27)
						{
							for (int g = 21; g < i; g++)
							{
								if ((board.boardFields[bishopPositions[g, 0], bishopPositions[g, 1]].Color != "w") && (board.boardFields[bishopPositions[g, 0], bishopPositions[g, 1]].Color != "b"))
								{
									Console.WriteLine("The Bishop can't jump over other Pieces.");
									return false;
								}
							}
						}
						return true;
					}
				}
            }
			Console.WriteLine("The Bishop can't step here.");
			return false;
		}








		}
}
