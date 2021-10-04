using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    class ChessBishop : ChessPiece
    {
		char name;
		char color;
		public ChessBishop(char color) : base(color)
		{
			this.name = 'B';
			this.color = color;
		}
		public override string Name => this.name.ToString();
		public override string Color => this.color.ToString();



	}
}
