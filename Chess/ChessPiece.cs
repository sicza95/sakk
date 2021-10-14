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

        public List<string> MoveSet { get => new List<string>(); }

        public int RowIndex { get; private set; }
        public int ColIndex { get; private set; }

        public Board Board { get; private set; }

        public ChessPiece(string name, string color)
        {
            Name = name;
            Color = color;
        }

        public ChessPiece(string nameAndColor)
        {
            Name = nameAndColor[0].ToString();
            Color = nameAndColor[1].ToString();
        }
        public ChessPiece(string nameAndColor, int rowIndex, int colIndex, Board board)
        {
            Name = nameAndColor[0].ToString();
            Color = nameAndColor[1].ToString();

            RowIndex = rowIndex;
            ColIndex = colIndex;
            Board = board;
        }
    }
}
