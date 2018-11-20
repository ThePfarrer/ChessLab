using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessProgram.Pieces
{
    class Castle : Piece
    {
        public Castle(col color) : base(color)
        {
            letterDisplay = 'C';
        }

        public override bool movementLegal(int dx, int dy)
        {
            int X = Math.Abs(dx);
            int Y = Math.Abs(dy);
            if (X == 0 || Y == 0)
            {
                return true;
            }
            return false;
        }
    }
}
