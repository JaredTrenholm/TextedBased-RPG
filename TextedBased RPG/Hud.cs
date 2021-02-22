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
        private Enemy enemy;

        public Hud(Player userTarget, Enemy enemyTarget)
        {
            user = userTarget;
            enemy = enemyTarget;
        }
        public void Display()
        {
            Console.WriteLine("Health: " + user.GetHealth() + "       " + user.CharacterX + ", " + user.CharacterY);
            Console.WriteLine("Weapon: " + user.Weapon);
            Console.WriteLine("Attack: " + user.attack);
            Console.WriteLine(Map.GetTileDesc());
            Console.WriteLine(user.PlayerAttackMessage);
            if(enemy.Alive == true)
            {
            Console.WriteLine(enemy.GetAttackMessage());
            }

        }

    }
}
