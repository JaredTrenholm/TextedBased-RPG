using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextedBased_RPG
{
    abstract class CharacterSystem
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
        protected int Damagetaken;
        public int attack;
        public int baseAttack;

        private int BonusAttack = 0;
        public string Weapon = "None";


        public void TakeDamage(int damage)
        {
            
            if(damage > health)
            {
                damage = health;
                Damagetaken = damage;
                health = 0;
                Alive = false;
               
            }
            else
            {
                health = health - damage;
                Damagetaken = damage;
            }
        }

        public void WeaponChange(int WeaponID)
        {
            
            if(ItemData.GetWeaponName(WeaponID) == "None")
            {
                Weapon = ItemData.GetWeaponName(WeaponID);
                BonusAttack = 0;
            } else if (ItemData.GetWeaponName(WeaponID) == "Sword")
            {
                Weapon = ItemData.GetWeaponName(WeaponID);
                BonusAttack = 10;
            }
            attack = baseAttack + BonusAttack;
        }

        
    }
}
