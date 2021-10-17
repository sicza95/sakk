using System;

namespace ChessGame
{
    class ChessKing : ChessPiece
    {
		char name;
		char color;
		int[,] kingPositions = new int[10, 2];
		int[,] attackPositions = new int[64, 2];
		int steps;
		int numberOfAttackers;
		int[,] positionOfAttackers = new int[64, 2];
		int[,] checkableFields = new int[64, 2];
		public ChessKing(char color) : base(color)
		{
			this.name = 'K';
			this.color = color;
			this.steps = 0;
		}
		public override string Name => this.name.ToString();
		public override string Color => this.color.ToString();
		public override int Steps => this.steps;
		public override int[,] AttackPositions => this.attackPositions;
		public override bool MoveSet(int starti, int startj, int endi, int endj, Chessboard currentboard, bool kiiras)
		{
			kingPositions[0, 0] = starti - 1; kingPositions[0, 1] = startj - 1;
			kingPositions[1, 0] = starti - 1; kingPositions[1, 1] = startj;
			kingPositions[2, 0] = starti - 1; kingPositions[2, 1] = startj + 1;
			kingPositions[3, 0] = starti; kingPositions[3, 1] = startj - 1;
			kingPositions[4, 0] = starti; kingPositions[4, 1] = startj + 1;
			kingPositions[5, 0] = starti + 1; kingPositions[5, 1] = startj - 1;
			kingPositions[6, 0] = starti + 1; kingPositions[6, 1] = startj;
			kingPositions[7, 0] = starti + 1; kingPositions[7, 1] = startj + 1;

			Chessboard board = currentboard;
			for (int i = 0; i < 8; i++)
			{
                if (0 <= kingPositions[i, 0] && kingPositions[i, 0] <= 7 && 0 <= kingPositions[i, 1] && kingPositions[i, 1] <= 7)
                {
					if (this.Color == "W")
					{
						if ((endi == kingPositions[i, 0] && endj == kingPositions[i, 1]) && (board.boardFields[endi, endj].Color != "W"))
						{
							this.steps++;
							return true;
						}
					}
					else
					{
						if ((endi == kingPositions[i, 0] && endj == kingPositions[i, 1]) && (board.boardFields[endi, endj].Color != "B"))
						{
							this.steps++;
							return true;
						}
					}
				}
			}
            if (kiiras == true)
            {
				Console.WriteLine("The King can't step here.");
			}
			return false;
		}

		public override bool MoveSet2(int starti, int startj, Chessboard currentboard)
        {
            
			kingPositions[0, 0] = starti - 1; kingPositions[0, 1] = startj - 1;
			kingPositions[1, 0] = starti - 1; kingPositions[1, 1] = startj;
			kingPositions[2, 0] = starti - 1; kingPositions[2, 1] = startj + 1;
			kingPositions[3, 0] = starti; kingPositions[3, 1] = startj - 1;
			kingPositions[4, 0] = starti; kingPositions[4, 1] = startj + 1;
			kingPositions[5, 0] = starti + 1; kingPositions[5, 1] = startj - 1;
			kingPositions[6, 0] = starti + 1; kingPositions[6, 1] = startj;
			kingPositions[7, 0] = starti + 1; kingPositions[7, 1] = startj + 1;

			Chessboard board = currentboard;
			for (int i = 0; i < 8; i++)
			{
				if (0 <= kingPositions[i, 0] && kingPositions[i, 0] <= 7 && 0 <= kingPositions[i, 1] && kingPositions[i, 1] <= 7)
				{
                    if (board.player == "white")
                    {
						if (board.boardFields[kingPositions[i, 0], kingPositions[i, 1]].Color != "W")
						{
							if (this.WillKingBeInCheck(starti, startj, board, starti, startj, kingPositions[i, 0], kingPositions[i, 1]) == true)
							{
								return false;
							}
							return true;
						}
					}
                    else if(board.player == "black")
					{
						if (board.boardFields[kingPositions[i, 0], kingPositions[i, 1]].Color != "B")
						{
							if (this.WillKingBeInCheck(starti, startj, board, starti, startj, kingPositions[i, 0], kingPositions[i, 1]) == true)
							{
								return false;
							}
							return true;
						}
					}
                    else
                    {
					}
				}
			}

			return false;
		}


