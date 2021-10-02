using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class ChessPiece
    {
        string name;
        string position;
        string[] moveSet = new string[25];
        public string Name { get => this.name; }
        public string Position { get => this.position; }
        public string[] MoveSet { get => this.moveSet; }
        public ChessPiece(string name, string position, string[] moveSet)
        {
            this.name = name;
            this.position = position;
            this.moveSet = moveSet;
        }
    }
}
