using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibAssignment
{
    public class AttackItem : IWorldObject
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public Position position { get; set; }
        public int Defence { get; set; }

        public AttackItem(string name, int damage, int maxX, int maxY)
        {
            this.Name = name;
            this.Damage = damage;
            this.position = new Position(maxX, maxY);
            this.Defence = 0;
        }


        public AttackItem(string name, int damage)
        {
            this.Name = name;
            this.Damage = damage;
            this.position = GetRandomPosition();
            this.Defence = 0;
        }

        public Position GetRandomPosition()
        {
            Random rnd = new Random();

            int x = 0;
            int y = 0;

            if (World.Instance != null)
            {
                x = rnd.Next(1, World.Instance.maxX - 1);
                y = rnd.Next(1, World.Instance.maxY - 1);
            }
            return new Position(x, y);
        }

    }
}
