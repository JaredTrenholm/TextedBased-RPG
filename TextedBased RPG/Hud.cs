using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextedBased_RPG
{

    class Hud
    {
        private Player user;
        private Enemy[] enemy;

        private Enemy PreviousEnemy;

        private string input;
        public bool inGame = false;

        public void findTargets(Player userTarget, Enemy[] enemyTarget)
        {
            user = userTarget;
            enemy = enemyTarget;
        }
        public void Display()
        {
            string Clear = "                                                                                                                                                                                                                                                                                      ";
            int HUDy = Console.CursorTop;
            int HUDx = Console.CursorLeft;
            PreviousEnemy = user.targetFoe;
            Console.WriteLine(Clear);
            Console.WriteLine(Clear);
            Console.WriteLine(Clear);
            Console.WriteLine(Clear);
            Console.WriteLine(Clear);
            Console.SetCursorPosition(0, 15);
            Console.WriteLine(Clear);
            Console.WriteLine(Clear);
            Console.WriteLine(Clear);
            Console.WriteLine(Clear);
            Console.WriteLine(Clear);
            Console.WriteLine(Clear);
            Console.WriteLine(Clear);
            Console.WriteLine(Clear);

            Console.SetCursorPosition(HUDx, HUDy);

            Console.WriteLine("Health: " + user.GetHealth() + "       " + user.CharacterX + ", " + user.CharacterY + "");
            Console.WriteLine("Potions: " + user.potionNumber + "");
            Console.WriteLine("Weapon: " + user.Weapon + "");
            Console.WriteLine("Attack: " + user.attack);
            Console.WriteLine("");
            Console.SetCursorPosition(0, 15);
            Console.WriteLine(Renderer.GetTileDesc());
            Console.WriteLine(user.PlayerAttackMessage);

            if (PreviousEnemy != null)
            {
                if (PreviousEnemy.Alive != false)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Name: " + PreviousEnemy.GetName() + "");
                    Console.WriteLine("Health: " + PreviousEnemy.GetHealth() + "");
                    Console.WriteLine("Weapon: " + PreviousEnemy.Weapon + "");
                    Console.WriteLine("Attack: " + PreviousEnemy.attack + "");
                    Console.WriteLine(PreviousEnemy.GetAttackMessage() + "");
                }
            }

            Console.CursorVisible = false;

        }

        public void MainMenu()
        {
            for(int x = 0; x < 1;)
            {
                Console.Clear();
                Console.WriteLine("┌──────────────────────────────────────────────────────────────────────────┐");
                Console.WriteLine("│                               Text Hero                                  │");
                Console.WriteLine("│                       Created by: Jared Trenholm                         │");
                Console.WriteLine("│                                                                          │");
                Console.WriteLine("│                           Move using WASD.                               │");
                Console.WriteLine("│ To make choices, press the letter that is represented beside the option. │");
                Console.WriteLine("└──────────────────────────────────────────────────────────────────────────┘");
                Console.WriteLine("                               ┌───────┐");
                Console.WriteLine("                               │P) Play│");
                Console.WriteLine("                               │Q) Quit│");
                Console.WriteLine("                               └───────┘");
                input = Console.ReadKey(true).Key.ToString();

                if(input == "P")
                {
                    x = 1;
                    inGame = true;
                } else if (input == "p")
                {
                    x = 1;
                    inGame = true;
                }
                else if(input == "Q")
                {
                    x = 1;
                    System.Environment.Exit(1);
                }
                else if (input == "q")
                {
                    x = 1;
                    System.Environment.Exit(1);
                }
                else
                {

                }
                Console.Clear();
            }
            
        }

        public void Intro()
        {
            Console.WriteLine("Welcome to the land of Azara! A once mighty nation, plagued by a bandit threat.");
            Console.WriteLine("Bandits have invaded most of the southern regions and is advancing up north quickly.");
            Console.WriteLine("You, on your return to your home village, run into the bandit army, led by Bandit Lord, Serdun.");
            Console.WriteLine("Will you sneak your way home, defeat the bandits, or die in their war path?");
            Console.WriteLine(" ");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey(true);
            Console.Clear();



        }

    }
}
