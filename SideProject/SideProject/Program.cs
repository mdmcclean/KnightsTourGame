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
            bool goodInput = false;
            Console.WriteLine("What size do you want the board? (8 is the normal sized chess board)");
            while (!goodInput)
            {
                try
                {
                    boardsize = int.Parse(Console.ReadLine());
                    goodInput = true;
                }
                catch
                {
                    Console.WriteLine("Not valid input.. enter a number");
                }
            }

            Console.WriteLine("What X position do you want the knight to start?");
            goodInput = false;
            while(!goodInput)
            {
                try
                {
                    startingX = int.Parse(Console.ReadLine());
                    if(startingX > 0 && startingX <= boardsize)
                    {
                        goodInput = true;
                    }
                    else
                    {
                        Console.WriteLine($"Starting position must be between 1 and {boardsize}");
                    }
                }
                catch
                {
                    Console.WriteLine($"Not valid input... Starting position must be between 1 and {boardsize}");

                }
            }

            Console.WriteLine("What Y position do you want the knight to start?"); goodInput = false;
            while (!goodInput)
            {
                try
                {
                    startingY = int.Parse(Console.ReadLine());
                    if (startingY > 0 && startingY <= boardsize)
                    {
                        goodInput = true;
                    }
                    else
                    {
                        Console.WriteLine($"Starting position must be between 1 and {boardsize}");
                    }
                }
                catch
                {
                    Console.WriteLine($"Not valid input... Starting position must be between 1 and {boardsize}");

                }
            }

            Board board = new Board(boardsize);
            bool noMoreMoves = false;
            Knight knight = new Knight(boardsize - startingY, startingX - 1, board);
            
            while (!noMoreMoves)
            {
                noMoreMoves = true;
                List<int> knightAvailMoveIndex = new List<int>();

                knightAvailMoveIndex = knight.CheckValidMoves();
                List<int> yMove = new List<int>();
                List<int> xMove = new List<int>();

                foreach(int move in knightAvailMoveIndex)
                {
                    yMove.Add(knight.moveY[move]);
                    xMove.Add(knight.moveX[move]);
                }
                bool possibleMove = false;
                Console.Clear();
                for (int i = 0; i < board.BoardSize; i++)
                {
                    Console.WriteLine();
                    for (int j = 0; j < board.BoardSize; j++)
                    {
                        possibleMove = false;
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
                                possibleMove = true;
                                noMoreMoves = false;
                            }
                        }
                        if (!possibleMove)
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
                if (!noMoreMoves)
                {
                    goodInput = false;
                    while (!goodInput)
                    {
                        try
                        {
                            Console.Write("\nWhere would you like to move next? Make a number selection: ");
                            selection = int.Parse(Console.ReadKey().KeyChar.ToString());

                            nextMove[0] = xMove[selection - 1];
                            nextMove[1] = yMove[selection - 1];


                            knight.MoveKnight(nextMove[0], nextMove[1]);
                            goodInput = true;
                        }
                        catch
                        {
                            Console.WriteLine("Not a valid move...");
                        }
                    }
                }
            }
            if (board.WinGame(knight))
            {
                Console.WriteLine("\nCongratulations! You've completed the Knights Tour!");
            }
            else
            {
                Console.WriteLine("\nThere are no more possible moves... You lose.");
            }
            Console.ReadKey();
        }
    }
}
