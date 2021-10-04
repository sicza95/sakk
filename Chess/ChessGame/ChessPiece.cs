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
		public ChessPiece(char color)
		{
			this.name = ' ';
			this.color = color;
		}
		public virtual string Name => this.name.ToString();
		public virtual string Color => this.color.ToString();



	}
}
