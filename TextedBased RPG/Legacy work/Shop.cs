using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextedBased_RPG
{
    class Shop : InteractiveArea
    {
        private int shopTax = 3; // added to sold items
        private ItemManager items;
        //constructor
        public Shop(string name, string DesiredDialogue, int x, int y, ItemManager itemsTarget) : base(name, DesiredDialogue)
        {
            base.x = x;
            base.y = y;
            avatar = "$";
            items = itemsTarget;
        }

        private void Buy()
        {
            Console.Clear();
            lastAction = "BUY SOMETHING, :D HA,HA,HA.";
            Console.WriteLine();
            Console.WriteLine($"Your ca$h: {user.Money}");
            Console.WriteLine("stepping close to take a good look, you see little of value");
            bool shopping = true;
            while (shopping)
            {
                Console.WriteLine(lastAction);
                Console.WriteLine();
                Console.WriteLine("What would you like to buy?");
                Console.WriteLine($"S) {items.GetWeaponName(ITEM.SWORD)} / ATTK^{items.GetWeaponAttack(ITEM.SWORD)} - {items.GetItemPrice(ITEM.SWORD)}$\nB) {items.GetWeaponName(ITEM.SHORTBOW)} / ATTK^{items.GetWeaponAttack(ITEM.SHORTBOW)} - {items.GetItemPrice(ITEM.SHORTBOW)}$\nP) Potion - {items.GetItemPrice(ITEM.POTION)}$\nR) Return");

                input = Console.ReadKey(true).Key;
                switch (input)
                {
                    case ConsoleKey.S:
                        if (user.Money >= items.GetItemPrice(ITEM.SWORD))
                        {
                            Console.Clear();
                            lastAction = $"you purchase a {items.GetWeaponName(ITEM.SWORD)}";
                            int attackChange = user.baseAttack + items.GetWeaponAttack(ITEM.SWORD);
                            Console.WriteLine($"purchasing a {items.GetWeaponName(ITEM.SWORD)} \nwill change your attack to " + attackChange + " from " + user.attack + ".");
                            user.CashSpend(items.GetItemPrice(ITEM.SWORD));
                            user.WeaponChange(ITEM.SWORD);
                            Console.ReadKey(true);
                        }
                        else
                        {
                            lastAction = "come back with more cash";
                        }
                        break;

                    case ConsoleKey.B:
                        if (user.Money >= items.GetItemPrice(ITEM.SHORTBOW))
                        {
                            Console.Clear();
                            lastAction = $"you purchased a {items.GetWeaponName(ITEM.SHORTBOW)}";
                            int attackChange = user.baseAttack + items.GetWeaponAttack(ITEM.SHORTBOW);
                            Console.WriteLine($"purchasing a {items.GetWeaponName(ITEM.SHORTBOW)} \nwill change your attack to " + attackChange + " from " + user.attack + ".");
                            user.CashSpend(items.GetItemPrice(ITEM.SHORTBOW));
                            user.WeaponChange(ITEM.SHORTBOW);
                            Console.ReadKey(true);
                        }
                        else
                        {
                            lastAction = "come back with more cash";
                        }
                        break;

                    case ConsoleKey.P:
                        if (user.Money >= items.GetItemPrice(ITEM.POTION))
                        {
                            lastAction = $"you buy a potion with {items.GetItemPrice(ITEM.POTION)}$";
                            user.CashSpend(items.GetItemPrice(ITEM.POTION));
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
        }

        private void Sell()
        {
            bool selling = true;
            while (selling) 
            { 
                Console.Clear();
                Console.WriteLine(lastAction);
                Console.WriteLine();
                Console.WriteLine($"Your ca$h: {user.Money}");
                Console.WriteLine("What would you like to sell");
                Console.WriteLine($"P) {items.GetItemName(ITEM.POTION)} - {items.GetItemPrice(ITEM.POTION)-shopTax}");
                if (user.HeldWeapon != ITEM.NULL)
                { 
                    Console.WriteLine($"W) {user.Weapon} - {items.GetItemPrice(user.HeldWeapon)-shopTax}");
                }
                Console.WriteLine("R) Return");

                input = Console.ReadKey(true).Key;
                switch (input)
                {
                    case ConsoleKey.P:
                        if (user.potionNumber >= 1)
                        {
                            lastAction = "You sold a Potion";
                            user.CashGain(items.GetItemPrice(ITEM.POTION)-shopTax);
                            user.potionNumber--;
                        }
                        else
                        {
                            lastAction = "You dont have enough potions to sell";
                        }
                        break;

                    case ConsoleKey.W:
                        if (user.HeldWeapon != ITEM.NULL)
                        {
                            lastAction = $"You sold a {items.GetWeaponName(user.HeldWeapon)} for {items.GetItemPrice(user.HeldWeapon) - shopTax}$";
                            user.CashGain(items.GetItemPrice(user.HeldWeapon) - shopTax);
                            user.Weapon = "None";
                            user.HeldWeapon = ITEM.NULL;
                            user.attack =- 5;
                        }
                        else
                        {
                            lastAction = "Your hands are empty";
                        }
                        break;

                    case ConsoleKey.R:
                        selling = false;
                        break;
                }
            }
            Console.Clear();
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
                        Buy();
                        break;

                    case ConsoleKey.S://sell
                        Sell();
                        break;

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
