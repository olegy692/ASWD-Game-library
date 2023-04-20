using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibAssignment
{
    public interface ICreature
    {
        string Name { get; set; }
        int Health { get; set; }
        int Damage { get; set; }
        Position position { get; set; }

        public void PickUp(IWorldObject worldObject);
        void Attack(Player player);
        void Attack(Enemy enemy);







    }
}
