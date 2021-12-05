using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class ChessPiece
    {
        public string Name { get; private set; }

        public string Color { get; private set; }

        public bool Touched { get; set; }

        public List<string> MoveSet {
            get {
                switch(Name)
                {
                    case "P":
                        return PawnMoves;
                    case "K":
                        return KingMoves;
                    case "Q":
                        return QueenMoves;
                    case "R":
                        return RookMoves;
                    case "B":
                        return BishopMoves;
                    case "N":
                        return KnightMoves;
                }
                return new List<string>();
            }
        }

        public int Direction => Color == "W" ? -1 : 1;

        public List<string> PawnMoves
        {
            get {
                List<string> moves = CastRay(0, Touched ? 1 : 2, false);

                // check if hit is available...

                // ...in the next row
                int r = RowIndex + Direction;

                // ...to the right
                RequestAttack(r, ColIndex + 1, ref moves);

                // ...to the left
                RequestAttack(r, ColIndex - 1, ref moves);

                return moves;
            }
        }
        public List<string> KingMoves
        {
            get
            {
                List<string> moves = new List<string>();
                List<int> directions = new List<int> { 0, 45, 90, 135, 180, 225, 270, 315 };

                directions.ForEach(deg => moves = moves.Concat(CastRay(deg, Touched ? 1 : 2)).ToList());

                return moves;
            }
        }
        public List<string> QueenMoves
        {
            get
            {
                List<string> moves = new List<string>();
                List<int> directions = new List<int> { 0, 45, 90, 135, 180, 225, 270, 315 };

                directions.ForEach(deg => moves = moves.Concat(CastRay(deg)).ToList());

                return moves;
            }
        }

        public List<string> RookMoves
        {
            get
            {
                List<string> moves = new List<string>();
                List<int> directions = new List<int> { 0, 90, 180, 270 };

                directions.ForEach(deg => moves = moves.Concat(CastRay(deg)).ToList());

                return moves;
            }
        }
        public List<string> BishopMoves
        {
            get
            {
                List<string> moves = new List<string>();
                List<int> directions = new List<int> { 45, 135, 225, 315 };

                directions.ForEach(deg => moves = moves.Concat(CastRay(deg)).ToList());

                return moves;
            }
        }
        public List<string> KnightMoves
        {
            get
            {
                List<string> moves = new List<string>();

                RequestStep(RowIndex + 2, ColIndex + 1, ref moves);
                RequestStep(RowIndex + 1, ColIndex + 2, ref moves);

                RequestStep(RowIndex - 1, ColIndex + 2, ref moves);
                RequestStep(RowIndex - 2, ColIndex + 1, ref moves);

                RequestStep(RowIndex - 2, ColIndex - 1, ref moves);
                RequestStep(RowIndex - 1, ColIndex - 2, ref moves);

                RequestStep(RowIndex + 1, ColIndex - 2, ref moves);
                RequestStep(RowIndex + 2, ColIndex - 1, ref moves);

                return moves;
            }
        }
        public List<string> CastRay(int deg = 0, int length = 7, bool includeLast = true)
        {
            List<string> rc = new List<string>();
            int r = RowIndex, c = ColIndex;

            for (int step = 1; step <= length; step++)
            {
                IncrementByDirection(ref r, ref c, deg);

                // no cell
                if (!Cell.DoesExist(r, c))
                {
                    break;
                }
                Cell cell = Board.GetAt(r, c);

                // has piece
                if (cell.HasPiece)
                {
                    // have to stop no matter what, but the piece is an enemy, we add it to our moves
                    // except includeLast is False
                    if (includeLast && cell.Piece.Color != Color)
                    {
                        rc.Add($"{r}{c}");
                    }

                    break;
                }

                rc.Add($"{r}{c}");
            }

            return rc;
        }

        public int RowIndex => Cell.RowIndex;

        public int ColIndex => Cell.ColIndex;

        public Cell Cell { get; set; }

        public Board Board => Cell.Board;

        public ChessPiece(string nameAndColor, Cell cell)
        {
            Name = nameAndColor[0].ToString();
            Color = nameAndColor[1].ToString();

            Cell = cell;
        }

        public ChessPiece ToKing()
        {
            if (Name == "P") Name = "K";

            return this;
        }

        public ChessPiece ToQueen()
        {
            if (Name == "P") Name = "Q";

            return this;
        }

        public ChessPiece ToRook()
        {
            if (Name == "P") Name = "R";

            return this;
        }

        public ChessPiece ToBishop()
        {
            if (Name == "P") Name = "B";

            return this;
        }

        public ChessPiece ToKnight()
        {
            if (Name == "P") Name = "N";

            return this;
        }

        private void RequestStep(int r, int c, ref List<string> moves)
        {
            if (Cell.DoesExist(r, c))
            {
                Cell cell = Board.GetAt(r, c);

                if (!cell.HasPiece || cell.Piece.Color != Color)
                {
                    moves.Add($"{r}{c}");
                }
            }
        }

        private void RequestAttack(int r, int c, ref List<string> moves)
        {
            if (Cell.DoesExist(r, c))
            {
                Cell cell = Board.GetAt(r, c);

                if (cell.HasPiece && cell.Piece.Color != Color)
                {
                    moves.Add($"{r}{c}");
                }
            }
        }

        private void IncrementByDirection(ref int r, ref int c, int deg)
        {
            // Up
            if (0 == deg)
            {
                r += Direction;
            }

            // Up - Right
            if (45 == deg)
            {
                r += Direction;
                c += 1;
            }

            // Right
            if (90 == deg)
            {
                c += 1;
            }

            // Down - Right
            if (135 == deg)
            {
                r -= Direction;
                c += 1;
            }

            // Down
            if (180 == deg)
            {
                r -= Direction;
            }

            // Down - Left
            if (225 == deg)
            {
                r -= Direction;
                c -= 1;
            }

            // Left
            if (270 == deg)
            {
                c -= 1;
            }

            // Up - Left
            if (315 == deg)
            {
                r += Direction;
                c -= 1;
            }
        }
    }
}
