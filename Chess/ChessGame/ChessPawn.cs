using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
	class ChessPawn : ChessPiece
    {
		char name;
		char color;
		bool enPassant = false;
		int[,] pawnPositions = new int[3,2];
		public ChessPawn(char color) : base(color)
		{
			this.name = 'P';
			this.color = color;
		}
		public override string Name => this.name.ToString();
		public override string Color => this.color.ToString();
		public override bool EnPassant => this.enPassant;
		public override bool MoveSet(int starti, int startj, int endi, int endj, Chessboard currentboard)
		{
			Chessboard board = currentboard;
			pawnPositions[0, 0] = starti-1; pawnPositions[0, 1] = startj-1;
			pawnPositions[1, 0] = starti-1; pawnPositions[1, 1] = startj+1;
			pawnPositions[2, 0] = starti-1; pawnPositions[2, 1] = startj;


            if (this.Color == "W")
            {
                if (starti == 6 && endi == starti - 2 && endj == startj)
                {
                    if (startj == 0)
                    {
                        if (board.boardFields[starti - 2, startj + 1].Color == "B")
						{
							this.enPassant = true;
							return true;
						}
						this.enPassant = false;
						return true;
					}
					else if (startj == 7)
                    {
						if (board.boardFields[starti - 2, startj - 1].Color == "B")
						{
							this.enPassant = true;
							return true;
						}
						this.enPassant = false;
						return true;
					}
                    else
                    {
						if (board.boardFields[starti - 2, startj - 1].Color == "B" || board.boardFields[starti - 2, startj + 1].Color == "B")
						{
							this.enPassant = true;
							return true;
						}
						this.enPassant = false;
						return true;
					}
                }
                else if (((board.boardFields[starti - 1, startj].Color == "w") && (endi == starti - 1) && (endj == startj)) || ((board.boardFields[starti - 1, startj].Color == "b") && (endi == starti - 1) && (endj == startj)))
				{
					this.enPassant = false;
					return true;
				}
                else if (0 <= starti - 1 && starti - 1 <= 77 && 0 <= startj - 1 && startj - 1 <= 7 && endi == starti - 1 && endj == startj - 1)
				{
					if ((board.boardFields[starti - 1, startj - 1].Color == "B") && (endi == starti - 1) && (endj == startj - 1))
					{
						this.enPassant = false;
						return true;
					}
					Console.WriteLine("The Pawn can't step there.");
					return false;
				}
				else if (0 <= starti - 1 && starti - 1 <= 77 && 0 <= startj + 1 && startj + 1 <= 7 && endi == starti - 1 && endj == startj + 1)
                {
					if ((board.boardFields[starti - 1, startj + 1].Color == "B") && (endi == starti - 1) && (endj == startj + 1))
					{
						this.enPassant = false;
						return true;
					}
					Console.WriteLine("The Pawn can't step there.");
					return false;
				}
				else
				{
                    Console.WriteLine("The Pawn can't step there.");
					return false;
				}
			}
            else
            {
				if (starti == 1 && endi == starti + 2 && endj == startj)
				{
					if (startj == 0)
                    {
                        if (board.boardFields[starti + 2, startj + 1].Color == "W")
						{
							this.enPassant = true;
							return true;
						}
						this.enPassant = false;
						return true;
					}
					else if (startj == 7)
                    {
						if (board.boardFields[starti + 2, startj - 1].Color == "W")
						{
							this.enPassant = true;
							return true;
						}
						this.enPassant = false;
						return true;
					}
                    else
                    {
						if (board.boardFields[starti + 2, startj - 1].Color == "W" || board.boardFields[starti + 2, startj + 1].Color == "W")
						{
							this.enPassant = true;
							return true;
						}
						this.enPassant = false;
						return true;
					}
				}
				else if (((board.boardFields[starti + 1, startj].Color == "w") && (endi == starti + 1) && (endj == startj)) || ((board.boardFields[starti + 1, startj].Color == "b") && (endi == starti + 1) && (endj == startj)))
				{
					this.enPassant = false;
					return true;
				}
				//
				else if (0<= starti+1 && starti+1 <= 77 && 0 <= startj -1 && startj - 1 <= 7 && endi == starti + 1 && endj == startj - 1)
                {
					if ((board.boardFields[starti + 1, startj - 1].Color == "W") && (endi == starti + 1) && (endj == startj - 1))
					{
						this.enPassant = false;
						return true;
					}
					Console.WriteLine("The Pawn can't step there.");
					return false;
				}
				//
				else if (0 <= starti + 1 && starti + 1 <= 77 && 0 <= startj + 1 && startj + 1 <= 7 && endi == starti + 1 && endj == startj + 1)
                {
					if ((board.boardFields[starti + 1, startj + 1].Color == "W") && (endi == starti + 1) && (endj == startj + 1))
					{
						this.enPassant = false;
						return true;
					}
					Console.WriteLine("The Pawn can't step there.");
					return false;
				}
				else
				{
					Console.WriteLine("The Pawn can't step there.");
					return false;
				}
			}
		}

		







		}
}
