using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ChessGame
{
    class ChessMechanism
    {
		public void StartGame()
		{
			//ChessKnight knight = new ChessKnight('W');
			//knight.MoveSet(3, 4,5,5);
			Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
			bool endGame = false;
			Chessboard board = new Chessboard();
			board.DrawBoard();
			int[] temp = new int[4];
			board.player = "white";
			board.turnCounter = 1;
			//Console.WriteLine();
            Console.WriteLine("Type \"exit\" to exit the game.");
			Console.WriteLine("Type \"save\" to save the state of the game.");
			Console.WriteLine("Type \"load\" to load a saved game state.");
			Console.WriteLine("Type \"clear\" to clear the texts, and reload the chessboard.");
			Console.WriteLine("Type \"player\" to get which player has the current turn.");
			Console.WriteLine("Type \"turn\" to get how many steps have been made during the game.");
            Console.WriteLine("Type \"info\" to get this help list.");
            Console.WriteLine();

			while (endGame == false)
            {
				if (board.IsKingInCheck(board, board.player) == true)
				{
					if (board.IsCheckMate(board, board.player) == true)
					{
						Console.WriteLine("Checkmate! The Game Is Over!");
						endGame = true;
						break;
					}
					//Console.WriteLine(board.player);
					Console.WriteLine($"The {board.player}'s King is in check. You can only make moves to get out of check.");
				}
				
				bool validInputStart = false;
				while (validInputStart == false)
				{
					Console.WriteLine();
					Console.WriteLine("Give the row and col number of the start position like: row 3 col 4 as 34");
					Console.WriteLine("You can only use the numbers on the table.");
					string input;
					if (int.TryParse(input = Console.ReadLine(), out int start) == false)
					{
						board.Options(input);
					}
					else
					{
						if (0 <= start && start <= 77)
						{
							if (0 <= start && start <= 9)
							{
								if (start >= 8)
								{
									Console.WriteLine("The given field is not on the board.");
								}
								else
								{
									string startAsString = start.ToString();
									temp[0] = 0;
									temp[1] = int.Parse(startAsString[0].ToString());
									Console.WriteLine($" The given values are: {temp[0]},{temp[1]}");
									validInputStart = true;
								}
							}
							else
							{
								if ((start >= 18 && start < 20) || (start >= 28 && start < 30) || (start >= 38 && start < 40) || (start >= 48 && start < 50) || (start >= 58 && start < 60) || (start >= 68 && start < 70) || (start >= 78 && start < 80))
								{
									Console.WriteLine("The given field is not on the board.");
                                }
                                else
								{
									string startAsString = start.ToString();
									temp[0] = int.Parse(startAsString[0].ToString());
									temp[1] = int.Parse(startAsString[1].ToString());
									Console.WriteLine($" The given values are: {temp[0]},{temp[1]}");
									validInputStart = true;
								}
							}

						}
						else
						{
							Console.WriteLine("The given value is a number, but it is not between the numbers on the table.");
						}

					}
				}

				bool validInputEnd = false;
				while (validInputEnd == false)
				{
					Console.WriteLine();
					Console.WriteLine("Give the row and col number of the end position like: row 3 col 4 as 34");
					Console.WriteLine("You can only use the numbers on the table.");
					string input2;
					if (int.TryParse(input2 = Console.ReadLine(), out int start) == false)
					{
						board.Options(input2);
					}
					else
					{
						if (00 <= start && start <= 77)
						{
							if (0 <= start && start <= 9)
							{
								if (start >= 8)
								{
									Console.WriteLine("The given field is not on the board.");
								}
								else
								
									{
									string startAsString = start.ToString();
									temp[2] = 0;
									temp[3] = int.Parse(startAsString[0].ToString());
									Console.WriteLine($" The given values are: starti: {temp[0]}, startj: {temp[1]}, endi: {temp[2]}, endj: {temp[3]}");
									validInputEnd = true;
								}
                            }
							else
							{
								if ((start >= 18 && start < 20) || (start >= 28 && start < 30) || (start >= 38 && start < 40) || (start >= 48 && start < 50) || (start >= 58 && start < 60) || (start >= 68 && start < 70) || (start >= 78 && start < 80))
								{
									Console.WriteLine("The given field is not on the board.");
								}
								else
								{
									string startAsString = start.ToString();
									temp[2] = int.Parse(startAsString[0].ToString());
									temp[3] = int.Parse(startAsString[1].ToString());
									Console.WriteLine($" The given values are: starti: {temp[0]}, startj: {temp[1]}, endi: {temp[2]}, endj: {temp[3]}");
									validInputEnd = true;
								}
							}
						}
						else
						{
							Console.WriteLine("The given value is a number, but it is not between the numbers on the table.");
						}
					}
				}

				if (board.GetColor(temp[0], temp[1],board.player) == false)
				{
					Console.WriteLine("The chosen field does not contain a chessPiece or the piece's color is not equal to the player's color.");
                    if (board.turnCounter == 1)
                    {
						Console.WriteLine("White must start the game.");
					}
				}
                else
                {
                    if (board.IsKingInCheck(board,board.player) == true)
                    {
						if (board.boardFields[temp[0], temp[1]].Name != "K" && board.WillKingBeInCheck(temp[0], temp[1], temp[2], temp[3], board, board.player) == true)
						{
                            Console.WriteLine("You can't move there, because the King still would be in check!");
						}
						else if (board.boardFields[temp[0], temp[1]].Name != "K" && board.WillKingBeInCheck(temp[0], temp[1], temp[2], temp[3], board, board.player) == false)
						{
							board.boardFields[temp[2], temp[3]] = board.boardFields[temp[0], temp[1]];
							if (temp[0] % 2 == 0)
							{
								if (temp[1] % 2 == 0)
								{
									board.boardFields[temp[0], temp[1]] = new ChessPiece('w');    //White field
								}
								else
								{
									board.boardFields[temp[0], temp[1]] = new ChessPiece('b');    //Black Field
								}
							}
							else
							{
								if (temp[1] % 2 == 0)
								{
									board.boardFields[temp[0], temp[1]] = new ChessPiece('b');    //White field
								}
								else
								{
									board.boardFields[temp[0], temp[1]] = new ChessPiece('w');    //Black Field
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
						else if (board.boardFields[temp[0],temp[1]].Name == "K" && board.WillKingBeInCheck(temp[0], temp[1], temp[2], temp[3], board, board.player) == true)
                        {
                            Console.WriteLine("The King can't move there, or it still would be in Check!");
                        }
						else if (board.boardFields[temp[0], temp[1]].Name == "K" && board.WillKingBeInCheck(temp[0], temp[1], temp[2], temp[3], board, board.player) == false)
						{
							board.boardFields[temp[2], temp[3]] = board.boardFields[temp[0], temp[1]];
							if (temp[0] % 2 == 0)
							{
								if (temp[1] % 2 == 0)
								{
									board.boardFields[temp[0], temp[1]] = new ChessPiece('w');    //White field
								}
								else
								{
									board.boardFields[temp[0], temp[1]] = new ChessPiece('b');    //Black Field
								}
							}
							else
							{
								if (temp[1] % 2 == 0)
								{
									board.boardFields[temp[0], temp[1]] = new ChessPiece('b');    //White field
								}
								else
								{
									board.boardFields[temp[0], temp[1]] = new ChessPiece('w');    //Black Field
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
					else if (board.CheckCastling(temp[0], temp[1], temp[2], temp[3], board) == true)
                    {
						if (board.WillKingBeInCheck(temp[0], temp[1], temp[2], temp[3], board, board.player) == true)
						{
							Console.WriteLine($"Move can not be made, becasue The {board.player}'s King would be in Check.");
						}
						else
						{
							board.boardFields[temp[2], temp[3]] = board.boardFields[temp[0], temp[1]];
							if (temp[0] % 2 == 0)
							{
								if (temp[1] % 2 == 0)
								{
									board.boardFields[temp[0], temp[1]] = new ChessPiece('w');    //White field
								}
								else
								{
									board.boardFields[temp[0], temp[1]] = new ChessPiece('b');    //Black Field
								}
							}
							else
							{
								if (temp[1] % 2 == 0)
								{
									board.boardFields[temp[0], temp[1]] = new ChessPiece('b');    //White field
								}
								else
								{
									board.boardFields[temp[0], temp[1]] = new ChessPiece('w');    //Black Field
								}
							}

							if (temp[2] == 7 && temp[3] == 6)   //white - right
							{
								board.boardFields[7, 5] = board.boardFields[7, 7];
								board.boardFields[7, 7] = new ChessPiece('w');
							}
							else if (temp[2] == 7 && temp[3] == 2)  //white - left
							{
								board.boardFields[7, 3] = board.boardFields[7, 0];
								board.boardFields[7, 0] = new ChessPiece('b');
							}
							else if (temp[2] == 0 && temp[3] == 6)  //black - right
							{
								board.boardFields[0, 5] = board.boardFields[0, 7];
								board.boardFields[0, 7] = new ChessPiece('b');
							}
							else if (temp[2] == 0 && temp[3] == 2)  //black - left
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
					else if (board.CheckEnPassant(temp[0], temp[1], temp[2], temp[3]) == true)
                    {
						if (board.WillKingBeInCheck(temp[0], temp[1], temp[2], temp[3], board, board.player) == true)
						{
							Console.WriteLine($"Move can not be made, becasue The {board.player}'s King would be in Check.");
						}
						else
						{
							board.boardFields[temp[2], temp[3]] = board.boardFields[temp[0], temp[1]];
							if (temp[0] % 2 == 0)
							{
								if (temp[1] % 2 == 0)
								{
									board.boardFields[temp[0], temp[1]] = new ChessPiece('w');    //White field
								}
								else
								{
									board.boardFields[temp[0], temp[1]] = new ChessPiece('b');    //Black Field
								}
							}
							else
							{
								if (temp[1] % 2 == 0)
								{
									board.boardFields[temp[0], temp[1]] = new ChessPiece('b');    //White field
								}
								else
								{
									board.boardFields[temp[0], temp[1]] = new ChessPiece('w');    //Black Field
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
							board.CheckPawnPromotion(temp[2], temp[3]);
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
					else if (board.boardFields[temp[0], temp[1]].MoveSet(temp[0], temp[1], temp[2], temp[3], board,true) == true)
					{
						if (board.WillKingBeInCheck(temp[0], temp[1], temp[2], temp[3], board, board.player) == true)
						{
							Console.WriteLine($"Move can not be made, becasue The {board.player}'s King would be in Check.");
						}
						else
						{
							board.boardFields[temp[2], temp[3]] = board.boardFields[temp[0], temp[1]];
							if (temp[0] % 2 == 0)
							{
								if (temp[1] % 2 == 0)
								{
									board.boardFields[temp[0], temp[1]] = new ChessPiece('w');    //White field
								}
								else
								{
									board.boardFields[temp[0], temp[1]] = new ChessPiece('b');    //Black Field
								}
							}
							else
							{
								if (temp[1] % 2 == 0)
								{
									board.boardFields[temp[0], temp[1]] = new ChessPiece('b');    //White field
								}
								else
								{
									board.boardFields[temp[0], temp[1]] = new ChessPiece('w');    //Black Field
								}
							}
							board.CheckPawnPromotion(temp[2], temp[3]);
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
		}

	}
}
