using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextedBased_RPG
{
    class Dog : Enemy
    {

        public Dog(Random random) : base(random)
        {
            
            maxHealth = 10;
            health = maxHealth;
            Alive = true;
            name = "Dog";
            attack = Global.BASE_ATTACK / 2;
            Avatar = "D";
        }
    }
}
