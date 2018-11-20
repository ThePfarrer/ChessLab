using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessProgram.Pieces
{
    class Queen : Piece
    {
        public Queen(col color) : base(color)
        {
            letterDisplay = 'Q';
        }

        public override bool movementLegal(int dx, int dy)
        {
            int X = Math.Abs(dx);
            int Y = Math.Abs(dy);
            if (X == 0 || Y == 0 || X == Y) { return true; }
            return false;
        }
    }
}
