using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextedBased_RPG
{
    class Slime : Enemy
    {

        public Slime(Random random) : base(random)
        {
            maxHealth = 10;
            health = maxHealth;
            Alive = true;
            name = "Slime";
            attack = Global.BASE_ATTACK / 5;
            Avatar = "S";

        }
    }
}
