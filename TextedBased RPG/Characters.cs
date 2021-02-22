using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextedBased_RPG
{
    abstract class Characters
    {
        protected string name;
        protected int health;
        protected string AttackMessage = "";
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
        protected int movementType = 0;   // 0 = normal; 1 = aquatic; 2 = mountain; 3 = flying;
        protected int SpeciesType = 0;   // 0 = normal; 1 = aquatic; 2 = mountain; 3 = flying;



        public string GetAttackMessage()
        {
            return AttackMessage;
        }

        public void SetAttackMessage(string Message)
        {
            AttackMessage = Message;
        }
        public void CheckHealth()
        {

            if (health <= 0)
            {
                Alive = false;
            }
        }

        public string GetName()
        {
            return name;
        }
        public void SetName(string nameChange)
        {
            name = nameChange;
        }

        public int GetHealth()
        {
            return health;
        }
        public void SetHealth(int HealthChange)
        {
            health = HealthChange;
        }

        public void SetSpeciesType(int Species)
        {
            SpeciesType = Species;
            SetMovementType();
        }
        private void SetMovementType()
        {
            if (SpeciesType == 0)
            {
                movementType = 0;
            }
            else if (SpeciesType == 1)
            {
                movementType = 1;
            }
            else if (SpeciesType == 2)
            {
                movementType = 2;
            }
            else if (SpeciesType == 3)
            {
                movementType = 3;
            }
        }

        


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
