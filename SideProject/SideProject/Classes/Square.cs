using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SideProject
{
    /*
     * 
     * 
     * */
    class Square
    {
        public bool isKnight1 { get; set; }
        public bool isKnight2 { get; set; }
        public bool isOpen { get; set; }
        public bool isBestMove { get; set; }
        public bool isPossMove { get; set; }
        public int xPos { get; set; }
        public int yPos { get; set; }
        public Knight knight { get; set; }
        public List<int[,]> occupiedSquares { get; set; }

        public Square(Knight knight, int xPosition, int yPosition, List<int[,]> listOfTakenSquares)
        {
            xPos = xPosition;
            yPos = yPosition;
            this.knight = knight;

        }
        public void CheckSquare()
        {
            if(knight.CurrentX == xPos && knight.CurrentY == yPos)
            {
                writeToScreen(" K ");
            }
        }

       
        
        private void writeToScreen(string str)
        {
            Console.WriteLine(str);
        }

    }
}
