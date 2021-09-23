using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextedBased_RPG
{
    class Shop : InteractiveArea
    {
        private int tax = 0; // added to sold items, set in constructor
        private ItemManager items; 
        public List<ITEM> itemsInShop = new List<ITEM>(); 
        private string itemsToBuy; // string that shows what player can  buy  at the shop
        private string itemsToSell; // ^^ but                            sell

        //constructor
        public Shop(string name, string DesiredDialogue, int x, int y, ItemManager itemsTarget, List<ITEM> itemsForStock, int thisShopTax) : base(name, DesiredDialogue)
        {
            base.x = x;
            base.y = y;
            avatar = "$";
            items = itemsTarget;
            itemsInShop = itemsForStock;
            tax = thisShopTax;
            SetBuyAndSellString();
        }
        
        //gets/sets
        public List<ITEM> ItemsInShop { set { itemsInShop = value; } }

        //public methods
        public void SetBuyAndSellString() // set string to itemsToBuy/Sell then read string to input message // should only be able to buy and sell if item is in ItemsInShop
        {
            if (itemsInShop.Contains(ITEM.POTION))
            {
                itemsToBuy = itemsToBuy + $"\n{items.GetItemName(ITEM.POTION)[0]}) {items.GetItemName(ITEM.POTION)} - {items.GetItemPrice(ITEM.POTION) + tax}$";
                itemsToSell = itemsToSell + $"\n{items.GetItemName(ITEM.POTION)[0]}) {items.GetItemName(ITEM.POTION)} - {items.GetItemPrice(ITEM.POTION) }$";
            }
            if (itemsInShop.Contains(ITEM.RAFT))
            {
                itemsToBuy = itemsToBuy + $"\n{items.GetItemName(ITEM.RAFT)[0]}) {items.GetItemName(ITEM.RAFT)} - {items.GetItemPrice(ITEM.RAFT) + tax}$";
                itemsToSell = itemsToSell + $"\n{items.GetItemName(ITEM.RAFT)[0]}) {items.GetItemName(ITEM.RAFT)} - {items.GetItemPrice(ITEM.RAFT)}$";
            }
            if (itemsInShop.Contains(ITEM.SWORD))
            {
                itemsToBuy = itemsToBuy + $"\n{items.GetWeaponName(ITEM.SWORD)[0]}) {items.GetWeaponName(ITEM.SWORD)} / ATTK^{items.GetWeaponAttack(ITEM.SWORD)} - {items.GetItemPrice(ITEM.SWORD) + tax}$";
            }
            if (itemsInShop.Contains(ITEM.BOW))
            {
                itemsToBuy = itemsToBuy + $"\n{items.GetWeaponName(ITEM.BOW)[0]}) {items.GetWeaponName(ITEM.BOW)} / ATTK^{items.GetWeaponAttack(ITEM.BOW)} - {items.GetItemPrice(ITEM.BOW) + tax}$";
            }
        }
        private void BuyOutput() // Exchanges Money for a taxed item
        {

            if (input == (ConsoleKey)items.GetWeaponName(ITEM.SWORD)[0] && itemsInShop.Contains(ITEM.SWORD))
            {
                if (user.Money >= items.GetItemPrice(ITEM.SWORD)) // buy method
                {
                    Console.Clear();
                    lastAction = $"you purchase a {items.GetWeaponName(ITEM.SWORD)} for {items.GetItemPrice(ITEM.SWORD) + tax}";
                    int attackChange = user.baseAttack + items.GetWeaponAttack(ITEM.SWORD);
                    Console.WriteLine($"purchasing a {items.GetWeaponName(ITEM.SWORD)} \nwill change your attack to " + attackChange + " from " + user.attack + ".");
                    user.CashSpend(items.GetItemPrice(ITEM.SWORD) + tax);
                    user.WeaponChange(ITEM.SWORD);
                    Console.ReadKey(true);
                }
                else
                {
                    lastAction = "come back with more cash";
                }
            }
            else if (input == (ConsoleKey)items.GetWeaponName(ITEM.BOW)[0] && itemsInShop.Contains(ITEM.BOW))
            {
                if (user.Money >= items.GetItemPrice(ITEM.BOW))
                {
                    Console.Clear();
                    lastAction = $"you purchased a {items.GetWeaponName(ITEM.BOW)} for {items.GetItemPrice(ITEM.BOW) + tax}";
                    int attackChange = user.baseAttack + items.GetWeaponAttack(ITEM.BOW);
                    Console.WriteLine($"purchasing a {items.GetWeaponName(ITEM.BOW)} \nwill change your attack to " + attackChange + " from " + user.attack + ".");
                    user.CashSpend(items.GetItemPrice(ITEM.BOW) + tax);
                    user.WeaponChange(ITEM.BOW);
                    Console.ReadKey(true);
                }
                else
                {
                    lastAction = "come back with more cash";
                }
            }
            else if (input == (ConsoleKey)items.GetItemName(ITEM.POTION)[0] && itemsInShop.Contains(ITEM.POTION))
            {
                if (user.Money >= items.GetItemPrice(ITEM.POTION))
                {
                    lastAction = $"you buy a {items.GetItemName(ITEM.POTION)} with {items.GetItemPrice(ITEM.POTION) + tax}$";
                    user.CashSpend(items.GetItemPrice(ITEM.POTION) + tax);
                    user.potionNumber++;
                }
                else
                {
                    lastAction = "come back with more cash";
                }
            }
            else if (input == (ConsoleKey)items.GetItemName(ITEM.RAFT)[0] && itemsInShop.Contains(ITEM.RAFT))
            {
                if (user.Money >= items.GetItemPrice(ITEM.RAFT) && !user.hasBoat)
                {
                    lastAction = $"You buy a {items.GetItemName(ITEM.RAFT)} with {items.GetItemPrice(ITEM.RAFT) + tax}$";
                    user.CashSpend(items.GetItemPrice(ITEM.RAFT) + tax);
                    user.hasBoat = true;
                }
                else if (user.hasBoat)
                {
                    lastAction = "You already have a boat";
                }
                else
                {
                    lastAction = "come back with more cash";
                }
            }
        }
        private void SellOutput() // Exchanges Items for Money
        {
            if (input == (ConsoleKey)items.GetItemName(ITEM.POTION)[0] && itemsInShop.Contains(ITEM.POTION))
            {
                if (user.potionNumber >= 1)
                {
                    lastAction = $"You sold a Potion for {items.GetItemPrice(ITEM.POTION)}";
                    user.CashGain(items.GetItemPrice(ITEM.POTION));
                    user.potionNumber--;
                }
                else
                {
                    lastAction = "You dont have enough potions to sell";
                }
            }
            else if (input == (ConsoleKey)items.GetItemName(ITEM.RAFT)[0] && itemsInShop.Contains(ITEM.RAFT))
            {
                if (user.hasBoat)
                {
                    lastAction = $"You sold your boat for {items.GetItemPrice(ITEM.RAFT)}";
                    user.CashGain(items.GetItemPrice(ITEM.RAFT));
                    user.hasBoat = false;
                }
                else 
                {
                    lastAction = "You dont have a boat to sell";
                }
            }
            else if (input == ConsoleKey.W) // entry into weapon selling is already guarded / no itemsinShop.Contains necessary
            {
                if (user.HeldWeapon != ITEM.NULL) // sell method
                {
                    lastAction = $"You sold a {items.GetWeaponName(user.HeldWeapon)} for {items.GetItemPrice(user.HeldWeapon) }$";
                    user.CashGain(items.GetItemPrice(user.HeldWeapon));
                    user.Weapon = "None";
                    user.HeldWeapon = ITEM.NULL;
                    user.attack = -5;
                }
                else
                {
                    lastAction = "Your hands are empty";
                }
            }
        }

        //public methods
        private void Shopping() // Shopping menu
        {
            Console.Clear();
            lastAction = "BUY SOMETHING, :D HA,HA,HA.";
            Console.WriteLine("stepping close to take a good look, you see little of value");
            bool shopping = true;
            while (shopping)
            {
                Console.WriteLine(lastAction);
                Console.WriteLine();
                Console.WriteLine($"Your cash: {user.Money}$");
                Console.WriteLine();
                Console.WriteLine("What would you like to buy?");
                Console.WriteLine($"{itemsToBuy}\nR) Return");

                input = Console.ReadKey(true).Key;
                BuyOutput();
                if (input == ConsoleKey.R)
                {
                    shopping = false;
                }
                Console.Clear();
            }
        }
        private void Selling() // Selling menu
        {
            bool selling = true;
            while (selling) 
            { 
                Console.Clear();
                Console.WriteLine(lastAction);
                Console.WriteLine();
                Console.WriteLine($"Your cash: {user.Money}$");
                Console.WriteLine();
                Console.WriteLine("What would you like to sell");
                Console.WriteLine(itemsToSell);
                if (user.HeldWeapon != ITEM.NULL) // only shows up if player has weapon to sell
                { 
                    Console.WriteLine($"W) {user.Weapon} - {items.GetItemPrice(user.HeldWeapon)-tax}$"); // Sell prompt
                }
                Console.WriteLine("R) Return");

                input = Console.ReadKey(true).Key;
                SellOutput();
                if (input == ConsoleKey.R)
                {
                    selling = false;
                }
            }
            Console.Clear();
        }
        public void EnterShop() // Shop Lobby
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
                        Shopping();
                        break;

                    case ConsoleKey.S://sell
                        Selling();
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
