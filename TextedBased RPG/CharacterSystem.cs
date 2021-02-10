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
        public int MinPos = 0;
        public int MaxPosY = 29;
        public int MaxPosX = 29;
        public int CharacterX;
        public int CharacterY;
        

        public void TakeDamage(int damage)
        {
            
            if(damage > health)
            {
                damage = health;
                health = 0;
                Alive = false;
               
            }
            else
            {
                health = health - damage;
            }
        }

        
    }
}
