using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibAssignment
{
    public class Position
    {
        ///
        public int X { get; set; }
        public int Y { get; set; }

        /// <summary>
        /// Class which is used to represent position of objects in world 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }
        /// <summary>
        /// Method to check if object is withing one cell of each other
        /// </summary>
        /// <param name="position1"></param>
        /// <param name="position2"></param>
        /// <returns></returns>
        public static bool IsWithinOneCell(Position position1, Position position2)
        {
            int x = Math.Abs(position1.X - position2.X);
            int y = Math.Abs(position1.Y - position2.Y);
            return (x <= 1 && y <= 1 && x + y <= 1);
        }

        public static bool IsWithinNoOfCells(Position position1, Position position2, int cells) //same but amount of cells can be set manually
        {
            int x = Math.Abs(position1.X - position2.X);
            int y = Math.Abs(position1.Y - position2.Y);
            return (x <= cells && y <= cells && x + y <= cells);
        }


    }
}
