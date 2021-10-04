using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    class ChessRook : ChessPiece
    {
		char name;
		char color;
		public ChessRook(char color) : base(color)
        {
			this.name = 'R';
			this.color = color;
        }
		public override string Name => this.name.ToString();
		public override string Color => this.color.ToString();



	}
}
