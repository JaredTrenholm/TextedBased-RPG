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

        private ItemManager items;

        public Chest(int itemTypeTarget, int itemIDTarget, ItemManager itemTarget)
        {
            itemType = itemTypeTarget;
            ItemID = itemIDTarget;
            xPos = 0;
            yPos = 0;
            Opened = false;
            items = itemTarget;

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

                    Renderer.RenderData[yPos, xPos] = "C";
            }
            else
            {

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
                        Console.WriteLine(player.GetName() + " have found a " + items.GetWeaponName(ItemID));
                        attackChange = player.baseAttack + items.GetWeaponAttack(ItemID);
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
                        Console.WriteLine(player.GetName() + " have found a " + items.GetItemName(ItemID) + ".");
                        if (ItemID == 1)
                        {
                            player.potionNumber = player.potionNumber + 1;
                            Opened = true;
                            if (player.potionNumber > 1)
                            {
                                Console.WriteLine(player.GetName() + " now have " + player.potionNumber + " potions.");
                            }
                            else
                            {
                                Console.WriteLine(player.GetName() + " now have " + player.potionNumber + " potion.");
                            }
                            Console.ReadKey(true);
                            x = 1;
                        } else if(ItemID == 2)
                        {
                            Console.WriteLine(player.GetName() + " can now travel on water!");
                            player.hasBoat = true;
                            Opened = true;
                            Console.ReadKey(true);
                            x = 1;
                        }
                    }
                }
            Console.Clear();
            }

        }
    }
}
