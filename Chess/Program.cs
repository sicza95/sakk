using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Program
    {
        static int OnUpArrow(Board board)
        {
            return board.HasSelectedCell ? board.OverRowIndex-- : board.ActiveRowIndex--;
        }

        static int OnDownArrow(Board board)
        {
            return board.HasSelectedCell ? board.OverRowIndex++ : board.ActiveRowIndex++;
        }

        static int OnLeftArrow(Board board)
        {
            return board.HasSelectedCell ? board.OverColIndex-- : board.ActiveColIndex--;
        }

        static int OnRightArrow(Board board)
        {
            return board.HasSelectedCell ? board.OverColIndex++ : board.ActiveColIndex++;
        }

        static Cell OnEnter(Board board)
        {
            Cell cell = board.CellList.Find(c => c.RowIndex == board.OverRowIndex && c.ColIndex == board.OverColIndex);

            if (!board.HasSelectedCell)
            {
                if (!cell.HasPiece)
                {
                    // Empty cell
                    return PlayError();
                }

                ChessPiece piece = cell.Piece;

                if (piece.Color != board.Player || 0 == piece.MoveSet.Count)
                {
                    // Invalid piece color || no moves
                    return PlayError();
                }

                // Start move
                return board.SelectedCell = cell;
            }
            else
            {
                Cell selCell = board.SelectedCell;

                if (cell.RowIndex == selCell.RowIndex && cell.ColIndex == selCell.ColIndex)
                {
                    // No moves made
                    return PlayError();
                }

                if (!board.SelectedCell.Piece.MoveSet.Contains($"{cell.RowIndex}{cell.ColIndex}"))
                {
                    // Invalid move
                    return PlayError();
                }

                // End move
                return Move(board);
            }
        }

        static Cell Move(Board board)
        {
            Cell sourceCell = board.SelectedCell;
            Cell targetCell = board.OverCell;

            ChessPiece piece = sourceCell.Piece;

            string record = $"{piece.Color}{piece.Name} {sourceCell.Name} -> {targetCell.Name}";

            if (!targetCell.HasPiece)
            {
                board.history.Add(record);
                PlayStep();
            }
            else
            {
                board.history.Add($"{record} x {targetCell.Piece.Color}{targetCell.Piece.Name}");
                PlayHit();
            }

            if (piece.Name == "P")
            {
                if (piece.Color == "B" && targetCell.RowIndex == 7)
                {
                    piece.Promote();
                    PlayPromotion();
                }
                if (piece.Color == "W" && targetCell.RowIndex == 0)
                {
                    piece.Promote();
                    PlayPromotion();
                }
            }

            board.DrawLastMove();

            targetCell.Piece = piece;
            piece.Touched = true;

            sourceCell.Piece = null;

            board.ActiveRowIndex = board.OverRowIndex;
            board.ActiveColIndex = board.OverColIndex;

            return board.SelectedCell = null;
        }

        static void OnBackspace(Board board)
        {
            board.SelectedCell = null;
        }

        static void OnF5(Board board)
        {
            board.Save();
        }
        static void OnF6(Board board)
        {
            board.Load();
        }
        static void OnF2(Board board)
        {
            board.New();
        }

        static void StartListeners(Board board)
        {
            ConsoleKey key;

            do
            {
                key = Console.ReadKey().Key;

                if (key == ConsoleKey.UpArrow) OnUpArrow(board);

                if (key == ConsoleKey.DownArrow) OnDownArrow(board);

                if (key == ConsoleKey.LeftArrow) OnLeftArrow(board);

                if (key == ConsoleKey.RightArrow) OnRightArrow(board);

                if (key == ConsoleKey.Enter) OnEnter(board);

                if (key == ConsoleKey.Backspace) OnBackspace(board);

                if (key == ConsoleKey.F5) OnF5(board);

                if (key == ConsoleKey.F6) OnF6(board);

                if (key == ConsoleKey.F2) OnF2(board);

                if (!board.HasSelectedCell)
                {
                    board.OverRowIndex = board.ActiveRowIndex;
                    board.OverColIndex = board.ActiveColIndex;
                }

                board.Draw();

            } while (key != ConsoleKey.Escape);
        }

        static Cell PlayError()
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"./asset/sound/Windows Ding.wav");
            player.Play();

            return null;
        }

        static Cell PlayStart()
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"./asset/sound/Windows Logon.wav");
            player.Play();

            return null;
        }

        static Cell PlayStep()
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"./asset/sound/Windows Startup.wav");
            player.Play();

            return null;
        }

        static Cell PlayHit()
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"./asset/sound/recycle.wav");
            player.Play();

            return null;
        }

        static Cell PlayPromotion()
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"./asset/sound/tada.wav");
            player.Play();

            return null;
        }

        static void Main(string[] args)
        {
            PlayStart();
            Board.DrawRules();
            StartListeners(new Board());
        }
    }
}
