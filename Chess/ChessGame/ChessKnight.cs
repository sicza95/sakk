using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    class ChessKnight : ChessPiece
    {
		char name;
		char color;
		int[,] knightPositions = new int[8, 2];
		
		public ChessKnight(char color) : base(color)
		{
			this.name = 'N';
			this.color = color;
		}
		public override string Name => this.name.ToString();
		public override string Color => this.color.ToString();
		
        public override bool MoveSet(int starti, int startj, int endi, int endj, Chessboard currentboard)
		{
			knightPositions[0, 0] = starti-2; knightPositions[0, 1] = startj-1;
			knightPositions[1, 0] = starti-2; knightPositions[1, 1] = startj+1;
			knightPositions[2, 0] = starti-1; knightPositions[2, 1] = startj-2;
			knightPositions[3, 0] = starti-1; knightPositions[3, 1] = startj+2;
			knightPositions[4, 0] = starti+1; knightPositions[4, 1] = startj-2;
			knightPositions[5, 0] = starti+1; knightPositions[5, 1] = startj+2;
			knightPositions[6, 0] = starti+2; knightPositions[6, 1] = startj-1;
			knightPositions[7, 0] = starti+2; knightPositions[7, 1] = startj+1;

			Chessboard board = currentboard;
            for (int i = 0; i < 8; i++)
            {
                if (this.Color == "W")
                {
					if (endi == knightPositions[i, 0] && endj == knightPositions[i, 1] && (board.boardFields[endi, endj].Color != "W"))
					{
						return true;
					}
				}
                else
                {
					if (endi == knightPositions[i, 0] && endj == knightPositions[i, 1] && (board.boardFields[endi, endj].Color != "B"))
					{
						return true;
					}
				}
            }
            Console.WriteLine("The Knight can't step here.");
			return false;
        }









	}
}
