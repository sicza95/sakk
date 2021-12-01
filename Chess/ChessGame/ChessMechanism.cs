using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace ChessGame
{
	class ChessMechanism
	{
		private bool isGameOver;
		private string player;
		private int turnCounter;
		private Chessboard board;
		private object[] playersMovingPieceCoordinates = new object[4];
		private bool validInputStart;
		private bool validInputEnd;

		private bool IsGameOver { get => isGameOver; set => this.isGameOver = value; }
		public string Player { get => player; set => this.player = value; }
		private int TurnCounter { get => turnCounter; set => this.turnCounter = value; }
		private Chessboard Board { get => board; set => this.Board = value; }
		//private object PlayersMovingPieceCoordinates { get; set; }
		private bool ValidInputStart { get => validInputStart; set => this.validInputStart = value; }
		private bool ValidInputEnd { get => validInputEnd; set => this.validInputEnd = value; }

		public ChessMechanism()
        {
			Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
			this.IsGameOver = false;
			this.Player = "W";
			this.TurnCounter = 1;
			this.Board = new Chessboard();
			this.ValidInputStart = false;
			this.ValidInputEnd = false;
		}

		private void ShowInfo()
        {
			Console.WriteLine();
			Console.WriteLine("Type \"exit\" to exit the game.");
			Console.WriteLine("Type \"save\" to save the state of the game.");
			Console.WriteLine("Type \"load\" to load a saved game state.");
			Console.WriteLine("Type \"clear\" to clear the texts, and reload the chessboard.");
			Console.WriteLine("Type \"player\" to get which player has the current turn.");
			Console.WriteLine("Type \"turn\" to get how many steps have been made during the game.");
			Console.WriteLine("Type \"info\" to get this help list.");
			Console.WriteLine();
		}   //Módosítva

		public bool HasTheChosenPieceAndThePlayerSameColor(char chosenFile, int chosenRank, string playerColor)
        {
			Field chosenField = this.Board.fields.FindAll(x => x.File == chosenFile).Find(x => x.Rank == chosenRank);
            if ((chosenField.Piece.Color != "W" && playerColor == "W") || (chosenField.Piece.Color != "B" && playerColor == "B"))
            {
				return false;
            }
			return true;
		}   //Módosítva

		public void Log(int turnCounter)
		{
			if (turnCounter == 1)
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
				if (0 <= starti - 1 && starti - 1 <= 7 && 0 <= startj - 1 && startj - 1 <= 7 && 0 <= starti + 1 && starti + 1 <= 7 && 0 <= startj + 1 && startj + 1 <= 7)
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
			else if (this.boardFields[starti, startj].Color == "B" && this.boardFields[starti, startj].Name == "P")
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
			if (this.boardFields[starti, startj].Name == "K" && this.boardFields[starti, startj].Steps == 0)
			{
				if (this.boardFields[starti, startj].Color == "W")
				{
					if (endi == 7 && endj == 6) //	white - right
					{
						Console.WriteLine("Do You Want to Castle?	(yes/no)");
						if (Console.ReadLine() == "yes")
						{
							if (this.boardFields[7, 7].Steps == 0 && this.boardFields[7, 7].Name == "R")
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
											if (/*this.boardFields[7, 1].IsFieldUnderAttack(7, 1, currentboard) == false &&*/ this.boardFields[7, 2].IsFieldUnderAttack(7, 2, currentboard) == false && this.boardFields[7, 3].IsFieldUnderAttack(7, 3, currentboard) == false)
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
											if (this.boardFields[0, 5].IsFieldUnderAttack(0, 5, currentboard) == false && this.boardFields[0, 6].IsFieldUnderAttack(0, 6, currentboard) == false)
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
									if (/*this.boardFields[starti, startj].IsKingInCheck() == false*/ this.IsKingInCheck(currentboard, "black") == false)
									{
										if (this.boardFields[starti, startj].WillKingBeInCheck(starti, startj, currentboard, starti, startj, endi, endj) == false)
										{
											if (/*this.boardFields[0, 1].IsFieldUnderAttack(0, 1, currentboard) == false &&*/ this.boardFields[0, 2].IsFieldUnderAttack(0, 2, currentboard) == false && this.boardFields[0, 3].IsFieldUnderAttack(0, 3, currentboard) == false)
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

		public bool WillKingBeInCheck(int starti, int startj, int endi, int endj, Chessboard currentboard, string player)
		{
			Field kingsField = this.Board.fields.FindAll(x => x.Piece.Name == "K").Find(x => x.Piece.Color == "W");
			for (int i = 0; i < 8; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					if (player == "white" && this.boardFields[i, j].Name == "K" && this.boardFields[i, j].Color == "W")
					{
						if (this.boardFields[i, j].WillKingBeInCheckKing(i, j, currentboard, starti, startj, endi, endj) == true)
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

		public bool IsKingInCheck(Chessboard currentboard, string player)
		{
			Field playersKingField = this.Board.fields.FindAll(x => x.Piece.Name == "K").Find(x => x.Piece.Color == player);
			if (playersKingField.Piece.IsFieldUnderAttack(playersKingField.File, playersKingField.Rank,currentboard))
            {
				Console.WriteLine($"The ({player}) king is in check!");
				return true;
			}
			Console.WriteLine($"The ({player}) king is not in check! So You can move normally.");
			return false;
		}    //Módosítva

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
								if (0 <= virtualboard.boardFields[kingLocationi, kingLocationj].AttackPositions[g, 0] && virtualboard.boardFields[kingLocationi, kingLocationj].AttackPositions[g, 0] <= 7 && 0 <= virtualboard.boardFields[kingLocationi, kingLocationj].AttackPositions[g, 1] && virtualboard.boardFields[kingLocationi, kingLocationj].AttackPositions[g, 1] <= 7)
								{
									//Console.WriteLine($"{i}{j} - {kingLocationi}{kingLocationj}{virtualboard.boardFields[kingLocationi, kingLocationj].Name} - {virtualboard.boardFields[kingLocationi, kingLocationj].AttackPositions[g, 0]}{virtualboard.boardFields[kingLocationi, kingLocationj].AttackPositions[g, 1]}");
									if (virtualboard.boardFields[i, j].MoveSet(i, j, virtualboard.boardFields[kingLocationi, kingLocationj].AttackPositions[g, 0], virtualboard.boardFields[kingLocationi, kingLocationj].AttackPositions[g, 1], virtualboard, false) == true)
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
									if (virtualboard.boardFields[i, j].MoveSet(i, j, virtualboard.boardFields[kingLocationi, kingLocationj].AttackPositions[g, 0], virtualboard.boardFields[kingLocationi, kingLocationj].AttackPositions[g, 1], virtualboard, false) == true)
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

		public void Commands(string input)
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
				this.ShowInfo();
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
				Console.WriteLine("The given value is not a coordinate and not a proper command.");
			}
		}
		
		public bool IsInputCoordinate(string input)
        {
			if (input.Length == 2 && Char.IsLetter(input[0]) && Char.IsDigit(input[1]))
            {
				return true;
            }
			return false;
		}   //Módosítva

		public void getInputFromPlayer(bool validCoordinate, int[] arr)
        {
			while (!validCoordinate)
			{
				//Qg5;	g5;
				Console.WriteLine();
				string startOrEnd = (nameof(validCoordinate) == "ValidInputStart") ? "start" : "end";
				Console.WriteLine($"Give the file and the rank of the {startOrEnd} position like: g5");
                Console.WriteLine("Or give a Command like: clear");

				string input = Console.ReadLine();

				if (IsInputCoordinate(input))
                {
					char givenFile = Convert.ToChar(input[0]);
					int givenRank = Convert.ToInt32(input[1]);

					foreach (var field in this.Board.fields)
					{
						if (field.File == givenFile && field.Rank == givenRank)
						{
							playersMovingPieceCoordinates[arr[0]] = givenFile;
							playersMovingPieceCoordinates[arr[1]] = givenRank;
							validCoordinate = true;
						}
                        else
                        {
							throw new Exception("A megadott koordináta nem szerepel a táblán.");
						}
					}
				}
                else
                {
					this.Commands(input);
                }
			}
		}   //Módosítva

		public void GetPlayerValidInputCoordinates()
        {
			getInputFromPlayer(this.ValidInputStart, new int[] { 0, 1 });
			getInputFromPlayer(this.ValidInputEnd, new int[] { 2, 3 });
		}   //Módosítva

		public bool IsTheGameOver()
        {
			if (this.IsKingInCheck(this.Board, this.Player))
			{
				if (this.IsCheckMate(this.Board, this.Player))
				{
					Console.WriteLine("Checkmate! The Game Is Over!");
					this.IsGameOver = true;
					return true;
				}
				Console.WriteLine($"The {this.Player}'s King is in check. You can only make moves to get out of check.");
				return false;
			}
			return false;
		}   //Módosítva

		

		public void StartGame()
		{
			Board.DrawBoard();
			this.ShowInfo();

			while (!this.IsGameOver)
            {
                if (IsTheGameOver())
                {
					break;
				}

				this.GetPlayerValidInputCoordinates();
				char startingFile = Convert.ToChar(playersMovingPieceCoordinates[0]);
				int startingRank = Convert.ToInt32(playersMovingPieceCoordinates[1]);
				char endFile = Convert.ToChar(playersMovingPieceCoordinates[2]);
				int endRank = Convert.ToInt32(playersMovingPieceCoordinates[3]);

				if (!this.HasTheChosenPieceAndThePlayerSameColor(startingFile, startingRank, this.Player))
				{
					Console.WriteLine("The chosen field does not contain a chessPiece or the piece's color is not equal to the player's color.");
                    if (this.TurnCounter == 1)
                    {
						Console.WriteLine("White must start the game.");
					}
				}
                else
                {
                    if (this.IsKingInCheck(this.Board,this.Player))
                    {
						if (board.boardFields[startingFile, startingRank].Name != "K" && board.WillKingBeInCheck(startingFile, startingRank, endFile, endRank, board, board.player) == true)
						{
                            Console.WriteLine("You can't move there, because the King still would be in check!");
						}
						else if (board.boardFields[startingFile, startingRank].Name != "K" && board.WillKingBeInCheck(startingFile, startingRank, endFile, endRank, board, board.player) == false)
						{
							board.boardFields[endFile, endRank] = board.boardFields[startingFile, startingRank];
							if (startingFile % 2 == 0)
							{
								if (startingRank % 2 == 0)
								{
									board.boardFields[startingFile, startingRank] = new ChessPiece('w');    //White field
								}
								else
								{
									board.boardFields[startingFile, startingRank] = new ChessPiece('b');    //Black Field
								}
							}
							else
							{
								if (startingRank % 2 == 0)
								{
									board.boardFields[startingFile, startingRank] = new ChessPiece('b');    //White field
								}
								else
								{
									board.boardFields[startingFile, startingRank] = new ChessPiece('w');    //Black Field
								}
							}
							board.DrawBoard();
							Console.WriteLine($"The {board.player} King got out of Check!");
							board.Log(board.turnCounter);
							//Change Player:
							if (board.player == "white")
							{
								board.player = "black";
							}
							else if (board.player == "black")
							{
								board.player = "white";
							}
							board.turnCounter++;
						}
						else if (board.boardFields[startingFile,startingRank].Name == "K" && board.WillKingBeInCheck(startingFile, startingRank, endFile, endRank, board, board.player) == true)
                        {
                            Console.WriteLine("The King can't move there, or it still would be in Check!");
                        }
						else if (board.boardFields[startingFile, startingRank].Name == "K" && board.WillKingBeInCheck(startingFile, startingRank, endFile, endRank, board, board.player) == false)
						{
							board.boardFields[endFile, endRank] = board.boardFields[startingFile, startingRank];
							if (startingFile % 2 == 0)
							{
								if (startingRank % 2 == 0)
								{
									board.boardFields[startingFile, startingRank] = new ChessPiece('w');    //White field
								}
								else
								{
									board.boardFields[startingFile, startingRank] = new ChessPiece('b');    //Black Field
								}
							}
							else
							{
								if (startingRank % 2 == 0)
								{
									board.boardFields[startingFile, startingRank] = new ChessPiece('b');    //White field
								}
								else
								{
									board.boardFields[startingFile, startingRank] = new ChessPiece('w');    //Black Field
								}
							}
							board.DrawBoard();
							Console.WriteLine($"The {board.player} King got out of Check!");
							board.Log(board.turnCounter);
							//Change Player:
							if (board.player == "white")
							{
								board.player = "black";
							}
							else if (board.player == "black")
							{
								board.player = "white";
							}
							board.turnCounter++;
						}
						//Capturing the checking piece, with either the king or another piece.

						//Moving the king to an adjacent square where it is not in check.

						//Blocking the check.
					}
					else if (board.CheckCastling(startingFile, startingRank, endFile, endRank, board) == true)
                    {
						if (board.WillKingBeInCheck(startingFile, startingRank, endFile, endRank, board, board.player) == true)
						{
							Console.WriteLine($"Move can not be made, becasue The {board.player}'s King would be in Check.");
						}
						else
						{
							board.boardFields[endFile, endRank] = board.boardFields[startingFile, startingRank];
							if (startingFile % 2 == 0)
							{
								if (startingRank % 2 == 0)
								{
									board.boardFields[startingFile, startingRank] = new ChessPiece('w');    //White field
								}
								else
								{
									board.boardFields[startingFile, startingRank] = new ChessPiece('b');    //Black Field
								}
							}
							else
							{
								if (startingRank % 2 == 0)
								{
									board.boardFields[startingFile, startingRank] = new ChessPiece('b');    //White field
								}
								else
								{
									board.boardFields[startingFile, startingRank] = new ChessPiece('w');    //Black Field
								}
							}

							if (endFile == 7 && endRank == 6)   //white - right
							{
								board.boardFields[7, 5] = board.boardFields[7, 7];
								board.boardFields[7, 7] = new ChessPiece('w');
							}
							else if (endFile == 7 && endRank == 2)  //white - left
							{
								board.boardFields[7, 3] = board.boardFields[7, 0];
								board.boardFields[7, 0] = new ChessPiece('b');
							}
							else if (endFile == 0 && endRank == 6)  //black - right
							{
								board.boardFields[0, 5] = board.boardFields[0, 7];
								board.boardFields[0, 7] = new ChessPiece('b');
							}
							else if (endFile == 0 && endRank == 2)  //black - left
							{
								board.boardFields[0, 3] = board.boardFields[0, 0];
								board.boardFields[0, 0] = new ChessPiece('w');
							}

							board.DrawBoard();
							Console.WriteLine("A \"Castling\" Move has been made!");
							board.Log(board.turnCounter);
							//Change Player:
							if (board.player == "white")
							{
								board.player = "black";
							}
							else if (board.player == "black")
							{
								board.player = "white";
							}
							board.turnCounter++;
						}
					}
					else if (board.CheckEnPassant(startingFile, startingRank, endFile, endRank) == true)
                    {
						if (board.WillKingBeInCheck(startingFile, startingRank, endFile, endRank, board, board.player) == true)
						{
							Console.WriteLine($"Move can not be made, becasue The {board.player}'s King would be in Check.");
						}
						else
						{
							board.boardFields[endFile, endRank] = board.boardFields[startingFile, startingRank];
							if (startingFile % 2 == 0)
							{
								if (startingRank % 2 == 0)
								{
									board.boardFields[startingFile, startingRank] = new ChessPiece('w');    //White field
								}
								else
								{
									board.boardFields[startingFile, startingRank] = new ChessPiece('b');    //Black Field
								}
							}
							else
							{
								if (startingRank % 2 == 0)
								{
									board.boardFields[startingFile, startingRank] = new ChessPiece('b');    //White field
								}
								else
								{
									board.boardFields[startingFile, startingRank] = new ChessPiece('w');    //Black Field
								}
							}

							if (board.takenPawnPositioni % 2 == 0)
							{
								if (board.takenPawnPositionj % 2 == 0)
								{
									board.boardFields[board.takenPawnPositioni, board.takenPawnPositionj] = new ChessPiece('w');    //White field
								}
								else
								{
									board.boardFields[board.takenPawnPositioni, board.takenPawnPositionj] = new ChessPiece('b');    //Black Field
								}
							}
							else
							{
								if (board.takenPawnPositionj % 2 == 0)
								{
									board.boardFields[board.takenPawnPositioni, board.takenPawnPositionj] = new ChessPiece('b');    //White field
								}
								else
								{
									board.boardFields[board.takenPawnPositioni, board.takenPawnPositionj] = new ChessPiece('w');    //Black Field
								}
							}
							board.CheckPawnPromotion(endFile, endRank);
							board.DrawBoard();
							Console.WriteLine($"{board.takenPawnPositioni},{board.takenPawnPositionj}");
							Console.WriteLine("An \"En Passant\" Move has been made!");
							board.Log(board.turnCounter);
							//Change Player:
							if (board.player == "white")
							{
								board.player = "black";
							}
							else if (board.player == "black")
							{
								board.player = "white";
							}
							board.turnCounter++;
						}
					}
					else if (board.boardFields[startingFile, startingRank].MoveSet(startingFile, startingRank, endFile, endRank, board,true) == true)
					{
						if (board.WillKingBeInCheck(startingFile, startingRank, endFile, endRank, board, board.player) == true)
						{
							Console.WriteLine($"Move can not be made, becasue The {board.player}'s King would be in Check.");
						}
						else
						{
							board.boardFields[endFile, endRank] = board.boardFields[startingFile, startingRank];
							if (startingFile % 2 == 0)
							{
								if (startingRank % 2 == 0)
								{
									board.boardFields[startingFile, startingRank] = new ChessPiece('w');    //White field
								}
								else
								{
									board.boardFields[startingFile, startingRank] = new ChessPiece('b');    //Black Field
								}
							}
							else
							{
								if (startingRank % 2 == 0)
								{
									board.boardFields[startingFile, startingRank] = new ChessPiece('b');    //White field
								}
								else
								{
									board.boardFields[startingFile, startingRank] = new ChessPiece('w');    //Black Field
								}
							}
							board.CheckPawnPromotion(endFile, endRank);
							board.DrawBoard();
							board.Log(board.turnCounter);
							//Change Player:
							if (board.player == "white")
							{
								board.player = "black";
							}
							else if (board.player == "black")
							{
								board.player = "white";
							}
							board.turnCounter++;
						}
					}
					else
					{
						Console.WriteLine("Type in another option.");
					}
                }
			}
            Console.WriteLine("To exit, press a button.");
            Console.ReadLine();
			/*
			int start = int.Parse(Console.ReadLine());
			int temp[]
            Console.WriteLine("írd be a cél pozíció értékét(pl: 5.sor 4.oszlop) = 54");
			Console.WriteLine("Csak a táblán megadott értékek érvényesek.");
			int end = int.Parse(Console.ReadLine());
			string chosenPieceColor = board[]
			*/
		}   //Módosítás folyamatban

	}
}
