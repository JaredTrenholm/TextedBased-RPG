using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextedBased_RPG
{
    class Town
    {
        public string Dialogue = "";
        public string Name = "Town";
        private string LastAction;
        public int x;
        public int y;
        private string input;

        private Player user;



        public Town(string townName, string DesiredDialogue)
        {
            Name = townName;
            Dialogue = DesiredDialogue;
            x = 15;
            y = 10;

        }

        public void SetPlayer(Player userTarget)
        {
            user = userTarget;
        }

        public void Draw()
        {

            Renderer.RenderData[y, x] = "T";


        }
        public void EnterTown()
        {
            LastAction = "";
            for (int x = 0; x < 1;)
            {
                Console.Clear();
                Console.WriteLine("You are in the friendly town of " + Name + "!");
                Console.WriteLine(LastAction);
                Console.WriteLine("");
                Console.WriteLine("What do you want to do?");
                Console.WriteLine("T) Talk\nH) Heal\nL) Leave");

                input = Console.ReadKey(true).Key.ToString();

                if (input == "T")
                {
                    Console.Clear();
                    LastAction = "You found some friendly villagers to talk to.";
                    Console.WriteLine("You found some friendly villagers. Here is what they had to say.");
                    Console.WriteLine();
                    Console.WriteLine(Dialogue);
                    Console.ReadKey(true);
                }
                else if (input == "t")
                {
                    Console.Clear();
                    Console.WriteLine("You found some friendly villagers. Here is what they had to say.");
                    Console.WriteLine();
                    Console.WriteLine(Dialogue);
                    Console.ReadKey(true);
                }
                else if (input == "H")
                {
                    LastAction = "You rested and made sure you were at perfect health before leaving!";
                    user.HealAll();
                    
                }
                else if (input == "h")
                {
                    LastAction = "You rested and made sure you were at perfect health before leaving!";
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

                }
            }

            Console.Clear();
        }
    }
}
