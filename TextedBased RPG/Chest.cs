using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextedBased_RPG
{
    class Chest
    {
        public bool Opened = false;
        public int ItemType; //0 = Weapon
        public int ItemID; //the index of the item type

        public int x;
        public int y;

        private string input;

        public Chest()
        {
            
            x = 0;
            y = 0;
            Opened = false;
            ItemType = 0;
            ItemID = 1;

        }

        public void DrawChest()
        {
            if (Opened == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Map.mapData[y, x] = "C";
                Console.ForegroundColor = ConsoleColor.White;
            }


        }

        public void CheckChest()
        {
            if(Opened == false)
            {
                if (ItemType == 0)
                {
                    for(int x = 0; x < 1;)
                    {
                        Console.Clear();
                        Console.WriteLine(Program.GM.user.name + " have found a " + ItemData.GetWeaponName(ItemID));
                        Console.WriteLine("Equip it? Y/N");
                        Opened = true;
                        input = Console.ReadKey(true).Key.ToString();
                        if(input == ConsoleKey.Y.ToString())
                        {
                            Program.GM.user.WeaponChange(ItemID);
                            x = 1;
                        } else if (input == ConsoleKey.N.ToString())
                        {
                            x = 1;
                        }

                    }
                }
            }
        }
    }
}
