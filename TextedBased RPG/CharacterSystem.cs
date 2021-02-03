using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextedBased_RPG
{
    class CharacterSystem
    {
        public string name;
        public int health;
        public int maxHealth;
        public bool Alive;
        public int MinPos = 1;
        public int MaxPosY = 10;
        public int MaxPosX = 20;
        public int CharacterX;
        public int CharacterY;

        public void TakeDamage(int damage)
        {
            
            if(damage > health)
            {
                damage = health;
                health = 0;
                Console.WriteLine(name + " took " + damage + " points of damage!");
                Alive = false;
               
            }
            else
            {
                health = health - damage;
                Console.WriteLine(name + " took " + damage + " points of damage!");
            }
        }
    }
}
