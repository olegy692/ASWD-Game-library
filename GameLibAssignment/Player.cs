using GameLibAssignment.DecorationDesignPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibAssignment
{

    public class Player : ICreature, IMagicAttack
    {

        public string Name { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public int Defence { get; set; }
        public int Energy { get; set; }
        public Position position { get; set; }
        public List<AttackItem> weapons { get; set; }
        public List<DefenceItem> shields { get; set; }
        public World? world { get; set; }

        /// <summary>
        /// Player class with basic properties and methods to move on grid, attack and pickup world objects
        /// </summary>
        /// <param name="name"></param>
        /// <param name="health"></param>
        /// <param name="damage"></param>
        public Player(string name, int health, int damage, int energy)
        {
            Name = name;
            Health = health;
            Damage = damage;
            Energy = energy;
            position = new Position(2, 2); //default position where player will spawn when created

            weapons = new List<AttackItem>();
            shields = new List<DefenceItem>();

            Logger.Log($"Player with name: {Name}, health: {Health}, damage: {Damage}, energy: {Energy} is created");
        }

        public void Move(char direction, World world)
        {
            int newX = position.X;
            int newY = position.Y;

            switch (direction)
            {
                case 'w':
                    newY--;
                    break;
                case 'a':
                    newX--;
                    break;
                case 's':
                    newY++;
                    break;
                case 'd':
                    newX++;
                    break;
                default:
                    break;
            }

            // Check if the new position is inside the boundaries of the grid
            if (newX >= 0 && newX < world.maxX && newY >= 0 && newY < world.maxY)
            {
                // Check if the new position is empty or contains an enemy
                if (world.grid[newX, newY] == ' ')
                {
                    // Update the player's position on the grid
                    world.grid[position.X, position.Y] = ' ';
                    position.X = newX;
                    position.Y = newY;
                    world.grid[newX, newY] = '@';

                    Logger.Log($"Player with name: {Name} moved to new position ({newX}, {newY})");
                }
                else if (world.grid[newX, newY] == 'M') { }  //if cell is occupied by enemy do nothing
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
                Logger.Log($"You picked up {attackItem.Name}, + {attackItem.Damage} damage.");

                weapons.Add(attackItem);
            }
            else if (worldObject is DefenceItem defenceItem)
            {
                Logger.Log($"You picked up {defenceItem.Name}, + {defenceItem.Defence} defence.");

                shields.Add(defenceItem);
            }
        }
        public void Attack(Enemy enemy)
        {
            int totalDmg = Damage - enemy.Defence;
            if (totalDmg < 0) { totalDmg = 0; }
            enemy.Health -= totalDmg;

            Logger.Log($"{Name} attacked {enemy.Name} and dealt {totalDmg} damage.");

            if (enemy.Health <= 0)
            {
                Logger.Log($"{enemy.Name} was defeated!");
            }
        }

        /*
        public int TotalDmg()
        {
            foreach (AttackItem item in weapons)
            {
                Damage += item.Damage;
            }
            return Damage;
        }

        public int TotadDef()
        {
            foreach (DefenceItem item in shields)
            {
                Defence += item.Defence;
            }
            return Defence;
        }
        */


        //using LINQ to iterate over lists
        public int TotalDmg()
        {
            return weapons.Sum(item => item.Damage);
        }

        public int TotalDef()
        {
            return shields.Sum(item => item.Defence);
        }


        public void DisplayPlayerInfo(Player player)
        {
            Console.WriteLine($"Player health: {player.Health}");
            Console.WriteLine($"Player damage: {player.Damage}");
            Console.WriteLine($"Player defence: {player.Defence}");
            Console.WriteLine($"Player energy: {player.Energy}");
        }

        public void MagicAttack(Enemy enemy)
        {
            Logger.Log($"You used Magic attack on {enemy.Name}");

            Attack(enemy);
            Energy -= 10;

        }


        public void Attack(Player player)
        {
            throw new NotImplementedException();
        }


    }

}
