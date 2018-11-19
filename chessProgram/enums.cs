using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessProgram
{
   enum col { Black, White };

   enum MovementResult
    {
        Hit, LegalMove, NoPieceOnSource, TargetOccupiedByOwnPiece, TargetOutsideBoard, Collision, IllegalMovement
    }
}
