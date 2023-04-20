using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibAssignment
{

    public interface IWorldObject
    {
        string Name { get; set; }
        public Position position { get; set; }
        int Damage { get; set; }
        int Defence { get; set; }


        public abstract Position GetRandomPosition();

    }
}
