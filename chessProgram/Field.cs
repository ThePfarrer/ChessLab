using chessProgram.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessProgram
{
    class Field
    {
        public Piece piece;
        public col col;

        public Field(col col)
        {
            this.col = col;
        }

        public void drawChessField()
        {
            if (col == col.White)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                if (piece != null)
                {
                    piece.drawLetterDisplay();

                }
                else
                {
                    Console.Write("   ");
                }
                Console.BackgroundColor = ConsoleColor.Black;
            } else
            {
                if (piece != null)
                {
                    piece.drawLetterDisplay();

                }
                else
                {
                    Console.Write("   ");
                }
            }
            
        }
    }
}
