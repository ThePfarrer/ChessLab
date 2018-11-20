using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessProgram.Pieces
{
    class Knight : Piece
    {
        public Knight(col color) : base(color)
        {
            letterDisplay = 'N';
        }

        public override bool movementLegal(int dx, int dy)
        {
            int X = Math.Abs(dx);
            int Y = Math.Abs(dy);

            if ((X == 2 && Y == 1) || (X == 1) && (Y == 2)) { return true; }
            return false;
        }
    }
}
