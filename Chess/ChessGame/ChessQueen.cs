using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    class ChessQueen : ChessPiece
    {
		char name;
		char color;
		public ChessQueen(char color) : base(color)
		{
			this.name = 'Q';
			this.color = color;
		}
		public override string Name => this.name.ToString();
		public override string Color => this.color.ToString();




	}
}
