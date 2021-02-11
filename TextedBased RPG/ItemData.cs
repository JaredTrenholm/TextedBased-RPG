using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextedBased_RPG
{
    class ItemData
    {
        private static string weaponName;
        public static string GetWeaponName(int WeaponID)
        {
            if(WeaponID == 0)
            {
                weaponName = "None";
            } else if (WeaponID == 1)
            {
                weaponName = "Sword";
            }
            return weaponName;
        }

        public static void SetWeaponID(int WeaponID)
        {

        }

    }
}
