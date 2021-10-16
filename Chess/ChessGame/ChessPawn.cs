using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
	class ChessPawn : ChessPiece
    {
		char name;
		char color;
		bool enPassant = false;
		int[,] pawnPositions = new int[3,2];
		int[,] attackPositions = new int[64, 2];
		public ChessPawn(char color) : base(color)
		{
			this.name = 'P';
			this.color = color;
		}
		public override string Name => this.name.ToString();
		public override string Color => this.color.ToString();
		public override bool EnPassant => this.enPassant;
		public override bool MoveSet(int starti, int startj, int endi, int endj, Chessboard currentboard, bool kiiras)
		{
			Chessboard board = currentboard;
			pawnPositions[0, 0] = starti-1; pawnPositions[0, 1] = startj-1;
			pawnPositions[1, 0] = starti-1; pawnPositions[1, 1] = startj+1;
			pawnPositions[2, 0] = starti-1; pawnPositions[2, 1] = startj;


            if (this.Color == "W")
            {
                if (starti == 6 && endi == starti - 2 && endj == startj && board.boardFields[endi,endj].Color != "B" && board.boardFields[endi, endj].Color != "W" && board.boardFields[endi+1, endj].Color != "B" && board.boardFields[endi+1, endj].Color != "W")
                {
                    if (startj == 0)
                    {
                        if (board.boardFields[starti - 2, startj + 1].Color == "B")
						{
							this.enPassant = true;
							return true;
						}
						this.enPassant = false;
						return true;
					}
					else if (startj == 7)
                    {
						if (board.boardFields[starti - 2, startj - 1].Color == "B")
						{
							this.enPassant = true;
							return true;
						}
						this.enPassant = false;
						return true;
					}
                    else
                    {
						if (board.boardFields[starti - 2, startj - 1].Color == "B" || board.boardFields[starti - 2, startj + 1].Color == "B")
						{
							this.enPassant = true;
							return true;
						}
						this.enPassant = false;
						return true;
					}
                }
                else if (((board.boardFields[starti - 1, startj].Color == "w") && (endi == starti - 1) && (endj == startj)) || ((board.boardFields[starti - 1, startj].Color == "b") && (endi == starti - 1) && (endj == startj)))
				{
					this.enPassant = false;
					return true;
				}
                else if (0 <= starti - 1 && starti - 1 <= 77 && 0 <= startj - 1 && startj - 1 <= 7 && endi == starti - 1 && endj == startj - 1)
				{
					if ((board.boardFields[starti - 1, startj - 1].Color == "B") && (endi == starti - 1) && (endj == startj - 1))
					{
						this.enPassant = false;
						return true;
					}
                    if (kiiras == true)
                    {
						Console.WriteLine("The Pawn can't step there.");
					}
					return false;
				}
				else if (0 <= starti - 1 && starti - 1 <= 77 && 0 <= startj + 1 && startj + 1 <= 7 && endi == starti - 1 && endj == startj + 1)
                {
					if ((board.boardFields[starti - 1, startj + 1].Color == "B") && (endi == starti - 1) && (endj == startj + 1))
					{
						this.enPassant = false;
						return true;
					}
					if (kiiras == true)
					{
						Console.WriteLine("The Pawn can't step there.");
					}
					return false;
				}
				else
				{
					if (kiiras == true)
					{
						Console.WriteLine("The Pawn can't step there.");
					}
					return false;
				}
			}
            else
            {
				if (starti == 1 && endi == starti + 2 && endj == startj && board.boardFields[endi, endj].Color != "B" && board.boardFields[endi, endj].Color != "W" && board.boardFields[endi-1, endj].Color != "B" && board.boardFields[endi-1, endj].Color != "W")
				{
					if (startj == 0)
                    {
                        if (board.boardFields[starti + 2, startj + 1].Color == "W")
						{
							this.enPassant = true;
							return true;
						}
						this.enPassant = false;
						return true;
					}
					else if (startj == 7)
                    {
						if (board.boardFields[starti + 2, startj - 1].Color == "W")
						{
							this.enPassant = true;
							return true;
						}
						this.enPassant = false;
						return true;
					}
                    else
                    {
						if (board.boardFields[starti + 2, startj - 1].Color == "W" || board.boardFields[starti + 2, startj + 1].Color == "W")
						{
							this.enPassant = true;
							return true;
						}
						this.enPassant = false;
						return true;
					}
				}
				else if (((board.boardFields[starti + 1, startj].Color == "w") && (endi == starti + 1) && (endj == startj)) || ((board.boardFields[starti + 1, startj].Color == "b") && (endi == starti + 1) && (endj == startj)))
				{
					this.enPassant = false;
					return true;
				}
				//
				else if (0<= starti+1 && starti+1 <= 77 && 0 <= startj -1 && startj - 1 <= 7 && endi == starti + 1 && endj == startj - 1)
                {
					if ((board.boardFields[starti + 1, startj - 1].Color == "W") && (endi == starti + 1) && (endj == startj - 1))
					{
						this.enPassant = false;
						return true;
					}
					if (kiiras == true)
					{
						Console.WriteLine("The Pawn can't step there.");
					}
					return false;
				}
				//
				else if (0 <= starti + 1 && starti + 1 <= 77 && 0 <= startj + 1 && startj + 1 <= 7 && endi == starti + 1 && endj == startj + 1)
                {
					if ((board.boardFields[starti + 1, startj + 1].Color == "W") && (endi == starti + 1) && (endj == startj + 1))
					{
						this.enPassant = false;
						return true;
					}
					if (kiiras == true)
					{
						Console.WriteLine("The Pawn can't step there.");
					}
					return false;
				}
				else
				{
					if (kiiras == true)
					{
						Console.WriteLine("The Pawn can't step there.");
					}
					return false;
				}
			}
		}

		public override bool IsFieldUnderAttack(int fieldi, int fieldj, Chessboard currentboard)
		{
			// horizontal left positions:
			attackPositions[0, 0] = fieldi; attackPositions[0, 1] = fieldj - 1;
			attackPositions[1, 0] = fieldi; attackPositions[1, 1] = fieldj - 2;
			attackPositions[2, 0] = fieldi; attackPositions[2, 1] = fieldj - 3;
			attackPositions[3, 0] = fieldi; attackPositions[3, 1] = fieldj - 4;
			attackPositions[4, 0] = fieldi; attackPositions[4, 1] = fieldj - 5;
			attackPositions[5, 0] = fieldi; attackPositions[5, 1] = fieldj - 6;
			attackPositions[6, 0] = fieldi; attackPositions[6, 1] = fieldj - 7;
			// diagonal left up:
			attackPositions[7, 0] = fieldi - 1; attackPositions[7, 1] = fieldj - 1;
			attackPositions[8, 0] = fieldi - 2; attackPositions[8, 1] = fieldj - 2;
			attackPositions[9, 0] = fieldi - 3; attackPositions[9, 1] = fieldj - 3;
			attackPositions[10, 0] = fieldi - 4; attackPositions[10, 1] = fieldj - 4;
			attackPositions[11, 0] = fieldi - 5; attackPositions[11, 1] = fieldj - 5;
			attackPositions[12, 0] = fieldi - 6; attackPositions[12, 1] = fieldj - 6;
			attackPositions[13, 0] = fieldi - 7; attackPositions[13, 1] = fieldj - 7;
			// vertical up positions:
			attackPositions[14, 0] = fieldi - 1; attackPositions[14, 1] = fieldj;
			attackPositions[15, 0] = fieldi - 2; attackPositions[15, 1] = fieldj;
			attackPositions[16, 0] = fieldi - 3; attackPositions[16, 1] = fieldj;
			attackPositions[17, 0] = fieldi - 4; attackPositions[17, 1] = fieldj;
			attackPositions[18, 0] = fieldi - 5; attackPositions[18, 1] = fieldj;
			attackPositions[19, 0] = fieldi - 6; attackPositions[19, 1] = fieldj;
			attackPositions[20, 0] = fieldi - 7; attackPositions[20, 1] = fieldj;
			// diagonal right up:
			attackPositions[21, 0] = fieldi - 1; attackPositions[21, 1] = fieldj + 1;
			attackPositions[22, 0] = fieldi - 2; attackPositions[22, 1] = fieldj + 2;
			attackPositions[23, 0] = fieldi - 3; attackPositions[23, 1] = fieldj + 3;
			attackPositions[24, 0] = fieldi - 4; attackPositions[24, 1] = fieldj + 4;
			attackPositions[25, 0] = fieldi - 5; attackPositions[25, 1] = fieldj + 5;
			attackPositions[26, 0] = fieldi - 6; attackPositions[26, 1] = fieldj + 6;
			attackPositions[27, 0] = fieldi - 7; attackPositions[27, 1] = fieldj + 7;
			// horizontal right positions:
			attackPositions[28, 0] = fieldi; attackPositions[28, 1] = fieldj + 1;
			attackPositions[29, 0] = fieldi; attackPositions[29, 1] = fieldj + 2;
			attackPositions[30, 0] = fieldi; attackPositions[30, 1] = fieldj + 3;
			attackPositions[31, 0] = fieldi; attackPositions[31, 1] = fieldj + 4;
			attackPositions[32, 0] = fieldi; attackPositions[32, 1] = fieldj + 5;
			attackPositions[33, 0] = fieldi; attackPositions[33, 1] = fieldj + 6;
			attackPositions[34, 0] = fieldi; attackPositions[34, 1] = fieldj + 7;
			// diagonal right down:
			attackPositions[35, 0] = fieldi + 1; attackPositions[35, 1] = fieldj + 1;
			attackPositions[36, 0] = fieldi + 2; attackPositions[36, 1] = fieldj + 2;
			attackPositions[37, 0] = fieldi + 3; attackPositions[37, 1] = fieldj + 3;
			attackPositions[38, 0] = fieldi + 4; attackPositions[38, 1] = fieldj + 4;
			attackPositions[39, 0] = fieldi + 5; attackPositions[39, 1] = fieldj + 5;
			attackPositions[40, 0] = fieldi + 6; attackPositions[40, 1] = fieldj + 6;
			attackPositions[41, 0] = fieldi + 7; attackPositions[41, 1] = fieldj + 7;
			// vertical down positions:
			attackPositions[42, 0] = fieldi + 1; attackPositions[42, 1] = fieldj;
			attackPositions[43, 0] = fieldi + 2; attackPositions[43, 1] = fieldj;
			attackPositions[44, 0] = fieldi + 3; attackPositions[44, 1] = fieldj;
			attackPositions[45, 0] = fieldi + 4; attackPositions[45, 1] = fieldj;
			attackPositions[46, 0] = fieldi + 5; attackPositions[46, 1] = fieldj;
			attackPositions[47, 0] = fieldi + 6; attackPositions[47, 1] = fieldj;
			attackPositions[48, 0] = fieldi + 7; attackPositions[48, 1] = fieldj;
			// diagonal left down:
			attackPositions[49, 0] = fieldi + 1; attackPositions[49, 1] = fieldj - 1;
			attackPositions[50, 0] = fieldi + 2; attackPositions[50, 1] = fieldj - 2;
			attackPositions[51, 0] = fieldi + 3; attackPositions[51, 1] = fieldj - 3;
			attackPositions[52, 0] = fieldi + 4; attackPositions[52, 1] = fieldj - 4;
			attackPositions[53, 0] = fieldi + 5; attackPositions[53, 1] = fieldj - 5;
			attackPositions[54, 0] = fieldi + 6; attackPositions[54, 1] = fieldj - 6;
			attackPositions[55, 0] = fieldi + 7; attackPositions[55, 1] = fieldj - 7;
			// the knight positions:
			attackPositions[56, 0] = fieldi - 1; attackPositions[56, 1] = fieldj - 2; //left up
			attackPositions[57, 0] = fieldi + 1; attackPositions[57, 1] = fieldj - 2; //left down
			attackPositions[58, 0] = fieldi - 2; attackPositions[58, 1] = fieldj - 1; //up left
			attackPositions[59, 0] = fieldi - 2; attackPositions[59, 1] = fieldj + 1; //up right
			attackPositions[60, 0] = fieldi - 1; attackPositions[60, 1] = fieldj + 2; //right up
			attackPositions[61, 0] = fieldi + 1; attackPositions[61, 1] = fieldj + 2; //right down
			attackPositions[62, 0] = fieldi + 2; attackPositions[62, 1] = fieldj - 1; //down left
			attackPositions[63, 0] = fieldi + 2; attackPositions[63, 1] = fieldj + 1; //down right

			Chessboard board = currentboard;
			for (int i = 0; i < attackPositions.Length; i++)
			{
				if (0 <= attackPositions[i, 0] && attackPositions[i, 0] <= 7 && 0 <= attackPositions[i, 1] && attackPositions[i, 1] <= 7)
				{
					if (0 <= i && i <= 6)
					{
						// horizontal left positions
						if (i == 0 && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "K" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "Q" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "R") && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color != this.Color))
						{
							return true;
						}
						else
						{
							if ((board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "Q" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "R") && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color != this.Color))
							{
								for (int g = 0; g < i; g++)
								{
									if (board.boardFields[attackPositions[g, 0], attackPositions[g, 1]].Color == this.Color)
									{
										return false;
									}
								}
								return true;
							}
						}
						return false;
					}
					else if (7 <= i && i <= 13)
					{
						// diagonal left up:
						if (i == 7 && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "K" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "Q" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "B" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "P") && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color != this.Color))
						{
							return true;
						}
						else
						{
							if ((board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "Q" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "B") && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color != this.Color))
							{
								for (int g = 7; g < i; g++)
								{
									if (board.boardFields[attackPositions[g, 0], attackPositions[g, 1]].Color == this.Color)
									{
										return false;
									}
								}
								return true;
							}
						}
						return false;
					}
					else if (14 <= i && i <= 20)
					{
						// vertical up positions:
						if (i == 14 && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "K" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "Q" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "R") && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color != this.Color))
						{
							return true;
						}
						else
						{
							if ((board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "Q" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "R") && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color != this.Color))
							{
								for (int g = 14; g < i; g++)
								{
									if (board.boardFields[attackPositions[g, 0], attackPositions[g, 1]].Color == this.Color)
									{
										return false;
									}
								}
								return true;
							}
						}
						return false;
					}
					else if (21 <= i && i <= 27)
					{
						// diagonal right up:
						if (i == 21 && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "K" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "Q" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "B" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "P") && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color != this.Color))
						{
							return true;
						}
						else
						{
							if ((board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "Q" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "B") && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color != this.Color))
							{
								for (int g = 21; g < i; g++)
								{
									if (board.boardFields[attackPositions[g, 0], attackPositions[g, 1]].Color == this.Color)
									{
										return false;
									}
								}
								return true;
							}
						}
						return false;
					}
					else if (28 <= i && i <= 34)
					{
						// horizontal right positions:
						if (i == 28 && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "K" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "Q" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "R") && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color != this.Color))
						{
							return true;
						}
						else
						{
							if ((board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "Q" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "R") && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color != this.Color))
							{
								for (int g = 28; g < i; g++)
								{
									if (board.boardFields[attackPositions[g, 0], attackPositions[g, 1]].Color == this.Color)
									{
										return false;
									}
								}
								return true;
							}
						}
						return false;
					}
					else if (35 <= i && i <= 41)
					{
						// diagonal right down:
						if (i == 35 && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "K" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "Q" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "B" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "P") && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color != this.Color))
						{
							return true;
						}
						else
						{
							if ((board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "Q" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "B") && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color != this.Color))
							{
								for (int g = 35; g < i; g++)
								{
									if (board.boardFields[attackPositions[g, 0], attackPositions[g, 1]].Color == this.Color)
									{
										return false;
									}
								}
								return true;
							}
						}
						return false;
					}
					else if (42 <= i && i <= 48)
					{
						// vertical down positions:
						if (i == 42 && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "K" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "Q" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "R") && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color != this.Color))
						{
							return true;
						}
						else
						{
							if ((board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "Q" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "R") && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color != this.Color))
							{
								for (int g = 42; g < i; g++)
								{
									if (board.boardFields[attackPositions[g, 0], attackPositions[g, 1]].Color == this.Color)
									{
										return false;
									}
								}
								return true;
							}
						}
						return false;
					}
					else if (49 <= i && i <= 55)
					{
						// diagonal left down:
						if (i == 49 && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "K" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "Q" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "B" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "P") && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color != this.Color))
						{
							return true;
						}
						else
						{
							if ((board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "Q" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "B") && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color != this.Color))
							{
								for (int g = 49; g < i; g++)
								{
									if (board.boardFields[attackPositions[g, 0], attackPositions[g, 1]].Color == this.Color)
									{
										return false;
									}
								}
								return true;
							}
						}
						return false;
					}
					else if (56 <= i && i <= 63)
					{
						// the knight positions:
						if (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "N" && board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color != this.Color)
						{
							return true;
						}
						return false;
					}
					return false;
				}
			}
			return false;
		}

		/*
		
	*/







	}
}