		public override bool IsKingInCheck()
		{
			return false;
		}

		public override bool WillKingBeInCheck(int fieldi, int fieldj, Chessboard currentboard, int starti, int startj, int endi, int endj)
		{
			Chessboard virtualboard = new Chessboard(currentboard);
			if (this.IsFieldUnderAttack(fieldi, fieldj, virtualboard) == true)
            {
				virtualboard.boardFields[endi, endj] = virtualboard.boardFields[starti, startj];
				if (starti % 2 == 0)
				{
					if (startj % 2 == 0)
					{
						virtualboard.boardFields[starti, startj] = new ChessPiece('w');    //White field
					}
					else
					{
						virtualboard.boardFields[starti, startj] = new ChessPiece('b');    //Black Field
					}
				}
				else
				{
					if (startj % 2 == 0)
					{
						virtualboard.boardFields[starti, startj] = new ChessPiece('b');    //White field
					}
					else
					{
						virtualboard.boardFields[starti, startj] = new ChessPiece('w');    //Black Field
					}
				}
                if (virtualboard.boardFields[fieldi,fieldj].Name == "K")
                {
					if (this.IsFieldUnderAttack(fieldi, fieldj, virtualboard) == true)
					{
						return true;
					}
					return false;
				}
                else
                {
					if (this.IsFieldUnderAttack(endi, endj, virtualboard) == true)
					{
						return true;
					}
					return false;
				}
                
			}
			else if (this.IsFieldUnderAttack(fieldi, fieldj, virtualboard) == false)
			{
				virtualboard.boardFields[endi, endj] = virtualboard.boardFields[starti, startj];
				if (starti % 2 == 0)
				{
					if (startj % 2 == 0)
					{
						virtualboard.boardFields[starti, startj] = new ChessPiece('w');    //White field
					}
					else
					{
						virtualboard.boardFields[starti, startj] = new ChessPiece('b');    //Black Field
					}
				}
				else
				{
					if (startj % 2 == 0)
					{
						virtualboard.boardFields[starti, startj] = new ChessPiece('b');    //White field
					}
					else
					{
						virtualboard.boardFields[starti, startj] = new ChessPiece('w');    //Black Field
					}
				}
				if (virtualboard.boardFields[fieldi, fieldj].Name == "K")
				{
					if (this.IsFieldUnderAttack(fieldi, fieldj, virtualboard) == true)
					{
						return true;
					}
					return false;
				}
				else
				{
					if (this.IsFieldUnderAttack(endi, endj, virtualboard) == true)
					{
						return true;
					}
					return false;
				}
			}
            else
            {
				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 8; j++)
					{
						Console.WriteLine(virtualboard.boardFields[i, j]);
					}
				}
				return true;
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
			this.numberOfAttackers = 0;
			bool middleman = false;
            for (int i = 0; i < 64; i++)
            {
                if (0 <= attackPositions[i, 0] && attackPositions[i, 0] <= 7 && 0 <= attackPositions[i, 1] && attackPositions[i, 1] <= 7)
                {
                    if (0 <= i && i <= 6)
                    {
                        if (i == 0)
                        {
                            if ((board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "K" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "Q" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "R") && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color != this.Color))
                            {
                                this.numberOfAttackers++;
                                this.positionOfAttackers[i, 0] = attackPositions[i, 0]; this.positionOfAttackers[i, 1] = attackPositions[i, 1];
                            }
                        }
                        else
                        {
                            if ((board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "Q" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "R") && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color != this.Color))
                            {
                                for (int g = 0; g < i; g++)
                                {
                                    if (board.boardFields[attackPositions[g, 0], attackPositions[g, 1]].Color == this.Color)
                                    {
										middleman = true;
										this.positionOfAttackers[i, 0] = fieldi; this.positionOfAttackers[i, 1] = fieldj;
                                    }
                                }
                                if (middleman == false)
                                {
									this.numberOfAttackers++;
								}
                                this.positionOfAttackers[i, 0] = attackPositions[i, 0]; this.positionOfAttackers[i, 1] = attackPositions[i, 1];
                            }
                        }
                    }
                    else if (7 <= i && i <= 13)
                    {
                        // diagonal left up:
                        if (i == 7 && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "K" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "Q" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "B" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "P") && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color != this.Color))
                        {
                            this.numberOfAttackers++;
                            this.positionOfAttackers[i, 0] = attackPositions[i, 0]; this.positionOfAttackers[i, 1] = attackPositions[i, 1];
                        }
                        else
                        {
                            if ((board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "Q" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "B") && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color != this.Color))
                            {
                                for (int g = 7; g < i; g++)
                                {
                                    if (board.boardFields[attackPositions[g, 0], attackPositions[g, 1]].Color == this.Color)
                                    {
										middleman = true;
										this.positionOfAttackers[i, 0] = fieldi; this.positionOfAttackers[i, 1] = fieldj;
                                    }
                                }
								if (middleman == false)
								{
									this.numberOfAttackers++;
								}
								this.positionOfAttackers[i, 0] = attackPositions[i, 0]; this.positionOfAttackers[i, 1] = attackPositions[i, 1];
                            }
                        }
                    }
                    else if (14 <= i && i <= 20)
                    {
                        // vertical up positions:
                        if (i == 14 && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "K" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "Q" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "R") && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color != this.Color))
                        {
                            this.numberOfAttackers++;
                            this.positionOfAttackers[i, 0] = attackPositions[i, 0]; this.positionOfAttackers[i, 1] = attackPositions[i, 1];
                        }
                        else
                        {
                            if ((board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "Q" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "R") && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color != this.Color))
                            {
                                for (int g = 14; g < i; g++)
                                {
                                    if (board.boardFields[attackPositions[g, 0], attackPositions[g, 1]].Color == this.Color)
                                    {
										middleman = true;
                                        this.positionOfAttackers[i, 0] = fieldi; this.positionOfAttackers[i, 1] = fieldj;
                                    }
                                }
								if (middleman == false)
								{
									this.numberOfAttackers++;
								}
								this.positionOfAttackers[i, 0] = attackPositions[i, 0]; this.positionOfAttackers[i, 1] = attackPositions[i, 1];
                            }
                        }
                    }
                    else if (21 <= i && i <= 27)
                    {
                        // diagonal right up:
                        if (i == 21 && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "K" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "Q" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "B" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "P") && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color != this.Color))
                        {
                            this.numberOfAttackers++;
                            this.positionOfAttackers[i, 0] = attackPositions[i, 0]; this.positionOfAttackers[i, 1] = attackPositions[i, 1];
                        }
                        else if (21 < i && i <= 27)
                        {
                            if ((board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "Q" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "B") && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color != this.Color))
                            {
                                for (int g = 21; g < i; g++)
                                {
									if (board.boardFields[attackPositions[g, 0], attackPositions[g, 1]].Color == this.Color)
                                    {
										middleman = true;
                                        this.positionOfAttackers[i, 0] = fieldi; this.positionOfAttackers[i, 1] = fieldj;
                                    }
                                }
								if (middleman == false)
								{
									this.numberOfAttackers++;
								}
								this.positionOfAttackers[i, 0] = attackPositions[i, 0]; this.positionOfAttackers[i, 1] = attackPositions[i, 1];
                            }
                        }
                    }
                    else if (28 <= i && i <= 34)
                    {
                        // horizontal right posi
                        if (i == 28 && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "K" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "Q" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "R") && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color != this.Color))
                        {
                            this.numberOfAttackers++;
                            this.positionOfAttackers[i, 0] = attackPositions[i, 0]; this.positionOfAttackers[i, 1] = attackPositions[i, 1];
                        }
                        else
                        {
                            if ((board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "Q" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "R") && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color != this.Color))
                            {
                                for (int g = 28; g < i; g++)
                                {
                                    if (board.boardFields[attackPositions[g, 0], attackPositions[g, 1]].Color == this.Color)
                                    {
										middleman = true;
                                        this.positionOfAttackers[i, 0] = fieldi; this.positionOfAttackers[i, 1] = fieldj;
                                    }
                                }
								if (middleman == false)
								{
									this.numberOfAttackers++;
								}
								this.positionOfAttackers[i, 0] = attackPositions[i, 0]; this.positionOfAttackers[i, 1] = attackPositions[i, 1];
                            }
                        }
                    }
                    else if (35 <= i && i <= 41)
                    {
                        // diagonal right down:
                        if (i == 35 && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "K" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "Q" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "B" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "P") && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color != this.Color))
                        {
                            this.numberOfAttackers++;
                            this.positionOfAttackers[i, 0] = attackPositions[i, 0]; this.positionOfAttackers[i, 1] = attackPositions[i, 1];
                        }
                        else
                        {
                            if ((board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "Q" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "B") && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color != this.Color))
                            {
                                for (int g = 35; g < i; g++)
                                {
                                    if (board.boardFields[attackPositions[g, 0], attackPositions[g, 1]].Color == this.Color)
                                    {
										middleman = true;
                                        this.positionOfAttackers[i, 0] = fieldi; this.positionOfAttackers[i, 1] = fieldj;
                                    }
                                }
								if (middleman == false)
								{
									this.numberOfAttackers++;
								}
								this.positionOfAttackers[i, 0] = attackPositions[i, 0]; this.positionOfAttackers[i, 1] = attackPositions[i, 1];
                            }
                        }
                        this.positionOfAttackers[i, 0] = fieldi; this.positionOfAttackers[i, 1] = fieldj;
                    }
                    else if (42 <= i && i <= 48)
                    {
                        // vertical down positions:
                        if (i == 42 && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "K" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "Q" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "R") && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color != this.Color))
                        {
                            this.numberOfAttackers++;
                            this.positionOfAttackers[i, 0] = attackPositions[i, 0]; this.positionOfAttackers[i, 1] = attackPositions[i, 1];
                        }
                        else
                        {
                            if ((board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "Q" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "R") && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color != this.Color))
                            {
                                for (int g = 42; g < i; g++)
                                {
                                    if (board.boardFields[attackPositions[g, 0], attackPositions[g, 1]].Color == this.Color)
                                    {
										middleman = true;
                                        this.positionOfAttackers[i, 0] = fieldi; this.positionOfAttackers[i, 1] = fieldj;
                                    }
                                }
								if (middleman == false)
								{
									this.numberOfAttackers++;
								}
								this.positionOfAttackers[i, 0] = attackPositions[i, 0]; this.positionOfAttackers[i, 1] = attackPositions[i, 1];
                            }
                        }
                        this.positionOfAttackers[i, 0] = fieldi; this.positionOfAttackers[i, 1] = fieldj;
                    }
                    else if (49 <= i && i <= 55)
                    {
                        // diagonal left down:
                        if (i == 49 && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "K" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "Q" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "B" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "P") && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color != this.Color))
                        {
                            this.numberOfAttackers++;
                            this.positionOfAttackers[i, 0] = attackPositions[i, 0]; this.positionOfAttackers[i, 1] = attackPositions[i, 1];
                        }
                        else
                        {
                            if ((board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "Q" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "B") && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color != this.Color))
                            {
                                for (int g = 49; g < i; g++)
                                {
                                    if (board.boardFields[attackPositions[g, 0], attackPositions[g, 1]].Color == this.Color)
                                    {
										middleman = true;
                                        this.positionOfAttackers[i, 0] = fieldi; this.positionOfAttackers[i, 1] = fieldj;
                                    }
                                }
								if (middleman == false)
								{
									this.numberOfAttackers++;
								}
								this.positionOfAttackers[i, 0] = attackPositions[i, 0]; this.positionOfAttackers[i, 1] = attackPositions[i, 1];
                            }
                        }
                        this.positionOfAttackers[i, 0] = fieldi; this.positionOfAttackers[i, 1] = fieldj;
                    }
                    else if (56 <= i && i <= 63)
                    {
                        // the knight positions:
                        if (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "N" && board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color != this.Color)
                        {
                            this.numberOfAttackers++;
                            this.positionOfAttackers[i, 0] = attackPositions[i, 0]; this.positionOfAttackers[i, 1] = attackPositions[i, 1];
                        }
                    }
                }
                else
                {
                }
            }
            if (this.numberOfAttackers > 0)
			{
				for (int i = 0; i < 64; i++)
				{
                    if (this.positionOfAttackers[i, 0] != fieldi && this.positionOfAttackers[i,1] != fieldj)
					{
					}
				}
				for (int i = 0; i < 64; i++)
				{
				}
				return true;
			}
            else
            {
                for (int i = 0; i < 64; i++)
                {
				}
				for (int i = 0; i < 64; i++)
				{
				}
				return false;
			}
		}
	}
}
