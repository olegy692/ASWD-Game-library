using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibAssignment.DecorationDesignPattern
{
    public class FireAttack : AttackDecoratorPattern
    {

        private readonly int _fireDamage;

        public FireAttack(IMagicAttack magicAttack, int fireDamage) : base(magicAttack) //calling base constructor of IMagicAttack to initialize magicAttack parameter
        {
            _fireDamage = fireDamage;
        }

        public override void MagicAttack(Enemy enemy) //overriding method
        {
            base.MagicAttack(enemy);
            enemy.Health -= _fireDamage;
            Console.WriteLine($"You used fire attack, {_fireDamage} damage dealt");
        }



    }
}
