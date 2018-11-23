using chessProgram.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessProgram
{
    class Program
    {
        static col Turn = col.White;

        static void Main(string[] args)
        {

            Board board = new Board();
            board.drawChessBoard();

            while (true)
            {
                Console.WriteLine(PlayerColor(Turn) + " to move, please enter a move:");
                Console.WriteLine("Enter x1");
                int x1 = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Enter y1");
                int y1 = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Enter x2");
                int x2 = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Enter y2");
                int y2 = Int32.Parse(Console.ReadLine());

                if (board.GetPiece(x1, y1).piece == null ||
                    board.GetPiece(x1, y1).piece.GetCol() == Turn)
                {
                    Movement(board, x1, y1, x2, y2);
                }
                else
                {
                    Console.Clear();
                    board.drawChessBoard();
                    Console.WriteLine("Move invalid");
                    System.Threading.Thread.Sleep(500);
                    Console.Clear();
                    board.drawChessBoard();
                }
            }

        }

        private static void Movement(Board myBoard, int x1, int y1, int x2, int y2)
        {
            Console.Clear();
            MovementResult myRes = myBoard.move(x1, y1, x2, y2);
            myBoard.drawChessBoard();
            Console.WriteLine(myRes);
            System.Threading.Thread.Sleep(500);

            if ((myRes == MovementResult.LegalMove) || (myRes == MovementResult.Hit))
            {
                ChangeTurn();
            }
        }

        private static void ChangeTurn()
        {
            if (Turn == col.Black)
            {
                Turn = col.White;
            }
            else
            {
                Turn = col.Black;
            }
        }

        private static string PlayerColor(col color)
        {
            if (color == col.Black)
            {
                return "Black";
            }
            else
            {
                return "White";
            }
        }
    }
}
