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







	}
}
