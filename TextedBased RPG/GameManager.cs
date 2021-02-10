using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextedBased_RPG
{
    class GameManager
    {
        
        public Player user = new Player();
        public Enemy enemy = new Enemy();
        public string PlayerAttack = "";
        public string EnemyAttack = "";
        public bool enemyAlive = true;
        public bool playerAlive = true;


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
                CheckHealth();
                if(user.CharacterX == enemy.CharacterX)
                {
                    if(user.CharacterY == enemy.CharacterY)
                    {
                        enemy.EmergencyEnemyTurn();
                    }
                }
                Console.Clear();
                if(enemyAlive == true)
                {
                    enemy.DrawEnemy();
                }
                else
                {
                    Console.Clear();
                    Map.mapData[enemy.CharacterY, enemy.CharacterX] = Map.BaseMapData[enemy.CharacterY, enemy.CharacterX];
                }

                if (playerAlive == true)
                {
                    user.DrawPlayer();
                }
                else
                {
                    x = 1;
                    Console.Clear();
                    Map.mapData[user.CharacterY, user.CharacterX] = Map.BaseMapData[user.CharacterY, user.CharacterX];
                }
                Map.DrawMap();
                DisplayHUD();
                

                if (playerAlive == true)
                {
                    user.MovePlayer();
                }
                else
                {
                    x = 1;

                }

                if (enemyAlive == true)
                {
                    enemy.EnemyTurn();
                }
                
            }
        }

        public void DisplayHUD()
        {
            Console.WriteLine("Health: " + user.health);
            Console.WriteLine(PlayerAttack);
            Console.WriteLine(EnemyAttack);
            Console.WriteLine("YOU: " + user.CharacterY+ ", " + user.CharacterX);
            Console.WriteLine("FOE: " + enemy.CharacterY + ", " + enemy.CharacterX + ", " + enemy.health);

        }

        public void CheckHealth()
        {
            if(enemy.health <= 0)
            {
                enemyAlive = false;
            }

            if (user.health <= 0)
            {
                playerAlive = false;
            }
        }


        
    }
}
