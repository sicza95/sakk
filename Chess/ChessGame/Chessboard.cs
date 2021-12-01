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
		public int takenPawnPositioni;
		public int takenPawnPositionj;
		public List<Field> fields = new List<Field>(64);
		public char[] files = new char[] { 'a', 'b', 'c', 'd', 'e', 'g', 'h' };
		public int[] ranks = new int[] { 8, 7, 6, 5, 4, 3, 2, 1 };

		//	Drawing the Board.
		public void DrawBoard()
		{
			Console.Clear();
			Console.WriteLine();

			/*
			     a    b    c    d    e    f    g    h
			  -----------------------------------------
			8 | BR | BN | BB | BQ | BK | BB | BN | BR | 8
			  -----------------------------------------
			7 | BP | BP | BP | BP | BP | BP | BP | BP | 7
			  -----------------------------------------
			6 |    |    |    |    |    |    |    |    | 6
			  -----------------------------------------
			5 |    |    |    |    |    |    |    |    | 5
			  -----------------------------------------
			4 |    |    |    |    |    |    |    |    | 4
			  -----------------------------------------
			3 |    |    |    |    |    |    |    |    | 3
			  -----------------------------------------
			2 | WP | WP | WP | WP | WP | WP | WP | WP | 2
			  -----------------------------------------
			1 | WR | WN | WB | WQ | WK | WB | WN | WR | 1
			  -----------------------------------------
			    a    b    c    d    e    f    g    h
			 */

			Console.WriteLine(" a    b    c    d    e    f    g    h ");
			for (int sor = 8; sor >= 1; sor--)
			{
				Console.WriteLine("-----------------------------------------");
				Console.Write($"{sor} ");
				foreach (var field in fields.FindAll(x => x.Rank == sor))
				{
					Console.Write($"| {field.Piece.Color}{field.Piece.Name} ");
				}
				Console.WriteLine($"| {sor}");
			}
			Console.WriteLine("-----------------------------------------");
			Console.WriteLine(" a    b    c    d    e    f    g    h ");
		}   //Módosítva

		// Initialization of the board
		public Chessboard()
		{
			for (int file = 0; file < files.Length; file++)
			{
				for (int rank = 0; rank < ranks.Length; file++)
				{
					if ((file % 2 == 0) && (rank % 2 == 0) || !(file % 2 == 0) && !(rank % 2 == 0))
					{
						fields.Add(new Field(files[file], ranks[rank], 'w'));
					}
					else
					{
						fields.Add(new Field(files[file], ranks[rank], 'b'));
					}
				}
			}

			fields.ElementAt(0).Piece = new ChessRook('B', fields.ElementAt(0).File, fields.ElementAt(0).Rank);
			fields.ElementAt(1).Piece = new ChessKnight('B', fields.ElementAt(1).File, fields.ElementAt(1).Rank);
			fields.ElementAt(2).Piece = new ChessBishop('B', fields.ElementAt(2).File, fields.ElementAt(2).Rank);
			fields.ElementAt(3).Piece = new ChessQueen('B', fields.ElementAt(3).File, fields.ElementAt(3).Rank);
			fields.ElementAt(4).Piece = new ChessKing('B', fields.ElementAt(4).File, fields.ElementAt(4).Rank);
			fields.ElementAt(5).Piece = new ChessBishop('B', fields.ElementAt(5).File, fields.ElementAt(5).Rank);
			fields.ElementAt(6).Piece = new ChessKnight('B', fields.ElementAt(6).File, fields.ElementAt(6).Rank);
			fields.ElementAt(7).Piece = new ChessRook('B', fields.ElementAt(7).File, fields.ElementAt(7).Rank);

			foreach (var field in fields.FindAll(x => x.Rank == 7))
			{
				field.Piece = new ChessPawn('B', field.File, field.Rank);
			}

			foreach (var field in fields.FindAll(x => x.Rank == 2))
			{
				field.Piece = new ChessPawn('W', field.File, field.Rank);
			}

			fields.ElementAt(56).Piece = new ChessRook('W', fields.ElementAt(56).File, fields.ElementAt(56).Rank);
			fields.ElementAt(57).Piece = new ChessKnight('W', fields.ElementAt(57).File, fields.ElementAt(57).Rank);
			fields.ElementAt(58).Piece = new ChessBishop('W', fields.ElementAt(58).File, fields.ElementAt(58).Rank);
			fields.ElementAt(59).Piece = new ChessQueen('W', fields.ElementAt(59).File, fields.ElementAt(59).Rank);
			fields.ElementAt(60).Piece = new ChessKing('W', fields.ElementAt(60).File, fields.ElementAt(60).Rank);
			fields.ElementAt(61).Piece = new ChessBishop('W', fields.ElementAt(61).File, fields.ElementAt(61).Rank);
			fields.ElementAt(62).Piece = new ChessKnight('W', fields.ElementAt(62).File, fields.ElementAt(62).Rank);
			fields.ElementAt(63).Piece = new ChessRook('W', fields.ElementAt(63).File, fields.ElementAt(63).Rank);
			/*
			00 01 02 03 04 05 06 07
			08 09 10 11 12 13 14 15
			16 17 18 19 20 21 22 23
			24 25 26 27 28 29 30 31
			32 33 34 35 36 37 38 39
			40 41 42 43 44 45 46 47
			48 49 50 51 52 53 54 55
			56 57 58 59 60 61 62 63
			*/

		}   //Módosítva

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
		}	  // javítást igényel
	}
}
