using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibAssignment.DecorationDesignPattern
{
    public class AttackDecoratorPattern : IMagicAttack
    {

        private readonly IMagicAttack _attack;  //this private field represents instance of IMagicAttack that will be decorated


        public AttackDecoratorPattern(IMagicAttack magicAttack)
        {
            _attack = magicAttack;
        }

        public virtual void MagicAttack(Enemy enemy)
        {
            _attack.MagicAttack(enemy);
        }
    }
}
