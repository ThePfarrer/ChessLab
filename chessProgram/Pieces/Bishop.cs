using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessProgram.Pieces
{
    class Bishop : Piece
    {
        public Bishop(col color) : base(color)
        {
            letterDisplay = 'B';
        }

        public override bool movementLegal(int dx, int dy)
        {
            int X = Math.Abs(dx);
            int Y = Math.Abs(dy);
            if (X == Y) { return true; }
            return false;
        }
    }
}
