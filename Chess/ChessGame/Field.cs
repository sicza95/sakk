using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    class Field
    {
        private ChessPiece piece;
        private char file;
        private int rank;
        private char fieldColor;

        public char File { get => this.file; set => this.file = value; }
        public int Rank { get => this.rank; set => this.rank = value; }
        public ChessPiece Piece { get => this.piece; set => this.piece = value; }
        public char FieldColor { get => this.fieldColor; set => this.fieldColor = value; }

        public Field(char file, int rank, char fieldcolor)
        {
            this.File = file;
            this.Rank = rank;
            this.FieldColor = fieldcolor;
        }

        public void IsFieldUnderAttack(Chessboard currentBoard, string player)  //módosítás folyamatban
        {
            int index = currentBoard.fields.IndexOf(this);

            //int[] temp = new int[] {
            //    (index - 9 * 7), (index - 9 * 6), (index - 9 * 5), (index - 9 * 4), (index - 9 * 3), (index - 9 * 2), (index - 9 * 1),
            //    (index - 8 * 7), (index - 8 * 6), (index - 8 * 5), (index - 8 * 4), (index - 8 * 3), (index - 8 * 2), (index - 8 * 1),
            //    (index - 7 * 7), (index - 7 * 6), (index - 7 * 5), (index - 7 * 4), (index - 7 * 3), (index - 7 * 2), (index - 7 * 1),
            //    (index - 1 * 7), (index - 1 * 6), (index - 1 * 5), (index - 1 * 4), (index - 1 * 3), (index - 1 * 2), (index - 1 * 1),
            //    (index + 1 * 7), (index + 1 * 6), (index + 1 * 5), (index + 1 * 4), (index + 1 * 3), (index + 1 * 2), (index + 1 * 1),
            //    (index + 7 * 7), (index + 7 * 6), (index + 7 * 5), (index + 7 * 4), (index + 7 * 3), (index + 7 * 2), (index + 7 * 1),
            //    (index + 8 * 7), (index + 8 * 6), (index + 8 * 5), (index + 8 * 4), (index + 8 * 3), (index + 8 * 2), (index + 8 * 1),
            //    (index + 9 * 7), (index + 9 * 6), (index + 9 * 5), (index + 9 * 4), (index + 9 * 3), (index + 9 * 2), (index + 9 * 1),
            //};

            //int[] left = new int[7];
            //int[] leftUp = new int[7];
            //int[] up = new int[7];
            //int[] rightUp = new int[7];
            //int[] right = new int[7];
            //int[] rightDown = new int[7];
            //int[] down = new int[7];
            //int[] leftDown = new int[7];

            List<int> indexOfLeftFields = new List<int>();
            List<int> indexOfLeftUpFields = new List<int>();
            List<int> indexOfUpFields = new List<int>();
            List<int> indexOfRightUpFields = new List<int>();
            List<int> indexOfRightFields = new List<int>();
            List<int> indexOfRightDownFields = new List<int>();
            List<int> indexOfDownFields = new List<int>();
            List<int> indexOfLeftDownFields = new List<int>();

            for (int i = 1; i < 8; i++)
            {
                indexOfLeftUpFields.Add(index - 9 * i);
                indexOfUpFields.Add(index - 8 * i);
                indexOfRightUpFields.Add(index - 7 * i);
                indexOfLeftFields.Add(index - 1 * i);
                indexOfRightFields.Add(index + 1 * i);
                indexOfLeftDownFields.Add(index + 7 * i);
                indexOfDownFields.Add(index + 8 * i);
                indexOfRightDownFields.Add(index + 9 * i);
            }

            foreach (var indexOfCheckedField in indexOfLeftUpFields)
            {
                Field checkedField = currentBoard.fields.ElementAt(indexOfCheckedField);
                string pieceName = checkedField.Piece.Name;
                string pieceColor = checkedField.Piece.Color;

                if (indexOfCheckedField == indexOfLeftUpFields.First() && (pieceName == "K" || pieceName == "Q" || pieceName == "B" || pieceName == "P"))
                {
                    if (player != pieceColor)
                    {
                        return true;
                    }
                }
                else
                {
                    if ((pieceName == "Q" || pieceName == "B") && (pieceColor != player))
                    {
                        //int firstIndex = indexOfLeftUpFields.IndexOf(indexOfLeftUpFields.First());
                        int lastIndex = indexOfLeftUpFields.IndexOf(indexOfCheckedField);
                        for (int indexInLine = 0; indexInLine < lastIndex; indexInLine++)
                        {
                            Field inlineField = currentBoard.fields.ElementAt(indexOfLeftUpFields[indexInLine]);
                            if (inlineField.Piece.Color == player)
                            {
                                return false;
                            }
                        }
                    }
                    else if (true)
                    {

                    }
                }


                //Előző változat
                if (i == 7 && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "K" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "Q" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "B" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "P"))
                {
                    if (board.player == "white" && board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color == "B")
                    {
                        Console.WriteLine("1");
                        return true;
                    }
                    else if (board.player == "black" && board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color == "W")
                    {
                        Console.WriteLine("1");
                        return true;
                    }
                    return false;
                }
                else
                {
                    if ((board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "Q" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "B") && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color == "W"))
                    {
                        for (int g = 7; g < i; g++)
                        {
                            if (board.boardFields[attackPositions[g, 0], attackPositions[g, 1]].Color == "B")
                            {
                                return false;
                            }
                        }
                        Console.WriteLine("5");
                        return true;
                    }
                    else if ((board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "Q" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "B") && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color == "B"))
                    {
                        for (int g = 7; g < i; g++)
                        {
                            if (board.boardFields[attackPositions[g, 0], attackPositions[g, 1]].Color == "W")
                            {
                                return false;
                            }
                        }
                        Console.WriteLine("6");
                        return true;
                    }
                }
                return false;

            }

            foreach (var indexOfCheckedField in up)
            {

            }

            foreach (var indexOfCheckedField in rightUp)
            {

            }

            foreach (var indexOfCheckedField in left)
            {
                if (i == 0 && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "K" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "Q" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "R"))
                {
                    if (board.player == "white" && board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color == "B")
                    {
                        Console.WriteLine("1");
                        return true;
                    }
                    else if (board.player == "black" && board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color == "W")
                    {
                        Console.WriteLine("1");
                        return true;
                    }
                    return false;
                }
                else
                {
                    if ((board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "Q" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "R") && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color == "W"))
                    {
                        for (int g = 0; g < i; g++)
                        {
                            if (board.boardFields[attackPositions[g, 0], attackPositions[g, 1]].Color == "B")
                            {
                                return false;
                            }
                        }
                        Console.WriteLine("2");
                        return true;
                    }
                    else if ((board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "Q" || board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Name == "R") && (board.boardFields[attackPositions[i, 0], attackPositions[i, 1]].Color == "B"))
                    {
                        for (int g = 0; g < i; g++)
                        {
                            if (board.boardFields[attackPositions[g, 0], attackPositions[g, 1]].Color == "W")
                            {
                                return false;
                            }
                        }
                        Console.WriteLine("3");
                        return true;
                    }
                }
                return false;
            }

            foreach (var indexOfCheckedField in right)
            {

            }

            foreach (var indexOfCheckedField in leftDown)
            {

            }

            foreach (var indexOfCheckedField in down)
            {

            }

            foreach (var indexOfCheckedField in rightDown)
            {

            }



        }


        //public Field(char file, int rank, char fieldcolor, ChessPiece piece)
        //{
        //    this.File = file;
        //    this.Rank = rank;
        //    this.FieldColor = fieldcolor;
        //    this.Piece = piece;
        //}

    }
}
