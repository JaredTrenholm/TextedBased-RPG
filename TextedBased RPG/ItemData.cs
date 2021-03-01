using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextedBased_RPG
{
    abstract class ItemData
    {
        private static string weaponName;
        private static string itemName;

        private static int attackMod;
        public static string GetWeaponName(int WeaponID)
        {
            if(WeaponID == 0)
            {
                weaponName = "None";
            } else if (WeaponID == 1)
            {
                weaponName = "Sword";
            }
            else if (WeaponID == 2)
            {
                weaponName = "Short Bow"; //5 attack
            }
            return weaponName;
        }

        public static int GetWeaponAttack(int WeaponID)
        {
            if (WeaponID == 0)
            {
                attackMod = 0;
            }
            else if (WeaponID == 1)
            {
                attackMod = 10;
            }
            else if (WeaponID == 2)
            {
                attackMod = 5;
            }
            return attackMod;
        }

        public static void SetWeaponID(int WeaponID)
        {
            if (WeaponID == 0)
            {
                weaponName = "None"; //0 attack
            }
            else if (WeaponID == 1)
            {
                weaponName = "Sword"; //10 attack
            }
            else if (WeaponID == 2)
            {
                weaponName = "Short Bow"; //5 attack
            }
        }

        public static string GetItemName(int ItemID)
        {
            if (ItemID == 0)
            {
                itemName = "None"; //nothing
            }
            else if (ItemID == 1)
            {
                itemName = "Potion"; //potion for 25 health
            }
            return itemName;
        }

    }
}
