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
        public int MaxPosY = Global.MAP_Y_LENGTH-1;
        public int MaxPosX = Global.MAP_X_LENGTH-1;
        public int CharacterX;
        public int CharacterY;
        protected int Damagetaken;
        public int attack;
        public int baseAttack = Global.BASE_ATTACK;
        private int BonusAttack = 0;
        public string Weapon = "None";
        private ITEM heldWeapon;
        protected int movementType = 0;   // 0 = normal; 1 = aquatic; 2 = mountain; 3 = flying;
        protected int SpeciesType = 0;   // 0 = normal; 1 = aquatic; 2 = mountain; 3 = flying;

        protected ItemManager items;

        public ITEM HeldWeapon { get { return heldWeapon; } set { heldWeapon = value; } }

        public string GetAttackMessage()
        {
            return AttackMessage;
        }

        public void SetAttackMessage(string Message)
        {
            AttackMessage = Message;
        }
        virtual public void CheckHealth()
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

        public void HealAll()
        {
            health = maxHealth;
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

        public void WeaponChange(ITEM WeaponID)
        {
            
            if(WeaponID == ITEM.NULL)
            {
                Weapon = items.GetWeaponName(WeaponID);
                heldWeapon = ITEM.NULL;
                BonusAttack = 0;
            } else if (WeaponID == ITEM.SWORD)
            {
                Weapon = items.GetWeaponName(WeaponID);
                heldWeapon = ITEM.SWORD;
                BonusAttack = 10;
            }
            else if (WeaponID == ITEM.BOW)
            {
                Weapon = items.GetWeaponName(WeaponID);
                heldWeapon = ITEM.BOW; 
                BonusAttack = 5;
            }
            attack = baseAttack + BonusAttack;
        }

        public void UseItem(ITEM itemID)
        {
            if (items.GetItemName(itemID) == "None")
            {
                
            }
            else if (items.GetItemName(itemID) == "Potion")
            {
                health = health + Global.POTION_HEAL;
                if (health > maxHealth)
                {
                    health = maxHealth;
                }
            }
        }

        
    }
}
