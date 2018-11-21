using chessProgram.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessProgram
{
    class Board
    {
        Field[,] field = new Field[8, 8];

        public Board()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if ((i + j) % 2 == 0)
                    {
                        field[i, j] = new Field(col.White);
                    }
                    else
                    {
                        field[i, j] = new Field(col.Black);
                    }
                }
            }

            // Pawns
            for (int i = 0; i < 8; i++)
            {
                field[1, i].piece = new Pawn(col.Black);
                field[6, i].piece = new Pawn(col.White);
            }

            // Castle
            field[0, 0].piece = new Castle(col.Black);
            field[0, 7].piece = new Castle(col.Black);
            field[7, 0].piece = new Castle(col.White);
            field[7, 7].piece = new Castle(col.White);

            //Knight
            field[0, 1].piece = new Knight(col.Black);
            field[0, 6].piece = new Knight(col.Black);
            field[7, 1].piece = new Knight(col.White);
            field[7, 6].piece = new Knight(col.White);

            // Bishop
            field[0, 2].piece = new Bishop(col.Black);
            field[0, 5].piece = new Bishop(col.Black);
            field[7, 2].piece = new Bishop(col.White);
            field[7, 5].piece = new Bishop(col.White);

            // Queen
            field[0, 3].piece = new Queen(col.Black);
            field[7, 3].piece = new Queen(col.White);

            // King
            field[0, 4].piece = new King(col.Black);
            field[7, 4].piece = new King(col.White);
        }

        public void drawChessBoard()
        {
            string topLine = "┌───┬───┬───┬───┬───┬───┬───┬───┐";
            string verticalLine = "│";
            string inBetween = "├───┼───┼───┼───┼───┼───┼───┼───┤";
            string bottomLine = "└───┴───┴───┴───┴───┴───┴───┴───┘";


            Console.WriteLine(topLine);
            for (int i = 0; i < 8; i++)
            {
                Console.Write(verticalLine);
                for (int j = 0; j < 8; j++)
                {
                    field[i, j].drawChessField();
                    Console.Write(verticalLine);

                }
                if (i != 7)
                {
                    Console.WriteLine("\n" + inBetween);
                }


            }

            Console.WriteLine("\n" + bottomLine);


        }

        public MovementResult move(int x1, int y1, int x2, int y2)
        {
            if (x2 > 7 || x2 < 0 || y2 < 0 || y2 > 7)
            {
                return MovementResult.TargetOutsideBoard;
            }
            if (field[x1, y1].piece == null)
            {
                return MovementResult.NoPieceOnSource;
            }
            if (field[x1, y1].piece.GetCol() == field[x2, y2].piece.GetCol())
            {
                return MovementResult.TargetOccupiedByOwnPiece;
            }
            //if (!(field[x1,y1].piece.GetType() == typeof(Knight)))
            return MovementResult.IllegalMovement;
        }
    }
}
