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

                int r = RowIndex + Direction;
                int c = ColIndex + 1;

                if (Cell.DoesExist(r,c))
                {
                    Cell cell = Board.GetAt(r,c);

                    if (cell.HasPiece && cell.Piece.Color != Color)
                    {
                        moves.Add($"{r}{c}");
                    }
                }

                c = ColIndex - 1;

                if (Cell.DoesExist(r, c))
                {
                    Cell cell = Board.GetAt(r, c);

                    if (cell.HasPiece && cell.Piece.Color != Color)
                    {
                        moves.Add($"{r}{c}");
                    }
                }

                return moves;
            }
        }
        public List<string> KingMoves
        {
            get
            {
                List<string> moves = CastRay(135, Touched ? 1 : 2, false);

                int r = RowIndex + Direction;
                int c = ColIndex + 1;

                if (Cell.DoesExist(r, c))
                {
                    Cell cell = Board.GetAt(r, c);

                    if (cell.HasPiece && cell.Piece.Color != Color)
                    {
                        moves.Add($"{r}{c}");
                    }
                }

                c = ColIndex - 1;

                if (Cell.DoesExist(r, c))
                {
                    Cell cell = Board.GetAt(r, c);

                    if (cell.HasPiece && cell.Piece.Color != Color)
                    {
                        moves.Add($"{r}{c}");
                    }
                }

                return moves;
            }
        }
        public List<string> QueenMoves
        {
            get
            {
                List<string> moves45 = CastRay(45, Touched ? 1 : 2, false);
                List<string> moves90 = CastRay(90, Touched ? 1 : 2, false);
                List<string> moves = moves45.Union(moves90).ToList();

                int r = RowIndex + Direction;
                int c = ColIndex + 1;

                if (Cell.DoesExist(r, c))
                {
                    Cell cell = Board.GetAt(r, c);

                    if (cell.HasPiece && cell.Piece.Color != Color)
                    {
                        moves.Add($"{r}{c}");
                    }
                }

                c = ColIndex - 1;

                if (Cell.DoesExist(r, c))
                {
                    Cell cell = Board.GetAt(r, c);

                    if (cell.HasPiece && cell.Piece.Color != Color)
                    {
                        moves.Add($"{r}{c}");
                    }
                }

                return moves;
            }
        }

        public List<string> RookMoves
        {
            get
            {
                List<string> moves = CastRay(90, Touched ? 1 : 2, false);

                for (int i = 0; i < 7; i++)
                {
                    int r = RowIndex + Direction;
                    int c = ColIndex + 1;

                    if (Cell.DoesExist(r, c))
                    {
                        Cell cell = Board.GetAt(r, c);

                        if (cell.HasPiece && cell.Piece.Color != Color)
                        {
                            moves.Add($"{r}{c}");
                        }
                    }

                }
                return moves;
            }
        }
        public List<string> BishopMoves
        {
            get
            {
                List<string> moves = CastRay(45, Touched ? 1 : 2, false);

                for (int i = 0; i < 7; i++)
                {
                    int r = RowIndex + Direction;
                    int c = ColIndex + 1;

                    if (Cell.DoesExist(r, c))
                    {
                        Cell cell = Board.GetAt(r, c);

                        if (cell.HasPiece && cell.Piece.Color != Color)
                        {
                            moves.Add($"{r}{c}");
                        }
                    }

                }
                return moves;
            }
        }
        public List<string> KnightMoves
        {
            get
            {
                List<string> moves = CastRay(45, Touched ? 1 : 2, false);

                for (int i = 0; i < 7; i++)
                {
                    int r = RowIndex + Direction;
                    int c = ColIndex + 1;

                    if (Cell.DoesExist(r, c))
                    {
                        Cell cell = Board.GetAt(r, c);

                        if (cell.HasPiece && cell.Piece.Color != Color)
                        {
                            moves.Add($"{r}{c}");
                        }
                    }

                }
                return moves;
            }
        }
        public List<string> CastRay(int deg = 0, int length = 7, bool includeLast = true)
        {
            List<string> rc = new List<string>();
            int r = RowIndex, c = ColIndex;

            //set Rowindex, Colindex to initial value
            int IndexSet(int n) 
            {
                string name = nameof(n);
                if (name == "r")
                {
                    return RowIndex;
                }
                else
                    return ColIndex;
            }

            for (int step = 1; step <= length; step++)
            {
                // forward one step
                if (0 == deg) 
                {
                    r += Direction;

                    if (!Cell.DoesExist(r,c))
                    {
                        break;
                    }

                    Cell cell = Board.GetAt(r, c);

                    if (includeLast ? cell.HasPiece && cell.Piece.Color == Color : cell.HasPiece)
                    {
                        break;
                    }

                    rc.Add($"{r}{c}");
                }

                // diagonal all the way
                if (45 == deg) 
                {

                    for (int i = 0; i < 7; i++)
                    {
                        r -= 1;
                        c -= 1;
                        rc.Add($"{r}{c}");
                    }
                    IndexSet(r);
                    IndexSet(c);
                    for (int i = 0; i < 7; i++)
                    {
                        r += 1;
                        c += 1;
                        rc.Add($"{r}{c}");
                    }
                    IndexSet(r);
                    IndexSet(c);
                    for (int i = 0; i < 7; i++)
                    {
                        r -= 1;
                        c += 1;
                        rc.Add($"{r}{c}");
                    }
                    IndexSet(r);
                    IndexSet(c);
                    for (int i = 0; i < 7; i++)
                    {
                        r += 1;
                        c -= 1;
                        rc.Add($"{r}{c}");
                    }
                }

                // forward and sideways all the way
                if (90 == deg) 
                {
                    for (int i = 0; i < 7; i++)
                    {
                        r -= 1;
                        rc.Add($"{r}{c}");
                    }
                    r = RowIndex;
                    c = ColIndex;
                    for (int i = 0; i < 7; i++)
                    {
                        r += 1;
                        rc.Add($"{r}{c}");
                    }
                    r = RowIndex;
                    c = ColIndex;
                    for (int i = 0; i < 7; i++)
                    {
                        c += 1;
                        rc.Add($"{r}{c}");
                    }
                    r = RowIndex;
                    c = ColIndex;
                    for (int i = 0; i < 7; i++)
                    {
                        c -= 1;
                        rc.Add($"{r}{c}");
                    }
                }

                //forward,sidewawys,diagonal one step
                if (135 == deg) 
                {
                    //NOT WORKING!!!
                    r -= 1;
                    rc.Add($"{r}{c}");
                    c -= 1;
                    rc.Add($"{r}{c}");
                    IndexSet(r);
                    IndexSet(c);
                    r += 1;
                    rc.Add($"{r}{c}");
                    c += 1;
                    rc.Add($"{r}{c}");
                    IndexSet(r);
                    IndexSet(c);
                    r += 1;
                    c -= 1;
                    rc.Add($"{r}{c}");

                }
                if (180 == deg)
                {
                }
                if (225 == deg)
                {
                }
                if (270 == deg)
                {
                }
                if (315 == deg)
                {
                }
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
    }
}
