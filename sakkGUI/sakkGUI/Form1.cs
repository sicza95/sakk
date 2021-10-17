using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChessGame;

namespace sakkGUI
{
    public partial class Form1 : Form
    {
        public static Form1 ChessForm;

        public Form1()
        {
            InitializeComponent();
            ChessForm = this;
            ChessMechanism chessgame = new ChessMechanism();
            chessgame.StartGame();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string inputRaw = textBoxInput.Text;
        }


    }
 
}
