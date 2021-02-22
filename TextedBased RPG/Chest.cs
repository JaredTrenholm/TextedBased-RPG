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

        public int xPos;
        public int yPos;

        private string input;

        public Chest()
        {
            
            xPos = 0;
            yPos = 0;
            Opened = false;
            ItemType = 0;
            ItemID = 1;

        }

        public void DrawChest()
        {
            if (Opened == false)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Map.RenderData[yPos, xPos] = "C";
                    Console.ForegroundColor = ConsoleColor.White;
                }
                catch
                {
                    Console.WriteLine("X: " + xPos);
                    Console.WriteLine("Y: " + yPos);
                    Console.ReadKey(true);
                }
            }


        }

        public void SetPos(int x, int y)
        {
            xPos = x;
            yPos = y;
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
                        Console.WriteLine(Program.GM.user.GetName() + " have found a " + ItemData.GetWeaponName(ItemID));
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
