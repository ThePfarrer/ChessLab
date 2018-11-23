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

        public void setHasBeenMoved() { hasBeenMoved = true; }

        public void drawLetterDisplay()
        {
            if (color == col.Black)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(" " + letterDisplay + " ");
                Console.ForegroundColor = ConsoleColor.White;
            } else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(" " + letterDisplay + " ");
                Console.ForegroundColor = ConsoleColor.White;
            }
            
        }

        public col GetCol() { return color; }


        abstract public bool movementLegal(int dx, int dy);
    }
}
