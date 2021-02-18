using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextedBased_RPG
{
    class GameManager
    {

        public Player user;
        public Enemy enemy;


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
            enemy = new Enemy(Program.GM);
            user = new Player(enemy, Program.GM);
            enemy.GetPlayerTarget(user);
            user.Alive = true;
            enemy.Alive = true;
            chest.y = 2;
            chest.x = 12;
            npc.Dialogue = "To my north is water. You cannot cross without a boat.\nTo my east is a mountain. You cannot hike up without hiking gear.";

            user.SetSpeciesType(0);
            enemy.SetSpeciesType(1);
            
        }


        public void GameLoop()
        {
            Console.CursorVisible = false;
            for (int x = 0; x < 1;)
            {
                StartRound();
                Console.Clear();
                if(enemy.Alive == true)
                {
                    enemy.DrawEnemy();
                }
                else
                {
                    Console.Clear();
                    Map.mapData[enemy.CharacterY, enemy.CharacterX] = Map.BaseMapData[enemy.CharacterY, enemy.CharacterX];
                    enemy.SetAttackMessage(" ");
                }

                if (user.Alive == true)
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
                

                if (user.Alive == true)
                {
                    user.MovePlayer();
                    user.SetAttackMessage(" ");
                }
                else
                {
                    x = 1;

                }

                if (enemy.Alive == true)
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
            Console.WriteLine("Health: " + user.GetHealth() + "       " + user.CharacterX + ", " + user.CharacterY);
            Console.WriteLine("Weapon: " + user.Weapon);
            Console.WriteLine("Attack: " + user.attack);
            Console.WriteLine(Map.MapTile());
            Console.WriteLine(user.GetAttackMessage());
            Console.WriteLine(enemy.GetAttackMessage());

        }

        


        
    }
}
