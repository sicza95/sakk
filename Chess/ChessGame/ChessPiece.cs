using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    class ChessPiece
    {
		char name;
		char color;
		bool enPassant;
		int[,] attackPositions = new int[64, 2];
		int steps;
		char initialFile;
		int initialRank;
		
		public ChessPiece(char color,char file,int rank)
		{
			this.name = ' ';
			this.color = color;
			this.steps = 0;
			this.initialFile = file;
			this.initialRank = rank;
		}

		public virtual string Name => this.name.ToString();
		public virtual string Color => this.color.ToString();
		public virtual bool EnPassant => this.enPassant;
		public virtual int Steps => this.steps;
		public virtual int[,] AttackPositions => this.attackPositions;
		
		public virtual bool MoveSet(int starti, int startj, int endi, int endj, Chessboard currentboard, bool kiiras)
        {
			return false;
        }
		
		public virtual bool MoveSet2(int starti, int startj, Chessboard currentboard)
		{
			return false;
		}

		public virtual bool IsKingInCheck()
        {
			return false;
        }
		
		public virtual bool WillKingBeInCheck(int fieldi, int fieldj, Chessboard currentboard, int starti, int startj, int endi, int endj)
		{
			return false;
		}
		
		public virtual bool IsFieldUnderAttack(int fieldi, int fieldj, Chessboard currentboard)
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
			attackPositions[56, 0] = fieldi - 1; attackPositions[56, 1] = fieldj - 2;	//left up
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
                if (0 <= attackPositions[i,0] && attackPositions[i, 0] <= 7 && 0 <= attackPositions[i, 1] && attackPositions[i, 1] <= 7)
                {
                    if (0 <= i && i <= 6)
                    {
                        // horizontal left positions
                        if (i == 0 && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "K" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "Q" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "R"))
                        {
                            if (board.player == "white" && board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color == "B")
                            {
								Console.WriteLine("1");
								return true;
							}
                            else if(board.player == "black" && board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color == "W")
                            {
								Console.WriteLine("1");
								return true;
							}
							return false;
						}
                        else
                        {
                            if ( (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "Q" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "R") && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color == "W") )
                            {
                                for (int g = 0; g < i; g++)
                                {
                                    if (board.boardFields[attackPositions[g, 0], attackPositions[g, 1]].Color == "B")
                                    {
										return false;
                                    }
                                }
								Console.WriteLine("2");
								return true;
                            }
							else if ((board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "Q" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "R") && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color == "B"))
							{
								for (int g = 0; g < i; g++)
								{
									if (board.boardFields[attackPositions[g, 0], attackPositions[g, 1]].Color == "W")
									{
										return false;
									}
								}
								Console.WriteLine("3");
								return true;
							}
                        }
						return false;
					}
					else if (7 <= i && i <= 13)
                    {
						// diagonal left up:
						if (i == 7 && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "K" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "Q" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "B" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "P"))
						{
							if (board.player == "white" && board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color == "B")
							{
								Console.WriteLine("1");
								return true;
							}
							else if (board.player == "black" && board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color == "W")
							{
								Console.WriteLine("1");
								return true;
							}
							return false;
						}
						else
						{
							if ((board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "Q" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "B") && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color == "W"))
							{
								for (int g = 7; g < i; g++)
								{
									if (board.boardFields[attackPositions[g, 0], attackPositions[g, 1]].Color == "B")
									{
										return false;
									}
								}
								Console.WriteLine("5");
								return true;
							}
							else if ((board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "Q" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "B") && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color == "B"))
							{
								for (int g = 7; g < i; g++)
								{
									if (board.boardFields[attackPositions[g, 0], attackPositions[g, 1]].Color == "W")
									{
										return false;
									}
								}
								Console.WriteLine("6");
								return true;
							}
						}
						return false;
					}
					else if (14 <= i && i <= 20)
					{
						// vertical up positions:
						if (i == 14 && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "K" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "Q" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "R"))
						{
							if (board.player == "white" && board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color == "B")
							{
								Console.WriteLine("1");
								return true;
							}
							else if (board.player == "black" && board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color == "W")
							{
								Console.WriteLine("1");
								return true;
							}
							return false;
						}
						else
						{
							if ((board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "Q" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "R") && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color == "W"))
							{
								for (int g = 14; g < i; g++)
								{
									if (board.boardFields[attackPositions[g, 0], attackPositions[g, 1]].Color == "B")
									{
										return false;
									}
								}
								Console.WriteLine("8");
								return true;
							}
							else if ((board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "Q" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "R") && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color == "B"))
							{
								for (int g = 14; g < i; g++)
								{
									if (board.boardFields[attackPositions[g, 0], attackPositions[g, 1]].Color == "W")
									{
										return false;
									}
								}
								Console.WriteLine("9");
								return true;
							}
						}
						return false;
					}
					else if (21 <= i && i <= 27)
					{
						// diagonal right up:
						if (i == 21 && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "K" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "Q" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "B" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "P"))
						{
							if (board.player == "white" && board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color == "B")
							{
								Console.WriteLine("1");
								return true;
							}
							else if (board.player == "black" && board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color == "W")
							{
								Console.WriteLine("1");
								return true;
							}
							return false;
						}
						else
						{
							if ((board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "Q" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "B") && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color == "W"))
							{
								for (int g = 21; g < i; g++)
								{
									if (board.boardFields[attackPositions[g, 0], attackPositions[g, 1]].Color == "B")
									{
										return false;
									}
								}
								Console.WriteLine("11");
								return true;
							}
							else if ((board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "Q" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "B") && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color == "B"))
							{
								for (int g = 21; g < i; g++)
								{
									if (board.boardFields[attackPositions[g, 0], attackPositions[g, 1]].Color == "W")
									{
										return false;
									}
								}
								Console.WriteLine("12");
								return true;
							}
						}
						return false;
					}
					else if (28 <= i && i <= 34)
					{
						// horizontal right positions:
						if (i == 28 && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "K" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "Q" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "R"))
						{
							if (board.player == "white" && board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color == "B")
							{
								Console.WriteLine("1");
								return true;
							}
							else if (board.player == "black" && board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color == "W")
							{
								Console.WriteLine("1");
								return true;
							}
							return false;
						}
						else
						{
							if ((board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "Q" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "R") && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color == "W"))
							{
								for (int g = 28; g < i; g++)
								{
									if (board.boardFields[attackPositions[g, 0], attackPositions[g, 1]].Color == "B")
									{
										return false;
									}
								}
								Console.WriteLine("14");
								return true;
							}
							else if ((board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "Q" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "R") && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color == "B"))
							{
								for (int g = 28; g < i; g++)
								{
									if (board.boardFields[attackPositions[g, 0], attackPositions[g, 1]].Color == "W")
									{
										return false;
									}
								}
								Console.WriteLine("15");
								return true;
							}
						}
						return false;
					}
					else if (35 <= i && i <= 41)
					{
						// diagonal right down:
						if (i == 35 && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "K" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "Q" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "B" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "P"))
						{
							if (board.player == "white" && board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color == "B")
							{
								Console.WriteLine("1");
								return true;
							}
							else if (board.player == "black" && board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color == "W")
							{
								Console.WriteLine("1");
								return true;
							}
							return false;
						}
						else
						{
							if ((board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "Q" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "B") && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color == "W"))
							{
								for (int g = 35; g < i; g++)
								{
									if (board.boardFields[attackPositions[g, 0], attackPositions[g, 1]].Color == "B")
									{
										return false;
									}
								}
								Console.WriteLine("17");
								return true;
							}
							else if ((board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "Q" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "B") && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color == "B"))
							{
								for (int g = 35; g < i; g++)
								{
									if (board.boardFields[attackPositions[g, 0], attackPositions[g, 1]].Color == "W")
									{
										return false;
									}
								}
								Console.WriteLine("18");
								return true;
							}
						}
						return false;
					}
					else if (42 <= i && i <= 48)
					{
						// vertical down positions:
						if (i == 42 && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "K" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "Q" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "R"))
						{
							if (board.player == "white" && board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color == "B")
							{
								Console.WriteLine("1");
								return true;
							}
							else if (board.player == "black" && board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color == "W")
							{
								Console.WriteLine("1");
								return true;
							}
							return false;
						}
						else
						{
							if ((board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "Q" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "R") && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color == "W"))
							{
								for (int g = 42; g < i; g++)
								{
									if (board.boardFields[attackPositions[g, 0], attackPositions[g, 1]].Color == "B")
									{
										return false;
									}
								}
								Console.WriteLine("20");
								return true;
							}
							else if ((board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "Q" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "R") && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color == "B"))
							{
								for (int g = 42; g < i; g++)
								{
									if (board.boardFields[attackPositions[g, 0], attackPositions[g, 1]].Color == "W")
									{
										return false;
									}
								}
								Console.WriteLine("21");
								return true;
							}
						}
						return false;
					}
					else if (49 <= i && i <= 55)
					{
						// diagonal left down:
						if (i == 49 && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "K" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "Q" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "B" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "P"))
						{
							if (board.player == "white" && board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color == "B")
							{
								Console.WriteLine("1");
								return true;
							}
							else if (board.player == "black" && board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color == "W")
							{
								Console.WriteLine("1");
								return true;
							}
							return false;
						}
						else
						{
							if ((board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "Q" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "B") && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color == "W"))
							{
								for (int g = 49; g < i; g++)
								{
									if (board.boardFields[attackPositions[g, 0], attackPositions[g, 1]].Color == "B")
									{
										return false;
									}
								}
								Console.WriteLine("23");
								return true;
							}
							else if ((board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "Q" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "B") && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color == "B"))
							{
								for (int g = 49; g < i; g++)
								{
									if (board.boardFields[attackPositions[g, 0], attackPositions[g, 1]].Color == "W")
									{
										return false;
									}
								}
								Console.WriteLine("24");
								return true;
							}
						}
						return false;
					}
					else if (56 <= i && i <= 63)
					{
                        // the knight positions:
                        if (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "N")
                        {
							if (board.player == "white" && board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color == "B")
							{
								Console.WriteLine("1");
								return true;
							}
							else if (board.player == "black" && board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color == "W")
							{
								Console.WriteLine("1");
								return true;
							}
							return false;
						}
						return false;
					}
					return false;
				}
			}
			return false;
		}

	}
}
