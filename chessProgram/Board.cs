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
                    if ((i + j) / 2 == 0)
                    {
                        field[i, j] = new Field(col.White);
                    }
                    else
                    {
                        field[i, j] = new Field(col.Black);
                    }
                }
            }
        }

        public void drawChessBoard()
        {
            string topLine = "┌───┬───┬───┬───┬───┬───┬───┬───┐";
            string verticalLine = "│   │   │   │   │   │   │   │   │";
            string inBetween = "├───┼───┼───┼───┼───┼───┼───┼───┤";
            string bottomLine = "└───┴───┴───┴───┴───┴───┴───┴───┘";


            Console.WriteLine(topLine);
            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine(verticalLine);
                Console.WriteLine(inBetween);

            }

            Console.WriteLine(verticalLine);
            Console.WriteLine(bottomLine);


        }

        public MovementResult move(int x1, int y1, int x2, int y2)
        {
            if (x2 > 7 || x2 < 0 || y2 < 0 || y2 > 7)
            {
                return MovementResult.TargetOutsideBoard;
            }

        }
    }
}
