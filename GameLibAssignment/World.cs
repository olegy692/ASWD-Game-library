using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibAssignment
{

    public class World
    {
        public char[,] grid;
        public int maxX;
        public int maxY;
        public List<ICreature> creatures;
        public List<IWorldObject> worldObjects;
        public static World? Instance; // allows to access world without creating new instance every time
        /// <summary>
        /// World creation class with methods to draw world, add and remove creatures and world objects
        /// </summary>
        /// <param name="maxX"></param>
        /// <param name="maxY"></param>
        public World(int maxX, int maxY)
        {
            this.maxX = maxX;
            this.maxY = maxY;
            grid = new char[maxX, maxY];
            creatures = new List<ICreature>();
            worldObjects = new List<IWorldObject>();

            Instance = this;

            for (int x = 0; x < maxX; x++)
            {
                for (int y = 0; y < maxY; y++)
                {
                    if (x == 0 || x == maxX - 1 || y == 0 || y == maxY - 1)
                    {
                        grid[x, y] = '#';
                    }
                    else
                    {
                        grid[x, y] = ' ';
                    }
                }
            }

            Logger.Log($"World with X: {maxX} and Y: {maxY} has been created");

        }
        
        public void Draw()
        {
            for (int y = 0; y < maxY; y++)
            {
                for (int x = 0; x < maxX; x++)
                {
                    Console.Write(grid[x, y]);
                }
                Console.WriteLine();
            }
        }

        public void AddCreature(ICreature creature)
        {
            creatures.Add(creature);
            grid[creature.position.X, creature.position.Y] = creature.GetType() == typeof(Player) ? '@' : 'M';

            // ternary operator - checks if object is player and sets it to @ if not sets it to M

            Logger.Log($"Added a {creature.GetType().Name} at position ({creature.position.X}, {creature.position.Y}).");

        }


        public void AddWorldObject(IWorldObject worldObject)
        {
            worldObjects.Add(worldObject);
            if (worldObject is AttackItem)
            {
                grid[worldObject.position.X, worldObject.position.Y] = 'i';

                Logger.Log($"Added an attack item {((AttackItem)worldObject).Name} at position ({worldObject.position.X}, {worldObject.position.Y}).");

            }
            else
            {
                grid[worldObject.position.X, worldObject.position.Y] = 'o';

                Logger.Log($"Added a world object {worldObject.Name} at position ({worldObject.position.X}, {worldObject.position.Y}).");

            }
        }

        public void RemoveWorldObject(IWorldObject worldObject)
        {
            if (worldObjects.Contains(worldObject))
            {
                worldObjects.Remove(worldObject);
                if (worldObject is AttackItem || worldObject is DefenceItem)
                {
                    grid[worldObject.position.X, worldObject.position.Y] = ' ';

                    Logger.Log($"Removed an item at position ({worldObject.position.X}, {worldObject.position.Y}).");

                }
            }
        }




    }

}
