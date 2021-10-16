using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ChessGame
{
    class Chessboard
    {
		public string player;
		public int turnCounter;
		public ChessPiece[,] boardFields = new ChessPiece[8,8];
		public int takenPawnPositioni;
		public int takenPawnPositionj;

		//	Drawing the Board.
		public void DrawBoard()
		{
			Console.Clear();
            Console.WriteLine();
			int g = 2;				//indexing helper.
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

		public Chessboard(Chessboard currentboard)
		{
			this.player = currentboard.player;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
					this.boardFields[i, j] = currentboard.boardFields[i, j];
                }
            }
		}

        public bool GetColor(int starti, int startj, string playerColor)
        {
			if((boardFields[starti,startj].Color != "W" && playerColor == "white") || (boardFields[starti, startj].Color != "B" && playerColor == "black"))
            {
				return false;
            }
			return true;
        }

		public void Options(string input)
        {
			if (input == "clear")
			{
				this.DrawBoard();
				Console.WriteLine("The table is being reloaded.");
			}
			else if (input == "exit")
			{
				Console.WriteLine("The Game will exit in 3 seconds. Thank You for playing.");
				System.Threading.Thread.Sleep(3000);
				System.Environment.Exit(0);
			}
			else if (input == "info")
			{
				Console.WriteLine();
				Console.WriteLine("Type \"exit\" to exit the game.");
				Console.WriteLine("Type \"save\" to save the state of the game.");
				Console.WriteLine("Type \"load\" to load a saved game state.");
				Console.WriteLine("Type \"clear\" to clear the texts, and reload the chessboard.");
				Console.WriteLine("Type \"player\" to get which player has the current turn.");
				Console.WriteLine("Type \"turn\" to get how many steps have been made during the game.");
				Console.WriteLine("Type \"info\" to get this help list.");
			}
			else if (input == "player")
			{
				Console.WriteLine($"Now the {this.player} player has to step.");
			}
			else if (input == "turn")
			{
				Console.WriteLine($"This is the {this.turnCounter}. step in the game.");
			}
			else if (input == "save")
			{
				using (var gamestate = new StreamWriter("savedgamestate.txt", false, Encoding.Default))
				{
					gamestate.WriteLine("fieldRow;fieldCol;fieldColor;fieldPiece");
					gamestate.WriteLine($"{this.turnCounter};{this.player}");
					for (int i = 0; i < 8; i++)
					{
						for (int j = 0; j < 8; j++)
						{
							gamestate.Write($"{i};{j};{this.boardFields[i, j].Color};{this.boardFields[i, j].Name}\n");
						}
					}
				}
				System.Threading.Thread.Sleep(1000);
				Console.WriteLine("The game is saved.");
			}
			else if (input == "load")
			{
				using (var gamestate = new StreamReader("savedgamestate.txt"))
				{
					string[] temp2 = new string[4];
					gamestate.ReadLine().Skip(1);
					temp2 = gamestate.ReadLine().Split(';');
					this.turnCounter = int.Parse(temp2[0]);
					this.player = temp2[1];
					while (!gamestate.EndOfStream)
					{
						temp2 = gamestate.ReadLine().Split(';');
						int indexi = int.Parse(temp2[0]);
						int indexj = int.Parse(temp2[1]);
						char color = char.Parse(temp2[2]);
						if (temp2[3] == "R")
						{
							this.boardFields[indexi, indexj] = new ChessRook(color);
						}
						else if (temp2[3] == "N")
						{
							this.boardFields[indexi, indexj] = new ChessKnight(color);
						}
						else if (temp2[3] == "B")
						{
							this.boardFields[indexi, indexj] = new ChessBishop(color);
						}
						else if (temp2[3] == "Q")
						{
							this.boardFields[indexi, indexj] = new ChessQueen(color);
						}
						else if (temp2[3] == "K")
						{
							this.boardFields[indexi, indexj] = new ChessKing(color);
						}
						else if (temp2[3] == "P")
						{
							this.boardFields[indexi, indexj] = new ChessPawn(color);
						}
						else
						{
							this.boardFields[indexi, indexj] = new ChessPiece(color);
						}
					}
				}
				Console.WriteLine("Loading the saved game.");
				System.Threading.Thread.Sleep(2000);
				this.DrawBoard();
			}
			else
			{
				Console.WriteLine("The given value is not a number.");
			}
		}

		public void Log(int turnCounter)
        {
			if(turnCounter == 1)
            {
				using (var gameLog = new StreamWriter("gameLog.txt", false, Encoding.Default))
				{
					gameLog.WriteLine("turn;player;fieldRow fieldCol fieldColor fieldPiece;");
					Chessboard board = new Chessboard();
					gameLog.Write($"0;{this.player};");
					for (int i = 0; i < 8; i++)
					{
						for (int j = 0; j < 8; j++)
						{
							if (i == 7 && j == 7)
							{
								gameLog.Write($"{i}{j}{board.boardFields[i, j].Color}{board.boardFields[i, j].Name}\n");
							}
							else
							{
								gameLog.Write($"{i}{j}{board.boardFields[i, j].Color}{board.boardFields[i, j].Name};");
							}
						}
					}
				}
			}
			using (var gameLog = new StreamWriter("gameLog.txt", true, Encoding.Default))
			{
				gameLog.Write($"{this.turnCounter};{this.player};");
				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 8; j++)
					{
                        if (i == 7 && j == 7)
                        {
							gameLog.Write($"{i}{j}{this.boardFields[i, j].Color}{this.boardFields[i, j].Name}\n");
						}
                        else
						{
							gameLog.Write($"{i}{j}{this.boardFields[i, j].Color}{this.boardFields[i, j].Name};");
						}
					}
				}
			}
		}

		public void CheckPawnPromotion(int endi, int endj)
		{
			if (this.boardFields[endi, endj].Name == "P" && this.boardFields[endi, endj].Color == "W" && endi == 0)
			{
				Console.WriteLine($"The Pawn on {endi}{endj} can be promoted! Choose another Piece to replace the pawn (queen,bishop,rook or knight) can be chosen.");
				bool promotedPieceChosen = false;
				do
				{
					string promotedPiece = Console.ReadLine();
					if (promotedPiece == "queen")
					{
						this.boardFields[endi, endj] = new ChessQueen('W');
						promotedPieceChosen = true;
					}
					else if (promotedPiece == "bishop")
					{
						this.boardFields[endi, endj] = new ChessBishop('W');
						promotedPieceChosen = true;
					}
					else if (promotedPiece == "rook")
					{
						this.boardFields[endi, endj] = new ChessRook('W');
						promotedPieceChosen = true;
					}
					else if (promotedPiece == "knight")
					{
						this.boardFields[endi, endj] = new ChessKnight('W');
						promotedPieceChosen = true;
					}
				} while (promotedPieceChosen == false);
			}
			else if (this.boardFields[endi, endj].Name == "P" && this.boardFields[endi, endj].Color == "B" && endi == 7)
			{
				Console.WriteLine($"The Pawn on {endi}{endj} can be promoted! Choose another Piece to replace the pawn (queen,bishop,rook or knight) can be chosen.");
				bool promotedPieceChosen = false;
				do
				{
					string promotedPiece = Console.ReadLine();
					if (promotedPiece == "queen")
					{
						this.boardFields[endi, endj] = new ChessQueen('B');
						promotedPieceChosen = true;
					}
					else if (promotedPiece == "bishop")
					{
						this.boardFields[endi, endj] = new ChessBishop('B');
						promotedPieceChosen = true;
					}
					else if (promotedPiece == "rook")
					{
						this.boardFields[endi, endj] = new ChessRook('B');
						promotedPieceChosen = true;
					}
					else if (promotedPiece == "knight")
					{
						this.boardFields[endi, endj] = new ChessKnight('B');
						promotedPieceChosen = true;
					}
				} while (promotedPieceChosen == false);
			}
		}

		public bool CheckEnPassant(int starti, int startj, int endi, int endj)
        {
            if (this.boardFields[starti, startj].Color == "W" && this.boardFields[starti, startj].Name == "P")
            {
                if (0 <= starti-1 && starti-1 <= 7 && 0 <= startj-1 && startj-1 <= 7 && 0 <= starti + 1 && starti + 1 <= 7 && 0 <= startj + 1 && startj + 1 <= 7)
                {
					if (this.boardFields[starti, startj - 1].Name == "P" && this.boardFields[starti, startj - 1].Color == "B" && this.boardFields[starti, startj - 1].EnPassant == true)
					{
						if (endi == starti - 1 && endj == startj - 1)
						{
							this.takenPawnPositioni = starti;
							this.takenPawnPositionj = startj - 1;
							return true;
						}
						return false;
					}
					else if (this.boardFields[starti, startj + 1].Name == "P" && this.boardFields[starti, startj + 1].Color == "B" && this.boardFields[starti, startj + 1].EnPassant == true)
					{
						if (endi == starti - 1 && endj == startj + 1)
						{
							this.takenPawnPositioni = starti;
							this.takenPawnPositionj = startj + 1;
							return true;
						}
						return false;
					}
					return false;
				}
				return false;
			}
            else if(this.boardFields[starti, startj].Color == "B" && this.boardFields[starti, startj].Name == "P")
            {
				if (0 <= starti - 1 && starti - 1 <= 7 && 0 <= startj - 1 && startj - 1 <= 7 && 0 <= starti + 1 && starti + 1 <= 7 && 0 <= startj + 1 && startj + 1 <= 7)
				{
					if (this.boardFields[starti, startj - 1].Name == "P" && this.boardFields[starti, startj - 1].Color == "W" && this.boardFields[starti, startj - 1].EnPassant == true)
					{
						if (endi == starti + 1 && endj == startj - 1)
						{
							this.takenPawnPositioni = starti;
							this.takenPawnPositionj = startj - 1;
							return true;
						}
						return false;
					}
					else if (this.boardFields[starti, startj + 1].Name == "P" && this.boardFields[starti, startj + 1].Color == "W" && this.boardFields[starti, startj + 1].EnPassant == true)
					{
						if (endi == starti + 1 && endj == startj + 1)
						{
							this.takenPawnPositioni = starti;
							this.takenPawnPositionj = startj + 1;
							return true;
						}
						return false;
					}
					return false;
				}
                return false;
			}
			return false;
        }

		public bool CheckCastling(int starti, int startj, int endi, int endj, Chessboard currentboard)
		{
            if (this.boardFields[starti,startj].Name == "K" && this.boardFields[starti, startj].Steps == 0)
            {
				if (this.boardFields[starti, startj].Color == "W")
				{
					if (endi == 7 && endj == 6)	//	white - right
					{
                        Console.WriteLine("Do You Want to Castle?	(yes/no)");
                        if (Console.ReadLine() == "yes")
                        {
							if(this.boardFields[7,7].Steps == 0 && this.boardFields[7,7].Name == "R")
                            {
                                if ((this.boardFields[7, 5].Color == "w" || this.boardFields[7, 5].Color == "b") && (this.boardFields[7, 6].Color == "w" || this.boardFields[7, 6].Color == "b"))
                                {
                                    if (/*this.boardFields[starti, startj].IsKingInCheck() == false*/ this.IsKingInCheck(currentboard, "white") == false)
                                    {
										if (this.boardFields[starti, startj].WillKingBeInCheck(starti, startj, currentboard, starti, startj, endi, endj) == false)
										{
                                            if (this.boardFields[7, 5].IsFieldUnderAttack(7, 5, currentboard) == false && this.boardFields[7, 6].IsFieldUnderAttack(7, 6, currentboard) == false)
                                            {
												return true;
                                            }
											return false;
										}
										Console.WriteLine("Cannot make move, because The king will be in check.");
										return false;
									}
                                    Console.WriteLine("The king is in check.");
									return false;
								}
                                else
                                {
                                    Console.WriteLine("Some Fields are occupied by another piece.");
									return false;
                                }
                            }
                            else
                            {
                                Console.WriteLine("You can't castle, because the rook has already moved.");
								return false;
                            }
                        }
						return false;
					}
					else if (endi == 7 && endj == 2)    //	white - left
					{
						Console.WriteLine("Do You Want to Castle?	(yes/no)");
						if (Console.ReadLine() == "yes")
						{
							if (this.boardFields[7, 0].Steps == 0 && this.boardFields[7, 0].Name == "R")
							{
								if ((this.boardFields[7, 1].Color == "w" || this.boardFields[7, 1].Color == "b") && (this.boardFields[7, 2].Color == "w" || this.boardFields[7, 2].Color == "b") && (this.boardFields[7, 3].Color == "w" || this.boardFields[7, 3].Color == "b"))
								{
									if (/*this.boardFields[starti, startj].IsKingInCheck() == false*/ this.IsKingInCheck(currentboard, "white") == false)
									{
										if (this.boardFields[starti, startj].WillKingBeInCheck(starti, startj, currentboard, starti, startj, endi, endj) == false)
										{
                                            if (/*this.boardFields[7, 1].IsFieldUnderAttack(7, 1, currentboard) == false &&*/ this.boardFields[7, 2].IsFieldUnderAttack(7, 2, currentboard) == false && this.boardFields[7, 3].IsFieldUnderAttack(7, 3, currentboard) == false )
                                            {
												return true;
                                            }
											return false;
										}
										Console.WriteLine("Cannot make move, because The king will be in check.");
										return false;
									}
									Console.WriteLine("The king is in check.");
									return false;
								}
								else
								{
									Console.WriteLine("Some Fields are occupied by another piece.");
									return false;
								}
							}
							else
							{
								Console.WriteLine("You can't castle, because the rook has already moved.");
								return false;
							}
						}
						return false;
					}
					return false;
				}
				else
				{
					if (endi == 0 && endj == 6) //	black - right
					{
						Console.WriteLine("Do You Want to Castle?	(yes/no)");
						if (Console.ReadLine() == "yes")
						{
							if (this.boardFields[0, 7].Steps == 0 && this.boardFields[0, 7].Name == "R")
							{
								if ((this.boardFields[0, 5].Color == "w" || this.boardFields[0, 5].Color == "b") && (this.boardFields[0, 6].Color == "w" || this.boardFields[0, 6].Color == "b"))
								{
									if (/*this.boardFields[starti, startj].IsKingInCheck() == false*/ this.IsKingInCheck(currentboard, "black") == false)
									{
										if (this.boardFields[starti, startj].WillKingBeInCheck(starti, startj, currentboard, starti, startj, endi, endj) == false)
										{
											if (this.boardFields[0, 5].IsFieldUnderAttack(0, 5, currentboard) == false && this.boardFields[0, 6].IsFieldUnderAttack(0, 6, currentboard) == false )
											{
												return true;
											}
											return false;
										}
										Console.WriteLine("Cannot make move, because The king will be in check.");
										return false;
									}
									Console.WriteLine("The king is in check.");
									return false;
								}
								else
								{
									Console.WriteLine("Some Fields are occupied by another piece.");
									return false;
								}
							}
							else
							{
								Console.WriteLine("You can't castle, because the rook has already moved.");
								return false;
							}
						}
						return false;
					}
					else if (endi == 0 && endj == 2)    //	black - left
					{
						Console.WriteLine("Do You Want to Castle?	(yes/no)");
						if (Console.ReadLine() == "yes")
						{
							if (this.boardFields[0, 0].Steps == 0 && this.boardFields[0, 0].Name == "R")
							{
								if ((this.boardFields[0, 1].Color == "w" || this.boardFields[0, 1].Color == "b") && (this.boardFields[0, 2].Color == "w" || this.boardFields[0, 2].Color == "b") && (this.boardFields[0, 3].Color == "w" || this.boardFields[0, 3].Color == "b"))
								{
									if (/*this.boardFields[starti, startj].IsKingInCheck() == false*/ this.IsKingInCheck(currentboard,"black") == false)
									{
										if (this.boardFields[starti, startj].WillKingBeInCheck(starti,startj,currentboard,starti,startj,endi,endj) == false)
										{
                                            if (/*this.boardFields[0, 1].IsFieldUnderAttack(0, 1, currentboard) == false &&*/ this.boardFields[0, 2].IsFieldUnderAttack(0, 2, currentboard) == false && this.boardFields[0, 3].IsFieldUnderAttack(0, 3, currentboard) == false )
                                            {
												return true;
                                            }
                                            Console.WriteLine("Some fields are under attack!");
											return false;
										}
										Console.WriteLine("Cannot make move, because The king will be in check.");
										return false;
									}
									Console.WriteLine("The king is in check.");
									return false;
								}
								else
								{
									Console.WriteLine("Some Fields are occupied by another piece.");
									return false;
								}
							}
							else
							{
								Console.WriteLine("You can't castle, because the rook has already moved.");
								return false;
							}
						}
						return false;
					}
				}
            }
			return false;
		}

		public bool IsKingInCheck(Chessboard currentboard, string player)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if ( player == "white" && this.boardFields[i,j].Name == "K" && this.boardFields[i,j].Color == "W")
                    {
                        if (this.boardFields[i, j].IsFieldUnderAttack(i, j, currentboard) == true)
                        {
                            //Console.WriteLine("The white king is in check!");
							return true;
                        }
                        //Console.WriteLine($"{i}, {j}, {currentboard.boardFields[i,j].IsFieldUnderAttack(i,j,currentboard)}, {currentboard.boardFields[i,j].Name}, {currentboard.boardFields[i, j].Color}");
                        //Console.WriteLine(currentboard.player);
                        Console.WriteLine("The white king is not in check! So You can move normally.");
						return false;
                    }
                    else if (player == "black" && this.boardFields[i, j].Name == "K" && this.boardFields[i, j].Color == "B")
                    {
						if (this.boardFields[i, j].IsFieldUnderAttack(i, j, currentboard) == true)
						{
                            Console.WriteLine("The black king is in check!");
							return true;
						}
						Console.WriteLine("The black king is not in check! So You can move normally.");
						return false;
					}
                }  
            }
            Console.WriteLine("The player is not black nor white, or there are no kings on the table.");
			return false;
        }

		public bool WillKingBeInCheck(int starti, int startj, int endi, int endj, Chessboard currentboard, string player)
		{
			for (int i = 0; i < 8; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					if (player == "white" && this.boardFields[i, j].Name == "K" && this.boardFields[i, j].Color == "W")
					{
                        if (this.boardFields[i, j].WillKingBeInCheck(i, j, currentboard, starti, startj, endi, endj) == true)
                        {
							return true;
                        }
						return false;
                        
					}
					else if (player == "black" && this.boardFields[i, j].Name == "K" && this.boardFields[i, j].Color == "B")
					{
						if (this.boardFields[i, j].WillKingBeInCheck(i, j, currentboard, starti, startj, endi, endj) == true)
						{
							return true;
						}
						return false;
					}
				}
			}
			Console.WriteLine("The player is not black nor white, or there are no kings on the table.");
			return false;
		}

		public bool IsCheckMate(Chessboard currentboard, string player)
        {
			Chessboard virtualboard = new Chessboard(currentboard);
			int kingLocationi = 0;
			int kingLocationj = 0;
			//get the position of the king in check
			for (int i = 0; i < 8; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					if (player == "white" && virtualboard.boardFields[i, j].Name == "K" && this.boardFields[i, j].Color == "W")
					{
						kingLocationi = i;
						kingLocationj = j;
					}
					else if (player == "black" && virtualboard.boardFields[i, j].Name == "K" && this.boardFields[i, j].Color == "B")
					{
						kingLocationi = i;
						kingLocationj = j;
					}
				}
			}
            //virtualboard.boardFields[kingLocationi, kingLocationj].IsFieldUnderAttack(kingLocationj, kingLocationj, virtualboard);
            //moving the king and checking if it will be in check
            //int kingPossibleMoves = 0;

			if (virtualboard.boardFields[kingLocationi, kingLocationj].MoveSet2(kingLocationi, kingLocationj, virtualboard) == true)
            {
                Console.WriteLine("király mozoghat");
                //Console.WriteLine($"{kingLocationi}{kingLocationj}");
				return false;
            }
            else if (virtualboard.boardFields[kingLocationi, kingLocationj].MoveSet2(kingLocationi, kingLocationj, virtualboard) == false)
            {

                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (virtualboard.boardFields[i, j].Color == "W" && virtualboard.boardFields[i, j].Name != "K" && player == "white")
                        {
                            for (int g = 0; g < 64; g++)
                            {
								//virtualboard.boardFields[kingLocationi, kingLocationj].IsFieldUnderAttack(kingLocationi, kingLocationj, virtualboard);
								//Console.WriteLine($"{virtualboard.boardFields[i, j].Name}");
								if ( 0 <= virtualboard.boardFields[kingLocationi, kingLocationj].AttackPositions[g, 0] && virtualboard.boardFields[kingLocationi, kingLocationj].AttackPositions[g, 0] <= 7 && 0 <= virtualboard.boardFields[kingLocationi, kingLocationj].AttackPositions[g, 1] && virtualboard.boardFields[kingLocationi, kingLocationj].AttackPositions[g, 1] <= 7)
								{
									//Console.WriteLine($"{i}{j} - {kingLocationi}{kingLocationj}{virtualboard.boardFields[kingLocationi, kingLocationj].Name} - {virtualboard.boardFields[kingLocationi, kingLocationj].AttackPositions[g, 0]}{virtualboard.boardFields[kingLocationi, kingLocationj].AttackPositions[g, 1]}");
									if (virtualboard.boardFields[i, j].MoveSet(i, j, virtualboard.boardFields[kingLocationi, kingLocationj].AttackPositions[g, 0], virtualboard.boardFields[kingLocationi, kingLocationj].AttackPositions[g, 1], virtualboard,false) == true)
									{
										//Console.WriteLine("léphet");
										if (virtualboard.boardFields[kingLocationi, kingLocationj].WillKingBeInCheck(kingLocationi, kingLocationj, virtualboard, i, j, virtualboard.boardFields[kingLocationi, kingLocationj].AttackPositions[g, 0], virtualboard.boardFields[kingLocationi, kingLocationj].AttackPositions[g, 1]) == false)
										{
											//Console.WriteLine("léphet és a király nem lesz sakkban.");
											Console.WriteLine("A Piece can help the King to Get out of Check! white");
											return false;
										}
									} 
								}
							}
							//Console.WriteLine("A király sakkban marad white");
							//return true;
						}
                        else if (virtualboard.boardFields[i, j].Color == "B" && player == "black")
                        {
							for (int g = 0; g < 64; g++)
							{
								if (0 <= virtualboard.boardFields[kingLocationi, kingLocationj].AttackPositions[g, 0] && virtualboard.boardFields[kingLocationi, kingLocationj].AttackPositions[g, 0] <= 7 && 0 <= virtualboard.boardFields[kingLocationi, kingLocationj].AttackPositions[g, 1] && virtualboard.boardFields[kingLocationi, kingLocationj].AttackPositions[g, 1] <= 7)
								{
									if (virtualboard.boardFields[i, j].MoveSet(i, j, virtualboard.boardFields[kingLocationi, kingLocationj].AttackPositions[g, 0], virtualboard.boardFields[kingLocationi, kingLocationj].AttackPositions[g, 1], virtualboard,false) == true)
									{

										if (virtualboard.boardFields[kingLocationi, kingLocationj].WillKingBeInCheck(kingLocationi, kingLocationj, virtualboard, i, j, virtualboard.boardFields[kingLocationi, kingLocationj].AttackPositions[g, 0], virtualboard.boardFields[kingLocationi, kingLocationj].AttackPositions[g, 1]) == false)
										{
											Console.WriteLine("A Piece can help the King to Get out of Check! black");
											return false;
										}
									}
								}
							}
							//Console.WriteLine("A király sakkban marad black");
							//return true;
						}
						
                    }
                }
            }
            //moving another piece and checking if the king will be in check
            //Console.WriteLine("Ez a checkmate vége");
			return true;
		}











			/*

			class CBoard
			{
				public:
		CBoard()
				{                                     //Default Board constructor array initial value is 0,0
					for (int iRow = 0; iRow < 8; ++iRow)
					{
						for (int iCol = 0; iCol < 8; ++iCol)
						{
							mqpaaBoard[iRow][iCol] = 0;
						}
					}
					// Allocate and place black pieces            //Dynamically allocates Pieces on the Board (Black Pieces)
					for (int iCol = 0; iCol < 8; ++iCol)
					{
						mqpaaBoard[6][iCol] = new CPawn('B');
					}
					mqpaaBoard[7][0] = new CRook('B');
					mqpaaBoard[7][1] = new CKnight('B');
					mqpaaBoard[7][2] = new CBishop('B');
					mqpaaBoard[7][3] = new CKing('B');
					mqpaaBoard[7][4] = new CQueen('B');
					mqpaaBoard[7][5] = new CBishop('B');
					mqpaaBoard[7][6] = new CKnight('B');
					mqpaaBoard[7][7] = new CRook('B');
					// Allocate and place white pieces            //Dynamically allocates Pieces on the Board (White Pieces)
					for (int iCol = 0; iCol < 8; ++iCol)
					{
						mqpaaBoard[1][iCol] = new CPawn('W');
					}
					mqpaaBoard[0][0] = new CRook('W');
					mqpaaBoard[0][1] = new CKnight('W');
					mqpaaBoard[0][2] = new CBishop('W');
					mqpaaBoard[0][3] = new CKing('W');
					mqpaaBoard[0][4] = new CQueen('W');
					mqpaaBoard[0][5] = new CBishop('W');
					mqpaaBoard[0][6] = new CKnight('W');
					mqpaaBoard[0][7] = new CRook('W');        //----
				}
				~CBoard()
				{                                    //Allocated by the desctructor when the game is over.
					for (int iRow = 0; iRow < 8; ++iRow)
					{
						for (int iCol = 0; iCol < 8; ++iCol)
						{
							delete mqpaaBoard[iRow][iCol];
							mqpaaBoard[iRow][iCol] = 0;
						}
					}
				}

				void Print()
				{                                             //this whole thing Prints the board to the Console:
					using namespace std;
			const int kiSquareWidth = 4;
		const int kiSquareHeight = 3;
			for (int iRow = 0; iRow< 8*kiSquareHeight; ++iRow) {
				int iSquareRow = iRow / kiSquareHeight;
				// Print side border with numbering                          //Side Numbering
				if (iRow % 3 == 1) {
					cout << '-' << (char) ('1' + 7 - iSquareRow) << '-';
				} else {
					cout << "---";
				}
	// Print the chess board                                         //The actual Board
	for (int iCol = 0; iCol < 8 * kiSquareWidth; ++iCol)
	{
		int iSquareCol = iCol / kiSquareWidth;
		if (((iRow % 3) == 1) && ((iCol % 4) == 1 || (iCol % 4) == 2) && mqpaaBoard[7 - iSquareRow][iSquareCol] != 0)
		{
			if ((iCol % 4) == 1)
			{
				cout << mqpaaBoard[7 - iSquareRow][iSquareCol]->GetColor();         //GetColor function: Outputs "B" or "W" and
			}
			else
			{
				cout << mqpaaBoard[7 - iSquareRow][iSquareCol]->GetPiece();         //GetPiece(): gives the piece type:
			}                                                                     //   "P" "B" "Q" "N" "R" "K"
		}
		else
		{
			if ((iSquareRow + iSquareCol) % 2 == 1)
			{                      //  Black an White squares '*' - white ' ' - black
				cout << '*';
			}
			else
			{
				cout << ' ';
			}
		}
	}
	cout << endl;
			}
			// Print the bottom border with numbers                               //Bottom Numbering
			for (int iRow = 0; iRow < kiSquareHeight; ++iRow)
	{
		if (iRow % 3 == 1)
		{
			cout << "---";
			for (int iCol = 0; iCol < 8 * kiSquareWidth; ++iCol)
			{
				int iSquareCol = iCol / kiSquareWidth;
				if ((iCol % 4) == 1)
				{
					cout << (iSquareCol + 1);
				}
				else
				{
					cout << '-';
				}
			}
			cout << endl;
		}
		else
		{
			for (int iCol = 1; iCol < 9 * kiSquareWidth; ++iCol)
			{
				cout << '-';
			}
			cout << endl;
		}
	}
		}

		bool IsInCheck(char cColor)
	{      //Finds the location of the King of the given color, runs over                                                                        //the entire board to see whether any pieces of the opposite color can take the king.
		   // Find the king
		int iKingRow;
		int iKingCol;
		for (int iRow = 0; iRow < 8; ++iRow)
		{
			for (int iCol = 0; iCol < 8; ++iCol)
			{
				if (mqpaaBoard[iRow][iCol] != 0)
				{
					if (mqpaaBoard[iRow][iCol]->GetColor() == cColor)
					{
						if (mqpaaBoard[iRow][iCol]->GetPiece() == 'K')
						{
							iKingRow = iRow;
							iKingCol = iCol;
						}
					}
				}
			}
		}
		// Run through the opponent's pieces and see if any can take the king
		for (int iRow = 0; iRow < 8; ++iRow)
		{
			for (int iCol = 0; iCol < 8; ++iCol)
			{
				if (mqpaaBoard[iRow][iCol] != 0)
				{
					if (mqpaaBoard[iRow][iCol]->GetColor() != cColor)
					{
						if (mqpaaBoard[iRow][iCol]->IsLegalMove(iRow, iCol, iKingRow, iKingCol, mqpaaBoard))
						{
							return true;
						}
					}
				}
			}
		}

		return false;
	}

	bool CanMove(char cColor)
	{
		// Run through all pieces
		for (int iRow = 0; iRow < 8; ++iRow)
		{
			for (int iCol = 0; iCol < 8; ++iCol)
			{
				if (mqpaaBoard[iRow][iCol] != 0)
				{
					// If it is a piece of the current player, see if it has a legal move
					if (mqpaaBoard[iRow][iCol]->GetColor() == cColor)
					{     //CanMove runs over all the board's squares to 
						  //find each piece of the current players color and than runs over all the square of the board to check whether any move with this piece is legal and does not lead the current player in check
						for (int iMoveRow = 0; iMoveRow < 8; ++iMoveRow)
						{
							for (int iMoveCol = 0; iMoveCol < 8; ++iMoveCol)
							{
								if (mqpaaBoard[iRow][iCol]->IsLegalMove(iRow, iCol, iMoveRow, iMoveCol, mqpaaBoard))
								{
									// Make move and check whether king is in check
									CAPiece* qpTemp = mqpaaBoard[iMoveRow][iMoveCol];
									mqpaaBoard[iMoveRow][iMoveCol] = mqpaaBoard[iRow][iCol];
									mqpaaBoard[iRow][iCol] = 0;
									bool bCanMove = !IsInCheck(cColor);
									// Undo the move
									mqpaaBoard[iRow][iCol] = mqpaaBoard[iMoveRow][iMoveCol];
									mqpaaBoard[iMoveRow][iMoveCol] = qpTemp;
									if (bCanMove)
									{
										return true;
									}
								}
							}
						}
					}
				}
			}
		}
		return false;
	}

	CAPiece* mqpaaBoard[8][8];     // the board's data 8*8 array that points to (class) Pieces.
	};

	*/












		}
}
