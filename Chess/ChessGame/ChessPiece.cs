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
		public ChessPiece(char color)
		{
			this.name = ' ';
			this.color = color;
		}
		public virtual string Name => this.name.ToString();
		public virtual string Color => this.color.ToString();
		public virtual bool EnPassant => this.enPassant;
		public virtual bool MoveSet(int starti, int startj, int endi, int endj, Chessboard currentboard)
        {
			return false;
        }



	}
}
