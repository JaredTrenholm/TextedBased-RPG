using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextedBased_RPG
{
    class GameManager
    {
        
        public Enemy enemy = new Enemy();
        public string PlayerAttack = "";
        public string EnemyAttack = "";


        /// <summary>
        /// 9 left of the player is the map border
        /// 10 right of the player is the map border
        /// 4 up of the player is the map border
        /// 5 down of the player is the map border
        /// </summary>


        public void GameLoop()
        {
            Console.CursorVisible = false;
            for (int x = 0; x < 1;)
            {
                Console.Clear();
                enemy.DrawEnemy();
                Map.DrawMap();
                DisplayHUD();
                Program.user.DrawPlayer();
                Program.user.MovePlayer();
                enemy.EnemyTurn();
                //Map.ResetMap();
            }
        }

        public void DisplayHUD()
        {
            Console.WriteLine(EnemyAttack);
        }

        
    }
}
