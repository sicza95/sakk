using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class ChessPawn : ChessPiece
    {
        private string name = "P";
        private string color;
        private string nameAndColor;
        private int rowIndex;

        public string Name
        { 
            get => name;
            set { }
        }
        public string Color
        {
            get { return color; }
            set
            {
                if (value == "W" || value == "w")
                {
                    color = "W";
                }
                else
                    color ="B";
            }
        }
        public int RowIndex { get => rowIndex; private set { } }
        public int ColIndex { get; private set; }
        public Board Board { get; private set; }

        public ChessPawn(string nameAndColor) : base(nameAndColor)
        {
        }

        public ChessPawn(string name, string color) : base(name, color)
        {
        }

        public ChessPawn(string nameAndColor, int rowIndex, int colIndex, Board board) : base(nameAndColor, rowIndex, colIndex, board)
        {
            Color = nameAndColor[1].ToString();
            RowIndex = rowIndex;
            ColIndex = colIndex;
            Board = board;
        }

        public bool LegalMoves(int rowMove, int colMove)
        {
            bool poosibleRow;
            bool possibleCol;
            if (rowIndex == 2 && color == "W")
            {
                switch (rowMove)
                {
                    case 1:
                        poosibleRow = true;
                        break;
                    case 2:
                        poosibleRow = true;
                        break;
                    default:
                        poosibleRow = false;
                        break;
                }
            }
            else if (rowIndex == 7 && color == "B")
            {
                switch (rowMove)
                {
                    case -1:
                        poosibleRow = true;
                        break;
                    case -2:
                        poosibleRow = true;
                        break;
                    default:
                        poosibleRow = false;
                        break;
                }
            }
            else
            {
                poosibleRow = false;
            }
            if (colMove == 0)
            {
                possibleCol = true;
            }
            else
                possibleCol = false;
            if (possibleCol && poosibleRow)
            {
                return true;
            }
            else return false;
        }
    }
}
