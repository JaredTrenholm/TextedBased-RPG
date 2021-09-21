using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextedBased_RPG
{
    enum ITEM
    { 
        NULL,
        SWORD,
        SHORTBOW,
        POTION,
        BOAT,
        MONEY
    }
    enum ITEMTYPE
    { 
       NULL,
       ITEM,
       WEAPON
    }
    class ItemManager
    {
        private string weaponName;
        private string itemName;

        private int attackMod;
        public string GetWeaponName(ITEM WeaponID)
        {
            if(WeaponID == ITEM.NULL)
            {
                weaponName = "None";
            } 
            else if (WeaponID == ITEM.SWORD)
            {
                weaponName = "Sword";
            }
            else if (WeaponID == ITEM.SHORTBOW)
            {
                weaponName = "Short Bow"; //5 attack
            }
            return weaponName;
        }

        public int GetWeaponAttack(ITEM WeaponID)
        {
            if (WeaponID == ITEM.NULL)
            {
                attackMod = 0;
            }
            else if (WeaponID == ITEM.SWORD)
            {
                attackMod = 10;
            }
            else if (WeaponID == ITEM.SHORTBOW)
            {
                attackMod = 5;
            }
            return attackMod;
        }

        public string GetItemName(ITEM ItemID)
        {
            if (ItemID == ITEM.NULL)
            {
                itemName = "None"; //nothing
            }
            else if (ItemID == ITEM.POTION)
            {
                itemName = "Potion";
            }
            else if (ItemID == ITEM.BOAT)
            {
                itemName = "Boat";
            }
            else if (ItemID == ITEM.MONEY)
            {
                itemName = "Money";
            }
            return itemName;
        }

    }
}
