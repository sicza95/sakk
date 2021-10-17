using System.Windows.Forms;
using System.Drawing;

namespace sakkGUI
{
    class ChessImage
    {
        PictureBox pb;
        string piece;
        char color;

        public ChessImage(PictureBox pb, string piece, char color)
        {
            this.pb = pb;
            this.piece = piece;
            this.color = color;
        }

        public static void DrawImage(PictureBox pb, string piece, char color)
        {
            if (color == 'B')
            {
                switch (piece)
                {
                    case "bishop":
                        pb.Image = Image.FromFile(@"img\BishopB.png");
                        break;
                    case "king":
                        pb.Image = Image.FromFile(@"img\KingB.png");
                        break;
                    case "knight":
                        pb.Image = Image.FromFile(@"img\KnightB.png");
                        break;
                    case "pawn":
                        pb.Image = Image.FromFile(@"img\PawnB.png");
                        break;
                    case "queen":
                        pb.Image = Image.FromFile(@"img\QueenB.png");
                        break;
                    case "rook":
                        pb.Image = Image.FromFile(@"img\RookB.png");
                        break;
                    default:
                        pb.Image = null;
                        break;
                }
            }
            else
            {
                switch (piece)
                {
                    case "bishop":
                        pb.Image = Image.FromFile(@"img\BishopW.png");
                        break;
                    case "king":
                        pb.Image = Image.FromFile(@"img\KingW.png");
                        break;
                    case "knight":
                        pb.Image = Image.FromFile(@"img\KnightW.png");
                        break;
                    case "pawn":
                        pb.Image = Image.FromFile(@"img\PawnW.png");
                        break;
                    case "queen":
                        pb.Image = Image.FromFile(@"img\QueenW.png");
                        break;
                    case "rook":
                        pb.Image = Image.FromFile(@"img\RookW.png");
                        break;
                    default:
                        pb.Image = null;
                        break;
                }
            }
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}
