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
        BOW,
        POTION,
        RAFT,
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
            else if (WeaponID == ITEM.BOW)
            {
                weaponName = "Bow"; //5 attack
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
            else if (WeaponID == ITEM.BOW)
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
            else if (ItemID == ITEM.RAFT)
            {
                itemName = "Raft";
            }
            else if (ItemID == ITEM.MONEY)
            {
                itemName = "Money";
            }
            return itemName;
        }

        public int GetItemPrice(ITEM itemID)
        {
            int price = 0;
            if (itemID == ITEM.NULL)
            {
                price = 0;
            }
            else if (itemID == ITEM.POTION)
            {
                price = 10;
            }
            else if (itemID == ITEM.BOW)
            {
                price = 15;
            }
            else if (itemID == ITEM.SWORD)
            {
                price = 20;
            }
            else if (itemID == ITEM.RAFT)
            {
                price = 30;
            }
            return price;
        }

    }
}
