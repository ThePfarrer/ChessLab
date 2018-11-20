using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessProgram.Pieces
{
    abstract class Piece
    {
        protected char letterDisplay;
        protected col color;
        protected bool hasBeenMoved = false;

        public Piece(col color)
        {
            this.color = color;
        }

        public void drawLetterDisplay()
        {
            Console.Write(" " + letterDisplay + " ");
        }

        abstract public bool movementLegal(int dx, int dy);
    }
}
