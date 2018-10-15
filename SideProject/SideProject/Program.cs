using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SideProject
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingX = 0;
            int startingY = 0;
            int boardsize = 0;
            Console.WriteLine("What size do you want the board? (8 is the normal sized chess board)");
            boardsize = int.Parse(Console.ReadLine());
            Console.WriteLine("What X position do you want the knight to start?");
            startingX = int.Parse(Console.ReadLine());
            Console.WriteLine("What Y position do you want the knight to start?");
            startingY = int.Parse(Console.ReadLine());
            Board board = new Board(boardsize);

            Knight knight = new Knight(boardsize - startingY, startingX - 1, board);
            
            while (true)
            {
                List<int> knightAvailMoveIndex = new List<int>();

                knightAvailMoveIndex = knight.CheckValidMoves();
                List<int> yMove = new List<int>();
                List<int> xMove = new List<int>();

                foreach(int move in knightAvailMoveIndex)
                {
                    yMove.Add(knight.moveY[move]);
                    xMove.Add(knight.moveX[move]);
                }
                bool possMove = false;
                Console.Clear();
                for (int i = 0; i < board.BoardSize; i++)
                {
                    Console.WriteLine();
                    for (int j = 0; j < board.BoardSize; j++)
                    {
                        possMove = false;
                        for (int k = 0; k < xMove.Count; k++)
                        {
                            if (i == knight.CurrentX + xMove[k] && j == knight.CurrentY + yMove[k])
                            {
                                if (xMove[k] == knight.CheckBestMove()[0] && yMove[k] == knight.CheckBestMove()[1])
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                }
                                Console.Write($" {k+1} ");
                                Console.ResetColor();
                                possMove = true;
                            }
                        }
                        if (!possMove)
                        {
                            if (i == knight.CurrentX && j == knight.CurrentY)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(" K ");
                                Console.ResetColor();
                            }
                            else if (board.knightBoard[i, j] == true)
                            {
                                Console.Write(" O ");
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write(" X ");
                                Console.ResetColor();
                            }
                        }
                    }
                }
                //while (!valid)
                //{
                //    Console.Write("\nmove x? ");
                //    moveX = int.Parse(Console.ReadLine());
                //    Console.Write("move y? ");
                //    moveY = int.Parse(Console.ReadLine());
                //    if (knight.IsValid(knight.CurrentX, knight.CurrentY, moveX, moveY))
                //    {
                //        valid = true;
                //    }
                //    else
                //    {
                //        Console.WriteLine("not a valid move");
                //    }
                //}


                // int[] nextMove = knight.CheckBestMove();

                int[] nextMove = new int[2];
                int selection;
                    Console.Write("\nWhere would you like to move next? Make a number selection: ");
                selection = int.Parse(Console.ReadLine());

                nextMove[0] = xMove[selection - 1];
                nextMove[1] = yMove[selection - 1];

                
                knight.MoveKnight(nextMove[0], nextMove[1]);
            }
        }
    }
}
