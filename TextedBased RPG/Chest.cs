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

        private Player player;

        public int xPos;
        public int yPos;


        private int itemType;
        private int ItemID;
        private string input;

        private int attackChange = 0;

        public Chest(int itemTypeTarget, int itemIDTarget)
        {
            itemType = itemTypeTarget;
            ItemID = itemIDTarget;
            xPos = 0;
            yPos = 0;
            Opened = false;

        }
        public void ChangeType(int itemTypeTarget)
        {
            itemType = itemTypeTarget;
        }
        public void ChangeID(int itemIDTarget)
        {
            ItemID = itemIDTarget;
        }


        public void FindPlayer(Player playerTarget)
        {
            player = playerTarget;
        }

        public void Draw()
        {
            if (Opened == false)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Renderer.RenderData[yPos, xPos] = "C";
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
                if (itemType == 0)
                {
                    for(int x = 0; x < 1;)
                    {
                        Console.Clear();
                        Console.WriteLine(player.GetName() + " have found a " + ItemData.GetWeaponName(ItemID));
                        attackChange = player.baseAttack + ItemData.GetWeaponAttack(ItemID);
                        Console.WriteLine("It will change your attack to " + attackChange + " from " + player.attack +".");
                        Console.WriteLine("Equip it? Y/N");
                        input = Console.ReadKey(true).Key.ToString();
                        if(input == ConsoleKey.Y.ToString())
                        {
                            player.WeaponChange(ItemID);
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
                        Console.WriteLine(player.GetName() + " have found a " + ItemData.GetItemName(ItemID));
                        Console.WriteLine("Use it? Y/N");
                        input = Console.ReadKey(true).Key.ToString();
                        if (input == ConsoleKey.Y.ToString())
                        {
                            player.UseItem(ItemID);
                            x = 1;
                            Opened = true;
                        }
                        else if (input == ConsoleKey.N.ToString())
                        {
                            x = 1;
                        }

                    }
                }
            Console.Clear();
            }

        }
    }
}
