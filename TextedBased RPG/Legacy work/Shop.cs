using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextedBased_RPG
{
    class Shop : InteractiveArea
    {
    
        //constructor
        public Shop(string name, string DesiredDialogue) : base(name, DesiredDialogue)
        {
            x = 16;
            y = 7;
            avatar = "$";
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
                Console.WriteLine("B) Buy\nT) Talk\nL) Leave");

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
                            Console.WriteLine("N) Nothing\nP) Potion\nL) Leave");
                            
                            input = Console.ReadKey(true).Key;
                            switch(input)
                            {




                                case ConsoleKey.L:
                                    shopping = false;
                                    break;
                            }
                            Console.Clear();
                        }
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
