using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    class ChessKing : ChessPiece
    {
		char name;
		char color;
		int[,] kingPositions = new int[8, 2];
		public ChessKing(char color) : base(color)
		{
			this.name = 'K';
			this.color = color;
		}
		public override string Name => this.name.ToString();
		public override string Color => this.color.ToString();
		public override bool MoveSet(int starti, int startj, int endi, int endj, Chessboard currentboard)
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
                if (this.Color == "W")
                {
					if ((endi == kingPositions[i, 0] && endj == kingPositions[i, 1]) && (board.boardFields[endi, endj].Color != "W"))
					{
						return true;
					}
				}
                else
                {
					if ((endi == kingPositions[i, 0] && endj == kingPositions[i, 1]) && (board.boardFields[endi, endj].Color != "B"))
					{
						return true;
					}
				}
			}
			Console.WriteLine("The King can't step here.");
			return false;
		}






		}
}
