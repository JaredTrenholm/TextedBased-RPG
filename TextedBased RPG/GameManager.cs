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
        public bool enemyAlive;
        public bool playerAlive = true;

        public FriendlyNPC npc = new FriendlyNPC();
        private Chest chest = new Chest();


        /// <summary>
        /// 9 left of the player is the map border
        /// 10 right of the player is the map border
        /// 4 up of the player is the map border
        /// 5 down of the player is the map border
        /// </summary>
        /// 

        public GameManager()
        {
            enemyAlive = true;
            chest.y = 2;
            chest.x = 12;
            npc.Dialogue = "To my north is water. You cannot cross without a boat.\nTo my east is a mountain. You cannot hike up without hiking gear.";
            
        }


        public void GameLoop()
        {
            Console.CursorVisible = false;
            for (int x = 0; x < 1;)
            {
                StartRound();
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

                EndRound();
                
            }
        }

        private void StartRound()
        {
            chest.DrawChest();
            npc.DrawNPC();
        }
        private void EndRound()
        {
            if (user.CharacterX == chest.x)
            {
                if (user.CharacterY == chest.y)
                {
                    chest.CheckChest();
                }
            }
            else if (user.CharacterX == npc.x)
            {
                if (user.CharacterY == npc.y)
                {
                    npc.Talk();
                }
            }
        }

        public void DisplayHUD()
        {
            Console.WriteLine("Health: " + user.health + "       " + user.CharacterX + ", " + user.CharacterY);
            Console.WriteLine("Weapon: " + user.Weapon);
            Console.WriteLine("Attack: " + user.attack);
            Console.WriteLine(Map.MapTile());
            Console.WriteLine(PlayerAttack);
            Console.WriteLine(EnemyAttack);

        }

        public void CheckHealth()
        {
            
                if (enemy.health <= 0)
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
