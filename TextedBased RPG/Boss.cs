using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextedBased_RPG
{
    class Boss : Enemy
    {
        public Boss(Random random) : base(random)
        {
            maxHealth = 100;
            health = maxHealth;
            Alive = true;
            name = Global.BOSS_NAME;
            attack = Global.BASE_ATTACK;
            Avatar = "B";
        }
    }
}
