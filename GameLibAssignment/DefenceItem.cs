using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibAssignment
{
    public class DefenceItem : IWorldObject
    {
        public int Defence { get; set; }
        public string Name { get; set; }
        public Position position { get; set; }
        public int Damage { get; set; }

        public DefenceItem(string name, int defence, int maxX, int maxY) //constructor with specific position on grid
        {
            this.Name = name;
            this.Defence = defence;
            this.Damage = 0;
            this.position = new Position(maxX, maxY);
        }

        public DefenceItem(string name, int defence) //constructor with random position on grid
        {
            this.Name = name;
            this.Defence = defence;
            this.position = GetRandomPosition();
            this.Damage = 0;
        }

        public Position GetRandomPosition()
        {
            Random rnd = new Random();

            int x = 0;
            int y = 0;

            if(World.Instance != null)
            {
                x = rnd.Next(1, World.Instance.maxX - 1);
                y = rnd.Next(1, World.Instance.maxY - 1);
            }
            
            return new Position(x, y);
        }

    }
}
