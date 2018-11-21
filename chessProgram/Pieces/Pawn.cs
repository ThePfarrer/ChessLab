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
            int Direction,  Y;
           
            Y = Math.Abs(dy);
            if (color == col.White)
            {
                Direction = -1;
            } else
            {
                Direction = 1;
            }

            if ((!hasBeenMoved && dx == (Direction * 2) || dx == Direction ) && (dy == 0) || 
                (dx == Direction && Y == 1))
            {
                hasBeenMoved = true;
                return true;
            }
            return false;
        }
    }
}
