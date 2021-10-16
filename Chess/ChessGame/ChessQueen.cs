using System;

namespace ChessGame
{
    class ChessQueen : ChessPiece
    {
		char name;
		char color;
		int[,] queenPositions = new int[56, 2];
		int[,] attackPositions = new int[64, 2];
		public ChessQueen(char color) : base(color)
		{
			this.name = 'Q';
			this.color = color;
		}
		public override string Name => this.name.ToString();
		public override string Color => this.color.ToString();
		public override bool MoveSet(int starti, int startj, int endi, int endj, Chessboard currentboard, bool kiiras)
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
                if (0 <= queenPositions[i, 0] && queenPositions[i, 0] <= 7 && 0 <= queenPositions[i, 1] && queenPositions[i, 1] <= 7)
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
                                        if (kiiras == true)
                                        {
											Console.WriteLine("The Queen can't jump over other Pieces.");
										}
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
                                        if (kiiras == true)
                                        {
											Console.WriteLine("The Queen can't jump over other Pieces.");
										}
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
                                        if (kiiras == true)
                                        {
											Console.WriteLine("The Queen can't jump over other Pieces.");
										}
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
                                        if (kiiras == true)
                                        {
											Console.WriteLine("The Queen can't jump over other Pieces.");
										}
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
                                        if (kiiras == true)
                                        {
											Console.WriteLine("The Queen can't jump over other Pieces.");
										}
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
                                        if (kiiras == true)
                                        {
											Console.WriteLine("The Queen can't jump over other Pieces.");
										}
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
                                        if (kiiras == true)
                                        {
											Console.WriteLine("The Queen can't jump over other Pieces.");
										}
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
                                        if (kiiras == true)
                                        {
											Console.WriteLine("The Queen can't jump over other Pieces.");
										}
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
                                        if (kiiras == true)
                                        {
											Console.WriteLine("The Queen can't jump over other Pieces.");
										}
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
                                        if (kiiras == true)
                                        {
											Console.WriteLine("The Queen can't jump over other Pieces.");
										}
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
                                        if (kiiras == true)
                                        {
											Console.WriteLine("The Queen can't jump over other Pieces.");
										}
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
                                        if (kiiras == true)
                                        {
											Console.WriteLine("The Queen can't jump over other Pieces.");
										}
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
                                        if (kiiras == true)
                                        {
											Console.WriteLine("The Queen can't jump over other Pieces.");
										}
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
                                        if (kiiras == true)
                                        {
											Console.WriteLine("The Queen can't jump over other Pieces.");
										}
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
                                        if (kiiras == true)
                                        {
											Console.WriteLine("The Queen can't jump over other Pieces.");
										}
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
                                        if (kiiras == true)
                                        {
											Console.WriteLine("The Queen can't jump over other Pieces.");
										}
                                        return false;
                                    }
                                }
                            }
                            return true;
                        }
                    }
                }
            }
            if (kiiras == true)
            {
				Console.WriteLine("The Queen can't step here.");
			}
			return false;
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
						if (i == 0 && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "K" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "Q" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "R") && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color != this.Color) )
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
						if (i == 49 && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "K" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "Q" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "B" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "P") && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color != this.Color) )
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
	}
}
