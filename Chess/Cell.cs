using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Cell
    {
        public int RowIndex { get; private set; }
        public int ColIndex { get; private set; }

        private int Top { get => RowIndex * 3; }
        private int Left { get => ColIndex * 5; }

        public string Color { get; private set; }

        public ChessPiece Piece { get; set; }

        public Cell(int rowIndex, int colIndex)
        {
            RowIndex = rowIndex;
            ColIndex = colIndex;

            Color = Board.template[rowIndex][colIndex];
        }

        public Cell(int rowIndex, int colIndex, ChessPiece piece)
        {
            RowIndex = rowIndex;
            ColIndex = colIndex;

            Color = Board.template[rowIndex][colIndex];

            Piece = piece;
        }

        public void Draw(int rowIndex, int colIndex)
        {
            Console.SetCursorPosition(Left, Top);
            Box.Draw(Color, rowIndex, colIndex, Piece);
        }
    }
}
