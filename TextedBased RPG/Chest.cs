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

        public int xPos;
        public int yPos;

        private string input;

        private int attackChange = 0;

        public Chest()
        {
            
            xPos = 0;
            yPos = 0;
            Opened = false;

        }

        public void Draw()
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
        public void CheckChest(int itemType, int ItemID)
        {
            if(Opened == false)
            {
                if (itemType == 0)
                {
                    for(int x = 0; x < 1;)
                    {
                        Console.Clear();
                        Console.WriteLine(Program.GM.user.GetName() + " have found a " + ItemData.GetWeaponName(ItemID));
                        attackChange = Program.GM.user.baseAttack + ItemData.GetWeaponAttack(ItemID);
                        Console.WriteLine("It will change your attack to " + attackChange + " from " + Program.GM.user.attack +".");
                        Console.WriteLine("Equip it? Y/N");
                        input = Console.ReadKey(true).Key.ToString();
                        if(input == ConsoleKey.Y.ToString())
                        {
                            Program.GM.user.WeaponChange(ItemID);
                            x = 1;
                            Opened = true;
                        } else if (input == ConsoleKey.N.ToString())
                        {
                            x = 1;
                        }

                    }
                } else if (itemType == 1)
                {
                    for (int x = 0; x < 1;)
                    {
                        Console.Clear();
                        Console.WriteLine(Program.GM.user.GetName() + " have found a " + ItemData.GetItemName(ItemID));
                        Console.WriteLine("Use it? Y/N");
                        input = Console.ReadKey(true).Key.ToString();
                        if (input == ConsoleKey.Y.ToString())
                        {
                            Program.GM.user.UseItem(ItemID);
                            x = 1;
                            Opened = true;
                        }
                        else if (input == ConsoleKey.N.ToString())
                        {
                            x = 1;
                        }

                    }
                }
            }
            Console.Clear();

        }
    }
}
