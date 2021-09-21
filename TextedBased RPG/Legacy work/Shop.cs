using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextedBased_RPG
{
    class Shop : InteractiveArea
    {
        private int priceOfPotion = 10;
        private int priceOfSword = 20;
        private int priceOfBow = 15;
        private ItemManager items;
        //constructor
        public Shop(string name, string DesiredDialogue, int x, int y, ItemManager itemsTarget) : base(name, DesiredDialogue)
        {
            base.x = x;
            base.y = y;
            avatar = "$";
            items = itemsTarget;
        }

        public void EnterShop()
        {
            lastAction = "";
            for (int x = 0; x < 1;)
            {
                Console.Clear();
                Console.WriteLine($"In a dark hut, you stand in the middle of {name},\nyou look around behind their desk as they Grin");
                Console.WriteLine(lastAction);
                Console.WriteLine("");
                Console.WriteLine("What do you want to do?");
                Console.WriteLine("B) Buy\nS) Sell\nT) Talk\nL) Leave");

                input = Console.ReadKey(true).Key;
                switch (input)
                {
                    case ConsoleKey.B:
                        Console.Clear();
                        lastAction = "BUY SOMETHING, :D HA,HA,HA.";
                        Console.WriteLine("stepping close to take a good look, you see little of value");
                        Console.WriteLine();
                        bool shopping = true;
                        while (shopping)
                        {   
                            Console.WriteLine(lastAction);
                            Console.WriteLine();
                            Console.WriteLine("What would you like to buy?");
                            Console.WriteLine($"S) {items.GetWeaponName(ITEM.SWORD)} / ATTK^{items.GetWeaponAttack(ITEM.SWORD)} - {priceOfSword}$\nB) {items.GetWeaponName(ITEM.SHORTBOW)} / ATTK^{items.GetWeaponAttack(ITEM.SHORTBOW)} - {priceOfBow}$\nP) Potion - {priceOfPotion}$\nR) Return");
                            
                            input = Console.ReadKey(true).Key;
                            switch(input)
                            {
                                case ConsoleKey.S:
                                    if (user.Money >= priceOfSword)
                                    {
                                        Console.Clear();
                                        lastAction = $"you purchase a {items.GetWeaponName(ITEM.SWORD)}";
                                        int attackChange = user.baseAttack + items.GetWeaponAttack(ITEM.SWORD);
                                        Console.WriteLine($"purchasing a {items.GetWeaponName(ITEM.SWORD)} \nwill change your attack to " + attackChange + " from " + user.attack + ".");
                                        user.CashSpend(priceOfSword);
                                        user.WeaponChange(ITEM.SWORD);
                                        Console.ReadKey(true);
                                    }
                                    else
                                    {
                                        lastAction = "come back with more cash";
                                    }
                                    break;

                                case ConsoleKey.B:
                                    if (user.Money >= priceOfBow)
                                    {
                                        Console.Clear();
                                        lastAction = $"you purchased a {items.GetWeaponName(ITEM.SHORTBOW)}";
                                        int attackChange = user.baseAttack + items.GetWeaponAttack(ITEM.SHORTBOW);
                                        Console.WriteLine($"purchasing a {items.GetWeaponName(ITEM.SHORTBOW)} \nwill change your attack to " + attackChange + " from " + user.attack + ".");
                                        user.CashSpend(priceOfBow);
                                        user.WeaponChange(ITEM.SHORTBOW);
                                        Console.ReadKey(true);
                                    }
                                    else
                                    {
                                        lastAction = "come back with more cash";
                                    }
                                    break;

                                case ConsoleKey.P:
                                    if (user.Money >= priceOfPotion)
                                    { 
                                        lastAction = $"you buy a potion with {priceOfPotion}$";
                                        user.CashSpend(priceOfPotion);
                                        user.potionNumber++;
                                    }
                                    else
                                    {
                                        lastAction = "come back with more cash";
                                    }
                                    break;

                                case ConsoleKey.R:
                                    shopping = false;
                                    break;
                            }
                            Console.Clear();
                        }
                        break;

                    case ConsoleKey.S://sell


                    case ConsoleKey.T:
                        Console.Clear();
                        Console.WriteLine(dialogue);
                        lastAction = "T's'Alway's nice to chat with the Vagrant type.";
                        Console.ReadKey(true);
                        break;

                    case ConsoleKey.L:
                        x = 1;
                        break;
                }
            }
            
            Console.Clear();
        }
    }
}
