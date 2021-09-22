using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextedBased_RPG
{
    class Bandit : Enemy
    {

        public Bandit(Random random) : base(random)
        {
            maxHealth = 20;
            health = maxHealth;
            Alive = true;
            name = "Bandit";
            attack = Global.BASE_ATTACK / 2;
            Avatar = "E";
        }
    }
}
