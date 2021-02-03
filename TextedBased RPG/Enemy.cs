using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextedBased_RPG
{
    class Enemy : CharacterSystem
    {
        public Enemy()
        {
            maxHealth = 25;
            health = 25;
            Alive = true;
            name = "Your Foe";
        }
    }
}
