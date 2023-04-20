using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibAssignment
{

    public class Enemy : ICreature
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public int Defence { get; set; }
        public Position position { get; set; }
        public World? world { get; set; }
        public List<AttackItem> Weapons { get; set; }
        public List<DefenceItem> Shields { get; set; }

        private readonly Random random = new Random();


        /// <summary>
        /// Enemy class with attack, movement, pickUp methods with a little bit different implementation from player class
        /// </summary>
        /// <param name="name"></param>
        /// <param name="health"></param>
        /// <param name="damage"></param>

        public Enemy(string name, int health, int damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
            position = new Position(15, 15);

            Weapons = new List<AttackItem>();
            Shields = new List<DefenceItem>();

            Logger.Log($"Enemy with name: {Name}, health: {Health}, damage: {Damage} is created");


        }


        public void EnemyRandomMovement(int distance, World world)
        {

            // Array with possible direction which use array index to generate a random direction for movement 
            var directions = new[] { 'w', 'a', 's', 'd' };
            var direction = directions[random.Next(directions.Length)];

            // Move towards the random direction
            MoveToRandomPosition(distance, world, direction);

        }

        public void MoveToRandomPosition(int distance, World world, char direction)
        {
            // Calculate the new position based on the direction and distance(number of cell he can move)
            int newX = position.X;
            int newY = position.Y;

            switch (direction)
            {
                case 'w':
                    newY -= distance;
                    break;
                case 'a':
                    newX -= distance;
                    break;
                case 's':
                    newY += distance;
                    break;
                case 'd':
                    newX += distance;
                    break;
                default:
                    break;
            }

            // Check if the new position is inside the boundaries of the grid
            if (newX >= 0 && newX < world.maxX && newY >= 0 && newY < world.maxY)
            {
                // Check if the new position is empty
                if (world.grid[newX, newY] == ' ')
                {
                    Logger.Log($"Enemy moved to new position ({newX}, {newY}).");

                    // Update the enemy's position on the grid
                    world.grid[position.X, position.Y] = ' ';
                    position.X = newX;
                    position.Y = newY;
                    world.grid[newX, newY] = 'M';
                }
            }
        }


        public void PickUp(IWorldObject worldObject)
        {
            if (worldObject == null)
            {
                Logger.Log("Error: World object cannot be null.");

                return;
            }

            if (worldObject is AttackItem attackItem)
            {
                Logger.Log($"Enemy picked up {attackItem.Name}.");

                Weapons.Add(attackItem);

            }
            else if (worldObject is DefenceItem defenceItem)
            {
                Logger.Log($"Enemy picked up {defenceItem.Name}.");

                Shields.Add(defenceItem);

            }
        }


        public void Attack(Player player)
        {
            int totalDmg = Damage - player.Defence;
            if (totalDmg < 0) { totalDmg = 0; }
            player.Health -= totalDmg;
            Logger.Log($"{Name} attacked {player.Name} and dealt {totalDmg} damage.");
            if (player.Health <= 0)
            {
                Logger.Log($"{player.Name} was defeated!");
            }
        }

        /*
        public int TotalDmg()
        {
            foreach (AttackItem item in Weapons)
            {
                Damage += item.Damage;
            }
            return Damage;
        }

        public int TotadDef()
        {
            foreach (DefenceItem item in Shields)
            {
                Defence += item.Defence;
            }
            return Defence;
        }

        */

        //using LINQ to iterate over lists
        public int TotalDmg()
        {
            return Weapons.Sum(item => item.Damage);
        }

        public int TotalDef()
        {
            return Shields.Sum(item => item.Defence);
        }


        public void DisplayEnemyInfo(Enemy enemy)
        {
            Console.WriteLine($"Enemy health: {enemy.Health}");
            Console.WriteLine($"Enemy damage: {enemy.Damage}");
            Console.WriteLine($"Enemy defence: {enemy.Defence}");
        }

        public void Attack(Enemy enemy)
        {
            throw new NotImplementedException();
        }
    }

}
