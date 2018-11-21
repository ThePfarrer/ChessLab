using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessProgram.Pieces
{
    class Pawn : Piece
    {
        public Pawn(col color) : base(color)
        {
            letterDisplay = 'P';
        }

        public override bool movementLegal(int dx, int dy)
        {
            int Direction;
            if (color == col.White)
            {
                Direction = 1;
            } else
            {
                Direction = -1;
            }

            return true;
        }
    }
}
