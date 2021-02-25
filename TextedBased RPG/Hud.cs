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

        public Hud(Player userTarget, Enemy[] enemyTarget)
        {
            user = userTarget;
            enemy = enemyTarget;
        }
        public void Display()
        {
            PreviousEnemy = user.targetFoe;
            Console.WriteLine("Health: " + user.GetHealth() + "       " + user.CharacterX + ", " + user.CharacterY);
            Console.WriteLine("Weapon: " + user.Weapon);
            Console.WriteLine("Attack: " + user.attack);
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

    }
}
