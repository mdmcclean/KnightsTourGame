using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SideProject
{
    public class Board
    {
        public int BoardSize { get; }
        public bool[,] knightBoard { get; set; }

        public Board(int boardSize)
        {
            BoardSize = boardSize;
            knightBoard = new bool[BoardSize, BoardSize];
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    knightBoard[i, j] = true;
                }
            }
        }



    }
}
