using System;
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

        public Hud(Player userTarget, Enemy[] enemyTarget)
        {
            user = userTarget;
            enemy = enemyTarget;
        }
        public void Display()
        {
            PreviousEnemy = user.targetFoe;
            Console.WriteLine("Health: " + user.GetHealth() + "       " + user.CharacterX + ", " + user.CharacterY + "                                       ");
            Console.WriteLine("Weapon: " + user.Weapon);
            Console.WriteLine("Attack: " + user.attack);
            Console.WriteLine("                                                                                                         ");
            Console.SetCursorPosition(0, 15);
            Console.WriteLine(Map.GetTileDesc());
            Console.WriteLine(user.PlayerAttackMessage);

            if (PreviousEnemy != null)
            {
                if (PreviousEnemy.Alive != false)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Name: " + PreviousEnemy.GetName());
                    Console.WriteLine("Health: " + PreviousEnemy.GetHealth());
                    Console.WriteLine("Weapon: " + PreviousEnemy.Weapon);
                    Console.WriteLine("Attack: " + PreviousEnemy.attack);
                    Console.WriteLine(PreviousEnemy.GetAttackMessage());
                }
            }

        }

        public void MainMenu()
        {
            for(int x = 0; x < 1;)
            {
                Console.Clear();
                Console.WriteLine("----------------------");
                Console.WriteLine("Fantasy Rogue-like RPG");
                Console.WriteLine("----------------------");
                Console.WriteLine("");
                Console.WriteLine("P) Play");
                Console.WriteLine("Q) Quit");
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
                    inGame = false;
                    x = 1;
                }
                else if (input == "q")
                {
                    inGame = false;
                    x = 1;
                }
                else
                {

                }
                Console.Clear();
            }
            
        }

    }
}
