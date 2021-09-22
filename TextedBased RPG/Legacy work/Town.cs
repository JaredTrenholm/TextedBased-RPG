using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextedBased_RPG
{
    class Town : InteractiveArea
    {
        public string Name { get { return name; } set { name = value; } }

        //constructor
        public Town(string name, string DesiredDialogue) : base(name, DesiredDialogue)
        {
            x = 15;
            y = 10;
            avatar = "T";
        }

        public void EnterTown()
        {
            lastAction = "";
            for (int x = 0; x < 1;)
            {
                Console.Clear();
                Console.WriteLine("You are in the friendly town of " + name + "!");
                Console.WriteLine(lastAction);
                Console.WriteLine("");
                Console.WriteLine("What do you want to do?");
                Console.WriteLine("T) Talk\nH) Heal - 2$\nL) Leave");

                input = Console.ReadKey(true).Key;

                switch (input)
                {
                    case ConsoleKey.T:
                        Console.Clear();
                        lastAction = "You found some friendly villagers to talk to.";
                        Console.WriteLine("You found some friendly villagers. Here is what they had to say.");
                        Console.WriteLine();
                        Console.WriteLine(dialogue);
                        Console.ReadKey(true);
                        break;

                    case ConsoleKey.H:
                        lastAction = "You rested and made sure you were at perfect health before leaving!";
                        user.CashSpend(2);
                        user.HealAll();
                        break;

                    case ConsoleKey.L:
                        x = 1;
                        break;
                }
                {
                    /*
                                    if (input == "T")
                                    {

                                    }
                                    else if (input == "t")
                                    {
                                        Console.Clear();
                                        Console.WriteLine("You found some friendly villagers. Here is what they had to say.");
                                        Console.WriteLine();
                                        Console.WriteLine(dialogue);
                                        Console.ReadKey(true);
                                    }
                                    else if (input == "H")
                                    {


                                    }
                                    else if (input == "h")
                                    {
                                        lastAction = "You rested and made sure you were at perfect health before leaving!";
                                        user.HealAll();
                                    }
                                    else if (input == "L")
                                    {
                                        x = 1;
                                    }
                                    else if (input == "l")
                                    {
                                        x = 1;
                                    }
                                    else
                                    {

                                    }*/
                }// old switch (if)
            }

            Console.Clear();
        }
    }
}
