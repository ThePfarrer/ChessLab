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
        Piece piece;

        public Field(col col)
        {

        }

        public void drawChessField()
        {
            if (piece != null)
            {
                piece.drawLetterDisplay();
            } else
            {
                Console.Write("   ");
            }
        }
    }
}
