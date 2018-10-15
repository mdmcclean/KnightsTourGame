using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SideProject
{
    public class Knight 
    {
        public int[] moveX = { 2, 1, -2, -1, 2, 1, -2, -1 };
        public int[] moveY = { 1, 2, -1, -2, -1, -2, 1, 2 };
        public int BestMoveIndex { get; }
        public int CurrentX { get; private set; }
        public int CurrentY { get; private set; }
        public int moveNumber = 0;
        
        public int BoardSize { get; }
        public Board board { get; }
//        public bool[,] knightBoard { get; set; }
        public Knight(int startingX, int startingY, Board board)
        {
            this.board = board;
            BoardSize = board.BoardSize;
//            knightBoard = new bool[BoardSize,BoardSize];
            //for(int i = 0; i < BoardSize; i++)
            //{
            //    for(int j = 0; j < BoardSize; j++)
            //    {
            //        knightBoard[i, j] = true;
            //    }
            //}
            CurrentX = startingX;
            CurrentY = startingY;
        }

        public bool IsValid(int currentX, int currentY, int moveX, int moveY)
        {
            bool isLegal = false;
            if (currentX + moveX >= 0 && currentX + moveX < BoardSize
                && currentY + moveY >= 0 && currentY + moveY < BoardSize
                && board.knightBoard[currentX + moveX, currentY + moveY] == true)
            {
                for (int i = 0; i < this.moveX.Length; i++)
                {
                    if (this.moveX[i] == moveX && this.moveY[i] == moveY)
                    {
                        isLegal = true;
                    }
                }
            }
            return isLegal;
        }

        public void MoveKnight(int moveX, int moveY)
        {
            if(IsValid(CurrentX, CurrentY, moveX, moveY))
            {
                board.knightBoard[CurrentX, CurrentY] = false;
                CurrentX += moveX;
                CurrentY += moveY;
                moveNumber++;
            }
        }

        public List<int> CheckValidMoves()
        {
            List<int> validMoveIndex = new List<int>();

            for(int i = 0; i < moveX.Length; i++)
            {
                if(IsValid(CurrentX, CurrentY, moveX[i], moveY[i]))
                {
                    validMoveIndex.Add(i);
                }
            }
            return validMoveIndex;
        }

        public int[] CheckBestMove()
        {
            int x = 0;
            int y = 0;
            int minNumber = 9;
            for(int i = 0; i < moveX.Length; i++)
            {
                int amountOfNextTurns = 0;
                if(IsValid(CurrentX, CurrentY, moveX[i],moveY[i]))
                {
                    for(int j = 0; j < moveX.Length; j++)
                    {
                        if(IsValid(CurrentX + moveX[i], CurrentY + moveY[i], moveX[j], moveY[j]))
                        {
                            amountOfNextTurns++;
                        }
                    }
                    if(amountOfNextTurns > 0 && amountOfNextTurns < minNumber)
                    {
                        minNumber = amountOfNextTurns;
                        x = moveX[i];
                        y = moveY[i];
                    }
                }

            }
            return new int[] { x, y};
        }


    }
}
