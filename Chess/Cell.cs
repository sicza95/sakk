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

        public bool IsActive => Board.ActiveRowIndex == RowIndex && Board.ActiveColIndex == ColIndex;
        public bool IsOver => Board.OverRowIndex == RowIndex && Board.OverColIndex == ColIndex;
        public bool IsSelected => Board.SelectedCell == this;


        private ChessPiece piece = null;
        public ChessPiece Piece 
        {
            get => piece;
            set {
                piece = value;
                if (null != value)
                {
                    value.Cell = this;
                }
            }
        }

        public bool HasPiece => null != Piece;

        public Board Board { get; set; }

        public Cell(int rowIndex, int colIndex, Board board)
        {
            RowIndex = rowIndex;
            ColIndex = colIndex;

            Color = Board.template[rowIndex][colIndex];

            Board = board;
        }

        public void Draw()
        {
            Console.SetCursorPosition(Left, Top);
            Box.Draw(this);
        }

        private static bool IsIndexValid(int index)
        {
            return 0 <= index && index <= 7;
        }

        public static bool DoesExist(int rowIndex, int colIndex)
        {
            return IsIndexValid(rowIndex) && IsIndexValid(colIndex);
        }
    }
}
