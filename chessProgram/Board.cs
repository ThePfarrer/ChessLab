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
            if ((x1 > 7 || x1 < 0 || y1 < 0 || y1 > 7) ||
                field[x1, y1].piece == null)
            {
                return MovementResult.NoPieceOnSource;
            }
            if (field[x2, y2].piece != null &&
                field[x1, y1].piece.GetCol() == field[x2, y2].piece.GetCol())
            {
                return MovementResult.TargetOccupiedByOwnPiece;
            }
            if (field[x1, y1].piece.movementLegal((x2 - x1), (y2 - y1)))
            {
                // The Knight is allowed to jump over any piece
                if (field[x1, y1].piece.GetType() != typeof(Knight))
                {
                    int X = Math.Abs(x1 - x2);
                    int Y = Math.Abs(y1 - y2);

                    // Checks for collision if dx or dy is greater than 1
                    if (!(Math.Max(X, Y) == 1))
                    {
                        int X1, X2, Y1, Y2, counter; // temp variables
                        counter = 1;
                        X1 = x1;
                        Y1 = y1;
                        X2 = x2;
                        Y2 = y2;

                        while (counter < Math.Max(X, Y))
                        {
                            if (X1 > X2)
                            {
                                X1--;
                            }
                            else if (X1 == X2)
                            {
                                X1 += 0;
                            }
                            else
                            {
                                X1++;
                            }

                            if (Y1 > Y2)
                            {
                                Y1--;
                            }
                            else if (Y1 == Y2)
                            {
                                Y1 += 0;
                            }
                            else
                            {
                                Y1++;
                            }

                            if (field[X1, Y1].piece != null)
                            {
                                return MovementResult.Collision;
                            }
                            counter++;
                        }
                    }

                    //The Pawn movement isn't straightforward
                    if (field[x1, y1].piece.GetType() != typeof(Pawn))
                    {
                        field[x2, y2].piece = field[x1, y1].piece;
                        field[x1, y1].piece = null;
                        return MovementResult.LegalMove;
                    }
                    else
                    {
                        if (Math.Abs(y1 - y2) == 1 && field[x2, y2].piece != null)
                        {
                            field[x2, y2].piece = field[x1, y1].piece;
                            field[x2, y2].piece.setHasBeenMoved();
                            field[x1, y1].piece = null;
                            return MovementResult.Hit;
                        }
                        if (Math.Abs(y1 - y2) == 0 && field[x2, y2].piece == null)
                        {
                            field[x2, y2].piece = field[x1, y1].piece;
                            field[x2, y2].piece.setHasBeenMoved();
                            field[x1, y1].piece = null;
                            return MovementResult.LegalMove;
                        }
                    }
                }
                else
                {
                    field[x2, y2].piece = field[x1, y1].piece;
                    field[x1, y1].piece = null;
                    return MovementResult.LegalMove;
                }
            }
            return MovementResult.IllegalMovement;
        }

        public Field GetPiece(int x1, int y1)
        {
            return field[x1, y1];
        }
    }
}
